<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page Login"
    Inherits="System.Web.Mvc.ViewPage<QueueOverflow.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<script type="text/javascript">
    $(document).ready(
        function () {
            UserNamelabel.innerHTML = "&nbsp;";
            Passwordlabel.innerHTML = "&nbsp;";
        }
        );
    </script>
    <script type="text/javascript">
        function validateform() {

            var username = document.getElementById("UserName").value;
            var password = document.getElementById("Password").value;
            UserNamelabel.innerHTML = "&nbsp;";
            Passwordlabel.innerHTML = "&nbsp;";
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
     <div id="message" class="Message" style="width:274px; position: relative;
    top: 25px;background-color:transparent;    color: red;">
            <span style="position: relative; top: 2px;">
                <%:ViewBag.Pass as string%></span>
        </div>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div class="Box flipInY" id="animated-example">
        <div class="Label" style="">
            <div style="position: relative; top: 2px;">
                Login</div>
        </div>

        <div>
            <br />
        </div>
        <div>

            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", id="UserName" , @PlaceHolder = "UserName*" })%>
           <div id='UserNamelabel' class="ValidationLabel">"&nbsp;"
            </div>
        </div>

        <div>

            <%: Html.PasswordFor(model => model.Password, new { @class = "TextBox",id="Password", @PlaceHolder = "Password*" })%>
              <div id='Passwordlabel' class="ValidationLabel">"&nbsp;"
            </div>
        </div>

        <div style="position: relative;">
            <input type="submit" id="submit" class="myButton" value="Login" onclick="return validateform(UserName,Password)"
                style="font-weight: bold;" />
            <%: Html.ActionLink("Register", "Register", null, new { @class = "myButton" , style="font-weight: bold; position : right" })%>
        </div>
        <div>
            <br />
        </div>
        <p class="change_link" style = " position: relative; bottom: 8px;">
									Forgot Password ?
									<a href="../Home/Password" class="to_register">Click Here</a>
								</p>
    </div>
    <% } %>
</asp:Content>
