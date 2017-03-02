using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia.Models
{
    public class Pago
    {
        
        public int idPago { get; set; }
        public int idOrden{ get; set; }
        public decimal Pago1{ get; set; }
        public decimal Pago2{ get; set; }
        public decimal  PagoTotal{ get; set; }
        public int TipoPago { get; set; }
        public int Estado{ get; set; }
        public string fechaPago { get; set; }
        public string fechaActualizado {get; set;}

         public Pago() { }

        public Pago(int idpago, int idorden, decimal pago1, decimal pago2, decimal pagototal,int tipopago,int estado,string fechapago,string fechaactualizado)
        {
            this.idPago = idpago;
            this.idOrden = idorden;
            this.Pago1 = pago1;
            this.Pago2 = pago2;
            this.PagoTotal = pagototal;
            this.TipoPago = tipopago;
            this.Estado = estado;
            this.fechaPago = fechapago;
            this.fechaActualizado=fechaactualizado;
            
        }

    }
}
