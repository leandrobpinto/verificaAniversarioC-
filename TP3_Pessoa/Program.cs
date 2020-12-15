using PessoaLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Pessoa
{
    class Program
    {
        static void Main(string[] args)
        {
            ListPessoa listP = new ListPessoa();

            int opcao = 0;
            int confirmaDados = 0;
            string nomeTxt = "AT.txt";
            string path = $@"..\..\..\{nomeTxt}";

            listP.AbreTxt(listP, path);

            do
            {

                Console.WriteLine("\n1-Adicionar Pessoa");
                Console.WriteLine("2-Pesquisar Pessoa");
                Console.WriteLine("3-Sair");
                Console.Write("Escolha uma das opções acima: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Pessoa pessoa = new Pessoa();
                        DateTime data;

                        Console.Write("\nDigite o seu nome: ");
                        pessoa.Nome = Console.ReadLine();

                        Console.Write("digite seu sobrenome: ");
                        pessoa.SobreNome = Console.ReadLine();

                        do
                        {
                            Console.Write("Digite sua data de aniversário no formato dd/MM/yyyy: ");

                        } while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out data));
                        pessoa.DataAniversario = data;

                        Console.WriteLine("\nOs dados abaixo estao corretos?");
                        Console.WriteLine(pessoa.ToString());
                        Console.WriteLine("\n1-Sim\n2-Não\n");
                        confirmaDados = Convert.ToInt32(Console.ReadLine());
                        if (confirmaDados == 1)
                        {
                            listP.CriaPessoa(pessoa);
                        }
                        else
                        {
                            Console.WriteLine("faça o cadastro novamente\n");
                        }
                        break;
                    case 2:
                        string nomePessoa;
                        int escolhePessoa;
                        if (listP.pessoas.Count() == 0)
                        {
                            Console.WriteLine("\nCadastre alguem antes de usar esta opção");
                            break;
                        }
                        Console.Write("\nDigite o nome da pessoa que deseja pesquisar: ");
                        nomePessoa = Console.ReadLine();
                        listP.BuscaPessoa(nomePessoa);
                        if (!listP.existePessoa)
                        {
                            Console.Write("\nEscolha uma das pessoas para mais informações:\n");
                            escolhePessoa = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEscolha uma das opções abaixo:" +
                                "\n1- Editar" +
                                "\n2- Excluir" +
                                "\n3- Detalhar");
                            int escolhaOpcoes = Convert.ToInt32(Console.ReadLine());
                            switch (escolhaOpcoes)
                            {
                                case 1:
                                    DateTime NovaDataEditada;
                                    do
                                    {
                                        Console.WriteLine($"\ndigite a nova data da pessoa escolhida no formato dd/MM/yyyy");
                                    } while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out NovaDataEditada));
                                    listP.pessoas[escolhePessoa].DataAniversario = NovaDataEditada;
                                    break;

                                case 2:
                                    listP.pessoas.Remove(listP.pessoas[escolhePessoa]);
                                    break;
                                case 3:
                                    Console.WriteLine($"{listP.pessoas[escolhePessoa].ToString()}");
                                    Console.WriteLine(Pessoa.CalculaProximoAniversario(listP, escolhePessoa));
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não existe uma pessoa com este nome");
                            break;
                        }
                        break;
                    case 3:
                        listP.SalvaTxt(path);
                        break;
                }
            } while (opcao != 3);
        }

       

    }
}

