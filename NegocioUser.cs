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

        public int registro_usuario(string correo , string password)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"INSERT INTO Usuarios(correo, password )
					                   values('"+correo+"','"+password+"')";
               SqlCommand cmd = new SqlCommand(query, con);
                filas = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return filas;
        }

        public int ElimarUsuarios(string correo)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"delete from Usuarios where correo='"+correo+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                filas = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return filas;
        }
        public List<User> consultar_Usuarios()
        {
            SqlConnection con = new SqlConnection(Conexion.Cadena());

            List<User> user = new List<User>();
            try
            {
                con.Open();
                SqlCommand sqlcom;
                String sql = "select * from Usuarios";
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
