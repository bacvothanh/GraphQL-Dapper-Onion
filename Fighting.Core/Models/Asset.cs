using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Fighting.Core.Enums;
using Fighting.Core.Interfaces;

namespace Fighting.Core.Models
{
    public class Asset : IEntity<long>
    {
        public long Id { get; set; }
        [MaxLength(500)]
        public string Url { get; set; }
        [MaxLength(200)]
        public string Domain { get; set; }
        public AssetType Type { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
