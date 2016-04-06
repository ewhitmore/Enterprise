using System.Collections.Generic;
using Enterprise.Model;
using Enterprise.Web.Models;

namespace Enterprise.Web.Services
{
    public interface ITeacherService
    {
        Teacher Get(int id);
        List<Teacher> GetAll();
        void Save(Teacher teacher);
        void Update(Teacher teacher);
        Teacher Update(TeacherDto teacher);
        void HardDelete(int id);
        void SoftDelete(int id);
        void SetClassroom(int teacherId, int classroomId);
    }
}