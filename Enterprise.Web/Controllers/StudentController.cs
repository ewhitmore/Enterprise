using System.Web.Http;
using Enterprise.Web.Models;
using Enterprise.Web.Services;

namespace Enterprise.Web.Controllers
{
    public class StudentController : ApiController
    {
        public IStudentService StudentService { get; set; }

        //public StudentDto GetStudent(int id)
        //{
            
        //}

    }
}
