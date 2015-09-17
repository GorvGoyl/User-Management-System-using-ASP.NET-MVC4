<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page Password"
    Inherits="System.Web.Mvc.ViewPage<QueueOverflow.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Forget Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function validateform() {
            debugger;
            var username = document.getElementById("UserName").value;
            var email = document.getElementById("Email").value;
            UserNamelabel.innerHTML = "&nbsp;";
            Emaillabel.innerHTML = "&nbsp;";
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
     <div id="message" class="Message" style="width:274px; position: relative;
    top: 25px;background-color:transparent;">
            <span style="position: relative; top: 2px;">
                <%:ViewBag.Pass as string%></span>
        </div>

    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div class="Box flipInY" id="animated-example">
        <div class="Label" style="width: 204px;">
            <div style="position: relative; top: 2px;">
                Retrieve Password</div>
        </div>
       
        <div>
            <br />
        </div>
        <div>
            
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", id="UserName" , @PlaceHolder = "Your UserName*" })%>
           <div id='UserNamelabel' class="ValidationLabel">&nbsp;
            </div>
        </div>
    
        <div>
          
            <%: Html.TextBoxFor(model => model.Email, new { @class = "TextBox", id = "Email", @PlaceHolder = "Your Email*" })%>
              <div id='Emaillabel' class="ValidationLabel">&nbsp;
            </div>
        </div>
       
        <div style="position: relative;">
            <input type="submit" id="submit" class="myButton" value="Retrieve Password" onclick="return validateform()"
                style="font-weight: bold;" />
           <%-- <%: Html.ActionLink("Retrieve Password", "Password", "Home", new { @class = "myButton" , onclick="return validateform(UserName,Email)",style=" position : center" })%>--%>
        </div>
        <div>
            <br />
        </div>
     
    </div>
    <% } %>
</asp:Content>
