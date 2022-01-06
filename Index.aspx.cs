using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramaWeb
{
    public partial class Index : System.Web.UI.Page
    {
        List<User> ingre = new List<User>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string correo = Mail.Text;
            string pass = Password.Text;

            NegocioUser modelo = new NegocioUser();
            int filas = modelo.registro_usuario(correo, pass);

            Mail.Text = "";
            Password.Text = "";


            Response.Write("<script language=javascript>alert('USUARIOS CREADO CORECTAMENTE ');</script>");
            CargarDatGriwUsuairo();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CargarDatGriwUsuairo();
        }

        public void CargarDatGriwUsuairo()
        {
            NegocioUser modelo2 = new NegocioUser();
            ingre = modelo2.consultar_Usuarios();
            GridView1.DataSource = ingre.ToList();
            GridView1.DataBind();

        }


        protected void Btn_eliminar(object sender, EventArgs e)
        {
      
        }
    }
}