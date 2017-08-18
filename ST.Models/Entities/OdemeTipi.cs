using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Models.Entities
{
    [Table("ÖdemeTipleri")]
    public class OdemeTipi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ödeme Tipi")]
        public string OdemeTipiAdi { get; set; }
    }
}
