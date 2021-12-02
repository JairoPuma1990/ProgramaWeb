<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProgramaWeb.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="MI PRIMER PROGRAMA ASP.NET" CssClass="align-items-xl-center"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="JAIRO DAVID PUMA ASP.NET"></asp:Label>
    
            <h1>HOJA DE VIDA <span class="label label-default"></span></h1>

            <h2>NOMBRE <span class="label label-default"></span></h2>
             <h2>JAIRO DAVID PUMA <span class="label label-default">New</span></h2>
            <h3>Example <span class="label label-default">New</span></h3>
            <h4>Example <span class="label label-default">New</span></h4>
            <h5>Example <span class="label label-default">New</span></h5>
            <h6>Example <span class="label label-default">New</span></h6>
    <span class="label label-default">Default Label</span>
<span class="label label-primary">Primary Label</span>
<span class="label label-success">Success Label</span>
<span class="label label-info">Info Label</span>
<span class="label label-warning">Warning Label</span>
<span class="label label-danger">Danger Label</span>

        </div>
    </form>
</body>
</html>
