using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebCrf.Models;

namespace WebCrf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbUserController : ControllerBase
    {
        private readonly CrfDbContext context;

        public TbUserController(CrfDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var tb_users = context.tb_users.ToList();
            return Ok(tb_users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var tb_users = context.tb_users.Find(id);
            return Ok(tb_users);
        }

        [Route("Post")]
        [HttpPost]
        public ActionResult Post([FromBody] tb_user value)
        {

            //  context.tb_user_roles.Add(value);
            context.tb_users.Add(value);

            context.SaveChanges();
            //  context.tb_user_roles.Add(value);
            Random r = new Random();
            Dictionary<string, object> hasil = new Dictionary<string, object>();
            var tamp = context.tb_users.Where(o => o.NamaUser.Equals(value.NamaUser) && o.Email.Equals(value.Email));
            hasil.Add("Insert Succes", true);
            hasil.Add("UserName", tamp.ToList().Select(d => d.NamaUser));
            int myint = r.Next(100000000, 1000000000);
            string mycode = myint.ToString();
            string myname = value.NamaUser;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Rofiq", "rofiqainur180@gmail.com"));
            message.To.Add(new MailboxAddress(myname, value.Email));
            message.Subject = "A mail from ASPNET Core";

            message.Body = new TextPart("plain")
            {

                Text = @"Your Login Code  :" + mycode + "\n" + "Selamat Anda berhasil Register"


            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("rofiqainur180@gmail.com", "wakwauah123");
                client.Send(message);
                client.Disconnect(true);
            }

            tb_user item = context.tb_users.Where(p => p.IdUser.Equals(value.IdUser)).Single<tb_user>();
            item.Sandi = mycode;
            context.tb_users.Update(item);
            context.SaveChanges();

            return Ok(value);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] tb_user value)
        {
            context.tb_users.Attach(value);
            context.tb_users.Update(value);
            context.SaveChanges();

            return Accepted();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var findUser = context.tb_users.Find(id);
            if (findUser != null)
            {
                context.tb_users.Remove(findUser);
                context.SaveChanges();
            }
            return NoContent();
        }




        [Route("Login")]
        [HttpPost]
        public ActionResult Login([FromBody] tb_user tu)
        {


            // r.Next(1, 100);
            Dictionary<string, object> hasil = new Dictionary<string, object>();
            var tamp = context.tb_users.Where(o => o.NamaUser.Equals(tu.NamaUser) && o.Sandi.Equals(tu.Sandi));
            if (tamp.Count() != 0)
            {
                Random r = new Random();

                hasil.Add("Login Code", true);
                hasil.Add("UserName", tamp.ToList().Select(d => d.NamaUser));
                int myint = r.Next(100000000, 1000000000);
                string mycode = myint.ToString();
                var name = tamp.ToList().Select(d => d.NamaUser);
                string myname = name.ToString();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Rofiq", "rofiqainur180@gmail.com"));
                message.To.Add(new MailboxAddress(myname, "rofiqainur468@gmail.com"));
                message.Subject = "A mail from ASPNET Core";
                //   message.Body = hasil.Add("Login Code", r.Next(1, 1000000000));
                message.Body = new TextPart("plain")
                {
                    Text = "Your Login Code  :" + mycode
                };


                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("rofiqainur180@gmail.com", "wakwauah123");
                    //  client.Send(message);
                    // client.Disconnect(true);
                }
            }
            else
            {
                hasil.Add("gagal", tamp.Count());
            }

            return Ok(hasil);
        }
    }


}
