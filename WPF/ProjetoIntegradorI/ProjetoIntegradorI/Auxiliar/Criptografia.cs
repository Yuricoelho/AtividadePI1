using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;

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
        private string modulus;

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
            string[] key = { "", "", "" };
            StringBuilder _key = new StringBuilder();
            //while (!success)
            //{
            //    //C = Centena, Dz = Dezena, U = Unidade
            //    int c, dz, u;
            //    string cdu;
            //    char car;
            //    for (var i = 0; i < 256; i++)
            //    {
            //        cdu = "256";
            //        //Na tabela ASCII os únicos caracteres válidos estão entre as posições 33 e 126 e acima de 161. Valor máximo 255
            //        while ((int.Parse(cdu) > 126 && int.Parse(cdu) < 161) || int.Parse(cdu) < 33 || int.Parse(cdu) > 255)
            //        {
            //            //1 Byte vai de 0 à 256.
            //            c = Random(0, 2);
            //            dz = Random(0, 9);
            //            u = Random(0, 9);
            //            cdu = c.ToString() + dz.ToString() + u.ToString();
            //        }
            //        //Conversão de decimal para dítio válido conforme tabela ASCII
            //        //car = (char)int.Parse(cdu);
            //        //cdu = (string)car.ToString();
            //        _key.Append(cdu);
            //    }
            //    if (!publicPass)
            //    {
            //        key[0] = _key.ToString();
            //    }
            //    if (!success)
            //    {
            //        if (!privatePass)
            //        {
            //            key[1] = _key.ToString();
            //        }
            //        BigInteger p1 = BigInteger.Parse(key[0]);
            //        if (!VerificaPrimos(p1))
            //        {
            //            success = false;
            //        }
            //        else
            //        {
            //            key[0] = p1.ToString();
            //            publicPass = true;
            //            BigInteger q1 = BigInteger.Parse(key[1]);
            //            if (!VerificaPrimos(q1))
            //            {
            //                privatePass = false;
            //                success = false;
            //            }
            //            else
            //            {
            //                key[1] = q1.ToString();
            //                success = true;
            //                privatePass = true;
            //            }
            //        }
            //    }
            //}
            BigInteger p = BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007913129639747");
            BigInteger q = BigInteger.Parse("2037035976334486086268445688409378161051468393665936250636140449354381299763336706183397223");
            BigInteger n = BigInteger.Multiply(p, q);

            BigInteger pM = BigInteger.Subtract(p, BigInteger.One);
            BigInteger qM = BigInteger.Subtract(q, BigInteger.One);
            BigInteger phiN = BigInteger.Multiply(pM, qM);

            BigInteger e;
            do
            {
                var rngBig = new RNGCryptoServiceProvider();
                byte[] bytes = new byte[phiN.ToByteArray().Length - 1];
                rngBig.GetBytes(bytes);
                e = new BigInteger(bytes);
                e = BigInteger.Abs(e);
            } while (phiN % e == 0 || e <= 1 || BigInteger.GreatestCommonDivisor(e, phiN) != 1 || e >= (phiN - 1));

            bool é = BigInteger.GreatestCommonDivisor(e, phiN) == 1;
            BigInteger phiNminus1 = BigInteger.Subtract(phiN, BigInteger.One);
            BigInteger d = ModInverse(e, phiN);
            key[0] = e.ToString();
            key[1] = d.ToString();
            key[2] = n.ToString();
            return key;
        }

        //Método encapsulado de encriptação
        public string Encrypt(string text)
        {
            return this.encryptizer(text);
        }

        //Método encapsulado de desencriptação
        public string Decrypt(string text)
        {
            return this.decryptizer(text);
        }

        //Método interno de encriptação
        private string encryptizer(string text)
        {
            byte[] auxByte = Encoding.UTF8.GetBytes(text);
            BigInteger m = new BigInteger(auxByte);
            BigInteger e = BigInteger.Parse(publicKey);
            BigInteger N = BigInteger.Parse(modulus);
            BigInteger d = BigInteger.Parse(privateKey);
            BigInteger C = BigInteger.ModPow(m, e, N);
            auxByte = C.ToByteArray();
            text = Convert.ToBase64String(auxByte);
            return text;
        }

        //Método interno de desencriptação
        private string decryptizer(string text)
        {
            byte[] auxByte = Convert.FromBase64String(text);
            BigInteger C = new BigInteger(auxByte);
            BigInteger d = BigInteger.Parse(privateKey);
            BigInteger N = BigInteger.Parse(modulus);
            BigInteger m = BigInteger.ModPow(C, d, N);
            auxByte = m.ToByteArray();
            text = Encoding.UTF8.GetString(auxByte);
            return text;
        }

        //Verifica as chaves no arquivo
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
                modulus = keys[2];
                using (StreamWriter file = new StreamWriter(fullPath))
                {
                    file.WriteLine(publicKey);
                    file.WriteLine(privateKey);
                    file.WriteLine(modulus);
                }
            }
            else
            {
                string[] keys = File.ReadAllLines(fullPath);
                publicKey = keys[0];
                privateKey = keys[1];
                modulus = keys[2];
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

        private BigInteger Pow(BigInteger value, BigInteger exponent)
        {
            BigInteger originalValue = value;
            while (exponent-- > 1)
                value = BigInteger.Multiply(value, originalValue);
            return value;
        }

        private BigInteger ModInverse(BigInteger a, BigInteger n)
        {
            BigInteger t = 0;
            BigInteger newt = 1;
            BigInteger r = n;
            BigInteger newr = a;
            BigInteger quotient;
            BigInteger aux;
            while (newr != 0)
            {
                quotient = BigInteger.Divide(r, newr);
                aux = newt;
                newt = BigInteger.Subtract(t, BigInteger.Multiply(quotient, newt));
                t = aux;
                aux = newr;
                newr = BigInteger.Subtract(r, BigInteger.Multiply(quotient, newr));
                r = aux;
            }
            if (r > 1)
                return BigInteger.Zero;
            if (t < 0)
                t = t + n;
            return t;
        }

        #endregion
    }
}
