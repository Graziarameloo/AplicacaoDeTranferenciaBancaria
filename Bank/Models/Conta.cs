using Bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    internal class Conta
    {
        private TipoConta _tipoConta;
        private string _nome;
        private double _saldo;
        private double _credito;

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            _tipoConta = tipoConta;
            _nome = nome;
            _saldo = saldo;
            _credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if (_saldo - valorSaque < _credito)
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            _saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {Nome} é {_saldo} ");
            //pode der feito também ($"Saldo atual da conta de {0} é {1}, Nome, _saldo

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            _saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {Nome} é {_saldo} ");
        }

        public void Transferir(double valorTranferencia, Conta contaDestino)
        {
            if (Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
        }

       


        public string Nome
        {
            get => _nome.ToUpper();
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O campo NOME deve ser preenchido");
                }
                _nome = value;

            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo Conta: " + _tipoConta + "    ";
            retorno += "Nome: " + _nome + "    ";
            retorno += "Saldo: " + _saldo + "    ";
            retorno += "Crédito: " + _credito + "    ";

            return retorno;

        }

    }
}

