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
            <asp:Label ID="Label1" runat="server" Text="REGISTRO DE MAIL"></asp:Label>
            <asp:TextBox ID="Mail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="REGISTRO DE CLAVE"></asp:Label>
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="Button1" runat="server" Text="REGISTRA USUARIO" class="btn btn-success" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Usuarios" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="excel" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
            <asp:GridView ID="GridView1"  runat="server"  CssClass="table table-responsive tabla_datos"  BorderColor="Transparent" AutoGenerateColumns="False">
                 <Columns>
                    <asp:BoundField DataField="correo" HeaderText="MAIL" />
                    <asp:BoundField DataField="password" HeaderText="PASSWORD" />
 
                      <asp:TemplateField>
                <ItemTemplate>                   
                       <asp:LinkButton ID="btn_Asignar_rc" runat="server"  CommandArgument='<%# Eval("correo" ) %>'   CssClass="btn btn-primary" BorderColor="Transparent" OnClick="Btn_eliminar" >
                       <span class="glyphicon glyphicon-list-alt">ELIMINAR</span>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
