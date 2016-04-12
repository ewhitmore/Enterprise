module App.Teacher {
    "use strict";

    export interface ITeacherDao {
        id: number;
        fullname: string;
        birthday: Date;
    }

    export class TeacherDao implements ITeacherDao {
        id: number;
        fullname: string;
        birthday: Date;

        //constructor() {
            
        //}
    }
}