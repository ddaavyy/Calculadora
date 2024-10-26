using System.Data;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        // Variaveis para conferir algo
        bool conferer = false; // Para controle do '='
        bool conferer_apagar = false; // Para controle de apagar (quando aperta o '=')

        public Form1()
        {
            InitializeComponent();
        }

        // Numeros
        private void btnZero_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "0";
            conferer_apagar = true;
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "1";
            conferer_apagar = true;
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "2";
            conferer_apagar = true;
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "3";
            conferer_apagar = true;
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "4";
            conferer_apagar = true;
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "5";
            conferer_apagar = true;
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "6";
            conferer_apagar = true;
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "7";
            conferer_apagar = true;
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "8";
            conferer_apagar = true;
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtBaixo.Text += "9";
            conferer_apagar = true;
        }

        // Operações
        private void btnSoma_Click(object sender, EventArgs e)
        {
            if (conferer == true)
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " + ";
                txtBaixo.Text = "";
                conferer = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtBaixo.Text))
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " + ";
                txtBaixo.Text = "";
            }
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            if (conferer == true)
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " - ";
                txtBaixo.Text = "";
                conferer = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtBaixo.Text))
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " - ";
                txtBaixo.Text = "";
            }
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            if (conferer == true)
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " * ";
                txtBaixo.Text = "";
                conferer = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtBaixo.Text))
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " * ";
                txtBaixo.Text = "";
            }
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            if (conferer == true)
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " / ";
                txtBaixo.Text = "";
                conferer = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtBaixo.Text))
            {
                txtCima.Text = "";
                txtCima.Text += txtBaixo.Text + " / ";
                txtBaixo.Text = "";
            }
        }

        // "Ingual"
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (conferer == false)
            {
                try
                {
                    string expressao = txtCima.Text + txtBaixo.Text;
                    DataTable tabela = new DataTable();
                    var Resultado = tabela.Compute(expressao, "");
                    txtCima.Text += txtBaixo.Text;
                    txtBaixo.Text = Convert.ToString(Resultado);
                    conferer = true;
                }
                catch (SyntaxErrorException)
                {
                    txtCima.Text = txtCima.Text.Substring(0, txtCima.Text.Length - 1);
                    string expressao = txtCima.Text + txtBaixo.Text;
                    DataTable tabela = new DataTable();
                    var Resultado = tabela.Compute(expressao, "");
                    txtCima.Text += txtBaixo.Text;
                    txtBaixo.Text = Convert.ToString(Resultado);
                    conferer = true;
                }
            }
            conferer_apagar = false;
        }

        //Apagares
        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBaixo.Text) && conferer == false)
            {
                txtBaixo.Text = txtBaixo.Text.Substring(0, txtBaixo.Text.Length - 1);
            }
            else if (!string.IsNullOrWhiteSpace(txtBaixo.Text) && conferer_apagar == true)
                txtBaixo.Text = txtBaixo.Text.Substring(0, txtBaixo.Text.Length - 1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conferer = false;
            txtBaixo.Text = "";
            txtCima.Text = "";
        }

        // Ponto (casa decimal, ',')
        private void btnPonto_Click(object sender, EventArgs e)
        {
            if (conferer == true && !string.IsNullOrWhiteSpace(txtBaixo.Text) && !string.IsNullOrWhiteSpace(txtCima.Text))
            {
                if (!txtBaixo.Text.Contains("."))
                    txtBaixo.Text += ".";
                    conferer_apagar = true;
            }
            else
                if (!txtBaixo.Text.Contains(".") && !string.IsNullOrWhiteSpace(txtBaixo.Text))
                txtBaixo.Text += ".";
                conferer_apagar = true;
        }
    }
}
