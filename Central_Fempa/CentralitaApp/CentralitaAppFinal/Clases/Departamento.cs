using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaAppFinal.Clases
{
    internal class Departamento
    {

        private int id { get; set; }
        private string nombre { get; set; }
        private int telefono { get; set; }



        public Departamento(int id, string nombre, int telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;


        }

    }
}
