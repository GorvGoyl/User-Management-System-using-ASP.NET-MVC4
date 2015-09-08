<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page edit"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(
        function () {
            $("#Dob").datepicker({
                changeMonth: true,
                changeYear: true
            });
        }
        );
    </script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div class="Box flipInY" id="animated-example">
        <div class="Label" style="top: -477px;">
            <div style="position: relative; top: 2px;">
                New User</div>
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
            <%: Html.TextBoxFor(model => model.FullName, new { @class = "TextBox", @PlaceHolder = "FullName*", @required = "required" })%>
        </div>
        <br />
        <div>
            <%: Html.TextBoxFor(model => model.Phone, new { @class = "TextBox", @PlaceHolder = "Phone" ,pattern = "[0-9]{10}", title = "Phone Number must be 10 digits long and consists only digits." })%>
        </div>
        <br />
        <div>
            <%: Html.TextBoxFor(model => model.Email, new { @class = "TextBox", @PlaceHolder = "Email*" , @required = "required",  id="email" , type="email" })%>
        </div>
        <br />
        <div>
            <%: Html.TextBoxFor(model => model.City, new { @class = "TextBox", @PlaceHolder = "City" , pattern = "[a-zA-Z]{3,20}", title = "City must be 3 to 20 characters long and consists only letters." })%>
        </div>
        <br />
        <div>
            <%: Html.TextBoxFor(model => model.Dob, new { @class = "TextBox", @PlaceHolder = "Dob" ,pattern = @"[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4}", title = "Date format should be 'mm/dd/yyyy'" })%>
        </div>
        <br />
        <div>
            <%: Html.PasswordFor(model => model.Password, new { @class = "TextBox", @PlaceHolder = "Password*", @required = "required", pattern = "[a-zA-Z0-9]{3,10}", title = "Password must be 3 to 10 characters long and contains letters and numbers only." })%>
        </div>
        <br />
        <div>
            <input type="submit" class="myButton" value="Register" style="font-weight: bold;" />
            <%: Html.ActionLink("Login","Login", "Home", null, new { @class = "myButton" , style="font-weight: bold; position : right" })%>
        </div>
        <div>
            <br />
        </div>
    </div>
    <% } %>
</asp:Content>
