using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            Session["correo"] = 0;
            string cedper = (sender as LinkButton).CommandArgument;
            Session["correo"] = cedper;

            NegocioUser model = new NegocioUser();
            int filas = model.ElimarUsuarios(cedper);

            Response.Write("<script language=javascript>alert('uSUARIO ELIMINADO ');</script>");
            CargarDatGriwUsuairo();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            GridView1.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(GridView1);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Ingreso.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();
        }

        public DataTable DtUsuarios()
        {



            SqlConnection con = new SqlConnection(Conexion.Cadena());
            DataTable dsDat = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Usuarios ", con);
           SqlDataAdapter dsA = new SqlDataAdapter(cmd);
            dsA.Fill(dsDat);
            con.Close();

            return dsDat;

            //string oficina = Session["oficina_id"].ToString();
            //string ini = DateTime.Now.ToString("yyyy-MM-dd");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {



            string fechaingreso = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
          
            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = DtUsuarios();



            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);
                Font font10 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 15);


                PdfPTable table = new PdfPTable(dt.Columns.Count);
                document.Add(new Paragraph(20, "Informe de Usuarios", fontTitle));
                document.Add(new Chunk("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    widths[i] = 4f;

                table.SetWidths(widths);
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell(new Phrase("columns"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font9));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), font9));
                        }
                    }
                }

                document.Add(table);
                document.Add(new Chunk("\n"));
                document.Add(new Chunk("\n"));
                document.Add(new Chunk("\n"));
                document.Add(new Chunk("\n"));
                document.Add(new Paragraph(20, "Firma Client@s", font10));
                document.Add(new Paragraph(20, "jairo puma", font10));
                document.Add(new Paragraph(20, "Corp. cusa by Jp " + fechaingreso + "", font9));

            }
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=OrdeSalida" + ".pdf");
            HttpContext.Current.Response.Write(document);
            Response.Flush();
            Response.End();
        }
    }
}