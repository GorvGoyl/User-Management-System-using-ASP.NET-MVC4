<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/ViewMasterPage1.Master"
    Title="Content Page Index" %>

<%--<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>--%>
<%--<script type = "text/javascript" src="~/Scripts/jquery-ui-1.11.4.js">
        $(document).ready(function () {
            $('.delete').click(function () {
                $(this).parent().remove();
                return false;
            });

        });
    </script>
   
    <link href="../../StyleSheet.css" rel="stylesheet" type="text/css" />--%>
<%--</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>
        USER TABLE</h1>
    <h2>
        <%: Html.ActionLink("Create", "Create", "Home")%>
    </h2>
    <table class="TableColor" align="center" width="76%">
        <tr>
            <th class="th" align="left">
                <h4>
                    Name</h4>
            </th>
            <th class="th" align="right">
                <h4>
                    Phone</h4>
            </th>
            <th class="th" align="left">
                <h4>
                    City</h4>
            </th>
            <th class="th" align="right">
                <h4>
                    DOB</h4>
            </th>
            <th class="th" align="left">
                <h4>
                    Email</h4>
            </th>
            <th class="th">
                <h4 align="center">
                    Actions</h4>
            </th>
        </tr>
        <%  
            foreach (var customer in (ViewData["UserData"] as IEnumerable<MVC4_Html_Table.Models.User>))
            {

                if (customer == null) continue; %>
        <tr>
            <td class="td" align="left">
                <%= customer.Name %>
            </td>
            <td class="td" align="right">
                <%= customer.Phone %>
            </td>
            <td class="td" align="left">
                <%= customer.City %>
            </td>
            <td class="td" align="right">
                <%= customer.DOB %>
            </td>
            <td class="td" align="left">
                <%= customer.EMail %>
            </td>
            <td class="td">
                <%: Html.ActionLink("Edit", "Edit", "Home", new { guid = customer.GUID }, new { guid = customer.GUID })%>
                <%: Html.ActionLink("Delete", "Delete", "Home", new { guid = customer.GUID }, new { guid = customer.GUID })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
