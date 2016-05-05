module App.Layout {
    'use strict';

    interface IHomeScope {
        // Properties
        students: Student.IStudentDto[];

        // Methods
        getAllStudents(): void;
        save(student: Student.IStudentDto): void;
    }

    class HomeController implements IHomeScope {
        students: Student.IStudentDto[];

        static $inject = ['app.student.studentService'];
        constructor(private studentService: Student.IStudentService) {
            var vm = this;

            vm.getAllStudents();
        }

        getAllStudents(): void {
            this.studentService.getAll().then(students => {
                this.students = students;
            });
        }

        save(student: Student.IStudentDto): void {
            this.studentService.save(student).then(() => {
                this.getAllStudents();
            });
        }
    }

    // Hook my ts class into an angularjs module
    angular.module("app.layout")
        .controller("app.layout.homeController", HomeController);
}