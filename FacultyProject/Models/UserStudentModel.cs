using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacultyProject.Models
{
    public class UserStudentModel
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public String Password { get; set; }
        public int DepID { get; set; }
        public int groupId { get; set; }

    }
}