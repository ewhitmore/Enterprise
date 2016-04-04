using System.Collections.Generic;
using System.Linq;
using Enterprise.Model;
using Enterprise.Persistence.Dao;

namespace Enterprise.Web.Services
{
    public class ClassroomService
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