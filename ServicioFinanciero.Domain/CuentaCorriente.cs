using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioFinanciero.Domain
{
    class CuentaCorriente : Cuentas
    {
        public CuentaCorriente() : base()
        {
        }

        public override int Consignar(float monto, string ciudadDestino)
        {
            throw new NotImplementedException();
        }

        public override int Retirar(float monto)
        {
            throw new NotImplementedException();
        }
    }
}
