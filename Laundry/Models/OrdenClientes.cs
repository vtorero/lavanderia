using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Models
{
    public class OrdenClientes
    {
        public int idOrden { get; set; }
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string dniCliente{ get; set; }
        public string sucursal { get; set; }
        public string fechaCreado { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoPendiente { get; set; }
        public int TipoPago { get; set; }
        /*public decimal MontoTotal{ get; set; }*/
       
    
         public OrdenClientes() { }

     public OrdenClientes(
         int idorden, int idcliente, string nombrecliente, string sucur,string dnicliente,string fechacreado,
         decimal monto, decimal montopendiente,int tipopago/*,decimal montototal*/)
        {
            this.idOrden=idorden;
            this.idCliente = idcliente;
            this.nombreCliente=nombrecliente;
            this.dniCliente=dnicliente;
            this.sucursal=sucur;
            this.fechaCreado = fechacreado;
            this.Monto = monto;
            this.MontoPendiente= montopendiente;
            this.TipoPago = tipopago;
            /*this.MontoTotal= montototal;*/
            
        }
    
    }

}
