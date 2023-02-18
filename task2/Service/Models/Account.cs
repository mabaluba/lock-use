﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models
{
    [Table("accounts")]
    public class Account
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }

        [Column("currency")]
        public string Currency { get; set; }
    }
}