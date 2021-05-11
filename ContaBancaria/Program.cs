using ContaBancaria.Classe;
using System;
using System.Collections.Generic;
using ContaBancaria.Enums;

namespace ContaBancaria
{
    class Program
    {

        static List<Conta> listaDeContas = new List<Conta>();
        public static int TelaInicial()
        {
            Console.WriteLine("::::::::Banco Digital DIO::::::::");

            Console.WriteLine("\nInforme a opção desejada: ");
            Console.WriteLine("1-Criar Conta\n2-Listar Contas\n3-Sacar\n4-Depositar\n5-Trasnferir\n6-Emprestimo\n7-Deletar uma Conta\n8-Sair");
            int escolhaDoUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return escolhaDoUsuario;
        }

        private static void CriarConta()
        {
            try
            {
                Console.WriteLine("\n:::::::Criar conta:::::::");

                Console.Write("\nInforme o número da Conta: ");
                int numeroDaConta = int.Parse(Console.ReadLine());

                Console.Write("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
                int tipoConta = int.Parse(Console.ReadLine());

                if (tipoConta != 1 && tipoConta != 2)
                {
                    Console.Write("Erro ao cadastrar conta!\nEssa tipo de conta não existe");
                    CriarConta();
                }
                else
                {
                    if (tipoConta == 1)
                    {
                        Console.Write("Nome do cliente: ");
                        string nome = Console.ReadLine();
                        Console.Write("Saldo inicial:R$");
                        double saldoInicial = double.Parse(Console.ReadLine());
                        listaDeContas.Add(new Conta(numeroDaConta, nome, saldoInicial));
                        Console.Write("\nConta criada com sucesso!");
                    }
                    else
                    {
                        Console.Write("Nome da Empresa: ");
                        string nome = Console.ReadLine();
                        Console.Write("Saldo inicial:R$");
                        double saldoInicial = double.Parse(Console.ReadLine());
                        listaDeContas.Add(new ContaEmpresa(numeroDaConta, nome, saldoInicial));
                        Console.Write("\nConta criada com sucesso!");
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }

        private static void ListarConta()
        {
            Console.WriteLine("::::::::::Lista das Contas::::::::::");

            foreach (var item in listaDeContas)
                Console.WriteLine(item);
        }


        private static void Sacar()
        {
            try
            {
                Console.WriteLine("\n:::::::Saque:::::::");

                Console.Write("\nInforme o número da conta: ");
                int numeroDaConta = int.Parse(Console.ReadLine());

                if (listaDeContas[numeroDaConta] != null)
                {
                    Console.Write("Valor do saque:R$");
                    double saque = double.Parse(Console.ReadLine());
                    listaDeContas[numeroDaConta].Sacar(saque);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }

        private static void Depositar()
        {
            try
            {
                Console.WriteLine("\n:::::::Deposito:::::::");

                Console.Write("\nInforme o número da conta: ");
                int numeroDaConta = int.Parse(Console.ReadLine());

                if (listaDeContas[numeroDaConta] != null)
                {
                    Console.Write("Valor do deposito: R$");
                    double saque = double.Parse(Console.ReadLine());
                    listaDeContas[numeroDaConta].Depositar(saque);

                    Console.WriteLine($"Deposito realizado com sucesso!\n{listaDeContas[numeroDaConta]}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }

        private static void Trasnferir()
        {
            try
            {
                Console.WriteLine("\n:::::::Transferência:::::::");

                Console.Write("\nInforme o número da conta que ira realizar a transferência: ");
                int numeroDaConta = int.Parse(Console.ReadLine());
                Console.Write("Informe o número da conta destino:");
                int contaDestino = int.Parse(Console.ReadLine());

                if (listaDeContas[numeroDaConta] != null && listaDeContas[contaDestino] != null)
                {
                    Console.Write("Valor da transferência: R$");
                    double valorTrasnferencia = double.Parse(Console.ReadLine());
                    listaDeContas[numeroDaConta].Trasnferir(valorTrasnferencia, listaDeContas[contaDestino]);
                }

                else
                    Console.WriteLine("\nErro na transferência!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }


        private static void Emprestimo()
        {
            try
            {
                Console.WriteLine("\n:::::::Emprestimo:::::::");

                Console.Write("\nInforme o número da conta: ");
                int numeroDaConta = int.Parse(Console.ReadLine());

                if (listaDeContas[numeroDaConta] != null)
                    listaDeContas[numeroDaConta].RealizarEmprestimo();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }


        private static void DeletarConta()
        {
            try
            {

                Console.WriteLine("\n:::::::Deletar conta:::::::");

                Console.Write("\nInforme o número da conta a ser deletada: ");
                int numeroConta = int.Parse(Console.ReadLine());

                if (listaDeContas[numeroConta] != null)
                {
                    Console.WriteLine("Dados da conta:");

                    Console.WriteLine(listaDeContas[numeroConta].ToString());

                    Console.Write("1-Deletar Conta\n2-Voltar");
                    int escolha = int.Parse(Console.ReadLine());

                    if (escolha == 1)
                        listaDeContas.Remove(listaDeContas[numeroConta]);

                    Console.WriteLine("Conta deletada!");
                }

                else
                    Console.Write("Erro ao deletar, conta não encontrada.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro!\n{e.Message}");
            }
        }

        static void Main(string[] args)
        {
            int escolhaDoUsuario = TelaInicial();

            while (escolhaDoUsuario < 7)
            {
                switch (escolhaDoUsuario)
                {
                    case 1:
                        CriarConta();
                        break;
                    case 2:
                        ListarConta();
                        break;
                    case 3:
                        Sacar();
                        break;
                    case 4:
                        Depositar();
                        break;
                    case 5:
                       Trasnferir();
                        break;
                    case 6:
                        Emprestimo();
                        break;
                    case 7:
                        DeletarConta();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine("\n\n::::::::Enter para continuar::::::::");
                Console.ReadKey();
                Console.Clear();
                escolhaDoUsuario = TelaInicial();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
    }
}
