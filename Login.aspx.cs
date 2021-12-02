using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramaWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");


        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            List<User> log = new List<User>();

            String user = TextBox1.Text;
            String pass = TextBox2.Text;

            NegocioUser modelo = new NegocioUser();
            log = modelo.consultar_Administrador(user, pass);
            User user1 = log.FirstOrDefault();
            if (user1 != null)
            {

                Response.Write("<script language=javascript>alert('Clave Generada Exitosa Terminada');window.location.href= 'Index.aspx';</script>");


            }
            else
            {
                Response.Write("<script language=javascript>alert('Intente Otra vez ');</script>");

            }
        }
    }
}