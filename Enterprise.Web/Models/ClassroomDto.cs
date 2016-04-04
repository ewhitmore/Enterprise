using System.Collections.Generic;

namespace Enterprise.Web.Models
{
    public class ClassroomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Desks { get; set; }
        public TeacherDto Teacher { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}