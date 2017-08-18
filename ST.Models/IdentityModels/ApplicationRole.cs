using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ST.Models.IdentityModels
{
    public class ApplicationRole:IdentityRole
    {
        [StringLength(200)]
        public string Description { get; set; }
    }
}
