using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Auxiliar;

namespace ProjetoIntegradorI
{
    class Program
    {
        static void Main(string[] args)
        {

            bool reset = true;

            while (reset)
            {
                reset = MenuUrna();
            }

            Console.Clear();
            Console.WriteLine("Pressione Qualquer tecla para continuar");
            Console.ReadKey();
        }

        static private bool MenuUrna()
        {
            int menu;
            bool sair = false;
            bool success = false;

            int qtd_presidente;
            int qtd_votantes;
            int FaixaEtaria;
            int NivelFundamental;
            int NivelMedio;
            int NivelSuperior;
            int RacaNegra;
            int RacaBranca;
            int RacaAmarela;
            int voto;



            Console.Clear();
            Console.WriteLine("Bem vindo. Selecione a funcao: ");
            Console.WriteLine("1 - Administrativo");
            Console.WriteLine("2 - Eleitor");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("");
            string scanf = Console.ReadLine();
            if (!int.TryParse(scanf, out menu))
            {
                Console.WriteLine("Input inválido!");
            }

            if (menu != 1 && menu != 2 && menu != 3)
            {
                Console.WriteLine("Opção inválida!\nSelecione novamente.");
            }
            if (menu == 3)
            {
                return false;
            }
            while (!sair)
            {
                //FUNÇÃO ADMINISTRATIVO - INCOMPLETO.
                if (menu == 1)
                {

                    //Lê e atribui valor para a quantidade de candidatos para o cargo de presidente
                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("Quantidade de candidatos para o cargo de prefeito: ");
                        scanf = Console.ReadLine();
                        if (!int.TryParse(scanf, out qtd_presidente))
                        {
                            Console.WriteLine("Input inválido!");
                            success = false;
                        }
                        else
                        {
                            success = true;
                        }
                    }

                    //Lê e atribui valor para a quantidade de eleitores. Função para fins estatísticos.
                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("Quantidade de votantes: ");
                        scanf = Console.ReadLine();
                        if (!int.TryParse(scanf, out qtd_votantes))
                        {
                            Console.WriteLine("Input inválido!");
                            success = false;
                        }
                        else
                        {
                            success = true;
                        }
                    }

                    return true;
                    //Ainda vamos definir quais informações ficam guardadas em arquivos.
                }

                //MENU ELEITOR.
                if (menu == 2)
                {
                    string nome;
                    int idade;
                    int escolaridadeAux = 0;
                    string escolaridade;
                    float renda;

                    Console.WriteLine("Prezado eleitor, favor identifique-se:");

                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Nome:");
                        nome = Console.ReadLine();
                        if (string.IsNullOrEmpty(nome))
                        {
                            Console.WriteLine("Input inválido!");
                            success = false;
                        }
                        else
                        {
                            success = true;
                        }
                    }

                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Idade:");
                        scanf = Console.ReadLine();
                        if (!int.TryParse(scanf, out idade))
                        {
                            Console.WriteLine("Input inválido!");
                            success = false;
                        }
                        else
                        {
                            success = true;
                        }
                    }


                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Escolaridade:");
                        Console.WriteLine("1 - Nivel Fundamental incompleto.");
                        Console.WriteLine("2 - Nivel Fundamental completo.");
                        Console.WriteLine("3 - Nivel Medio incompleto.");
                        Console.WriteLine("4 - Nivel Medio Completo.");
                        Console.WriteLine("5 - Nivel Superior incompleto.");
                        Console.WriteLine("6 - Nivel Superior Completo.");
                        Console.WriteLine("7 - Pos - Graduacao.");
                        Console.WriteLine("");

                        scanf = Console.ReadLine();
                        if (!int.TryParse(scanf, out escolaridadeAux))
                        {
                            success = false;
                        }
                        else
                        {
                            switch (escolaridadeAux)
                            {
                                case 1:
                                    escolaridade = "Nivel Fundamental incompleto";
                                    success = true;
                                    break;
                                case 2:
                                    escolaridade = "Nivel Fundamental completo";
                                    success = true;
                                    break;
                                case 3:
                                    escolaridade = "Nivel Medio incompleto";
                                    success = true;
                                    break;
                                case 4:
                                    escolaridade = "Nivel Medio Completo";
                                    success = true;
                                    break;
                                case 5:
                                    escolaridade = "Nivel Superior incompleto";
                                    success = true;
                                    break;
                                case 6:
                                    escolaridade = "Nivel Superior Completo";
                                    success = true;
                                    break;
                                case 7:
                                    escolaridade = "Pos-Graduacao";
                                    success = true;
                                    break;
                                default:
                                    Console.WriteLine("Opcao invalida!\nSelecione novamente.");
                                    success = false;
                                    break;
                            }
                        }
                    }

                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Renda bruta mensal: (Use virgula caso necessario)");
                        scanf = Console.ReadLine();
                        if (!float.TryParse(scanf, out renda))
                        {
                            Console.WriteLine("Input inválido!");
                            success = false;
                        }
                        else
                        {
                            success = true;
                        }
                    }


                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("Muito obrigado por preencher suas informacoes.");
                    Console.WriteLine("______________________________________________________");

                    success = false;
                    while (!success)
                    {
                        Console.WriteLine("Faca seus votos:");
                        Console.WriteLine("1 - Candidato");
                        Console.WriteLine("2 - Nulo");
                        Console.WriteLine("3 - Branco");
                        scanf = Console.ReadLine();
                        if (!int.TryParse(scanf, out voto))
                        {
                            Console.WriteLine("Input Inválido!");
                            success = false;
                        }
                        else
                        {
                            bool auxiliar = false;
                            char confirma = 'S';
                            switch (voto)
                            {
                                case 1:
                                    auxiliar = votoCandidato(confirma);
                                    break;

                                case 2:
                                    //printf("\nVoto NULO. Confirma?  S/N\n");
                                    //scanf("%c", &confirma);
                                    //switch (confirma)
                                    //{
                                    //    case 'S':
                                    //        auxiliar = 1;
                                    //        break;
                                    //    case 'N':
                                    //        auxiliar = 0;
                                    //        break;
                                    //    default:
                                    //        printf("\nOpcao invalida! Selecione novamente.");
                                    //        auxiliar = 0;
                                    //        break;
                                    //}
                                    //numeroCandidato == -1;
                                    break;
                                case 3:
                                    //printf("\nVoto em branco. Confirma?  S/N\n");
                                    //scanf("%c", &confirma);
                                    //switch (confirma)
                                    //{
                                    //    case 'S':
                                    //        auxiliar = 1;
                                    //        break;
                                    //    case 'N':
                                    //        auxiliar = 0;
                                    //        break;
                                    //    default:
                                    //        printf("\nOpcao invalida! Selecione novamente.");
                                    //        auxiliar = 0;
                                    //        break;
                                    //}
                                    //numeroCandidato == 0;
                                    break;
                                default:
                                    Console.WriteLine("\nOpcao invalida! Selecione novamente.");
                                    break;
                            }
                        }
                    } 
                }
            }
            return true;
        }

        static private bool votoCandidato(char confirma)
        {
            Console.Clear();

            int numeroCandidato = 0;
            bool success = false;
            while (!success)
            {
                Console.WriteLine("Digite o numero do seu candidato:");
                string scanf = Console.ReadLine();
                if (!int.TryParse(scanf, out numeroCandidato))
                {
                    Console.WriteLine("Input Invalido");
                    success = false;
                }
                else
                {
                    success = true;
                }

            }

            success = false;
            while (!success)
            {
                Console.WriteLine("Seu voto: ");
                Console.WriteLine("Candidato: fulano.");
                Console.WriteLine("Numero: {0}", numeroCandidato);

                Console.WriteLine("Confirma?");
                Console.WriteLine("S / N");

                string scanf = Console.ReadLine();
                if (scanf.Length > 1)
                {
                    Console.WriteLine("Input Inválido!");
                    success = false;
                }
                else
                {
                    switch (confirma)
                    {
                        case 'S':
                            success = true;
                            return true;
                        case 'N':
                            success = true;
                            return false;
                        default:
                            success = false;
                            Console.WriteLine("\nOpcao invalida! Selecione novamente.");
                            return false;
                    }
                }

            }
            return true;
        }
    }
}

