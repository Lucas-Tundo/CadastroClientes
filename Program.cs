using System;
using System.Collections.Generic;

namespace CadastroClientes {
    class Program {
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args) {

            //Variavel para executar ou parar o programa
            bool Executando = true;

            while (Executando) {
                Console.WriteLine("Selecione:");
                Console.WriteLine("1 (Adicionar)");
                Console.WriteLine("2 (Ver)");
                Console.WriteLine("3 (Editar)");
                Console.WriteLine("4 (Deletar)");
                Console.WriteLine("5 (Sair)");

                //Assim que o usuario inserir algum numero essa função vai ler e armazenar
                int op = int.Parse(Console.ReadLine());

                switch (op) {
                    case 1:
                        Console.WriteLine("Você selecionou a opção adicionar cliente");
                        AdicionarCliente();
                        break;
                    case 2:
                        Console.WriteLine("Você selecionou a opção ver clientes");
                        VerClientes();
                        break;
                    case 3:
                        Console.WriteLine("Você selecionou a opção editar cliente");
                        EditarCliente();
                        break;
                    case 4:
                        Console.WriteLine("Você selecionou a opção deletar cliente");
                        DeletarCliente();
                        break;
                    case 5:
                        //O programa volta ao inicio
                        Executando = false;
                        break;
                    default:
                        Console.WriteLine("Selecione uma opção correta por favor!");
                        Console.WriteLine("--------------------------------------");
                        break;

                }
            }
        }

        //Adicionando a estrutura da parte de adicionar clientes
        static void AdicionarCliente() {
            Console.WriteLine("Digite o nome do cliente:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o e-mail do cliente:");
            string email = Console.ReadLine();

            //Adicionar nova instancia a estrutura
            Cliente cliente = new Cliente(nome, email);
            clientes.Add(cliente);

            Console.WriteLine("Cliente adicionado com sucesso!");
            Console.WriteLine("-------------------------------");
        }

        //Adicionando a estrutura de Visualizar os clientes
        static void VerClientes() {

            //Função de mostrar a variavel na tela
            foreach (Cliente cliente in clientes) {
                Console.WriteLine("Nome: " + cliente.Nome);
                Console.WriteLine("E-mail: " + cliente.Email);
                Console.WriteLine("--------------------------------------");
            }
        }

        //Adicionando a estrutura de Editar o cliente
        static void EditarCliente() {
            Console.WriteLine("Qual o nome do cliente que deseja editar:");
            string nome = Console.ReadLine();

            //Localizar na estrutura
            Cliente cliente = clientes.Find(c => c.Nome == nome);

            //Se caso o nome do cliente for diferente de vazio
            if (cliente != null) {
                Console.WriteLine("Digite o novo nome:");
                string novoNome = Console.ReadLine();

                Console.WriteLine("Digite o novo e-mail:");
                string novoEmail = Console.ReadLine();

                //Validando
                cliente.Nome = novoNome;
                cliente.Email = novoEmail;

                Console.WriteLine("Cliente alterado com sucesso!");
                Console.WriteLine("-----------------------------");
            } else {
                Console.WriteLine("Cliente não encontrado!");
                Console.WriteLine("-----------------------");
            }
        }

        //Adicionando a estrutura de Excluir
        static void DeletarCliente() {
            Console.WriteLine("Digite o nome de quem deseja deletar:");
            string nome = Console.ReadLine();

            //Localizar na estrutura
            Cliente cliente = clientes.Find(c => c.Nome == nome);

            if (cliente != null) {
                Console.WriteLine("Tem certeza?");
                Console.WriteLine("1- Sim");
                Console.WriteLine("2- Não");
                Console.WriteLine("***Esse processo é irreverssivel***");
                Console.WriteLine("-----------------------------------");

                bool finalizar = true;

                while (finalizar) {

                    int resp = int.Parse(Console.ReadLine());

                    switch (resp) {
                        case 1:
                            clientes.Remove(cliente);
                            Console.WriteLine("Cliente deletado com sucesso!");
                            Console.WriteLine("-----------------------------");
                            finalizar = false;
                            break;
                        case 2:
                            finalizar = false;
                            break;
                        default:
                            Console.WriteLine("Opção invalida!");
                            Console.WriteLine("Selecione outra por favor");
                            Console.WriteLine("-------------------------");
                            break;
                    }
                }

            } else {
                Console.WriteLine("Cliente não encontrado!");
                Console.WriteLine("-----------------------");
            }
        }
    }
    //Criando a classe Cliente
    class Cliente {

        //Setando o email e nome
        public string Nome { get; set; }
        public string Email { get; set; }

        public Cliente(string nome, string email) {
            Nome = nome;
            Email = email;
        }
    }
}