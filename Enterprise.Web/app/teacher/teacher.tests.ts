/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular-mocks.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular-route.d.ts"/>
/// <reference path="../../Scripts/typings/angularjs/angular-sanitize.d.ts"/>
/// <reference path="../../scripts/typings/angularjs/angular-cookies.d.ts" />
/// <reference path="../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />

/// <reference path="../app.ts" />
/// <reference path="../app.core.ts" />
/// <reference path="../app.module.ts" />
/// <reference path="../app.routes.ts" />
/// <reference path="../blocks/blocks.module.ts" />
/// <reference path="../layout/layout.module.ts" />
/// <reference path="../services/services.module.ts" />
/// <reference path="../teacher/teacher.module.ts" />
/// <reference path="../widgets/widgets.module.ts" />

/// <reference path="teacherDto.ts"/>
/// <reference path="teacher.service.ts" />





module App.Teacher.Tests {
    "use strict";   
   
    

    //describe("TeacherDto", () => {

    //    var teacher: ITeacherDto;
    //    var birthday = new Date("2016-01-15");
    //    beforeEach(() => {
    //        teacher = new TeacherDto(1, "John Doe", birthday);
    //    });

    //    it("should have id of 1", () => {
    //        expect(teacher.id).toBe(1);
    //    });

    //    it("should have fullname of John Doe", () => {
    //        expect(teacher.fullname).toBe("John Doe");
    //    });

    //    it("should have a birthday of 2016-01-15", () => {
    //        expect(teacher.birthday).toBe(birthday);
    //    });

    //});

    describe("TeacherService", () => {

        //beforeEach(
        //    angular.mock.module('app')
        //);

        //var myService;


        //beforeEach(
        //    function() {

        //        init.$inject = ['teacherService'];
        //        function init(teacherService) {
        //            myService = teacherService;
        //        }


        //    });


        //beforeEach(inject(function (_$h_) {
        //    // The injector unwraps the underscores (_) from around the parameter names when matching
        //    $controller = _$controller_;
        //}));


        it("should initialize correctly", () => {
         
            angular.module('app');
            angular.module('app.teacher');

     

            var $injector = angular.injector(['app.teacher']);
            var myService = $injector.get('app.teacher.teacherService');
            
            expect(myService).toBeDefined();
        });

    });   
}