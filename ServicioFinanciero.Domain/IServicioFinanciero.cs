using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServicioFinanciero.Domain
{
    /*Interfaz Servicio financieros*/

    /*Procesos realizados por el usuarios
     * 1->Consignaciones
     * 2->Retiros
     * 3->Traslado dinero
    */
    public interface IServicioFinanciero
    {
        /**
          * <summary>
          *  Este método permite agregar un monto de dinero a una cuenta
          *  1.1 La consignación inicial debe ser mayor o igual a 50 mil pesos
          *  1.2 El valor de la consignación debe ser mayor a 0
          *  1.3 El valor de la consignación se le adicionará al valor del saldo aumentará
          *  1.4 La consignación nacional (a una cuenta de otra ciudad) tendrá un costo de $10 mil pesos.
          * </summary>
          * <param name="monto">El monto de dinero que se va a consignar</param>
          * <param name="ciudadOrigen">Ciudad donde de la sucursal donde se encuentra realizando la Consignacion</param>
          * <param name="ciudadDestino">Ciudad donde se enviar la consignacion</param>
          * <returns>
          *  -1 = monto menor a 0
          *  -2 = monto en consignacion inicial menor a 50 mil
          *   1 = si la consignacion se hace correcta el monto aumenta
          *   2 = si la consignacion es correcta pero la ciudad de destino es diferente
          * </returns>
         */
        int Consignar(float monto, string ciudadDestino);



        /**
         * <summary>
         *  Como Usuario quiero realizar retiros a una cuenta de ahorro para obtener el dinero en efectivo
         *  2.1 El valor a retirar se debe descontar del saldo de la cuenta.
         *  2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
         *  2.3 Los primeros 3 retiros del mes no tendrán costo.
         *  2.4 Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.
         * </summary>
         * <param name="monto">El monto de dinero que se va a consignar</param>
         * <returns>
         * - 2 = el monto a retirar mayor al monto de la cuenta 
         *  -1 = monto de la cuenta menor a 20 mil
         *   1 = retiros gratis
         *   2 = retirno con 5 mil de descuento
         * </returns>
        */
        int Retirar(float monto);

    }

}