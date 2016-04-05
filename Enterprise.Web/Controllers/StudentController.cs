using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Enterprise.Web.Models;
using Enterprise.Web.Services;

namespace Enterprise.Web.Controllers
{
    [RoutePrefix("api/v1/student")]
    public class StudentController : ApiController
    {
        public IStudentService StudentService { get; set; }

        [Route("")]
        [HttpGet]
        public StudentDto Get(int id)
        {
            return new StudentDto(StudentService.Get(id));
        }

        [Route("")]
        [HttpGet]
        public IList<StudentDto> GetAll()
        {
            return StudentService.GetAll().Select(student => new StudentDto(student)).ToList();
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] StudentDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid Data");
            }

            try
            {
                StudentService.Save(dto.ToStudent());
            }
            catch (Exception exception)
            {

                return InternalServerError(exception);
            }

            return CreatedAtRoute("DefaultApi", new { id = dto.Id }, dto);
        }

        [Route("")]
        [HttpPut]
        public void Update()
        {
        }

        [Route("")]
        [HttpDelete]
        public void Delete()
        {
        }


    }
}
