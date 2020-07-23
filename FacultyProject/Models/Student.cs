using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FacultyProject.Models
{
    public class Student
    {
       
        public string Name { get; set; }

        [ForeignKey("Department")]
        public int DepId { get; set; }

        [ForeignKey("DepId")]
        [JsonIgnore]
        public virtual Department Department { get; set; }

        [ForeignKey("Groups")]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        [JsonIgnore]
        public virtual Groups Groups { get; set; }
        [JsonIgnore]
        public virtual ICollection<Attend> Attends { get; set; }
        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; set; }
        [Key]
        [ForeignKey("IdentityUser")]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual IdentityUser IdentityUser { get; set; }


    }
}