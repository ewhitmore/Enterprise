module App.Teacher {

    export interface ITeacher {
        getFullName():string;
    }

    class Teacher implements ITeacher {

        private id: number;
        private fullname: string;
        private birthday: Date;

        getFullName(): string {
            return this.fullname;
        }
    }

}