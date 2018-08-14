using System;
using System.IO;

namespace Auxiliar
{
    public class Arquivo
    {
        public Arquivo()
        {
            using (StreamWriter file = new StreamWriter("teste.txt"))
            {
                file.Write("testando");
                file.WriteLine("as das");
                file.WriteLine("ddddddd");

            };
        }


    }

}
