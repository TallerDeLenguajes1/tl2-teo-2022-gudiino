using System;
namespace CuentaBancaria
{
    public class Cuenta
    {
        private float saldo {get; set;}
        public enum Cuentas{CCAR, CCUSD, CAAR}
        private int tipo_cuenta {get; set;}
        public enum TipoExtraccion{CajeroHumano=1, CajeroAutomatico=2}
        private float saldoMin; 
        public Cuenta(int tipo){
            saldo=0;
            tipo_cuenta=tipo;
            switch (tipo)
            {
                case 0://ccar
                    saldoMin=-5000;
                    break;
                case 1:
                case 2://ccusd y caar
                    saldoMin=0;
                    break;
            }
        }
        public void insercion(int monto){
            saldo+=monto;
        }
        public bool tiene_saldo(float monto){
            return (saldo-monto)>saldoMin;
        }
        public void extraccion(float monto, int tipo_extraccion){
            if(tipo_extraccion==1){//cajero humano
                cajero_humano(monto);
            }
            if(tipo_extraccion==2){//cajero automatico
                cajero_automatico(monto);
            }
        }
        public void cajero_humano(float monto){
            if(tiene_saldo(monto)){
                saldo=saldo-monto;
                Console.WriteLine("Retiro Exitoso.");
            }else{
                Console.WriteLine("DENEGADO: No tiene fondo suficiene");
                Console.WriteLine("Saldo actual: ${0}",saldo);
            }
        }
        public void cajero_automatico(float monto){
            switch (tipo_cuenta)
            {
                case 0://cuenta corriente peso
                    retiroCajero(monto, 20000);
                    break;
                case 1://cuenta corriente dolar
                    retiroCajero(monto,200);
                    break;
                case 2://caja de ahorro
                    retiroCajero(monto,10000);
                    break;
            }
        }
        public void retiroCajero(float monto, float limite){
            if(tiene_saldo(monto)){
                if(monto<=limite){
                    saldo=saldo-monto;
                    Console.WriteLine("Extraccion Exitosa.");
                }else{
                    Console.WriteLine("DENEGADO: solo puede extraer un valor menor o igual a $10000");
                    Console.WriteLine("Saldo actual: ${0}",saldo);
                }
                
            }else{
                Console.WriteLine("DENEGADO: No tiene fondo suficiene");
                Console.WriteLine("Saldo actual: ${0}",saldo);
            }
        }
    }
}
    
    
   
        