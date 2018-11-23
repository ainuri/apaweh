using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrf.Models
{
    public class tb_user
    {
        [Key]
        public int IdUser { get; set; }
        public string NamaUser { get; set; }
        public string Email { get; set; }
        public string Sandi { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string Gambar { get; set; }
    }
}
