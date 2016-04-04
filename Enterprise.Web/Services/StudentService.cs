using System.Collections.Generic;
using System.Linq;
using Enterprise.Model;
using Enterprise.Persistence.Dao;

namespace Enterprise.Web.Services
{
    internal class StudentService : IStudentService
    {
        protected IStudentDao StudentDao { private get; set; }
        protected IClassroomDao ClassroomDao { private get; set; }

        public Student Get(int id)
        {
            return StudentDao.Get(id);
        }

        public List<Student> GetAll()
        {
            return StudentDao.GetAll().ToList();
        }

        public void Save(Student student)
        {
            StudentDao.Save(student);
        }

        public void Update(Student student)
        {
            StudentDao.Update(student);
        }

        public void HardDelete(int id)
        {
            StudentDao.Delete(StudentDao.Get(id));
        }

        public void SoftDelete(int id)
        {
            var student = StudentDao.Get(id);
            student.IsDeleted = true;
            StudentDao.Update(student);
        }

        public void SetClassroom(int studentId, int classroomId)
        {
            var student = StudentDao.Get(studentId);
            var classroom = ClassroomDao.Get(classroomId);

            student.Classroom = classroom;
            StudentDao.Update(student);
        }
    }
}