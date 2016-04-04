﻿using System.Collections.Generic;
using System.Linq;
using Enterprise.Model;
using Enterprise.Persistence.Dao;

namespace Enterprise.Web.Services
{
    internal class TeacherService : ITeacherService
    {
        protected ITeacherDao TeacherDao { private get; set; }
        protected IClassroomDao ClassroomDao { private get; set; }

        public Teacher Get(int id)
        {
            return TeacherDao.Get(id);
        }

        public List<Teacher> GetAll()
        {
            return TeacherDao.GetAll().ToList();
        }

        public void Save(Teacher teacher)
        {
            TeacherDao.Save(teacher);
        }

        public void Update(Teacher teacher)
        {
            TeacherDao.Update(teacher);
        }

        public void HardDelete(int id)
        {
            TeacherDao.Delete(TeacherDao.Get(id));
        }

        public void SoftDelete(int id)
        {
            var teacher = TeacherDao.Get(id);
            teacher.IsDeleted = true;
            TeacherDao.Update(teacher);
        }

        public void SetClassroom(int teacherId, int classroomId)
        {
            var teacher = TeacherDao.Get(teacherId);
            var classroom = ClassroomDao.Get(classroomId);

            teacher.Classroom = classroom;
            TeacherDao.Update(teacher);
        }
    }
}