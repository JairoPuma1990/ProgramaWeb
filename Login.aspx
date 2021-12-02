<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProgramaWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="resources/css/estilos1.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <!-- Tabs Titles -->
                <!-- Icon -->
                <div class="fadeIn first">
                    <img src="https://storage.googleapis.com/wenqui/alfa/alfa-new-200px.jpg" id="icon" alt="User Icon" />
                </div>

                <!-- Login Form -->
                <form>
                    <asp:TextBox ID="TextBox1" runat="server"  placeholder="login"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="password"></asp:TextBox>
                    <asp:Button runat="server" Text="Log In" OnClick="Unnamed1_Click" />
                </form>
                <!-- Remind Passowrd -->
                <div id="formFooter">
                    <a class="underlineHover" href="#">Forgot Password?</a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
