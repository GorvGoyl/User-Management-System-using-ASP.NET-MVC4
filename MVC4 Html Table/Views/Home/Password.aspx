<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page Password"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Forget Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function validateform() {

            var username = document.getElementById("UserName").value;
            var email = document.getElementById("Email").value;
            UserNamelabel.innerHTML = "";
            Passwordlabel.innerHTML = "";
            if (username == null || username == "") {
                UserNamelabel.innerHTML = "*Please enter your Username";
                UserName.focus();
                return false;
            }
            if (username.length < 3) {
                UserNamelabel.innerHTML = "*UserName must be at least 3 characters long";
                UserName.focus();
                return false;
            }
            if (email == null || email == "") {
                Emaillabel.innerHTML = "*Please enter your Email";
                Email.focus();
                return false;
            }

            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/
            var EmailmatchArray = email.match(emailPat);
            if (EmailmatchArray == null) {
                Emaillabel.innerHTML = "*Please enter valid Email";
                Email.focus();
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
            
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", id="UserName" , @PlaceHolder = "Your UserName*" })%>
           <div id='UserNamelabel' class="ValidationLabel">
            </div>
        </div>
        <br />
        <div>
          
            <%: Html.TextBoxFor(model => model.Email, new { @class = "TextBox", id = "Email", @PlaceHolder = "Your Email*" })%>
              <div id='Emaillabel' class="ValidationLabel">
            </div>
        </div>
        <br />
        <div style="position: relative;">
            <input type="submit" id="submit" class="myButton" value="Retrieve Password" onclick="return validateform(UserName,Email)"
                style="font-weight: bold;" />
            <%: Html.ActionLink("Retrieve Password", "Password", null, new { @class = "myButton" , style="font-weight: bold; position : right" })%>
        </div>
        <div>
            <br />
        </div>
     
    </div>
    <% } %>
</asp:Content>
