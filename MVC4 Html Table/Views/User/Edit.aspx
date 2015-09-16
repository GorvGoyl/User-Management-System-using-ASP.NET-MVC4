<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page edit"
    Inherits="System.Web.Mvc.ViewPage<QueueOverflow.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(
        function () {
            $("#message").hide(0);
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

            UserNamelabel.innerHTML = "&nbsp;";
            FullNamelabel.innerHTML = "&nbsp;";
            Phonelabel.innerHTML = "&nbsp;";
            Emaillabel.innerHTML = "&nbsp;";
            Citylabel.innerHTML = "&nbsp;";
            Doblabel.innerHTML = "&nbsp;";


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
            if (PhonematchArray == null) {
                Phonelabel.innerHTML = "*Please enter 10 digit Phone Number";
                Phone.focus();
                return false;

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
            if (dob != null && dob != "") {
                if (DobmatchArray == null) {
                    Doblabel.innerHTML = "*Date format should be 'mm/dd/yyyy'";
                    Dob.focus();
                    return false;

                }
            }


            var user = {};
            user.UserId = $("#UserId").val();
            user.UserName = $("#UserName").val();
            user.FullName = $("#FullName").val();
            user.Phone = $("#Phone").val();
            user.Email = $("#Email").val();
            user.City = $("#City").val();
            user.Dob = $("#Dob").val();
            
            $.ajax({
                type: "POST",
                url: "../User/SaveUser",
                data: '{objUser: ' + JSON.stringify(user) + '}',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $("#message").fadeIn("slow").delay(1000).fadeOut("fast", function () {
                        window.location = "Index";
                    });
                  
                  },
                error: function () {
                    alert("Error while updating user");
                }
            });
            return false;  

        } 
    </script>
     <div id="message" class="Message" style="width:274px; display:none;position: relative;
    top: 25px;">
            <span style="position: relative; top: 2px;">
                User Updated Successfully</span>
        </div>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <div class="Box flipInY" id="animated-example">
        <div class="Label" style="width:132px;">
            <span style="position: relative; top: 2px;">
                Edit Details</span>
        </div>
        <div>
         
        </div>

        <div style="margin-right: 8px;">
            
            <%: Html.LabelFor(model => model.UserName)%>
            <%: Html.TextBoxFor(model => model.UserName, new { @class = "TextBox", @PlaceHolder = "UserName*"})%>
            <div id='UserNamelabel' class="ValidationLabel" style="margin-left: 132px;">&nbsp;
            </div>
        </div>
    
        <div style="margin-right: 4px;">
            </div>
            <%: Html.LabelFor(model => model.FullName)%>
            <%: Html.TextBoxFor(model => model.FullName, new { @class = "TextBox", @PlaceHolder = "FullName*" })%>
        <div id='FullNamelabel' class="ValidationLabel" style="margin-left: 132px;">&nbsp;

        </div>
      
        <div style="margin-right: -17px;">
        
            <%: Html.LabelFor(model => model.Phone)%>
            <%: Html.TextBoxFor(model => model.Phone, new { @class = "TextBox", @PlaceHolder = "Phone*" })%>
            <div id='Phonelabel' class="ValidationLabel" style="margin-left: 132px;">&nbsp;
            </div>
        </div>
       
        <div style="margin-right: -22px;">
       
            <%: Html.LabelFor(model => model.Email)%>
            <%: Html.TextBoxFor(model => model.Email, new { @class = "TextBox", @PlaceHolder = "Email*" })%>
              <div id='Emaillabel' class="ValidationLabel" style="margin-left: 132px;">&nbsp;
            </div>
        </div>
       
        <div style="margin-right: -32px;">
         
            <%: Html.LabelFor(model => model.City)%>
            <%: Html.TextBoxFor(model => model.City, new { @class = "TextBox", @PlaceHolder = "City" })%>
              <div id='Citylabel' class="ValidationLabel" style="margin-left: 132px;">&nbsp;
            </div>
        </div>
    
        <div style="margin-right: -28px;">
          
            <%: Html.LabelFor(model => model.Dob)%>
            <%: Html.TextBoxFor(model => model.Dob, new { @class = "TextBox", @PlaceHolder = "Dob" })%>
            <div id='Doblabel' class="ValidationLabel" style="margin-left: 132px;">&nbsp;
            </div>
        </div>
        <div>
            <%: Html.HiddenFor(model => model.Password)%>
            <%: Html.HiddenFor(model => model.UserId)%>
        </div>
        
        <div>
            <input type="submit" class="myButton" onclick="return validateform(UserName,FullName,Phone,Email,Dob)" value="Update" style="font-weight: bold;"  />
        </div>
        <div>
            <br />
        </div>
    </div>
    <% } %>
</asp:Content>
