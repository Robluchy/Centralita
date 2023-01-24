using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaAppFinal.Clases
{
    internal class Registros
    {

        private int id { get; set; }
        private string contacto_persona { get; set; }
        private string empresa { get; set; }
        private string fecha { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private int telefono { get; set; }
        private int departamento_id_id { get; set; }
        private int rol_id_id { get; set; }



        public Registros(int id, string contacto_persona, string empresa, string fecha
            , string email, string password, int telefono, int departamento_id_id, int rol_id_id)
        {
            this.id = id;
            this.contacto_persona = contacto_persona;
            this.empresa = empresa;
            this.fecha = fecha;
            this.email = email;
            this.password = password;
            this.telefono = telefono;
            this.departamento_id_id = departamento_id_id;
            this.rol_id_id = rol_id_id;


        }

    }
}
