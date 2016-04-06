using System.Collections.Generic;
using Enterprise.Model;
using Enterprise.Web.Models;

namespace Enterprise.Web.Services
{
    public interface IClassroomService
    {
        Classroom Get(int id);
        List<Classroom> GetAll();
        void Save(Classroom teacher);
        void Update(Classroom teacher);
        Classroom Update(ClassroomDto dto);
        void HardDelete(int id);
        void SoftDelete(int id);
        void SetTeacher(int classroomId, int teacherId);
        void AddStudent(int classroomId, int studentId);
    }
}