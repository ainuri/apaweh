using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCrf.Models;

namespace WebCrf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbRoleController : ControllerBase
    {
        private readonly CrfDbContext context;
        //private readonly CrfDbContext context2;

        public TbRoleController(CrfDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var tb_roles = context.tb_roles.ToList();
            return Ok(tb_roles);
        }

        
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var tb_roles = context.tb_roles.Find(id);
            return Ok(tb_roles);
        }

        [Route("Post")]
        [HttpPost]
        public ActionResult Post([FromBody] tb_role value)
        {
           
        //    Dictionary<string, object> cari = new Dictionary<string, object>();
          //  var ambil = context.tb_user_roles.Where(o => o.IdUserRole.Equals(value.IdRole));
          //  context.tb_user_roles.Add(ambil);
            context.tb_roles.Add(value);
            context.SaveChanges();
            return Ok(value);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] tb_role value)
        {
            context.tb_roles.Attach(value);
            context.tb_roles.Update(value);
            context.SaveChanges();
            return Accepted();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var findUser = context.tb_roles.Find(id);
            if (findUser != null)
            {
                context.tb_roles.Remove(findUser);
                context.SaveChanges();
            }
            return NoContent();
        }


        [Route("Login")]
        [HttpPost]
        public ActionResult Login([FromBody] tb_role tu)
        {
            Dictionary<string, object> hasil = new Dictionary<string, object>();
            var tamp = context.tb_roles.Where(o => o.NamaRole.Equals(tu.NamaRole) && o.Deskripsi.Equals(tu.Deskripsi));
            if (tamp.Count() != 0)
            {
                hasil.Add("Succes", tamp);
            }
            else
            {
                hasil.Add("gagal", tamp.Count());
            }

            return Ok(hasil);
        }
    }

}
