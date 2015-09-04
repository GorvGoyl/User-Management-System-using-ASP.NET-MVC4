<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page Login"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1 style="text-align: center">
        Create</h1>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
   <%-- <div class="Label">
     <div >
            
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", @PlaceHolder = "UserName*" })%>
            <%--  <%: Html.ValidationMessageFor(model => model.UserName)%>
        </div>
    </div>--%>

    <div class ="Box" >
    <br /><br /><br />
        <div >
            
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", @PlaceHolder = "UserName*" })%>
            <%--  <%: Html.ValidationMessageFor(model => model.UserName)%>--%>
        </div>
        <br />
        <div >
       
            <%: Html.PasswordFor(model => model.Password, new { @class = "TextBox", @PlaceHolder = "Password*" })%>
            <%-- <%: Html.ValidationMessageFor(model => model.Password)%>--%>
        </div>
      <br />
        <input type="submit" class="myButton" value="LOGIN" style="font-family: Segoe UI;
            font-weight: bold;" />
        <% } %>
    </div>
    <div id="myDIV" style="text-align: left">
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
