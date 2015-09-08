<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/ViewMasterPage.Master"
    Title="Content Page Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Super User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <div>
            <div style="margin-left: 67.5%; margin-bottom: 10px;">
                <%: Html.ActionLink("Create", "Create", "User", new { @class = "myButton", style = "font-weight: bold; " })%>
            </div>
            <table class="TableColor" align="center" style="margin-right: 160px;">
                <thead>
                    <tr style="height: 40px;">
                        <th align="left" style="padding-left: 5px;">
                            UserName
                        </th>
                        <th align="left" style="padding-left: 5px;">
                            Full Name
                        </th>
                        <th align="right" style="padding-right: 5px;">
                            Phone Number
                        </th>
                        <th align="left" style="padding-left: 5px;">
                            Email Address
                        </th>
                        <th align="left" style="padding-left: 5px;">
                            City
                        </th>
                        <th align="right" style="padding-right: 5px;">
                            Date Of Birth
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
                            <%= customer.UserName%>
                        </td>
                        <td class="td" align="left">
                            <%= customer.FullName%>
                        </td>
                        <td class="td" align="right">
                            <%= customer.Phone %>
                        </td>
                        <td class="td" align="left">
                            <%= customer.Email %>
                        </td>
                        <td class="td" align="left">
                            <%= customer.City %>
                        </td>
                        <td class="td" align="right">
                            <%= customer.Dob %>
                        </td>
                        <td class="td" style="min-width: 200px;">
                            <%: Html.ActionLink("Edit", "Edit", "User", new { id_value = customer.UserId }, new { @class = "myButton", style = "font-weight: bold; " })%>
                            <%: Html.ActionLink("Delete", "Delete", "User", new { id_value = customer.UserId }, new { @class = "myButton", style = "font-weight: bold; " })%>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
    <style>
        .headerholder th
        {
        }
    </style>
</asp:Content>
