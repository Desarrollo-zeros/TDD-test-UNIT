using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioFinanciero.Domain
{
    /// <summary>
    /// implemento una interfaz en la clase abstracta.
    /// </summary>
    public abstract class Cuentas : IServicioFinanciero
    {
        public string NumeroCuentaAhorro { set; get; }
        public float MontoCuenta { set; get; }
        public string CiudadOrigen {set;get;}
      
        public int TotalConsignacion { set; get; }
        public int conteoRetiro { set; get; }

        public float TotalRetiro { set; get; }

        public Cuentas() { TotalConsignacion = 0; }


        public abstract int Consignar(float montoConsignar,  string ciudadDestino);

        public abstract int Retirar(float monto);
    }
}
