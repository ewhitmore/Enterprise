module App.Layout {
    'use strict';

    interface IHomeScope {
        // Properties
        fullname: string;
      

        // Methods
      
    }

    class HomeController implements IHomeScope {

        fullname: string;

    }

    // Hook my ts class into an angularjs module
    angular.module("app.layout")
        .controller("app.layout.homeController", HomeController);
}