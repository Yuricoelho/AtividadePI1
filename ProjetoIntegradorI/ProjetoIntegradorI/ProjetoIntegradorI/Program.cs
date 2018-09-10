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
            bool success = false;
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
            //FUNÇÃO ADMINISTRATIVO.
            if (menu == 1)
            {
                menuAdm();
                return true;
            }

            //MENU ELEITOR.
            if (menu == 2)
            {
                
                return true;
            }
            return true;
        }

        static private void menuAdm()
        {
            bool success = false;
            bool admSair = false;
            int menuAdm = 1;

            while (!admSair)
            {
                Console.Clear();
                Console.WriteLine("Selecione a opção abaixo: ");
                Console.WriteLine("1 - Cadastrar candidato");
                Console.WriteLine("0 - Sair");

                //Lê valores para o menu adm
                success = false;
                while (!success)
                {
                    string scanf = Console.ReadLine();
                    //Verifica se input é válido como inteiro
                    if (!int.TryParse(scanf, out menuAdm))
                    {
                        Console.WriteLine("Input Inválido!");
                        success = false;
                    }
                    else
                    {
                        success = true;
                    }
                }
                switch (menuAdm)
                {
                    //Cadastrar Candidato
                    case 1:
                        cadastrarCandidato();
                        break;

                    //Sair do Administrativo
                    case 0:
                        Console.WriteLine("Saindo...");
                        admSair = true;
                        break;
                    default:
                        Console.WriteLine("Opcao invalida!\nSelecione novamente.");
                        break;
                }
            }
        }

        static private void menuEleitores()
        {
            Arquivo arq = new Arquivo();
            bool success = false;

            string regiao = string.Empty;

            int cpf = 00000000000;
            string CPF = "00000000000";

            int codCandidato = 0;
            int codPartido = 0;

            int codCandidatoRegional = 0;
            int codPartidoRegional = 0;

            int codMunicipio = 0;

            bool eleitoresSair = false;

            int codRegiao = 0;

            //Captura a região de votação
            success = false;
            while (!success)
            {
                Console.WriteLine("REGIÃO SUL");
                Console.WriteLine("Acessar votação de qual estado?");
                Console.WriteLine("1 - Paraná");
                Console.WriteLine("2 - Santa Catarina");
                Console.WriteLine("3 - Rio Grande do Sul");
                string scanf = Console.ReadLine();

                //verifica se o input é válido como inteiro
                if (!int.TryParse(scanf, out codRegiao))
                {
                    Console.WriteLine("Input inválido!");
                    success = false;
                }
                else
                {
                    //atribui o nome da região conforme selecionado
                    switch (codRegiao)
                    {
                        case 1:
                            regiao = "PR";
                            success = true;
                            break;
                        case 2:
                            regiao = "SC";
                            success = true;
                            break;
                        case 3:
                            regiao = "RS";
                            success = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida!\nTente novamente.");
                            success = false;
                            break;
                    }
                }

            }

            //Captura município
            //IMPLEMENTAR
            
            //menu de votação dos eleitores
            while (!eleitoresSair)
            {
                Console.Clear();
                Console.WriteLine("VOTAÇÃO DO ESTADO - " + regiao);
                Console.WriteLine("Identificação do Eleitor:");

                //CPF do eleitor
                success = false;
                while (!success)
                {
                    Console.WriteLine("CPF: (sem espaços ou caracteres especiais)");
                    string scanf = Console.ReadLine();

                    //Tamanho obrigatório 11
                    if (scanf.Trim().Length != 11)
                    {
                        Console.WriteLine("CPF INVÁLIDO!");
                        success = false;
                    }
                    else
                    {
                        //Verifica se é compatível com inteiro
                        if (!int.TryParse(scanf.Trim(), out cpf))
                        {
                            success = false;
                            Console.WriteLine("Inválido, entre apenas números");
                        }
                        else
                        {
                            //Confirmação do CPF digitado
                            Console.WriteLine("CPF digitado: " + cpf.ToString().Trim());
                            Console.WriteLine("Confirma?");
                            Console.WriteLine("S / N");
                            string confirma = Console.ReadLine().Trim().Substring(0,1);
                            if (confirma.Trim() == "s")
                            {
                                confirma = "S";
                            }
                            if (confirma.Trim() == "n")
                            {
                                confirma = "N";
                            }
                            switch (confirma)
                            {
                                case "S":

                                    //Trata pontuação do CPF   
                                    CPF = trataCPF(cpf.ToString().Trim());
                                    success = true;
                                    break;
                                case "N":
                                    success = false;
                                    break;
                                default:
                                    Console.WriteLine("Inválido. Escreva Novamente");
                                    success = false;
                                    break;
                            }
                        }
                    }
                }

                //Voto do candidato federal
                success = false;
                while (!success)
                {
                    Console.WriteLine("Digite o Número do seu candidato federal (Digite 'B' para votar em branco)");
                    string scanf = Console.ReadLine();

                    //verifica se é compatível com inteiros
                    if (!int.TryParse(scanf, out codCandidato))
                    {
                        if (scanf.Length > 1)
                        {
                            Console.WriteLine("Input inválido! Digite apenas números ou a letra 'B' para votar em branco");
                            success = false;
                        }
                        else
                        {
                            //B = VOTO BRANCO
                            if (scanf == "b" || scanf == "B")
                            {
                                Console.WriteLine("Voto em branco");
                                Console.WriteLine("Confirma? S / N");
                                string confirma = Console.ReadLine().Trim().Substring(0, 1);
                                if (confirma == "s")
                                {
                                    confirma = "S";
                                }
                                if (confirma == "n")
                                {
                                    confirma = "n";
                                }
                                switch (confirma)
                                {
                                    case "S":
                                        //Codigo do candidato = 0 || Voto em branco
                                        codCandidato = 0;
                                        success = true;
                                        break;
                                    case "N":
                                        success = false;
                                        break;
                                    default:
                                        Console.WriteLine("Digite novamente");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input inválido! Digite apenas números ou a letra 'B' para votar em branco");
                                success = false;
                            }
                        }
                    }
                    else
                    {
                        string candidatoCompleto = arq.recuperaCandidato(codCandidato);
                        string[] candidato = candidatoCompleto.Split(';');
                        if (candidatoCompleto == string.Empty)
                        {
                            Console.WriteLine("Voto nulo");
                            Console.WriteLine("Confirma?  S / N");
                            string confirma = Console.ReadLine().Substring(0,1);
                            if (confirma == "s")
                            {
                                confirma = "S";
                            }
                            if (confirma == "n")
                            {
                                confirma = "N";
                            }
                            switch (confirma)
                            {
                                case "S":
                                    //Código do candidato = -1 || Voto nulo
                                    codCandidato = -1;
                                    success = true;
                                    break;
                                case "N":
                                    success = false;
                                    break;
                                default:
                                    Console.WriteLine("Inválido! tente novamente");
                                    success = false;
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Candidato federal escolhido: " + candidato[1]);
                            Console.WriteLine("Número do candidato: " + candidato[0]);
                            Console.WriteLine("Código do partido: " + candidato[2]);
                            Console.WriteLine("Confirma?  S / N");
                            string confirma = Console.ReadLine().Trim().Substring(0, 1);
                            if (confirma == "s")
                                confirma = "S";
                            if (confirma == "n")
                                confirma = "N";
                            switch (confirma)
                            {
                                case "S":
                                    codPartido = Convert.ToInt32(candidato[2]);
                                    success = true;
                                    break;
                                case "N":
                                    success = false;
                                    break;
                                default:
                                    Console.WriteLine("Inválido! Digite Novamente");
                                    success = false;
                                    break;
                            }
                        }
                    }
                }

                //Voto do candidato regional
                success = false;
                while (!success)
                {
                    Console.WriteLine("Digite o Número do seu candidato federal (Digite 'B' para votar em branco)");
                    string scanf = Console.ReadLine();

                    //verifica se é compatível com inteiros
                    if (!int.TryParse(scanf, out codCandidatoRegional))
                    {
                        if (scanf.Length > 1)
                        {
                            Console.WriteLine("Input inválido! Digite apenas números ou a letra 'B' para votar em branco");
                            success = false;
                        }
                        else
                        {
                            //B = VOTO BRANCO
                            if (scanf == "b" || scanf == "B")
                            {
                                Console.WriteLine("Voto em branco");
                                Console.WriteLine("Confirma? S / N");
                                string confirma = Console.ReadLine().Trim().Substring(0, 1);
                                if (confirma == "s")
                                {
                                    confirma = "S";
                                }
                                if (confirma == "n")
                                {
                                    confirma = "n";
                                }
                                switch (confirma)
                                {
                                    case "S":
                                        //Codigo do candidato = 0 || Voto em branco
                                        codCandidatoRegional = 0;
                                        success = true;
                                        break;
                                    case "N":
                                        success = false;
                                        break;
                                    default:
                                        Console.WriteLine("Digite novamente");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input inválido! Digite apenas números ou a letra 'B' para votar em branco");
                                success = false;
                            }
                        }
                    }
                    else
                    {
                        string candidatoCompleto = arq.recuperaCandidato(codCandidatoRegional);
                        string[] candidato = candidatoCompleto.Split(';');
                        if (candidatoCompleto == string.Empty)
                        {
                            Console.WriteLine("Voto nulo");
                            Console.WriteLine("Confirma?  S / N");
                            string confirma = Console.ReadLine().Substring(0, 1);
                            if (confirma == "s")
                            {
                                confirma = "S";
                            }
                            if (confirma == "n")
                            {
                                confirma = "N";
                            }
                            switch (confirma)
                            {
                                case "S":
                                    //Código do candidato = -1 || Voto nulo
                                    codCandidatoRegional = -1;
                                    success = true;
                                    break;
                                case "N":
                                    success = false;
                                    break;
                                default:
                                    Console.WriteLine("Inválido! tente novamente");
                                    success = false;
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Candidato federal escolhido: " + candidato[1]);
                            Console.WriteLine("Número do candidato: " + candidato[0]);
                            Console.WriteLine("Código do partido: " + candidato[2]);
                            Console.WriteLine("Confirma?  S / N");
                            string confirma = Console.ReadLine().Trim().Substring(0, 1);
                            if (confirma == "s")
                                confirma = "S";
                            if (confirma == "n")
                                confirma = "N";
                            switch (confirma)
                            {
                                case "S":
                                    codPartidoRegional = Convert.ToInt32(candidato[2]);
                                    success = true;
                                    break;
                                case "N":
                                    success = false;
                                    break;
                                default:
                                    Console.WriteLine("Inválido! Digite Novamente");
                                    success = false;
                                    break;
                            }
                        }
                    }
                }

                arq.escreveVoto(regiao, CPF, codMunicipio, codCandidato, codPartido, codCandidatoRegional, codPartidoRegional);
                Console.Clear();
                Console.WriteLine("Voto concluído com sucesso!");
                Console.WriteLine("Pressione qualquer tecla");

                //A votação deve continuar, então tem uma combinação específica que o adm deve presionar para voltar para o menu
                //para impedir eleitores de tentar navegar pelo menu
                string sair = Console.ReadLine();
                if (sair == "000")
                {
                    eleitoresSair = true;
                }
            }
        }

        //Cadastro de novo candidato
        static private void cadastrarCandidato()
        {
            Arquivo arq = new Arquivo();

            int codCandidato = 0;
            string nomeCandidato = string.Empty;
            int codPartido = 0;
            bool success = false;
            Console.WriteLine("");

            //Código do candidato
            success = false;
            while (!success)
            {
                Console.WriteLine("Código do candidato:");
                string scanf = Console.ReadLine();

                //verifica se input é válido como inteiro
                if (!int.TryParse(scanf, out codCandidato))
                {
                    Console.WriteLine("Input Inválido!");
                    success = false;
                }
                else
                {
                    //Se candidato já existe não permite inserir duplicado
                    if (arq.existeCandidato(codCandidato))
                    {
                        Console.WriteLine("Candidato já cadastrado!");
                        success = false;
                    }
                    else
                    {
                        //Apenas códigos positivos
                        if (codCandidato <= 0)
                        {
                            Console.WriteLine("Favor inserir numero maior que 0.");
                            success = false;
                        }
                        else
                        {
                            success = true;
                        }
                    }
                }
            }

            //Nome do candidato
            success = false;
            while (!success)
            {
                Console.WriteLine("Nome do candidato:");
                string scanf = Console.ReadLine();

                //Impede de inserir nome com apenas uma letra
                if (scanf.Length > 1)
                {
                    nomeCandidato = scanf;
                    success = true;
                }
                else
                {
                    Console.WriteLine("Nome inválido!");
                    success = false;
                }
            }

            //Código do partido
            success = false;
            while (!success)
            {
                Console.WriteLine("Código do partido:");
                string scanf = Console.ReadLine();

                //Verifica se o input é válido como inteiro
                if (!int.TryParse(scanf, out codPartido))
                {
                    Console.WriteLine("Input Inválido");
                    success = false;
                }
                else
                {
                    //Apenas códigos posisitivos
                    if (codPartido <= 0)
                    {
                        Console.WriteLine("Favor inserir valor maior que 0!");
                        success = false;
                    }
                    else
                    {
                        success = true;
                    }
                }
            }

            //Insere o candidato de facto
            arq.escreveCandidato(codCandidato, nomeCandidato, codPartido);
        }

        //Faz tratamento de pontuação do CPF
        static private string trataCPF(string CPF)
        {
            string cpfsub1 = CPF.Substring(0, 2);
            string cpfsub2 = CPF.Substring(3, 5);
            string cpfsub3 = CPF.Substring(6, 8);
            string digito = CPF.Substring(9, 10);
            CPF = cpfsub1 + "." + cpfsub2 + "." + cpfsub3 + "-" + digito;
            return CPF;
        }
    }
}

