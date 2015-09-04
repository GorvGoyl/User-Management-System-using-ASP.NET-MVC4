<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage1.Master" Title="Content Page Login"  Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Create
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1 style="text-align: center">
        Create</h1>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>

 
    <table class="TableColor" align="center" style="margin-left: 9cm" width="50%">
        <%--<thead>
            <tr>
                <th>
                    <h1>
                        Data</h1>
                </th>
                <th>
                    <h1 style="text-align: left">
                        Value</h1>
                </th>
            </tr>
        </thead>--%>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.UserName)%>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.UserName)%>
                    <%: Html.ValidationMessageFor(model => model.UserName)%>
                </div>
            </td>
        </tr>
    
      
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Password) %>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.Password)%>
                    <%: Html.ValidationMessageFor(model => model.Password)%>
                </div>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td>
                </td>
                <td>
                    <p style="text-align: left">
                        <input type="submit" value="Login" />
                    </p>
                </td>
            </tr>
        </tfoot>
    </table>
    <% } %>
    <div id="myDIV" style="text-align: left">
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
