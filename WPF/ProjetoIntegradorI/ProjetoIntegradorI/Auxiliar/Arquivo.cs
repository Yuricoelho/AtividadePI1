using System;
using System.Configuration;
using System.Collections.Specialized;
using ProjetoIntegradorI;
using System.IO;

namespace Auxiliar
{
    public class Arquivo
    {
        //Construtor
        public Arquivo()
        {

        }
        private string headerVotos = "1;regiao;cpf;numero_sequencial_de_voto;codigo_do_municipio;codigo_candidato_federal;codigo_do_partido_federal;codigo_do_candidato_regional;codigo_do_partido_regional";

        //Métodos

        //Grava os dados dos candidatos
        public void escreveCandidato(int codCandidato, string nomeCandidato, int codPartido)
        {
            string nomeArq = "Candidatos.txt";
            string path = ConfigurationManager.AppSettings["CaminhoArquivos"];
            string text = codCandidato.ToString() + ";" + nomeCandidato + ";" + codPartido.ToString();
            string fullPath = path + nomeArq;

            //Se não existe um arquivo ainda, cria. Se não, adiciona o conteúdo ao mesmo.
            if (!File.Exists(fullPath))
            {
                using (StreamWriter file = new StreamWriter(fullPath))
                {
                    file.WriteLine(text);
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter(fullPath, true))
                {
                    file.WriteLine(text);
                }
            }
        }

        //Verifica se determinado candidato existe pelo código dele
        public bool existeCandidato(int codCandidato)
        {
            string nomeArq = "Candidatos.txt";
            string path = ConfigurationManager.AppSettings["CaminhoArquivos"];
            string fullPath = path + nomeArq;
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string l in lines)
            {
                string codigo = l.Split(';')[0];
                if (codigo == codCandidato.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public string recuperaCandidato(int codCandidato)
        {
            string nomeArq = "Candidatos.txt";
            string path = ConfigurationManager.AppSettings["CaminhoArquivos"];
            string fullPath = path + nomeArq;
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string l in lines)
            {
                string codigo = l.Split(';')[0];
                if (codigo == codCandidato.ToString())
                {
                    return l;
                }
            }
            return string.Empty;
        }

        //Grava os dados dos votos
        public void escreveVoto(string regiao, string cpf, int codMunicipio, int codCandidatoFederal, int codPartidoFederal, int codCandidatoRegional, int codPartidoregional)
        {
            string nomeArq = "Votos.txt";
            string path = ConfigurationManager.AppSettings["CaminhoArquivos"];
            string text1 = regiao + ";" + cpf;
            string text2 = codMunicipio.ToString() + ";" + codCandidatoFederal.ToString() + ";" + codPartidoFederal.ToString() + ";" + codCandidatoFederal.ToString() + ";" + codPartidoregional.ToString();
            string fullPath = path + nomeArq;
            Criptografia crypt = new Criptografia();
            if (!File.Exists(fullPath))
            {
                string text = "2;" + text1 + ";1;" + text2;

                text = crypt.Encrypt(text);
                //header = crypt.Encrypt(header);
                using (StreamWriter file = new StreamWriter(fullPath))
                {
                    file.WriteLine(text);
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(fullPath);
                //n é o número sequencial que será inserido como identificador para o voto
                int n = lines.Length;
                string text = "2;" + text1 + ";" + n.ToString() + ";" + text2;
                text = crypt.Encrypt(text);
                using (StreamWriter file = new StreamWriter(fullPath, true))
                {
                    file.WriteLine(text);
                }
            }
        }

        public void exportaVotos()
        {
            Criptografia crypt = new Criptografia();
            string nomeArq = "Votos.txt";
            string path = ConfigurationManager.AppSettings["CaminhoArquivos"];
            string fullPath = path + nomeArq;
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("Não há votos cadastrados!");
            }
            else
            {
                string[] lines = File.ReadAllLines(fullPath);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = crypt.Decrypt(lines[i]);
                }
                string fullpathExporta = path + "VotosExporta.txt";
                using (StreamWriter file = new StreamWriter(fullpathExporta))
                {
                    file.WriteLine(headerVotos);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        file.WriteLine(lines[i]);
                    }
                }
            }
        }
    }

}
