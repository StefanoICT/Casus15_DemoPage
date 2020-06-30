<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Face_demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    function FaceOrient() {
        var overAllData = null;
        var pageUrl = '<%= ResolveUrl ("~/Default.aspx/FaceOrient")%>';
        console.log(pageUrl);
        $.ajax({
            type: 'POST',
            url: pageUrl,
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "Json",
            success: function (data) {
                console.log(data);
                onSuccess(data)
            },
            error: function (data, success, error) {
                console.log("error: " + error);
                alert("ERROR : " + error)
            },
           
            
        });

        function onSuccess(data) {
            //document.write("SUCCES!!");
            alert(data.d.Result["LookingAtScreen"]);
            overAllData = data;
            google.charts.load("current", { packages: ["corechart"] });
            google.charts.setOnLoadCallback(drawChart);
           
    }
        function drawChart() {

            //Met deze variabele word de pie chart verdeeld, deze variabele moeten overeenkomen met die van de server
            //var Teacher = 2;
            var Smartboard = overAllData.d.Result["LookingAtScreen"];
            //var Laptop = 2;
            var Overig = (overAllData.d.Result["totalFaces"] - overAllData.d.Result["LookingAtScreen"]);
            //total = totalFaces  en gezichten = LookingAtScreen

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                //['Docent', Teacher],
                //['Laptop', Laptop],
                ['SmartBoard', Smartboard],
                ['Overig', Overig]
            ]);

            var options = {
                title: 'Concentratie verdeling',
                is3D: true,
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
            chart.draw(data, options);
        }
    }
    $('document').ready(function () {
        FaceOrient();
    });

   
</script>
    

    <div class="jumbotron">
                    <p runat="server" id="faceCounter"></p>
        <h1>Home</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/image.jpg" />
        <h2> Diagram:</h2>

        <script type="text/javascript">
            
    </script>
    </div>

    <div id="piechart_3d" style="width: 900px; height: 500px;"></div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

    <div class PieModel>
    </div>

</asp:Content>
