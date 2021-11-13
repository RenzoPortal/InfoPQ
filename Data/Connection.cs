using InfoPQ.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfoPQ.Data
{
    public class Connection
    {

        private readonly string URL = "https://webapidni20211112202937.azurewebsites.net/api/Person";

        public async Task<Persona> GetPerson(string dni)
        {
            Persona dt = new Persona();
            using (var httpcliente = new HttpClient())
            {
                string url = URL + "/" + dni;
                HttpResponseMessage response = await httpcliente.GetAsync(url);
                string airresponse = await response.Content.ReadAsStringAsync();
                dt = JsonConvert.DeserializeObject<Persona>(airresponse);
                if (dt.DNI == null)
                {
                    dt.Nombre = "No se encontro registro";
                    dt.Apellido = "";
                }
            }
            return dt;
        }
        public async Task CrearPersona(string nombre, string apellido, string dni)
        {
            using (var httpcliente = new HttpClient())
            {
                Person per = new Person();
                per.Nombre = nombre;
                per.Apellido = apellido;
                per.Dni = dni;
                string url = URL;
                StringContent content = new StringContent(JsonConvert.SerializeObject(per), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpcliente.PostAsync(url, content);
                string airresponse = await response.Content.ReadAsStringAsync();
            }
        }

        //public Persona ConsultaDNI(string dni)
        //{
        //    Persona info = new Persona();

        //    conn = new SqlConnection("Server=tcp:consultadnidbserver.database.windows.net,1433;Initial Catalog=InfoPQ_db;Persist Security Info=False;User ID=RenzoPortal;Password=Consuldni@1357;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    string consulta = "select * from Persona where DNI='" + dni + "'";
        //    comando = new SqlCommand(consulta, conn);
        //    conn.Open();
        //    reader = comando.ExecuteReader();

        //    bool search = reader.Read();
        //    if (search)
        //    {
        //        info.Nombre = reader[1].ToString();
        //        info.Apellido = reader[2].ToString();
        //        info.DNI = reader[3].ToString();
        //        info.Sexo = reader[4].ToString();
        //    }
        //    else
        //    {
        //        info.Nombre = "No se encontro";
        //        info.Apellido = "";
        //    }
        //    conn.Close();
        //    return info;
        //}
        //public Persona Registrarse(string nombre, string apellido, string dni, string sexo)
        //{
        //    Persona registrar = new Persona();
        //    conn = new SqlConnection("Server=tcp:consultadnidbserver.database.windows.net,1433;Initial Catalog=InfoPQ_db;Persist Security Info=False;User ID=RenzoPortal;Password=Consuldni@1357;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    string guardar = "insert into Persona (Nombre, Apellido, DNI, Sexo) values ('"+nombre+"', '"+apellido+"', '"+dni+"', '"+sexo+"')";
        //    comando = new SqlCommand(guardar, conn);
        //    conn.Open();
        //    comando.ExecuteNonQuery();
        //    conn.Close();
        //    return registrar;
        //}
    }
}
