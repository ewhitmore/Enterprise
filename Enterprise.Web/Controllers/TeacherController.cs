using System.Web.Http;
using Enterprise.Web.Services;

namespace Enterprise.Web.Controllers
{
    [RoutePrefix("api/v1/teacher")]
    public class TeacherController : ApiController
    {
        public ITeacherService TeacherService { get; set; }
    }
}
