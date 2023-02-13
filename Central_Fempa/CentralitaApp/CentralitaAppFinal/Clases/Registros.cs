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
        public string telefono_persona { get; set; }
        public string email { get; set; }
        public string empresa { get; set; }
        public string fecha_hora { get; set; }
        public string motivo { get; set; }
        public string nombre_persona { get; set; }
        public string observaciones { get; set; }
        private int atendido_por { get; set; }
        private int empleado { get; set; }

        public Registros(string telefono_persona, string email, string empresa, string fecha_hora, string motivo, string nombre_persona, string observaciones)
        {
            this.telefono_persona = telefono_persona;
            this.email = email;
            this.empresa = empresa;
            this.fecha_hora = fecha_hora;
            this.motivo = motivo;
            this.nombre_persona = nombre_persona;
            this.observaciones = observaciones;
        }

        public override string ToString()
        {
            return String.Concat("Email: ", email,
                "Empresa: ", empresa,
                "Fecha y hora: ", fecha_hora,
                "Motivo: ", motivo,
                "Nombre persona: ", nombre_persona,
                "Observaciones: ", observaciones,
                "Telefono Persona: ", telefono_persona);
        }
    }
}
