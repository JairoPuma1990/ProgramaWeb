using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgramaWeb
{
    public class NegocioUser
    {
        public List<User> consultar_Administrador(String users, String pass)
        {
            SqlConnection con = new SqlConnection(Conexion.Cadena());

            List<User> user = new List<User>();
            try
            {
                con.Open();
                SqlCommand sqlcom;
                String sql = "select * from Usuarios where password ='" + pass + "' and correo='" + users + "'";
                sqlcom = new SqlCommand(sql, con);
                SqlDataReader r = sqlcom.ExecuteReader();
                while (r.Read())
                {
                    user.Add(new User
                    {
                        correo = r.GetString(0),
                        password = r.GetString(1)

                    });

                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            finally
            {
                con.Close();
            }

            return user;
        }
    }
}
