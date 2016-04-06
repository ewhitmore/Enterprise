using System;
using System.Web.Http;
using Autofac.Extras.Moq;
using Autofac.Integration.WebApi;
using Enterprise.Model;
using Enterprise.Persistence.Dao;
using Enterprise.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enterprise.Web.Tests.Services
{
    [TestClass]
    public class StudentServiceUnitTests
    {

        private HttpConfiguration _configuration;

        [TestInitialize]
        public void Init()
        {
            AutofacConfig.RegisterAutofac();

            _configuration = new HttpConfiguration
            {
                DependencyResolver = new AutofacWebApiDependencyResolver(AutofacConfig.Container)
            };

            var tes = AutofacConfig.Container;
        }

        [TestCleanup]
        public void CleanUp()
        {
            _configuration.Dispose();
        }

        [TestMethod]
        public void StudentService_Get_1_ReturnsStudent()
        {

            // Arrange
            var mock = AutoMock.GetLoose();
            var mockedStudent = new Student
            {
                Birthday = new DateTime(2000,01,01),
                CreatedAt = DateTime.Now,
                FullName = "John Doe",
                IsDeleted = false,
                ModifiedAt = DateTime.Now,
                Id = 1,
                Classroom = new Classroom ()
            };

            mock.Mock<IStudentDao>().Setup(x => x.Get(1)).Returns(mockedStudent);
            
            var studentService = mock.Create<StudentService>();

            // Act
            var student = studentService.Get(1);

            // Assert
            mock.Mock<IStudentDao>().Verify(x => x.Get(1));
            Assert.AreEqual(mockedStudent, student);

        }
    }
}
