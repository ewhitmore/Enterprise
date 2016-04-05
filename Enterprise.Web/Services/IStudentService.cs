using System.Collections.Generic;
using Enterprise.Model;
using Enterprise.Web.Models;

namespace Enterprise.Web.Services
{
    public interface IStudentService
    {
        Student Get(int id);
        IList<Student> GetAll();
        IList<Student> FindAll();
        IList<Student> GetActive();
        void Save(Student student);
        void Update(Student student);
        Student Update(StudentDto dto);
        void HardDelete(int id);
        void SoftDelete(int id);
        void SetClassroom(int studentId, int classroomId);
    }
}