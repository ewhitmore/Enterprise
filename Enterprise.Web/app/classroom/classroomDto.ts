module App.Classroom {
    "use strict";

    export interface IClassroomDto {
        id: number;
        name: string;
        desks: number;
        teacher: App.Teacher.ITeacherDto;
        students: App.Student.IStudentDto[];
        
    }

    export class ClassroomDto implements IClassroomDto {
        id: number;
        name: string;
        desks: number;
        teacher: App.Teacher.ITeacherDto;
        students: App.Student.IStudentDto[];

        constructor(id: number, name: string, desks: number, teacher: App.Teacher.ITeacherDto, students: App.Student.IStudentDto[]) {}
    }
}