using System;

namespace Enterprise.Web.Models
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public ClassroomDto Classroom { get; set; }
    }
}