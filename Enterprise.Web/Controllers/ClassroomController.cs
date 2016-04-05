using System.Web.Http;
using Enterprise.Web.Services;

namespace Enterprise.Web.Controllers
{
    [RoutePrefix("api/v1/classroom")]
    public class ClassroomController : ApiController
    {
        public IClassroomService ClassroomService { get; set; }
    }
}
