using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaAppFinal.Clases
{
    internal class Usuario
    {


        private int id { get; set; }
        private string nombre { get; set; }
        private string apellidos { get; set; }
        private string dni { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private int telefono { get; set; }
        private int departamento_id_id { get; set; }
        private int rol_id_id { get; set; }

        public Usuario(int id, string nombre, string apellidos, string dni, string email, string password, int telefono, int departamento_id_id, int rol_id_id)
        {
            this.id = id;
            this.nombre = nombre;
            this.dni = dni;
            this.email = email;
            this.password = password;
            this.telefono = telefono;
            this.departamento_id_id = departamento_id_id;
            this.rol_id_id = rol_id_id;


        }
        public Usuario(String nombre, String password)
        {
            this.nombre = nombre;
            this.password = password;
        }

    }
}
