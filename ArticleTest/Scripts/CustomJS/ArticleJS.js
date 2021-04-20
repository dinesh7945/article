var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    article_Details = {};
    $scope.Submit = function () {
        debugger
        /* alert("Success");*/


        var title = $scope.title;

        var sub_Title = $scope.sub_Title;
        var tags = $scope.tags;
        var article_Desc = $scope.article_Desc;

        if (title == null || title == undefined || title == "") {
            alert("Please Insert Title");
            return false;
        }
        else if (sub_Title == null || sub_Title == undefined || sub_Title == "") {
            alert("Please Insert Sub Title")
            return false;
        }
        else if (tags == null || tags == undefined || tags == "") {
            alert("Please Insert Tags")
            return false;
        }
        else if (article_Desc == null || article_Desc == undefined || article_Desc == "") {
            alert("Please Insert Article Description")
            return false;
        }
        else {

            Action = document.getElementById("buttonSubmit").getAttribute("value");
            if (Action == "Submit") {
                debugger
                $scope.article_Details = {};
                $scope.article_Details.title = $scope.title;
                $scope.article_Details.subTitle = $scope.sub_Title;
                $scope.article_Details.tags = $scope.tags;
                $scope.article_Details.articleDesc = $scope.article_Desc;
                $http({
                    method: "post",
                    url: "/Article/InsertDetails",
                    datatype: "json",
                    data: JSON.stringify($scope.article_Details)
                }).then(function (response) {
                    $scope.GetAllData();
                    $scope.title = "";
                    $scope.sub_Title = "";
                    $scope.tags = "";
                    $scope.article_Desc = "";
                    alert(response.data);
                });

            }
        }
    }

    $scope.Update = function (art) {
        debugger
        $scope.article_Details = {};
        //document.getElementById("id").value = art.id;

        
        $scope.article_Details.tid = $scope.id;
        $scope.article_Details.title = $scope.title;
        $scope.article_Details.subTitle = $scope.sub_Title;
        $scope.article_Details.tags = $scope.tags;
        $scope.article_Details.articleDesc = $scope.article_Desc;
        $http({
            method: "Post",
            url: "/Article/Update_Details",
            datatype: "json",
            data: JSON.stringify($scope.article_Details)
        }).then(function () {
            alert(response.data);

            //document.getElementById("btnSave").setAttribute("value", "Submit");
            //document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
            //document.getElementById("spn").innerHTML = "Add New Employee";
        })
    }

    $scope.Delete = function (art) {
        debugger
      //  document.getElementById("id").value = art.tid;
        $scope.article_Details = {};
        $scope.article_Details.tid = art.tid;
        $http({
            method: "Post",
            url: "/Article/Delete_Details",
            datatype: "json",
            data: JSON.stringify($scope.article_Details)
        }).then(function () {
            $scope.GetAllData();
            alert(response.data);
            //document.getElementById("btnSave").setAttribute("value", "Submit");
            //document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
            //document.getElementById("spn").innerHTML = "Add New Employee";
        })
    }

    $scope.GetAllData = function () {
       
        $http({
            method: "get",
            url: "/Article/Select_Details"
        }).then(function (response) {
         
            $scope.Article_Details = response.data;
        }, function () {
            alert("Error Occur");
        })
    };

    $scope.Edit = function (art)
    {
        debugger
        $scope.id = art.tid;
        $scope.title = art.title;
        $scope.sub_Title = art.subTitle;
        $scope.tags = art.tags;
        $scope.article_Desc = art.articleDesc;
      //  $("#buttonSubmit").hide();
       // $("#buttonUpdate").show();
        $scope.IsVisible = true;
       // document.getElementById("buttonSubmit").setAttribute("value", "Update");
    }
});