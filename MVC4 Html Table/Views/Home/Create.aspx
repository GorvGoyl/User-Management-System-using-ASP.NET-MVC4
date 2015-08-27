<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVC4_Html_Table.Models.User>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <!-- Load jQuery JS -->
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <!-- Load jQuery UI Main JS  -->
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <!-- Load SCRIPT.JS which will create datepicker for input field  -->
    <script src="../../script.js"></script>
    <link rel="stylesheet" href="../../style.css" />
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>User</legend>
        <%-- <div class="editor-label">
                <%: Html.LabelFor(model => model.GUID) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.GUID) %>
                <%: Html.ValidationMessageFor(model => model.GUID) %>--%>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Phone) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Phone) %>
            <%: Html.ValidationMessageFor(model => model.Phone) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.City) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.City) %>
            <%: Html.ValidationMessageFor(model => model.City) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.DOB) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.DOB) %>
            <%: Html.ValidationMessageFor(model => model.DOB) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.EMail) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.EMail) %>
            <%: Html.ValidationMessageFor(model => model.EMail) %>
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</body>
</html>
