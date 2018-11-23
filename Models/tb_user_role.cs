using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrf.Models
{
    public class tb_user_role
    {
        [Key]
        public int IdUserRole { get; set; }
        public virtual tb_role tb_role { get; set; }
        public virtual tb_user Tb_User { get; set; }
    }
}
