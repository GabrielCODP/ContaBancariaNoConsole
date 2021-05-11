using ContaBancaria.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Classe
{
    class Conta
    {
        public int NumeroDaConta { get; protected set; }
        public string Nome { get; protected set; }
        public double Saldo { get; protected set; }
        public double Emprestimo { get; protected set; }


        public Conta() { }

        public Conta(int numeroDaConta, string nome, double saldo)
        {
            NumeroDaConta = numeroDaConta;
            Nome = nome;
            Saldo = saldo;
        }

        public virtual bool Sacar(double valorDeSaque) //Uma pessoa paga uma taxa de 10 reais, por saque
        {
            if (valorDeSaque+10 > Saldo)
            {
                Console.Write($"Não é possível sacar o dinheiro.\nSaldo insuficiente!\nSaldo: R${Saldo}");

                return false;
            }

            Saldo -= valorDeSaque + 10;

            Console.WriteLine($"Saldo atual: R${Saldo.ToString("F2")}");

            return true;
        }

        public void Depositar(double deposito)
        {
            Saldo += deposito;
     
        }

        public void Trasnferir(double trasnferencia, Conta destino)
        {
            if (Sacar(trasnferencia))
            {
                destino.Depositar(trasnferencia);
            }
        }

        public virtual void RealizarEmprestimo() //Uma pessoa pode realizar emprestimo, ela precisa ter um saldo acima de 100 reias.
        {
            if (Saldo <= 100)
            {
                Console.WriteLine($"Saldo insuficiente!\nVocê precisa ter um valor acima de 100\nSaldo atual: R${Saldo}");
                return;
            }


            Emprestimo = Saldo * 0.50; //Valor do emprestimo
            Saldo += Emprestimo; //Emprestimo Realizado
            Emprestimo += Emprestimo * 0.12;  //Juros de 12% sobre o valor

            Console.WriteLine("Emprestimo Realizado com sucesso");
        }


        public virtual void PagarEmprestimo(double valor)
        {
            if (Emprestimo == 0)
            {
                Console.WriteLine("Não a nenhum valor pendente");
                return;
            }

            Emprestimo -= valor;

            Console.WriteLine("Pagamento realizado com sucesso!");
        }



        public override string ToString()
        {
            return $"\n\n:::Conta Simples:::\nNome: {Nome}\nNúmero da Conta: {NumeroDaConta}\nSaldo:R${Saldo.ToString("F2")}\nEmprestimo em aberto:R${Emprestimo.ToString("F2")} ";
        }
    }
}
