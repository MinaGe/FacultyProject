using FacultyProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FacultyProject.Controllers
{


    public class InstructorController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> registration(UserInstructorModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserStore<IdentityUser> store =
                    new UserStore<IdentityUser>(new ApplicationDbContext());

                UserManager<IdentityUser> manager =
                    new UserManager<IdentityUser>(store);
                IdentityUser user = new IdentityUser();
                user.UserName = account.Name;
                user.Email = account.Email;
                user.PasswordHash = account.Password;

                IdentityResult result = await manager.CreateAsync(user, account.Password);
                if (result.Succeeded)
                {
                    return Created("", "Register Sucess " + user.UserName);
                }
                else
                    return BadRequest((result.Errors.ToList())[0]);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        [Route("api/Instructor/GetallGroups")]

        public IHttpActionResult GetGroups()
        {
            //IList<Groups> groups = null;

            //using (var ctx = new ApplicationDbContext())
            //{
            //    groups = ctx.Groups.ToList<Groups>();
            //}

            //return Ok(groups);

            List<Groups> groups = db.Groups.ToList();
            return Ok<List<Groups>>(groups);


        }
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        [Route("api/Instructor/GetallCourses")]
        public IHttpActionResult GetallCourses(string id)
        {
            List<Course> courses = db.Courses.Where(c => c.InstructorId == id).ToList();
            return Ok<List<Course>>(courses);

        }
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public IHttpActionResult AddCourse(Course course)
        {



            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                List<Course> courses = db.Courses.ToList();

                db.Courses.Add(course);

                db.SaveChanges();
                string urlDetails = Url.Link("DefaultApi", null);
                return Created(urlDetails, "Added Sucess");




            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400

            }

        }
        [Authorize(Roles = "Instructor")]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Id == id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return Ok("Delete Success");

        }
    }
}


