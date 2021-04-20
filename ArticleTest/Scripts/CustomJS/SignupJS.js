var app = angular.module("myAppsign", []);
app.controller("myCtrlsign", function ($scope, $http) {



    $scope.signupSubmit = function () {
        debugger
        //  alert("Success");


        var name = $scope.name;

        var email = $scope.email;
        var password = $scope.password;


        if (name == null || name == undefined || name == "") {
            alert("Please Insert name");
            return false;
        }
        else if (email == null || email == undefined || email == "") {
            alert("Please Insert email")
            return false;
        }
        else if (password == null || password == undefined || password == "") {
            alert("Please Insert password")
            return false;
        }

        else {

            Action = document.getElementById("buttonSubmit").getAttribute("value");
            if (Action == "Submit") {
                debugger
                $scope.article_Details = {};
                $scope.article_Details.username = $scope.name;
                $scope.article_Details.email = $scope.email;
                $scope.article_Details.password = $scope.password;
                $http({
                    method: "post",
                    url: "/signup/InsertDetails",
                    datatype: "json",
                    data: JSON.stringify($scope.article_Details)
                }).then(function (response) {
                    debugger

                    if (response < 0) {
                        alert("user registeration successful");
                    } else {
                        alert("user not registeration");
                    }
                    alert(response.data);
                    $scope.name = "";
                    $scope.email = "";
                    $scope.password = "";

                });

            }
        }
    }

    $scope.loginSubmit = function () {


        var email = $scope.email;
        var password = $scope.password;

        if (email == null || email == undefined || email == "") {
            alert("Please Insert name");
            return false;
        }
        else if (password == null || password == undefined || password == "") {
            alert("Please Insert email")
            return false;
        } else {

            Action = document.getElementById("buttonSubmitlogin").getAttribute("value");
            if (Action == "Submit") {
                $scope.article_Details = {};

                $scope.article_Details.email = $scope.email;
                $scope.article_Details.password = $scope.password;
                $http({
                    method: "post",
                    url: "/Home/login",
                    datatype: "json",
                    data: JSON.stringify($scope.article_Details)
                }).then(function (data) {
                    debugger
                    window.location.href = data.redirectUrl;
                    if (response == 0) {

                        window.location.href = "/Article/ArticleView";

                        // alert("login success")
                        //RedirectToAction("ArticleView", "Article");
                        //window.location.href = ("ArticleView", "Article");

                    } else {

                        alert(response);
                    }

                    $scope.user = null;
                  
                    $scope.name = "";
                    $scope.email = "";
                    $scope.password = "";

                });

            }

        }

    }


    $scope.demo = function () {
        debugger
        $http({
            method: "post",
            url: "/Home/login",
            datatype: "json",
            data: JSON.stringify($scope.article_Details)
        }).then(function (response) {
            debugger

            alert("succsess");
            //if (response !== 0) {

            //    window.location.href = "/Article/ArticleView";

            //    alert("login success")
            //    //RedirectToAction("ArticleView", "Article");
            //    //window.location.href = ("ArticleView", "Article");

            //} else {

            //    alert(response);

            //}
            //$scope.user = null;


        });
    }

});