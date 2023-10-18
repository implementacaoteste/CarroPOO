using POO;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace UIWinFormsApp
{
    public partial class FormPrincipal : Form
    {
        Carro carro;
        public FormPrincipal()
        {
            InitializeComponent();
            carro = new Carro("Chevrolet", "Sedan", "Branco", 1984, "KA-4187", 50, 100, 160);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exibir();

            //PneuDianteiroEsquerdo.Exibir();
            //PneuDianteiroDireito.Exibir();
            //PneuTraseiroEsquerdo.Exibir();
            //PneuTraseiroDireito.Exibir();
            //PneuDeEstepe.Exibir();
        }

        private void ExibirPneu(Pneu _pneu, TextBox _textBox)
        {
            _textBox.Text = "Aro: " + _pneu.Aro;
            _textBox.Text = _textBox.Text + "\r\nMarca: " + _pneu.Marca;
            _textBox.Text = _textBox.Text + "\r\nPSI: " + _pneu.PSI;
            _textBox.Text = _textBox.Text + "\r\nPSIMaximo: " + _pneu.PSIMaximo;
            _textBox.Text = _textBox.Text + "\r\nPSIMinimo: " + _pneu.PSIMinimo;
            _textBox.Text = _textBox.Text + "\r\nLargura: " + _pneu.Largura;
            _textBox.Text = _textBox.Text + "\r\nPercentualBorracha: " + _pneu.PercentualBorracha;
            _textBox.Text = _textBox.Text + "\r\nVelocidadeMaxima: " + _pneu.VelocidadeMaxima;
            _textBox.Text = _textBox.Text + "\r\nVelocidadeAtual: " + _pneu.VelocidadeAtual;
            _textBox.Text = _textBox.Text + "\r\nCargaMaxima: " + _pneu.CargaMaxima;
            _textBox.Text = _textBox.Text + "\r\nCargaAtual: " + _pneu.CargaAtual;
            _textBox.Text = _textBox.Text + "\r\nEstourado: " + _pneu.Estourado;
            _textBox.Text = _textBox.Text + "\r\nFurado: " + _pneu.Furado;
            _textBox.Text = _textBox.Text + "\r\nEstepe: " + _pneu.Estepe;

            _textBox.BackColor = Color.White;

            if (_pneu.Estourado)
                _textBox.BackColor = Color.Red;
        }

        private void buttonLigar_Click(object sender, EventArgs e)
        {
            if (carro.Ligado)
                carro.Desligar();
            else
                carro.Ligar();

            Exibir();
        }

        private void Exibir()
        {
            textBoxExibir.Text = "Marca: " + carro.Marca;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nModelo: " + carro.Modelo;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nCor: " + carro.Cor;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nAno: " + carro.Ano;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nPlaca: " + carro.Placa;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nCapacidadeDoTanque: " + carro.CapacidadeDoTanque;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nPercentualDeCombustivel: " + carro.PercentualDeCombustivel;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nLigado: " + carro.Ligado;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nVelocidadeMaxima: " + carro.VelocidadeMaxima;
            textBoxExibir.Text = textBoxExibir.Text + "\r\nVelocidadeAtual: " + carro.VelocidadeAtual;

            ExibirPneu(carro.PneuDianteiroEsquerdo, textBoxPneuDianteiroEsquerdo);
            ExibirPneu(carro.PneuDianteiroDireito, textBoxPneuDianteiroDireito);
            ExibirPneu(carro.PneuTraseiroEsquerdo, textBoxPneuTraseiroEsquerdo);
            ExibirPneu(carro.PneuTraseiroDireito, textBoxPneuTraseiroDireito);
            ExibirPneu(carro.PneuDeEstepe, textBoxPneuDeEstepe);

            if (carro.Ligado)
                buttonLigar.Text = "Desligar";
            else
                buttonLigar.Text = "Ligar";
        }

        private void buttonAcelerar_Click(object sender, EventArgs e)
        {
            carro.Acelerar(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();
        }

        private void buttonFrear_Click(object sender, EventArgs e)
        {
            carro.Frear(Convert.ToInt32(textBoxImpulso.Text));
            Exibir();
        }

        private void buttonTrocarPneu_Click(object sender, EventArgs e)
        {
            try
            {
                Pneu pneu = null;

                switch (comboBoxPneu.SelectedIndex)
                {
                    case 0:
                        pneu = carro.PneuDianteiroEsquerdo;
                        carro.PneuDianteiroEsquerdo = carro.PneuDeEstepe;
                        break;
                    case 1:
                        pneu = carro.PneuDianteiroDireito;
                        carro.PneuDianteiroDireito = carro.PneuDeEstepe;
                        break;
                    case 2:
                        pneu = carro.PneuTraseiroEsquerdo;
                        carro.PneuTraseiroEsquerdo = carro.PneuDeEstepe;
                        break;
                    case 3:
                        pneu = carro.PneuTraseiroDireito;
                        carro.PneuTraseiroDireito = carro.PneuDeEstepe;
                        break;
                    default:
                        break;
                }

                if (pneu != null)
                    carro.PneuDeEstepe = pneu;

                Exibir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}