using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                 Faça uma matriz 3 x 3, solicite ao usuário
                 que informe todos os valores da matriz, no
                 final você deve imprimir os valores informados
                 na tela.
                */

            int y = 2;
            y = 24;
            //Console.WriteLine("+---+---+---+");
            //Console.Write("|" + y.ToString().PadLeft(3));
            //Console.Write("|" + y.ToString().PadLeft(3));
            //Console.WriteLine("|" + y.ToString().PadLeft(3) + "|");
            //Console.WriteLine("+---+---+---+");
            //Console.Write("|" + y.ToString().PadLeft(3));
            //Console.Write("|" + y.ToString().PadLeft(3));
            //Console.WriteLine("|" + y.ToString().PadLeft(3) + "|");
            //Console.WriteLine("+---+---+---+");
            //Console.Write("|" + y.ToString().PadLeft(3));
            //Console.Write("|" + y.ToString().PadLeft(3));
            //Console.WriteLine("|" + y.ToString().PadLeft(3) + "|");
            //Console.WriteLine("+---+---+---+");

            //return;

            int[,,] x = new int[3, 3, 2];
            int[,] jogoDaVelha = new int[4, 5];

            Console.WriteLine(x.Rank);
            Console.WriteLine("Linhas: " + jogoDaVelha.GetLength(0) + " Colunas: " + jogoDaVelha.GetLength(1));


            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.WriteLine($"Informe o {((i * 3) + j) + 1}º número");
                    x[i, j, 0] = Convert.ToInt32(Console.ReadLine());
                }
            }










            return;





            Console.Clear();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("+---+---+---+");
                Console.Write("|");

                for (int j = 0; j < 3; j++)
                    Console.Write(x[i, j, 0].ToString().PadLeft(3) + "|");

                Console.WriteLine();
            }
            Console.WriteLine("+---+---+---+");
        }
    }
}