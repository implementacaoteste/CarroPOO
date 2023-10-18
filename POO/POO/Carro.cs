using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POO
{
    //PascalCase: Nomes de classes, métodos e propriedades
    //camelCase: Nomes de variáveis privadas
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

        private Pneu pneuDianteiroEsquerdo;
        public Pneu PneuDianteiroEsquerdo
        {
            get
            {
                return pneuDianteiroEsquerdo;
            }
            set
            {
                if (VelocidadeAtual > 0)
                    throw new Exception("Vai trocar o pneu com carro andando? Pare o carro.");

                if (Ligado)
                    throw new Exception("Seu animal, desligue o carro.");

                pneuDianteiroEsquerdo = value;
            }
        }

        public Pneu PneuDianteiroDireito { get; set; }
        public Pneu PneuTraseiroEsquerdo { get; set; }
        public Pneu PneuTraseiroDireito { get; set; }
        public Pneu PneuDeEstepe { get; set; }
        public int CapacidadeDoTanque { get; set; }
        public int PercentualDeCombustivel { get; set; }
        public bool Ligado { get; set; }
        public int VelocidadeMaxima { get; set; }
        public int VelocidadeAtual { get; set; }

        public Carro(string _marca, string _modelo, string _cor, int _ano, string _placa, int _capacidadeDoTanque, int _percentualDeCombustivel, int _velocidadeMaxima)
        {
            Marca = _marca;
            Modelo = _modelo;
            Cor = _cor;
            Ano = _ano;
            Placa = _placa;
            PneuDianteiroEsquerdo = new Pneu(13, "Michelin", 33, 38, 25, 240, 500);
            PneuDianteiroDireito = new Pneu(13, "Michelin", 33, 38, 25, 240, 500);
            PneuTraseiroEsquerdo = new Pneu(13, "Michelin", 33, 38, 25, 240, 500);
            PneuTraseiroDireito = new Pneu(13, "Michelin", 33, 38, 25, 240, 500);
            PneuDeEstepe = new Pneu(13, "Michelin", 33, 38, 20, 70, 300, true);
            CapacidadeDoTanque = _capacidadeDoTanque;
            PercentualDeCombustivel = _percentualDeCombustivel;
            Ligado = false;
            VelocidadeAtual = 0;
            VelocidadeMaxima = _velocidadeMaxima;
        }
        public void Exibir()
        {
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Cor: " + Cor);
            Console.WriteLine("Ano: " + Ano);
            Console.WriteLine("Placa: " + Placa);
            Console.WriteLine("CapacidadeDoTanque: " + CapacidadeDoTanque);
            Console.WriteLine("PercentualDeCombustivel: " + PercentualDeCombustivel);
            Console.WriteLine("Ligado: " + Ligado);
            Console.WriteLine("VelocidadeMaxima: " + VelocidadeMaxima);
            Console.WriteLine("VelocidadeAtual: " + VelocidadeAtual);

            Console.WriteLine("\nPneuDianteiroEsquerdo");
            PneuDianteiroEsquerdo.Exibir();
            Console.WriteLine("\nPneuDianteiroDireito");
            PneuDianteiroDireito.Exibir();
            Console.WriteLine("\nPneuTraseiroEsquerdo");
            PneuTraseiroEsquerdo.Exibir();
            Console.WriteLine("\nPneuTraseiroDireito");
            PneuTraseiroDireito.Exibir();
            Console.WriteLine("\nPneuDeEstepe");
            PneuDeEstepe.Exibir();
        }
        public void Ligar()
        {
            if (PercentualDeCombustivel > 0)
            {
                Ligado = true;
                PercentualDeCombustivel = PercentualDeCombustivel - 1;
            }
        }
        public void Desligar()
        {
            Ligado = false;
            Parar();
        }
        public void Acelerar(int _impulso)
        {
            if (!Ligado)
            {
                Console.WriteLine("O carro está desligado.");
                return;
            }
            if (CarroEstaOperacional())
            {
                PercentualDeCombustivel -= 5;
                VelocidadeAtual += _impulso;
                PneuDianteiroDireito.Acelerar(_impulso);
                PneuDianteiroEsquerdo.Acelerar(_impulso);
                PneuTraseiroDireito.Acelerar(_impulso);
                PneuTraseiroEsquerdo.Acelerar(_impulso);
                CarroEstaOperacional();
            }
        }
        public void Frear(int _impulso)
        {
            VelocidadeAtual -= _impulso;
            PneuDianteiroDireito.Frear(_impulso);
            PneuDianteiroEsquerdo.Frear(_impulso);
            PneuTraseiroDireito.Frear(_impulso);
            PneuTraseiroEsquerdo.Frear(_impulso);

            if (VelocidadeAtual < 0)
                VelocidadeAtual = 0;
        }
        private bool CarroEstaOperacional()
        {
            if (PercentualDeCombustivel <= 0)
            {
                PercentualDeCombustivel = 0;
                Console.WriteLine("O carro está sem combustível.");
                Desligar();
                return false;
            }
            if (PneuDianteiroDireito.Estourado || PneuDianteiroDireito.Furado)
            {
                Console.WriteLine("Problema com o pneu dianteiro direito");
                //TODO: Fazer um método para validar se o pneu está operacional
                Parar();
                return false;
            }
            if (PneuDianteiroEsquerdo.Estourado || PneuDianteiroEsquerdo.Furado)
            {
                Console.WriteLine("Problema com o pneu dianteiro esquerdo");
                //TODO: Fazer um método para validar se o pneu está operacional
                Parar();
                return false;
            }
            if (PneuTraseiroDireito.Estourado || PneuTraseiroDireito.Furado)
            {
                Console.WriteLine("Problema com o pneu traseiro direito");
                //TODO: Fazer um método para validar se o pneu está operacional
                Parar();
                return false;
            }
            if (PneuTraseiroEsquerdo.Estourado || PneuTraseiroEsquerdo.Furado)
            {
                Console.WriteLine("Problema com o pneu traseiro esquerdo");
                //TODO: Fazer um método para validar se o pneu está operacional
                Parar();
                return false;
            }
            return true;
        }
        private void Parar()
        {
            Frear(VelocidadeAtual);
        }
    }
}










