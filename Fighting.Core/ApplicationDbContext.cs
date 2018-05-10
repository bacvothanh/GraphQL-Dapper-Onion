using System;
using System.Collections.Generic;
using System.Text;
using Fighting.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Fighting.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Arena> Arenas { get; set; }
        public DbSet<AccountArena> AccountArenas { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionDetail> QuestionDetails { get; set; }
        public DbSet<QuestionInput> QuestionInputs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
