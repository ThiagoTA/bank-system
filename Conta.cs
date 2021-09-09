using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    class Conta
    {
        public long Numero { get; private set; }

        public decimal Saldo { get; private set; }

        public Cliente Titular { get; set; }

        public string Cpf { get; private set; }

        public Conta(long numero, Cliente titular, string cpf)
        {
            if(numero == -999)
            {
                Random randomNumber = new Random();

                numero = randomNumber.Next(10000, 100000);
            }
           
            Numero = numero;
            Titular = titular;
            Cpf = cpf;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
 
        }

        public bool Sacar(decimal valor)
        {
            if ((Saldo - valor - 0.1m) < 0)
            {
                return false;
            }

            Saldo -= (valor + 0.1m);
            return true;
        }

        public bool Tranferir(Conta destino, decimal valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                return true;
            }
            return false;
        }
    }
}
