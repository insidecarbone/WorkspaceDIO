using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<ContaBancaria> listaContasBancarias = new List<ContaBancaria>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        NovaConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da Conta Origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da Conta Destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferir = double.Parse(Console.ReadLine());

            listaContasBancarias[indiceOrigem].Transferencia(listaContasBancarias[indiceDestino], valorTransferir);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da Conta Bancaria: ");
            int indiceContaBancaria = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDepositado = double.Parse(Console.ReadLine());

            listaContasBancarias[indiceContaBancaria].Depositar(valorDepositado);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da Conta Bancária: ");
            int indiceContaBancaria = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContasBancarias[indiceContaBancaria].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Conta Bancária");

            if (listaContasBancarias.Count ==0){
                Console.WriteLine("Nenhuma Conta Bancária cadastrada!");
                return;
            }

            for (int i = 0; i < listaContasBancarias.Count; i++)
            {
                ContaBancaria contaBancaria = listaContasBancarias[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(contaBancaria);
            }
        }

        private static void NovaConta()
        {
            Console.WriteLine("Cadastrando Nova Conta Bancária");

            Console.WriteLine("Digite 1 para PF e 2 para PJ: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo inicial da Conta bancária: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito da Conta Bancária");
            double entradaCredito = double.Parse(Console.ReadLine());

            ContaBancaria novaContaBancaria = new ContaBancaria(tipoConta: (TipoConta)entradaTipoConta,
                                                                saldo: entradaSaldo,
                                                                credito: entradaCredito,
                                                                nome: entradaNome);

            listaContasBancarias.Add(novaContaBancaria);        
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Nova Conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
