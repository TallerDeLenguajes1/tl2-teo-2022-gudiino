using System;
using System.Collections.Generic;

namespace CuentaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cuenta(int tipo)
            Cuenta nuevo= new Cuenta(0);//cuenta corriente pesos ar
            nuevo.insercion(50000);
            nuevo.extraccion(20000,2);
            Cuenta nuevo1= new Cuenta(1);//cuenta corriente pesos usd
            nuevo1.insercion(200);
            nuevo1.extraccion(20000,1);
        }
    }
}