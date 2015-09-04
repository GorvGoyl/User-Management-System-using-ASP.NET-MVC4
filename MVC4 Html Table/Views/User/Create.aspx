<%@ Page Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master" Title="Content Page edit"
    Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Create
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
    <h1 style="text-align: center">
        Create</h1>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
   <%-- <div class="editor-label">--%>
        <%--<%: Html.LabelFor(model => model.GUID) %>--%>
  <%--  </div>
    <div class="editor-field">--%>
        <%--<%: Html.HiddenFor(model => model.GUID) %>--%>
        <%--<%: Html.ValidationMessageFor(model => model.GUID) %>--%>
    <%--</div>--%>
    <table class="TableColor" align="center" style="margin-left: 9cm" width="50%">
        <%--<thead>
            <tr>
                <th>
                    <h1>
                        Data</h1>
                </th>
                <th>
                    <h1 style="text-align: left">
                        Value</h1>
                </th>
            </tr>
        </thead>--%>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.UserName)%>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.UserName)%>
                    <%: Html.ValidationMessageFor(model => model.UserName)%>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.FullName)%>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.FullName)%>
                    <%: Html.ValidationMessageFor(model => model.FullName)%>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Phone) %>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.Phone) %>
                    <%: Html.ValidationMessageFor(model => model.Phone) %>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Email) %>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.Email) %>
                    <%: Html.ValidationMessageFor(model => model.Email) %>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.City) %>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.City) %>
                    <%: Html.ValidationMessageFor(model => model.City) %>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Dob) %>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.Dob)%>
                    <%: Html.ValidationMessageFor(model => model.Dob)%>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td">
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Password) %>
                </div>
            </td>
            <td class="td">
                <div class="editor-field" style="text-align: left">
                    <%: Html.EditorFor(model => model.Password)%>
                    <%: Html.ValidationMessageFor(model => model.Password)%>
                </div>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td>
                </td>
                <td>
                    <p style="text-align: left">
                        <input type="submit" value="Save" />
                    </p>
                </td>
            </tr>
        </tfoot>
    </table>
    <% } %>
    <div style="text-align: left">
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
