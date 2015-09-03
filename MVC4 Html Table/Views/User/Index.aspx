<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/ViewMasterPage1.Master"
    Title="Content Page Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>
        USER TABLE</h1>
    <h2>
        <%: Html.ActionLink("Create", "Create", "User")%>
    </h2>
    <table class="TableColor" align="center" width="76%">
        <tr>
            <th class="th" align="left">
                <h4>
                    UserName</h4>
            </th>
             <th class="th" align="left">
                <h4>
                    FullName</h4>
            </th>
            <th class="th" align="right">
                <h4>
                    Phone</h4>
            </th>
             <th class="th" align="left">
                <h4>
                    Email</h4>
            </th>
            <th class="th" align="left">
                <h4>
                    City</h4>
            </th>
            <th class="th" align="right">
                <h4>
                    Dob</h4>
            </th>
           
            <th class="th">
                <h4 align="center">
                    Actions</h4>
            </th>
        </tr>
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
           
            <td class="td">
                <%: Html.ActionLink("Edit", "Edit", "User", new { id_value = customer.UserId }, new { id_value = customer.UserId })%>
                <%: Html.ActionLink("Delete", "Delete", "User", new { id_value = customer.UserId }, new { id_value = customer.UserId })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
