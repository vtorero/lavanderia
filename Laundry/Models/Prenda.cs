using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Models
{
    public class Prenda
    {
        public int idPrenda { get; set; }
        public string NombrePrenda { get; set; }
        public string Descripcion { get; set; }
        public decimal precioServicio { get; set; }



        public Prenda() { }

        public Prenda(int idprenda, string nombre, string descr, decimal precio)
        {
            this.idPrenda = idprenda;
            this.NombrePrenda = nombre;
            this.Descripcion = descr;
            this.precioServicio = precio;

        }

    }
}