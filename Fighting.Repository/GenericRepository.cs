using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using Dapper;
using Fighting.Core.Interfaces;
using Fighting.Infrastructure.Extensions;
using Fighting.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Fighting.Repository
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T>
    {
        private SqlConnection _connection;
        protected SqlConnection Connection => _connection ?? (_connection = GetOpenConnection());
        private readonly IConfigurationRoot _configurationRoot;
        protected GenericRepository(IConfigurationRoot configuration)
        {
            _configurationRoot = configuration;
        }

        private SqlConnection GetOpenConnection(bool mars = false)
        {
            var cs = _configurationRoot["ConnectionString"];
            if (mars)
            {
                var scsb = new SqlConnectionStringBuilder(cs)
                {
                    MultipleActiveResultSets = true
                };
                cs = scsb.ConnectionString;
            }

            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }

        private SqlConnection GetClosedConnection()
        {
            var conn = new SqlConnection(_configurationRoot["ConnectionString"]);
            if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");
            return conn;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        /// <summary>
        /// The name of table follow plural syntax name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            var table = typeof(T).Name.ConvertToPlural();
            var sql = $"SELECT * FROM {table} WHERE Id=@id";
            return Connection.Query<T>(sql, new { id = id }).FirstOrDefault();
        }


        public List<T> Gets(object whereConditions)
        {
            return Connection.GetList<T>(whereConditions).ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="whereConditions">ex : where age = 10 or Name like '%Smith%'</param>
        /// <returns></returns>
        public List<T> Gets(string whereConditions)
        {
            return Connection.GetList<T>(whereConditions).ToList();
        }

        private void UpdateTracking(T value, bool isInsert)
        {
            var identityId = Thread.CurrentPrincipal.GetUserId();
            var timeNow = DateTimeOffset.Now;
            var auditEntity = value as IAuditEntity;
            if (auditEntity != null)
            {
                if (isInsert)
                {
                    auditEntity.CreateBy = identityId;
                    auditEntity.TimeCreatedOffset = timeNow;
                }

                auditEntity.ModifyBy = identityId;
                auditEntity.TimeModifyOffset = timeNow;
            }

        }

        public T Insert(T value)
        {
            UpdateTracking(value, true);
            var newId = Connection.Insert(value);
            if (newId.HasValue == false)
            {
                throw new Exception("Cannot insert record to the database");
            }

            var returnValue = value as IEntity<long>;
            if (returnValue != null)
            {
                returnValue.Id = newId.Value;
                return (T)returnValue;
            }
            return value;
        }

        public int Update(T value)
        {
            UpdateTracking(value, false);
            var numberRecordAffected = Connection.Update(value);
            return numberRecordAffected;
        }

        public int DeleteById(object id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                var deleteEntity = entity as IDeleteEntity;
                if (deleteEntity != null)
                {
                    var identityId = Thread.CurrentPrincipal.GetUserId();
                    var timeNow = DateTimeOffset.Now;
                    deleteEntity.IsDeleted = true;
                    deleteEntity.DeleteBy = identityId;
                    deleteEntity.TimeDeleteOffset = timeNow;
                    var updateResult = Connection.Update(entity);
                    return updateResult;
                }

                var numberRecordAffected = Connection.Delete<T>(entity);
                return numberRecordAffected;
            }

            return 0;
        }
    }
}
