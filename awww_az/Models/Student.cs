using System.Collections.Generic;

namespace awww_az.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FieldOfStudy { get; set; }
    }
}
