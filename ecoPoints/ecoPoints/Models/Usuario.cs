using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MongoDB.Bson;

namespace ecoPoints.Models
{
    public class Usuario
    {

        public static String Registrar(int carne, string pass)
        {
            var respuesta = "";

            var conexion = "Server=us-cdbr-azure-west-c.cloudapp.net;Port=3306;DataBase=ecopoints;Uid=b9f20f54474fab;Pwd=4fdcff02";
            var conexionmysql = new MySqlConnection(conexion);
            conexionmysql.Open();

            string comandobuscar = "SELECT * FROM usuario";
            var nombre = new MySqlCommand(comandobuscar, conexionmysql);
            MySqlDataReader lector = nombre.ExecuteReader();
            List<Int32> ids = new List<Int32>();
            while (lector.Read())
            {
                ids.Add(lector.GetInt32("carne"));
            }
            lector.Close();
            Boolean existe = false;
            foreach (var carnets in ids)
            {
                if (carne == carnets)
                {
                    existe = true;
                }
            }

            if (existe == false)
            {
                string comando = "INSERT INTO usuario (carne, pass) VALUES(" + carne + ", " + pass + ")";
                var cmd = new MySqlCommand(comando, conexionmysql);
                cmd.ExecuteNonQuery();
                respuesta = "Registro Completo";
            }else
            {
                respuesta = "El usuario ya existe";
            }

            conexionmysql.Close();
            return respuesta;
        }
    }
}