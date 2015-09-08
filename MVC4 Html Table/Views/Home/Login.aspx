<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page Login"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
  
    <div class="Box flipInY" id="animated-example" >
    <div class="Label" style="top: -202px;">
            <div style="position: relative; top: 2px;">
                Login</div>
        </div>
        <div>
            <br />
        </div>
        <div>
            <br />
        </div>
        <div>
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", @PlaceHolder = "UserName*", @required = "required",  pattern = "[a-zA-Z]{3,10}", title = "UserName must be 3 to 10 characters long and consists only letters." })%>
        </div>
        <br />
        <div>
            <%: Html.PasswordFor(model => model.Password, new { @class = "TextBox", @PlaceHolder = "Password*", @required = "required", pattern = "[a-zA-Z0-9]{3,10}", title = "Password must be 3 to 10 characters long and contains letters and numbers only." })%>
        </div>
        <br />
        <div style = "position:relative;">
            <input type="submit" class="myButton" value="Login" style="font-weight: bold;" />
            <%: Html.ActionLink("Register", "Register", null, new { @class = "myButton" , style="font-weight: bold; position : right" })%>
        </div>
         <div><br /></div>
    </div>
    <% } %>
</asp:Content>
