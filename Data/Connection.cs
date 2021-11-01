using InfoPQ.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoPQ.Data
{
    public class Connection
    {
        SqlCommand comando;
        SqlConnection conn;
        SqlDataReader reader;

        public Persona ConsultaDNI(string dni)
        {
            Persona info = new Persona();

            conn = new SqlConnection("Server=tcp:consultadnidbserver.database.windows.net,1433;Initial Catalog=InfoPQ_db;Persist Security Info=False;User ID=RenzoPortal;Password=Consuldni@1357;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            string consulta = "select * from Persona where DNI='" + dni + "'";
            comando = new SqlCommand(consulta, conn);
            conn.Open();
            reader = comando.ExecuteReader();

            bool search = reader.Read();
            if (search)
            {
                info.Nombre = reader[1].ToString();
                info.Apellido = reader[2].ToString();
                info.DNI = reader[3].ToString();
                info.Sexo = reader[4].ToString();
            }
            else
            {
                info.Nombre = "No se encontro";
                info.Apellido = "";
            }
            return info;
        }
    }
}
