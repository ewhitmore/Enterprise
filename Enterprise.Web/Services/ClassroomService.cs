using System.Collections.Generic;
using System.Linq;
using Enterprise.Model;
using Enterprise.Persistence.Dao;
using Enterprise.Persistence.Dao.Implementation;
using Enterprise.Web.Models;

namespace Enterprise.Web.Services
{
    public class ClassroomService : IClassroomService
    {
        protected IClassroomDao ClassroomDao { private get;  set; }
        protected ITeacherDao TeacherDao { private get; set; }
        protected IStudentDao StudentDao { private get; set; }

        public Classroom Get(int id)
        {
            return ClassroomDao.Get(id);
        }

        public List<Classroom> GetAll()
        {
            return ClassroomDao.GetAll().ToList();
        }

        public void Save(Classroom teacher)
        {
            ClassroomDao.Save(teacher);
        }

        public void Update(Classroom teacher)
        {
            ClassroomDao.Update(teacher);
        }

        public Classroom Update(ClassroomDto dto)
        {
            var classroom = ClassroomDao.Get(dto.Id);
            
            // todo:  map dto to dao

            ClassroomDao.Update(classroom);

            return classroom;
        }

        public void HardDelete(int id)
        {
            ClassroomDao.Delete(ClassroomDao.Get(id));
        }

        public void SoftDelete(int id)
        {
            var classroom = ClassroomDao.Get(id);
            classroom.IsDeleted = true;
            ClassroomDao.Update(classroom);
        }

        public void SetTeacher(int classroomId, int teacherId)
        {
            var classroom = ClassroomDao.Get(classroomId);
            var teacher = TeacherDao.Get(teacherId);

            classroom.Teacher = teacher;
            ClassroomDao.Update(classroom);
        }

        public void AddStudent(int classroomId, int studentId)
        {
            var classroom = ClassroomDao.Get(classroomId);
            var student = StudentDao.Get(studentId);

            classroom.Students.Add(student);
            ClassroomDao.Update(classroom);
        }

    }
}