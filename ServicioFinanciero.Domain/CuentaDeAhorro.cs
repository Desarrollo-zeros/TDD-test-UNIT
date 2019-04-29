using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicioFinanciero.Domain
{
    public class CuentaDeAhorro : Cuentas
    {
        public CuentaDeAhorro() : base(){}

        public override int Consignar(float montoConsignar, string ciudadDestino)
        {
            bool r = false;
            if (montoConsignar <= 0) return -1; //validacion 1.2

            if (TotalConsignacion == 0 && montoConsignar < 50000) return -2;   //validacion 1.1

            if (!ciudadDestino.Equals(CiudadOrigen)){montoConsignar -= 10000; r = true;}  // validacion 1.4

            MontoCuenta += montoConsignar; TotalConsignacion++; //validacion  1.3
            return (r) ? 2 : 1;
        }


        public override int Retirar(float monto)
        {
            bool r = false;
            if (MontoCuenta < 20000) return -1;   //validacion 2.2
            if (monto > MontoCuenta) return -2;   //validacion 2.2
            MontoCuenta -= monto; //validacion 2.3 & 2.1
            if (conteoRetiro > 3) { monto -= 5000; r = true; } //validacion 2.4
            TotalRetiro = monto;
            return (r) ? 2 : 1;
        }
    }
}
