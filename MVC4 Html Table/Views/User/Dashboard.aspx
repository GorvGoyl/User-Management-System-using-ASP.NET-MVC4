<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page Dashboard"
    Inherits="System.Web.Mvc.ViewPage<QueueOverflow.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <script type="text/javascript">

        $(document).ready(function () {

            $(".tab_content").hide();
            $(".tab_content:first").show();

            $("ul.tabs li").click(function () {
                $("ul.tabs li").removeClass("active");
                $(this).addClass("active");
                $(".tab_content").hide();
                var activeTab = $(this).attr("rel");
                $("#" + activeTab).fadeIn();
            });
        });

    </script>
    <div style="padding-left: 220px; padding-right: 220px;">
        <div class="Label" style="width: 123px; position: relative;  top: 49px;    font-size: 30px;color:#005EBB;
               background-color:transparent">
            <span style="position: relative; top: 2px;">Dashboard</span>
        </div>
        <div class="Label" style="width: 400px; position: relative; top: 80px; margin-bottom: 86px;float:left;
            color: #5383D3; background-color: transparent;right: 94px;
">
            <span style="position: relative; top: 2px;">Welcome <span style="color: #002E40;">
                <%:ViewBag.FullName as string%><span></span>
        </div>
        <div>
            <ul class="tabs">
                <li class="active" rel="tab1">Questions</li>
                <li rel="tab2">Answers</li>
                <li rel="tab3">My Profile</li>
            </ul>
        </div>
        <div class="tab_container">
            <div id="tab1" class="tab_content">
                <p>
                    Q: <a href="#">How does #include bits/stdc++.h work in C++?</a><br />
                    Q: <a href="#">Why is processing a sorted array faster than an unsorted array?</a><br />
                    Q: <a href="#">Why does HTML think “chucknorris” is a color?</a><br />
                    Q: <a href="#">PUT vs POST in REST?</a>
                </p>
            </div>
            <!-- #tab1 -->
            <div id="tab2" class="tab_content">
                <p>
                    A: <a href="#">What's the difference between String and string?</a><br />
                    A: <a href="#">Href attribute for JavaScript links: “#” or “javascript:void(0)”?</a><br />
                    A: <a href="#">Is it possible to apply CSS to half of a character?</a><br />
                    A: <a href="#">Include a JavaScript file in another JavaScript file?</a><br />
                    A: <a href="#">How can I refresh a page with jQuery?</a>
                </p>
            </div>
            <!-- #tab2 -->
            <div id="tab3" class="tab_content">
               
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                UserName :
                            </td>
                            <td>
                                <%:ViewBag.UserName as string%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                FullName :
                                </td>
                                <td>
                                <%:ViewBag.FullName as string%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone :
                                </td>
                                <td>
                                <%:ViewBag.Phone as string%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email :
                                </td>
                                <td>
                                <%:ViewBag.Email as string%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                City :
                                </td>
                                <td>
                                <%:ViewBag.City as string%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Dob :
                                </td>
                                <td>
                                <%:ViewBag.Dob as string%>
                            </td>
                        </tr>
                    </table>
               
            </div>
            <!-- #tab3 -->
        </div>
        <!-- .tab_container -->
    </div>
</asp:Content>
