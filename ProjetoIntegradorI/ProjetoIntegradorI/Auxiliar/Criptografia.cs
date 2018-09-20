using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auxiliar
{
    //Classe principal de criptografia
    public class Criptografia
    {

        #region Construtor
        public Criptografia()
        {
            VerificaChaves();
        }
        #endregion

        #region Propriedades

        private static Random rnd;
        private string publicKey;
        private string privateKey;

        #endregion

        #region Métodos

        //Inicializa o método Random
        private static void InitRandom()
        {
            if (rnd == null) rnd = new Random();
        }

        //Gera estaticamente números aleatórios baseados em um valor mínimo e máximo. Funciona bem para valores pequenos.
        private static int Random(int min, int max)
        {
            InitRandom();
            return rnd.Next(min, max);
        }

        //Gera uma chave criptográfica de 2048 bits === 256 bytes
        private string GenerateKey()
        {
            //C = Centena, D = Dezena, U = Unidade
            int c, d, u;
            string cdu;
            char car;
            string key = "";
            StringBuilder _key = new StringBuilder();
            for (var i = 0; i< 256; i++)
            {
                cdu = "256";
                //Na tabela ASCII os únicos caracteres válidos estão entre as posições 33 e 126 e acima de 161. Valor máximo 255
                while ((int.Parse(cdu) > 126 && int.Parse(cdu) < 161) || int.Parse(cdu) < 33 || int.Parse(cdu) > 255)
                {
                    //1 Byte vai de 0 à 256.
                    c = Random(0, 2);
                    d = Random(0, 9);
                    u = Random(0, 9);
                    cdu = c.ToString() + d.ToString() + u.ToString();
                }
                //Conversão de decimal para dítio válido conforme tabela ASCII
                car = (char)int.Parse(cdu);
                cdu = (string)car.ToString();
                _key.Append(cdu);
            }
            key = _key.ToString();
            return key;
        }

        public void Encrypt()
        {
            

        }

        private void VerificaChaves()
        {
            string nomeArq = "Keys.txt";
            string path = ConfigurationManager.AppSettings["CaminhoCriptografia"];
            string fullPath = path + nomeArq;
            if (!File.Exists(fullPath))
            {
                publicKey = GenerateKey();
                privateKey = GenerateKey();
                using (StreamWriter file = new StreamWriter(fullPath))
                {
                    file.WriteLine(publicKey);
                    file.WriteLine(privateKey);
                }
            }
            else
            {
                string[] keys = File.ReadAllLines(fullPath);
                publicKey = keys[0];
                privateKey = keys[1];
            }
        }

        #endregion
    }
}
