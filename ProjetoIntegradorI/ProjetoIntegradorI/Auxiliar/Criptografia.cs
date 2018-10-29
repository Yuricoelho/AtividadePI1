using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

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
        private string[] GenerateKey()
        {
            bool success = false;
            bool publicPass = false;
            bool privatePass = false;
            string[] key = { "","" };
            StringBuilder _key = new StringBuilder();
            while (!success)
            {
                //C = Centena, Dz = Dezena, U = Unidade
                int c, dz, u;
                string cdu;
                char car;
                for (var i = 0; i < 256; i++)
                {
                    cdu = "256";
                    //Na tabela ASCII os únicos caracteres válidos estão entre as posições 33 e 126 e acima de 161. Valor máximo 255
                    while ((int.Parse(cdu) > 126 && int.Parse(cdu) < 161) || int.Parse(cdu) < 33 || int.Parse(cdu) > 255)
                    {
                        //1 Byte vai de 0 à 256.
                        c = Random(0, 2);
                        dz = Random(0, 9);
                        u = Random(0, 9);
                        cdu = c.ToString() + dz.ToString() + u.ToString();
                    }
                    //Conversão de decimal para dítio válido conforme tabela ASCII
                    //car = (char)int.Parse(cdu);
                    //cdu = (string)car.ToString();
                    _key.Append(cdu);
                }
                if (!publicPass)
                {
                    key[0] = _key.ToString();
                }
                if (!success)
                {
                    if (!privatePass)
                    {
                        key[1] = _key.ToString();
                    }
                    BigInteger p1 = BigInteger.Parse(key[0]);
                    if (!VerificaPrimos(p1))
                    {
                        success = false;
                    }
                    else
                    {
                        key[0] = p1.ToString();
                        publicPass = true;
                        BigInteger q1 = BigInteger.Parse(key[1]);
                        if (!VerificaPrimos(q1))
                        {
                            privatePass = false;
                            success = false;
                        }
                        else
                        {
                            key[1] = q1.ToString();
                            success = true;
                            privatePass = true;
                        }
                    }
                }
            }
            BigInteger p = BigInteger.Parse(key[0]);
            BigInteger q = BigInteger.Parse(key[1]);
            BigInteger n = p * q;
            BigInteger phiN = ((p - 1) * (q - 1));
            int e = Random(1, (int)phiN);
            BigInteger d = 0;
            while (d * e % phiN != 1)
            {
                d++;
            }
            key[0] = e.ToString();
            key[1] = d.ToString();
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
                string[] keys = GenerateKey();
                publicKey = keys[0];
                privateKey = keys[1];
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

        private bool VerificaPrimos(BigInteger value)
        {
            if (value == 1)
                return false;
            for (BigInteger i = 2; i < value; i++)
            {
                if (value % i == 0)
                    return false;
            }

            return true;
        } 

        #endregion
    }
}
