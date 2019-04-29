using System;
using ServicioFinanciero.Domain;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace ServicioFinanciero.Domain.Test
{
    [TestFixture()]
    public class CuentaDeAhorrosTests
    {
        /*Test HU1*/
        [Test()]
        public void TestConsignacionNegativaOCero()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "valledupar";
            cuentDeaAhorro.MontoCuenta = 0;
            cuentDeaAhorro.NumeroCuentaAhorro = "10001";
            int prueba = cuentDeaAhorro.Consignar(-1, "valledupar");
            Assert.AreEqual(-1, prueba, "Prueba: 1, el valor de consignacion es incorrecto");
            Console.WriteLine("el valor de consignacion es incorrecto");
        }

        [Test()]
        public void TestInicialCorrecta()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "valledupar";
            cuentDeaAhorro.MontoCuenta = 0;
            int prueba = cuentDeaAhorro.Consignar(50000, "valledupar");
            Assert.AreEqual(1, prueba, "Prueba: 2, Su nuevo saldo es $50000");
            Console.WriteLine(" Su nuevo saldo es $" + cuentDeaAhorro.MontoCuenta);
        }

        [Test()]
        public void TestInicialIncorrecta()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "valledupar";
            cuentDeaAhorro.MontoCuenta = 0;
            cuentDeaAhorro.NumeroCuentaAhorro = "10001";
            int prueba = cuentDeaAhorro.Consignar(49950, "valledupar");
            Assert.AreEqual(-2, prueba, "Prueba: 3, El valor mínimo de la primera consignación debe serde $50.000 mil pesos.Su nuevo saldo es $0 pesos");
            Console.WriteLine("El valor mínimo de la primera consignación debe serde $50.000 mil pesos.Su nuevo saldo es $0 pesos");
        }

        [Test()]
        public void TestPosteriorInicialCorrecta1()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "valledupar";
            cuentDeaAhorro.MontoCuenta = 30000;
            cuentDeaAhorro.TotalConsignacion++;
            cuentDeaAhorro.NumeroCuentaAhorro = "10001";
            int prueba = cuentDeaAhorro.Consignar(49950, "valledupar");
            Assert.AreEqual(1, prueba, "Prueba: 4, Su Nuevo Saldo es de $79.950,00 pesos m/c.");
            Console.WriteLine("Su Nuevo Saldo es de " + cuentDeaAhorro.MontoCuenta + " pesos m/c. ");
        }

        [Test()]
        public void TestPosteriorInicialCorrecta2()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "Bogota";
            cuentDeaAhorro.MontoCuenta = 30000;
            cuentDeaAhorro.TotalConsignacion++;
            cuentDeaAhorro.NumeroCuentaAhorro = "10001";
            int prueba = cuentDeaAhorro.Consignar(49950, "Valledupar");
            Assert.AreEqual(2, prueba, "Prueba: 5, Su Nuevo Saldo es de $69.950,00 pesos m/c.");
            Console.WriteLine("Su Nuevo Saldo es de " + cuentDeaAhorro.MontoCuenta + " pesos m/c. ");
        }


        /*Test HU2*/
        [Test()]
        //2.1
        /* Escenario: Retiro de cuenta de ahorro correcta
        *  HU Como usuario quiero que al realizar un retiro de mi cuenta de ahorro
            * *Criterio de acceptacion**
        *  2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
        *  
        *  Dado: el cliente al momento de consignar tiene un monto en su cuenta de $30000 y
        *  desea realizar un retiro de de 20000 siendo el primer retiro del mes
        *
        * Cuando: su retiro sea de $20000 pesos
        * 
        * Entonces: El sistema dara el dinero al usuario descontando el monto a retirar
        * y dando un mensaje, "Su nuevo saldo es de $10000
        */
        public void TestPrimerRetiroDelMesCorrecto()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "Bogota";
            cuentDeaAhorro.MontoCuenta = 30000;
            cuentDeaAhorro.NumeroCuentaAhorro = "10001";
            int prueba = cuentDeaAhorro.Retirar(20000);
            Assert.AreEqual(1, prueba, "Prueba: 1, Su Nuevo Saldo es de $10000 pesos m/c.");
            Console.WriteLine("Su Nuevo Saldo es de " + cuentDeaAhorro.MontoCuenta + " pesos m/c. ");
        }


        [Test()]
        //2.2
        /* Escenario: Retiro de cuenta de ahorro incorrecto
         *  HU Como usuario quiero que al realizar un retiro de mi cuenta de ahorro
             * *Criterio de acceptacion**
         *  2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
         *  
         *  Dado: el cliente al momento de consignar tiene un monto en su cuenta de $30000 y
         *  desea realizar un retiro de de $30950 siendo el primer retiro del mes
         *
         * Cuando: su retiro sea de 30950 pesos
         * 
         * Entonces: El sistema debera avisarle al usuario, "El monto a retirar es mayor que 
         * el monto de su cuenta, su saldo es de $30000"
         */
        public void TestPrimerRetiroDelMesIncorrecto()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "Bogota";
            cuentDeaAhorro.MontoCuenta = 30000;
            cuentDeaAhorro.NumeroCuentaAhorro = "10001";
            int prueba = cuentDeaAhorro.Retirar(30950);
            Assert.AreEqual(-2, prueba, "Prueba: 2, El monto a retirar es mayor que  el monto " +
                "de su cuenta, su saldo es de $3000");
            Console.WriteLine("El monto a retirar es mayor que  el monto " +
                "de su cuenta, su saldo es de $" + cuentDeaAhorro.MontoCuenta);
        }

        [Test()]
        //2.3
        /* Escenario: Retiro de cuenta de ahorro correcta
         *  HU Como usuario quiero que al realizar un retiro de mi cuenta de ahorro me reste un porcentaje
             * *Criterio de acceptacion**
         *  2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
         *  2.4 Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.
         *  
         *  Dado: el cliente al momento de consignar tiene un monto en su cuenta de $440000 y
         *  desea realizar un retiro de por cuarta vez.
         *
         * Cuando: su retiro sea $64000 pesos
         * 
         * Entonces: El sistema debera avisarle al usuario, 
         * "su monto total es de 376000 y el monto a retirar sera de $59000"
         */
        public void TestCuartoRetiroDelMes()
        {
            CuentaDeAhorro cuentDeaAhorro = new CuentaDeAhorro();
            Clientes cliente = new Clientes();
            cliente.PrimerNombreCliente = "Cuenta";
            cliente.PrimerApellido = "ejemplo";
            cuentDeaAhorro.CiudadOrigen = "Bogota";
            cuentDeaAhorro.MontoCuenta = 440000;
            cuentDeaAhorro.NumeroCuentaAhorro = "10001";
            cuentDeaAhorro.conteoRetiro = 4;
            int prueba = cuentDeaAhorro.Retirar(64000);
            Assert.AreEqual(2, prueba, "Prueba: 3, su monto total es de 376000 y el monto a retirar sera de $59000");
            Console.WriteLine("su monto total es de $"+cuentDeaAhorro.MontoCuenta+"" +
                " y el monto a retirar sera de $"+cuentDeaAhorro.TotalRetiro);
        }


        //2.4
        /* Escenario: Retiro de cuenta de ahorro Incorrecta
         *  HU Como usuario quiero que al realizar un retiro de mi cuenta de ahorro me reste un porcentaje
             * *Criterio de acceptacion**
         *  2.2 El saldo mínimo de la cuenta deberá ser de 20 mil pesos.
         *  2.4 Del cuarto retiro en adelante del mes tendrán un valor de 5 mil pesos.
         *  
         *  Dado: el cliente al momento de consignar tiene un monto en su cuenta de $440000 y
         *  desea realizar un retiro de por cuarta vez.
         *
         * Cuando: su retiro sea $64000 pesos
         * 
         * Entonces: El sistema debera avisarle al usuario, 
         * "su monto total es de 376000 y el monto a retirar sera de $59000"
         */

    }
}
