using System;
using System.Collections.Generic;

namespace ControleContas
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fecharPrograma = true;
            String num;
            List<Cliente> cadastrarClientes = new List<Cliente>();
            List<Conta> cadastrarContas = new List<Conta>();
            try
            {
                do
                {
                    Console.WriteLine("Informe a ação a ser realizada: ");
                    Console.WriteLine("[1] Cadastrar Cliente");
                    Console.WriteLine("[2] Criar Conta");
                    Console.WriteLine("[3] Listar Clientes");
                    Console.WriteLine("[4] Listar Contas");
                    Console.WriteLine("[5] Sacar");
                    Console.WriteLine("[6] Depositar");
                    Console.WriteLine("[7] Transferir");
                    Console.WriteLine("[8] Saldo Geral");
                    Console.WriteLine("[0] Encerrar aplicação\n");
                    num = Console.ReadLine();

                    if(num.Equals("1"))
                    {
                        Console.WriteLine("\n-Cadastrar Cliente-\n");

                        Console.WriteLine("\nQual é o seu nome?");
                        string nome = Console.ReadLine();

                        Console.WriteLine("\nEm que ano você nasceu?");
                        string anoNascimento = Console.ReadLine();

                        Console.WriteLine("\nQual é o seu email?");
                        string email = Console.ReadLine();

                        Console.WriteLine("\nQual é o seu cpf?");
                        string cpf = Console.ReadLine();

                        Cliente cadastro = new Cliente(nome, Convert.ToInt32(anoNascimento), email ,cpf);

                        cadastrarClientes.Add(cadastro);

                        Console.WriteLine("\n-----------------------------------------");
                        Console.WriteLine("Informações Cadastradas:\n " +
                        "\nNome: {0} \nNascimento: {1} \nEmail: {2} \nCPF: {3}", nome.ToUpper(), anoNascimento, email, cpf);
                        Console.WriteLine("-----------------------------------------");

                        Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                        string exit = Console.ReadLine();
                        
                        if (exit.ToLower() == "ok")
                            Console.Clear();   
                    }
                    else if (num.Equals("2"))
                    {
                        
                        Console.WriteLine("\n-Criar Conta-\n");

                        Console.WriteLine("\nQual o nome do Titular:");
                        string titular = Console.ReadLine();

                        Console.WriteLine("\nQual o número do CPF cadastrado:");
                        string cpf = Console.ReadLine();

                        Cliente procurarCliente = cadastrarClientes.Find(c => c.Cpf.Contains(cpf) && c.Nome.ToLower() == titular);

                        if(procurarCliente == null)
                        {
                            Console.WriteLine("\n\n-ERRO: Cliente não encontrado!-");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Conta conta = new Conta(-999, procurarCliente, cpf);

                            cadastrarContas.Add(conta);

                            Console.WriteLine("\n-----------------------------------------");
                            Console.WriteLine("Informações Cadastradas:\n " +
                            "\nNome do Titular: {0} \nCPF: {1} \nNúmero da Conta: {2}", titular.ToUpper(), cpf, conta.Numero);
                            Console.WriteLine("-----------------------------------------");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();

                            if (exit.ToLower() == "ok")
                                Console.Clear();

                        }
                    }
                    else if (num.Equals("3"))
                    {

                        Console.WriteLine("\n-Listar Clientes-\n");

                        foreach (Cliente cadastro in cadastrarClientes)
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Informações:\n  " +
                                "\nNome: {0} \nNascimento: {1} \nEmail: {2} \nCPF: {3}", 
                                cadastro.Nome.ToUpper(), cadastro.AnoNascimento, cadastro.Email, cadastro.Cpf);
                            Console.WriteLine("-----------------------------------------");
                        }

                        Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                        string exit = Console.ReadLine();

                        if (exit.ToLower() == "ok")
                            Console.Clear();

                    }
                    else if (num.Equals("4"))
                    {
                        Console.WriteLine("\n-Listar Contas-\n");

                        foreach (Conta conta in cadastrarContas)
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Informações:\n " +
                                "\nNome do Titular: {0} \nCPF: {1} \nConta: {2}",
                                conta.Titular.Nome.ToUpper(), conta.Cpf, conta.Numero
                                );
                            Console.WriteLine("-----------------------------------------");
                        }

                        Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                        string exit = Console.ReadLine();

                        if (exit.ToLower() == "ok")
                            Console.Clear();

                    }
                    else if (num.Equals("5"))
                    {
                        Console.WriteLine("\n-Sacar-\n");

                        Console.WriteLine("\nQual o número da Conta:");
                        string contaTitular = Console.ReadLine();

                        Console.WriteLine("\nQual o número do CPF cadastrado:");
                        string cpf = Console.ReadLine();

                        Console.WriteLine("\nQual o valor que deseja sacar: ");
                        string sacar = Console.ReadLine();

                        Conta procurarConta = cadastrarContas.Find(c => c.Numero == Convert.ToInt32(contaTitular) && c.Cpf.Contains(cpf));
                        if (procurarConta == null)
                        {
                            Console.WriteLine("\n\n-ERRO: Não existe essa conta!-");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }
                        else
                        {
                            procurarConta.Sacar(Convert.ToInt32(sacar));

                            Console.WriteLine("\n-----------------------------------------");
                            Console.WriteLine("Informações:\n " +
                            "\nNome do Titular: {0} \nCPF: {1} \nNúmero da Conta: {2} \nSaldo: {3}",
                            procurarConta.Titular.Nome.ToUpper(), cpf, procurarConta.Numero, procurarConta.Saldo);
                            Console.WriteLine("-----------------------------------------");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }


                    }
                    else if (num.Equals("6"))
                    {
                        Console.WriteLine("\n-Depositar-\n");

                        Console.WriteLine("\nQual o número da Conta:");
                        string contaTitular = Console.ReadLine();

                        Console.WriteLine("\nQual o número do CPF cadastrado:");
                        string cpf = Console.ReadLine();

                        Console.WriteLine("\nQual o valor que deseja depositar: ");
                        string depositar = Console.ReadLine();

                        Conta procurarConta = cadastrarContas.Find(c => c.Numero == Convert.ToInt32(contaTitular) && c.Cpf.Contains(cpf));
                        if (procurarConta == null)
                        {
                            Console.WriteLine("\n\n-ERRO: Não existe essa conta!-");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }
                        else
                        {
                            procurarConta.Depositar(Convert.ToInt32(depositar));

                            Console.WriteLine("\n-----------------------------------------");
                            Console.WriteLine("Informações:\n " +
                            "\nNome do Titular: {0} \nCPF: {1} \nNúmero da Conta: {2} \nSaldo Atual: {3}", 
                            procurarConta.Titular.Nome.ToUpper() ,cpf, procurarConta.Numero, procurarConta.Saldo);
                            Console.WriteLine("-----------------------------------------");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }
                    }
                    else if (num.Equals("7"))
                    {
                        Console.WriteLine("\n-Transferir-\n");

                        Console.WriteLine("\nQual o número da Conta:");
                        string contaTitular = Console.ReadLine();

                        Console.WriteLine("\nQual o número do CPF cadastrado:");
                        string cpf = Console.ReadLine();

                        Console.WriteLine("\nQual o valor que deseja transferir: ");
                        string transferir = Console.ReadLine();

                        Console.WriteLine("\nConta para ocorrer a tranferência:");
                        string contaTranferencia = Console.ReadLine();

                        Conta procurarConta = cadastrarContas.Find(c => c.Numero == Convert.ToInt32(contaTitular) && c.Cpf.Contains(cpf));
                        Conta procurarContaTranferir = cadastrarContas.Find(c => c.Numero == Convert.ToInt32(contaTranferencia));
                        if (procurarConta == null)
                        {
                            Console.WriteLine("\n\n-ERRO: Não existe essa conta!-");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }
                        else
                        {
                            procurarConta.Tranferir(procurarContaTranferir, Convert.ToInt32(transferir));

                            Console.WriteLine("\n-----------------------------------------");
                            Console.WriteLine("Informações:\n " +
                            "\nNome do Titular: {0} \nCPF: {1} \nNúmero da Conta: {2} \nSaldo Atual: {3} \n\nNome do Remetente: {4} \nSaldo Atual: {5}",
                            procurarConta.Titular.Nome.ToUpper(), cpf, procurarConta.Numero, procurarConta.Saldo, procurarContaTranferir.Titular.Nome.ToUpper(), procurarContaTranferir.Saldo);
                            Console.WriteLine("-----------------------------------------");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }
                    }
                    else if (num.Equals("8"))
                    {
                        Console.WriteLine("\n-Saldo Geral-\n");

                        Console.WriteLine("\nQual o número da Conta:");
                        string contaTitular = Console.ReadLine();

                        Console.WriteLine("\nQual o número do CPF cadastrado:");
                        string cpf = Console.ReadLine();

                        Conta procurarConta = cadastrarContas.Find(c => c.Numero == Convert.ToInt32(contaTitular) && c.Cpf.Contains(cpf));

                        if (procurarConta == null)
                        {
                            Console.WriteLine("\n\n-ERRO: Não existe essa conta!-");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }
                        else
                        {
                          
                            Console.WriteLine("\n-----------------------------------------");
                            Console.WriteLine("Informações:\n " +
                            "\nNome do Titular: {0} \nNascimento: {1} \nEmail: {2} \nCPF: {3} \nNúmero da Conta: {4} \nSaldo Atual: {5}",
                            procurarConta.Titular.Nome.ToUpper(), procurarConta.Titular.AnoNascimento, procurarConta.Titular.Email, cpf, procurarConta.Numero, procurarConta.Saldo);
                            Console.WriteLine("-----------------------------------------");

                            Console.WriteLine("\n\nDigite **OK** para voltar para o menu");
                            string exit = Console.ReadLine();
                            if (exit.ToLower() == "ok")
                            {
                                Console.Clear();
                            }
                        }

                    }
                    else if (num.Equals("0"))
                    {
                        Console.WriteLine("\nSaindo\n");
                        fecharPrograma = false;
                    }
                } while (fecharPrograma);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
