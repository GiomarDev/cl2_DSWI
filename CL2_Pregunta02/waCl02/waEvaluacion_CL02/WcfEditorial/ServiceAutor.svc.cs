using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfEditorial
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceAutor" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceAutor.svc o ServiceAutor.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceAutor : IServiceAutor
    {
            SqlConnection cn = new SqlConnection("server=GONDAR\\MSSQLSERVER01;database=BD_EDITORIAL;integrated security=true");

        public string actualizaAutor(AutorO objA)
        {
            String mensage = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZAAUTOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide_aut", objA.codigo);
                cmd.Parameters.AddWithValue("@nom_aut", objA.nombre);
                cmd.Parameters.AddWithValue("@ide_pai", objA.pais);
                cmd.Parameters.AddWithValue("@cor_aut", objA.correo);
                cmd.Parameters.AddWithValue("@fon_aut", objA.telefono);
                cmd.ExecuteNonQuery();
                mensage = "Autor modificado correctamente";
            }
            catch (Exception ex)
            {
                mensage = "Error al modificar Autor..!!" + ex.Message;
            }
            cn.Close();
            return mensage;
        }

        public void eliminaAutor(AutorO objA)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINAAUTOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", objA.codigo);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            cn.Close();
        }

        public List<Autor> listadoAutores()
            {
                List<Autor> aAutor = new List<Autor>();
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAAUTORES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    aAutor.Add(new Autor()
                    {
                        codigo = int.Parse(dr[0].ToString()),
                        nombre = dr[1].ToString(),
                        pais = dr[2].ToString(),
                        correo = dr[3].ToString(),
                        telefono = dr[4].ToString()
                    });
                }
                dr.Close();
                cn.Close();
                return aAutor;
            }

        public List<AutorO> listadoAutoresO()
        {
            List<AutorO> aAutor = new List<AutorO>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_AUTOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aAutor.Add(new AutorO()
                {
                    codigo = int.Parse(dr[0].ToString()),
                    nombre = dr[1].ToString(),
                    pais = int.Parse(dr[2].ToString()),
                    correo = dr[3].ToString(),
                    telefono = dr[4].ToString()
                });
            }
            dr.Close();
            cn.Close();
            return aAutor;
        }

        public List<Pais> listadoPais()
        {
            List<Pais> aPais = new List<Pais>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAPAISES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aPais.Add(new Pais()
                {
                    codigo = int.Parse(dr[0].ToString()),
                    nombre = dr[1].ToString()
                });
            }
            dr.Close();
            cn.Close();
            return aPais;
        }

        public string nuevoAutor(AutorO objA)
        {
            String mensage = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NUEVOAUTOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_aut", objA.nombre);
                cmd.Parameters.AddWithValue("@ide_pai", objA.pais);
                cmd.Parameters.AddWithValue("@cor_aut", objA.correo);
                cmd.Parameters.AddWithValue("@fon_aut", objA.telefono);
                cmd.ExecuteNonQuery();
                mensage = "Autor registrado correctamente";
            }
            catch (Exception ex)
            {
                mensage = "Error al registrar Autor..!!"+ex.Message;
            }
            cn.Close();
            return mensage;
        }
    }
}
