using Clases.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Clases.Accesos
{
    public class ClaseUsuario
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=Ejercicio#3; Uid=root; Pwd=Ranson_007;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuarios LoginUsuarios(string codigo, string clave)
        {
            Usuarios user = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo AND Clave = @Clave;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuarios();
                    user.Codigo = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Clave = reader[2].ToString();
                    user.Rol = reader[3].ToString();
                  
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
            }
            return user;
        }

        public DataTable ListarUsuarios()
        {
            DataTable listarUsuariosDT = new DataTable();
            try
            {
                string sql = "SELECT * FROM usuario;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listarUsuariosDT.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
            }
            return listarUsuariosDT;
        }

        public bool InsertarUsuario(Usuarios usuario)
        {
            bool inserto = false;

            try
            {
                string sql = "INSERT INTO usuario VALUES (@Codigo, @Nombre, @Clave, @Rol);";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                cmd.ExecuteNonQuery();
                inserto = true;
                conn.Close();
            }
            catch (Exception)
            {

            }
            return inserto;
        }
        public bool ModificarUsuario(Usuarios usuario)
        {
            bool modifico = false;

            try
            {
                string sql = "UPDATE usuario SET Codigo = @Codigo, Nombre = @Nombre, Clave = @Clave, Rol = @Rol WHERE Codigo = @Codigo;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
             
                cmd.ExecuteNonQuery();
                modifico = true;
                conn.Close();
            }
            catch (Exception)
            {

            }
            return modifico;
        }

        public bool EliminarUsuario(string codigo)
        {
            bool elimino = false;

            try
            {
                string sql = "DELETE FROM usuario WHERE Codigo = @Codigo;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);


                cmd.ExecuteNonQuery();
                elimino = true;
                conn.Close();
            }
            catch (Exception)
            {

            }
            return elimino;
        }
    }
}
