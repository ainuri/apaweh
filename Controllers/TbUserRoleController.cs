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
    public class TbUserRoleController : ControllerBase
    {
        private readonly CrfDbContext context;

        public TbUserRoleController(CrfDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var tb_user_role = context.tb_user_roles.ToList();
            return Ok(tb_user_role);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var tb_user_role = context.tb_user_roles.Find(id);

            return Ok(tb_user_role);
        }

        [Route("Post")]
        [HttpPost]
        public ActionResult Post([FromBody] tb_user_role value)
        {
        
            
            context.tb_user_roles.Add(value);
            context.SaveChanges();
            return Ok(value);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] tb_user_role value)
        {
            
            context.tb_user_roles.Attach(value);
            context.tb_user_roles.Update(value);
            context.SaveChanges();
            return Accepted();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var findUser = context.tb_user_roles.Find(id);
            if (findUser != null)
            {
                context.tb_user_roles.Remove(findUser);
                context.SaveChanges();
            }
            return NoContent();
        }


        [Route("Login")]
        [HttpPost]
        public ActionResult Login([FromBody] tb_user tu)
        {
            Dictionary<string, object> hasil = new Dictionary<string, object>();
            var tamp = context.tb_users.Where(o => o.NamaUser.Equals(tu.NamaUser) && o.Email.Equals(tu.Email));
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
