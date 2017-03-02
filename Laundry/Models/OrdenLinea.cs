using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Models
{
    public class OrdenLinea
    {
        public int idOrden { get; set; }
        public int Item { get; set; }
        public int idPrenda{ get; set; }
        public string Descripcion{ get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Defecto { get; set; }
        public string  Colores { get; set; }
        public decimal Total { get; set; }
        public int Estado { get; set; }
      
        public OrdenLinea() { }
    
           public OrdenLinea(int idorden, int item, int idprenda,string descripcion, int cantidad,string defecto,decimal precio,string colores,decimal total,int estado)
        {
            this.idOrden=idorden;
            this.Item = item;
            this.idPrenda = idprenda;
            this.Descripcion = descripcion;
            this.Cantidad= cantidad;
            this.Precio = precio;
            this.Defecto = defecto;
            this.Colores = colores;
            this.Total= total;
            this.Estado = estado;

            
        }
    
    }


}
