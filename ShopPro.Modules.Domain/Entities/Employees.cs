﻿using ShopPro.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPro.Modules.Domain.Entities
{
    [Table("Employees", Schema = "HR")]
    public class Employees : BaseEntity<int>
    {
        [Key]
        [Column("empid")]
        public override int Id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string title { get; set; }
        public string titleofcourtesy { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime hiredate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string? region { get; set; }
        public string? postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public int? mgrid { get; set; }
    }
}
