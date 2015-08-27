<%@ Page Language="C#" MasterPageFile="~/ViewMasterPage1.Master" Title="Content Page edit"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<h1 style="text-align:center">
        Edit and Create</h1>
    <h2>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <%-- <fieldset>
        <legend>User</legend>--%>
    <%--   <div class="editor-label">
                <%: Html.LabelFor(model => model.GUID) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.GUID) %>
                <%: Html.ValidationMessageFor(model => model.GUID) %>
            </div>--%>
    <table class="TableColor" align="center" style="margin-left:9cm" width ="50%">
        <thead>
            <tr>
                <th>
                   <h1 >Data</h1> 
                </th>
                <th>
                   <h1 style ="text-align:left" >Value</h1> 
                </th>
            </tr>
        </thead>
        <tr>
            <td class="td" >
                <div class="editor-label" >
                    <%: Html.LabelFor(model => model.Name) %>
                </div>
            </td>
            <td class="td" >
                <div class="editor-label">
                    <div class="editor-field" style="text-align:left">
                        <%: Html.EditorFor(model => model.Name) %>
                        <%: Html.ValidationMessageFor(model => model.Name) %>
                    </div>
            </td>
        </tr>
        <tr>
            <td class="td" >
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Phone) %>
                </div>
            </td>
            <td class="td" >
                <div class="editor-field" style="text-align:left">
                    <%: Html.EditorFor(model => model.Phone) %>
                    <%: Html.ValidationMessageFor(model => model.Phone) %>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td" >
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.City) %>
                </div>
            </td>
            <td class="td" >
                <div class="editor-label">
                    <div class="editor-field" style="text-align:left">
                        <%: Html.EditorFor(model => model.City) %>
                        <%: Html.ValidationMessageFor(model => model.City) %>
                    </div>
            </td>
        </tr>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.DOB) %>
                </div>
            </td>
            <td class="td" >
                <div class="editor-label">
                    <div class="editor-field" style="text-align:left">
                        <%: Html.EditorFor(model => model.DOB) %>
                        <%: Html.ValidationMessageFor(model => model.DOB) %>
                    </div>
            </td>
        </tr>
        <tr>
            <td class="td" >
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.EMail) %>
                </div>
            </td>
            <td class="td" >
                <div class="editor-label">
                    <div class="editor-field" style="text-align:left">
                        <%: Html.EditorFor(model => model.EMail) %>
                        <%: Html.ValidationMessageFor(model => model.EMail) %>
                    </div>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td>
                </td>
                <td>
                    <p style="text-align:left">
                        <input type="submit" value="Save" />
                    </p>
                </td>
            </tr>
        </tfoot>
    </table>
    <%--</fieldset>--%>
    <% } %>
    <div style="text-align:left">
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
