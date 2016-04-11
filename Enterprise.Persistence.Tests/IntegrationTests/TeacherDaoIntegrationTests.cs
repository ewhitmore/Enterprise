using System;
using Autofac;
using Enterprise.Model;
using Enterprise.Persistence.Dao;
using Enterprise.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Context;

namespace Enterprise.Persistence.Tests.IntegrationTests
{
    [TestClass]
    public class TeacherDaoIntegrationTests
    {
        [TestInitialize]
        public void Init()
        {
            TestingSessionFactory.CreateSessionFactory("thread_static"); // Create a thread_static NHibernate Session
            AutofacConfig.RegisterAutofac(TestingSessionFactory.SessionFactory); // Send session to IoC Container
            CurrentSessionContext.Bind(TestingSessionFactory.Session); // Bind to Unit Test Context
        }

        [TestCleanup]
        public void CleanUp()
        {
            HibernateConfig.Dispose();  // Release Session
        }

        [TestMethod]
        public void TeacherDao_CreateATeacher_ReturnsTrue()
        {
            // Arrange
            var teacherDao = AutofacConfig.Container.Resolve<ITeacherDao>();
            var teacher = new Teacher() {Birthday = new DateTime(200,01,01), FullName = "Joe Smith"};

            // Act
            teacherDao.Save(teacher);

            // Assert
            Assert.AreEqual(1, teacher.Id);
        }



    }
}
