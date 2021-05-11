using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Classe
{
    class ContaEmpresa : Conta //Conta empresa tem alguns beneficios
    {
        public ContaEmpresa()
        {
        }

        public ContaEmpresa(int numeroDaConta, string nome, double saldo) : base(numeroDaConta, nome, saldo)
        {
        }


        public override void RealizarEmprestimo() //A empresa pode realizar um emprestimo,se tiver mais de 10mil no sistema, o limete é de 70% do valor da sua conta e + 9% de juros
        {
            if (Saldo <= 10000)
            {
                Console.WriteLine($"Saldo insuficiente!\nVocê precisa ter um valor acima de 10.000\nSaldo atual: R${Saldo}");
                return;
            }



            Emprestimo = Saldo * 0.50; //Valor do emprestimo
            Saldo += Emprestimo; //Emprestimo Realizado
            Emprestimo += Emprestimo * 0.9;  //Juros de 9% sobre o valor

       

            Console.WriteLine("Emprestimo Realizado com sucesso");
        }

        public override bool Sacar(double valorDeSaque) //Empresa não paga por saldo e nem transferencia
        {
            if (valorDeSaque > Saldo)
            {
                Console.Write($"Não é possível sacar o dinheiro.\nSaldo insuficiente!\nSaldo: R${Saldo}");

                return false;
            }

            Saldo -= valorDeSaque;

            Console.WriteLine($"Saldo atual: R${Saldo.ToString("F2")}");

            return true;
        }

        public override string ToString()
        {
            return $"\n\n:::Conta Empresa:::\nNome da empresa: {Nome}\nNúmero da Conta: {NumeroDaConta}\nSaldo: {Saldo.ToString("F2")}\nEmprestimo em aberto:R${Emprestimo} ";
        }
    }
}
