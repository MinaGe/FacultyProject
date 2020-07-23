using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FacultyProject.Models
{
    public class Instrucrtor
    {
      

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        [Key]
        [ForeignKey("IdentityUser")]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual IdentityUser IdentityUser { get; set; }

    }
}