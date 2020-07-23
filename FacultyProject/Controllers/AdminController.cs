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
    public class AdminController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        [Route("api/Admin/addstudent")]
        public async Task<IHttpActionResult> addStudentUser(UserStudentModel userStudentModel)
        {
            if(! ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                UserStore<IdentityUser> store = 
                    new UserStore<IdentityUser>( new ApplicationDbContext ());
                UserManager<IdentityUser> manager =
                    new UserManager<IdentityUser>(store);
                IdentityUser user = new IdentityUser();
                user.UserName = userStudentModel.Name;
                user.Email = userStudentModel.Email;
                user.PasswordHash = userStudentModel.Password;
              IdentityResult result= await manager.CreateAsync(user, userStudentModel.Password);
                if (result.Succeeded)
                {
                    manager.AddToRole(user.Id, "Student");
                    Student student = new Student();
                    student.UserID = user.Id;
                    student.Name = user.UserName;
                    student.DepId = userStudentModel.DepID;
                    student.GroupId = userStudentModel.groupId;
                    db.Students.Add(student);
                    db.SaveChanges();
                    string urlDetails = Url.Link("DefaultApi", null);
                    return Created(urlDetails, "Added Sucess");


                }
                else
                    return BadRequest(result.Errors.First());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Admin/addInstructor")]
        public async Task<IHttpActionResult> addInstructorUser(UserInstructorModel userInstructorModel)
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
                user.UserName = userInstructorModel.Name;
                user.Email = userInstructorModel.Email;
                user.PasswordHash = userInstructorModel.Password;
                IdentityResult result = await manager.CreateAsync(user, userInstructorModel.Password);
                if (result.Succeeded)
                {
                    manager.AddToRole(user.Id, "Instructor");
                    Instrucrtor instrucrtor = new Instrucrtor();
                    instrucrtor.UserID = user.Id;
                    instrucrtor.Name = user.UserName;

                    db.Instrucrtors.Add(instrucrtor);
                    db.SaveChanges();
                   string urlDetails = Url.Link("DefaultApi",null);
                    return Created(urlDetails, "Added Sucess");


                }
                else
                    return BadRequest(result.Errors.First());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Admin/addCourse")]
        public IHttpActionResult addCourses(Course course )
        {
            if(! ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            else
            {
                try
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    string urlDetails = Url.Link("DefaultApi", null);
                    return Created(urlDetails, "Added Sucess");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                  
                }
            }
           

        }
        public IHttpActionResult AddGroup(Groups groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            else
            {
                try
                {
                    db.Groups.Add(groups);
                    db.SaveChanges();
                    string urlDetails = Url.Link("DefaultApi", null);
                    return Created(urlDetails, "Added Sucess");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
            }

        }
















    }




}
