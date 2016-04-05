using System.Collections.Generic;
using Enterprise.Model;

namespace Enterprise.Web.Services
{
    public interface IStudentService
    {
        Student Get(int id);
        IList<Student> GetAll();
        void Save(Student student);
        void Update(Student student);
        void HardDelete(int id);
        void SoftDelete(int id);
        void SetClassroom(int studentId, int classroomId);
    }
}