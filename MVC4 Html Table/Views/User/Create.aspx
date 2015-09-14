<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page edit"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(
        function () {
            $("#Dob").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: "-12y",
                minDate: "-100y"
            });
        }
        );
    </script>
    <script type="text/javascript">
        function validateform() {

            var username = document.getElementById("UserName").value;
            var fullname = document.getElementById("FullName").value;
            var phone = document.getElementById("Phone").value;
            var email = document.getElementById("Email").value;
            var dob = document.getElementById("Dob").value;
            var password = document.getElementById("Password").value;
            UserNamelabel.innerHTML = "&nbsp;";
            FullNamelabel.innerHTML = "&nbsp;";
            Phonelabel.innerHTML = "&nbsp;";
            Emaillabel.innerHTML = "&nbsp;";
            Citylabel.innerHTML = "&nbsp;";
            Doblabel.innerHTML = "&nbsp;";
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
            if (fullname == null || fullname == "") {
                FullNamelabel.innerHTML = "*Please enter your Name";
                FullName.focus();
                return false;
            }
            var phonePat = /^([0-9]{10})$/
            var PhonematchArray = phone.match(phonePat);
            if (phone != null && phone != "") {
                if (PhonematchArray == null) {
                    Phonelabel.innerHTML = "*Please enter 10 digit Phone Number";
                    Phone.focus();
                    return false;

                }
            }

            if (email == null || email == "") {
                Emaillabel.innerHTML = "*Please enter Email";
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

            var dobPat = /^([0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4})$/
            var DobmatchArray = dob.match(dobPat);
             if(dob!=null && dob!="")
             {
            if (DobmatchArray == null) {
                Doblabel.innerHTML = "*Date format should be 'mm/dd/yyyy'";
                Dob.focus();
                return false;

            }
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

            var user = {};
            user.UserName = $("#UserName").val();
            user.FullName = $("#FullName").val();
            user.Phone = $("#Phone").val();
            user.Email = $("#Email").val();
            user.City = $("#City").val();
            user.Dob = $("#Dob").val();
            user.Password = $("#Password").val();
            $.ajax({
                type: "POST",
                url: "../User/CreateUser",
                data: '{objUser: ' + JSON.stringify(user) + '}',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $("#message").fadeIn("slow").delay(1000).fadeOut("fast", function () {
                        window.location = "Index";
                    });

                },
                error: function () {
                    alert("Error while creating user");
                }
            });
            return false; 


        } 
    </script>
      <div id="message" class="Message" style="width:274px; display:none;position: relative;
    top: 25px;">
            <span style="position: relative; top: 2px;">
                User Created Successfully</span>
        </div>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div class="Box flipInY" id="animated-example">
        <div class="Label" style="width:132px">
            <div style="position: relative; top: 2px;">
                Create User</div>
        </div>
      
        <div>
            <br />
        </div>
        <div>
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", @PlaceHolder = "UserName*"})%>
            <div id='UserNamelabel' class="ValidationLabel">
                &nbsp;
            </div>
        </div>
        <div>
            <%: Html.TextBoxFor(model => model.FullName, new { @class = "TextBox", @PlaceHolder = "FullName*"})%>
            <div id='FullNamelabel' class="ValidationLabel">
                &nbsp;
            </div>
        </div>
        <div>
            <%: Html.TextBoxFor(model => model.Phone, new { @class = "TextBox", @PlaceHolder = "Phone*"  })%>
            <div id='Phonelabel' class="ValidationLabel">
                &nbsp;
            </div>
        </div>
        <div>
            <%: Html.TextBoxFor(model => model.Email, new { @class = "TextBox", @PlaceHolder = "Email*"  })%>
            <div id='Emaillabel' class="ValidationLabel">
                &nbsp;
            </div>
        </div>
        <div>
            <%: Html.TextBoxFor(model => model.City, new { @class = "TextBox", @PlaceHolder = "City"  })%>
            <div id='Citylabel' class="ValidationLabel">
                &nbsp;
            </div>
        </div>
        <div>
            <%: Html.TextBoxFor(model => model.Dob, new { @class = "TextBox", @PlaceHolder = "Dob" })%>
            <div id='Doblabel' class="ValidationLabel">
                &nbsp;
            </div>
        </div>
        <div>
            <%: Html.PasswordFor(model => model.Password, new { @class = "TextBox", @PlaceHolder = "Password*" })%>
            <div id='Passwordlabel' class="ValidationLabel">
                &nbsp;
            </div>
        </div>
        <div>
            <input type="submit" class="myButton" value="Create" style="font-weight: bold;" onclick="return validateform(UserName,FullName,Phone,Email,City,Dob,Password)" />
        </div>
        <div>
            <br />
        </div>
    </div>
    <% } %>
</asp:Content>
