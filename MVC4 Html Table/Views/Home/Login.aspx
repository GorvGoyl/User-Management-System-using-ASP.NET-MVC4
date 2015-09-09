<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page Login"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function validateform() {

            var username = document.getElementById("UserName").value;
            var password = document.getElementById("Password").value;
            UserNamelabel.innerHTML = "";
            Passwordlabel.innerHTML = "";
            if (username == null || username == "") {
                UserNamelabel.innerHTML = "*Please enter a Username";
                UserName.focus();
                return false;
            }
            if (username.length < 3) {
                UserNamelabel.innerHTML = "*UserName must be at least 3 characters long";
                UserName.focus();
                return false;
            }
            if (password == null || password == "") {
                Passwordlabel.innerHTML = "*Please enter a password";
                Password.focus();
                return false;
            }
            if (password.length < 3) {
                Passwordlabel.innerHTML = "*Password must be at least 3 characters long";
                Password.focus();
                return false;
            }

            return true;


        } 
    </script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div class="Box flipInY" id="animated-example">
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
            
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", id="UserName" , @PlaceHolder = "UserName*" })%>
           <div id='UserNamelabel' class="ValidationLabel">
            </div>
        </div>
        <br />
        <div>
          
            <%: Html.PasswordFor(model => model.Password, new { @class = "TextBox",id="Password", @PlaceHolder = "Password*" })%>
              <div id='Passwordlabel' class="ValidationLabel">
            </div>
        </div>
        <br />
        <div style="position: relative;">
            <input type="submit" id="submit" class="myButton" value="Login" onclick="return validateform(UserName,Password)"
                style="font-weight: bold;" />
            <%: Html.ActionLink("Register", "Register", null, new { @class = "myButton" , style="font-weight: bold; position : right" })%>
        </div>
        <div>
            <br />
        </div>
    </div>
    <% } %>
</asp:Content>
