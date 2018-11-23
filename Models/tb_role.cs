using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrf.Models
{
    public class tb_role
    {
        [Key]
        public int IdRole { get; set; }
        public string NamaRole { get; set; }
        public string Deskripsi { get; set; }
    }
}
