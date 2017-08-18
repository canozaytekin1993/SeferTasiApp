﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ST.Models.Entities;

namespace ST.Models.IdentityModels
{
    public class ApplicationUser:IdentityUser
    {
        [Index(IsUnique = true)]
        public override string Email { get; set; }

        [Index(IsUnique = true)]
        public override string UserName { get; set; }

        [StringLength(25)]
        [Required]
        public string Name { get; set; }

        [StringLength(35)]
        [Required]
        public string Surname { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public virtual List<Firma> Firmalar { get; set; } = new List<Firma>();

        public virtual List<Adres> Adresler { get; set; } = new List<Adres>();

        public virtual List<Siparis> Siparisler { get; set; } = new List<Siparis>();
    }
}
