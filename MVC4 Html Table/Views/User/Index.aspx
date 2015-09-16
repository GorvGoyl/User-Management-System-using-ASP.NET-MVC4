<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/ViewMasterPage.Master"
    Title="Content Page Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Super User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--  <script src="../../Content/JS/jquery.js" type="text/javascript"></script>--%>
    <script src="../../Content/JS/jquery.dataTables.min.js" type="text/javascript"></script>
    <link href="../../Content/CSS/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/IconButton.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {

            $('#myTable').dataTable({

                "dom": '<f<t>lip>',
                "columnDefs": [
    { "orderable": false, "targets": 6 }
  ]
            });
        });
    </script>


    <%--<script type="text/javascript">
        $(document).ready(function getDetails() {

            $.ajax({

                type: "POST",
                contentType: "application/json",
                url: "../User/GetData", //Default.aspx is page and GetData is the WebMethod  
                data: {entries:"25"},
                dataType: "json",
                success: function (data) {

                    $('#myTable tbody').remove(); // Every time I am removing the body of Table and applying loop to display data  
                    //console.log(data.d);    
                    for (var i = 0; i < 100; i++) {
                        var userid = data.Data[i]["UserId"];
                        $("#myTable").append(
                    "<tr><td>" + data.Data[i]["UserName"] + "</td><td>" + data.Data[i]["FullName"] + "</td>" +
                    "<td>" + data.Data[i]["Phone"] + "</td>" + "<td>" + data.Data[i]["Email"] + "</td>" +
                    "<td>" + data.Data[i]["City"] + "</td>" + "<td>" + data.Data[i]["Dob"] + "</td>"
                                     + "<td>" + '  <%: Html.ActionLink(" ", "Edit", "User", new { id_value = 4 }, new { @class = "IconButtons", style = " background: url(../../Content/Images/edit.png) 3px 5px no-repeat;" })%>'
                                     + '  <%: Html.ActionLink(" ", "Delete", "User", new { id_value = 5 }, new { @class = "IconButtons", style = "background: url(../../Content/Images/delete.png) 3px 5px no-repeat;" })%>'
                                     + "</td>"
                                     + "</tr>"
                    );
                    }
                },
                error: function (data) {
                   
                    alert("Error while Showing update data");
                }
            });
        });
    </script>--%>
    <br />
    <br />
    <div>
        <div id="myTable_wrapper" class="dataTables_wrapper no-footer" style="width: 1179px;
            /* text-align: right; */
    margin-left: auto; margin-right: auto;">
            <div style="width: 1056px; text-align: right; margin-left: auto; margin-right: auto;
                padding-top: 10px; padding-bottom: 10px;">
                <a style="position: relative; color: #002E40; font-size: 23px; pointer-events: none;
                    float: left; right: 59px; bottom: 22px;">Members</a>
                <%: Html.ActionLink("Create", "Create", "User", new { @class = "myButton", style = "position: relative; left: 58px;top: 21px; " })%>
            </div>
            <table id='myTable' class="TableColor" align="center" style="">
                <thead>
                    <tr style="height: 40px;">
                        <th align="left" style="padding-left: 5px;">
                            UserName
                        </th>
                        <th align="left" style="padding-left: 5px;">
                            Full Name
                        </th>
                        <th align="right" style="padding-right: 19px;">
                            Phone Number
                        </th>
                        <th align="left" style="padding-left: 5px;">
                            Email Address
                        </th>
                        <th align="left" style="padding-left: 5px;">
                            City
                        </th>
                        <th align="right" style="padding-right: 19px;">
                            Dob(mm/dd/yyyy)
                        </th>
                        <th align="center">
                            Actions
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <%  if (ViewData["UserData"] != null)
                            foreach (var customer in (ViewData["UserData"] as IEnumerable<MVC4_Html_Table.Models.User>))
                            {
                               

                                if (customer == null) continue; %>
                    <tr>
                        <td class="td" align="left">
                            <%= Html.Encode(customer.UserName)%>
                        </td>
                        <td class="td" align="left">
                            <%= Html.Encode(customer.FullName)%>
                        </td>
                        <td class="td" align="right">
                            <%= Html.Encode(customer.Phone )%>
                        </td>
                        <td class="td" align="left">
                            <%= Html.Encode(customer.Email) %>
                        </td>
                        <td class="td" align="left">
                            <%= Html.Encode(customer.City) %>
                        </td>
                        <td class="td" align="right">
                            <%= Html.Encode(customer.Dob) %>
                        </td>
                        <td class="td" style="min-width: 200px;">
                            <%: Html.ActionLink(" ", "Edit", "User", new { id_value = customer.UserId }, new { @class = "IconButtons", style = " background: url(../../Content/Images/edit.png) 3px 5px no-repeat;" })%>
                            <%: Html.ActionLink(" ", "Delete", "User", new { id_value = customer.UserId }, new { @class = "IconButtons", onclick = "return confirm('Do you want to delete this record?');", style = "background: url(../../Content/Images/delete.png) 3px 5px no-repeat;" })%>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
