﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.Moq;
using Enterprise.Model;
using Enterprise.Persistence.Dao;
using Enterprise.Web.Models;
using Enterprise.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enterprise.Web.Tests.Services
{
    [TestClass]
    public class StudentServiceUnitTests
    {

        [TestInitialize]
        public void Init()
        {
            AutofacConfig.RegisterAutofac();
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

        [TestMethod]
        public void StudentService_UpdateStudentFromDto_ReturnsTrue()
        {
            // Arrange
            var mock = AutoMock.GetLoose();
            var mockedStudent = new Student
            {
                Birthday = new DateTime(2000, 01, 01),
                CreatedAt = DateTime.Now,
                FullName = "John Doe",
                IsDeleted = false,
                ModifiedAt = DateTime.Now,
                Id = 1,
                Classroom = new Classroom()
            };

            mock.Mock<IStudentDao>().Setup(x => x.Get(1)).Returns(mockedStudent);

            var studentService = mock.Create<StudentService>();
            var newBirthday = new DateTime(2012, 01, 01);

            var dto = new StudentDto(mockedStudent);
            dto.Birthday = newBirthday;


            // Act
            var student = studentService.Update(dto);

            // Assert
            mock.Mock<IStudentDao>().Verify(x => x.Get(1));
            Assert.AreEqual(newBirthday, student.Birthday);

        }

        [TestMethod]
        public void StudentService_GetActive_ReturnActiveStudents()
        {
            // Arrange
            var mock = AutoMock.GetLoose();

            var mockedStudents = new List<Student>();
            var mockedStudent1 = new Student {
                Birthday = new DateTime(2000, 01, 01),
                CreatedAt = DateTime.Now,
                FullName = "John Doe",
                IsDeleted = false,
                ModifiedAt = DateTime.Now,
                Id = 1,
                Classroom = new Classroom()
            };

            var mockedStudent2 = new Student
            {
                Birthday = new DateTime(2000, 02, 01),
                CreatedAt = DateTime.Now,
                FullName = "Jane Doe",
                IsDeleted = false,
                ModifiedAt = DateTime.Now,
                Id = 2,
                Classroom = new Classroom()
            };

            var mockedStudent3 = new Student
            {
                Birthday = new DateTime(2000, 03, 01),
                CreatedAt = DateTime.Now,
                FullName = "Sally Doe",
                IsDeleted = false,
                ModifiedAt = DateTime.Now,
                Id = 3,
                Classroom = new Classroom()
            };

            var mockedStudent4 = new Student
            {
                Birthday = new DateTime(2000, 04, 01),
                CreatedAt = DateTime.Now,
                FullName = "Jim Doe",
                IsDeleted = true,
                ModifiedAt = DateTime.Now,
                Id = 4,
                Classroom = new Classroom()
            };

            mockedStudents.Add(mockedStudent1);
            mockedStudents.Add(mockedStudent2);
            mockedStudents.Add(mockedStudent3);
            mockedStudents.Add(mockedStudent4);

            // Act
            mock.Mock<IStudentDao>().Setup(x => x.FindAll()).Returns(mockedStudents.ToList().AsQueryable());

            var studentService = mock.Create<StudentService>();
            var result = studentService.GetActive();

            // Assert
            mock.Mock<IStudentDao>().Verify(x => x.FindAll());
            Assert.AreEqual(3,result.Count);

        }


    }
}
