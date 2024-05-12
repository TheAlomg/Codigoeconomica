using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Amortizacion : Form
    {
        public Amortizacion()
        {
            InitializeComponent();
        }

        private void Amortizacion_Load(object sender, EventArgs e)
        {

        }

        private void cmbCalcular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCalcular.Text == "Amortizacion Financiera")
            {

            }
            if(cmbCalcular.Text == "Amortizacion Tecnica")
            {

            }
        }

        private void cmbCalcular_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cmbCalcular.Text)
            {
                case "Amortizacion Aleman":
                    lblResultFormula.Text = "CF = P * (TIM * T(1 + TIM TP)) / TIM TP ";
                    break;
                case "Amortizacion Ingles":
                    lblResultFormula.Text = "CF = P * TIM (1 - m(TIM - TP)";
                    break;
                case "Amortizacion Americano":
                    lblResultFormula.Text = "CF = P * TIM (1 - m(TIM - TP)";
                    break;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            switch (cmbCalcular.Text)
            {
                case "Seleccionar":
                    MessageBox.Show("Seleccionar una de las opciones que quiera calcular...");
                    break;
                case "Amortizacion Aleman":
                    if(txtPrincipal.Text == "" || txtTiempo.Text == ""|| txtTasaInteresAnual.Text == "" || cmbTiempo.Text == "Seleccionar")
                    {
                        MessageBox.Show("Un campo se encuentra vacio");
                    }
                    else
                    {
                        if (validarInputAmortizacionFinanciera(txtPrincipal.Text, txtTiempo.Text, txtTasaInteresAnual.Text))
                        calcularAmortizacionAlemana();
                    }
                    break;
                case "Amortizacion Ingles":
                    if(txtPrincipal.Text == "" || txtTiempo.Text == "" || txtTasaInteresAnual.Text == "" || cmbTiempo.Text == "Seleccionar")
                    {
                        MessageBox.Show("Un campo se encuentra vacio");
                    }
                    else
                    {
                        if (validarInputAmortizacionFinanciera(txtPrincipal.Text, txtTiempo.Text, txtTasaInteresAnual.Text))
                            calcularAmortizacionIngles();
                    }
                    break;
                case "Amortizacion Americano":
                    if (txtPrincipal.Text == "" || txtTiempo.Text == "" || txtTasaInteresAnual.Text == "" || cmbTiempo.Text == "Seleccionar")
                    {
                        MessageBox.Show("Un campo se encuentra vacio");
                    }
                    else
                    {
                        if (validarInputAmortizacionFinanciera(txtPrincipal.Text, txtTiempo.Text, txtTasaInteresAnual.Text))
                            calcularAmortizacioAmericano();
                    }
                    break;
            }
        }

        private bool validarInputAmortizacionFinanciera(string c, string r, string t)
        {

            if (validateCosto(c)) return false;
            if (validateValoresidual(r)) return false;
            if (validateTiempo(t, cmbTiempo.Text)) return false;

            return true;
        }

        private bool validateCosto(string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ',' && str[i] != '0' && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5' && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9')
                {
                    MessageBox.Show("El costo solo permite numeros decimales");
                    return true;
                }
            }

            double cp = double.Parse(str);
            if (cp == 0)
            {
                MessageBox.Show("El costo no puede ser 0");
                return true;
            }

            return false;
        }

        private bool validateValoresidual(string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ',' && str[i] != '0' && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5' && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9')
                {
                    MessageBox.Show("El capital final solo permite numeros decimales");
                    return true;
                }
            }

            double cp = double.Parse(str);
            if (cp == 0)
            {
                MessageBox.Show("El capital final no puede ser 0");
                return true;
            }

            return false;
        }

        private bool validateTiempo(string str, string tiStr)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '.' && str[i] != '0' && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5' && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9')
                {
                    MessageBox.Show("El tiempo solo permite numeros decimales");
                    return true;
                }
            }
            double tiempo = double.Parse(str);
            if (tiempo == 0)
            {
                MessageBox.Show("");
                return true;
            }
            if (tiempo > 365 && tiStr == "Dias")
            {
                MessageBox.Show("");
                return true;
            }

            return false;
        }

            private void calcularAmortizacionAlemana()
        {
            double años = double.Parse(txtTiempo.Text);
            double tasaInteresAnual = double.Parse(txtTasaInteresAnual.Text);
            double principal = double.Parse(txtPrincipal.Text);
            double totalPagos = años * 12;
            double tasaInteresMensual = tasaInteresAnual / (12 * 100);
            double pago = principal * (tasaInteresMensual * Math.Pow(1 + tasaInteresMensual, totalPagos)) /
                (Math.Pow(1 + tasaInteresMensual, totalPagos) - 1);
            txtResultado.Text = pago.ToString();
        }

        private void calcularAmortizacionIngles()
        {
            double años = double.Parse(txtTiempo.Text);
            double tasaInteresAnual = double.Parse(txtTasaInteresAnual.Text);
            double principal = double.Parse(txtPrincipal.Text);
            double totalPagos = años * 12;
            double tasaInteresMensual = tasaInteresAnual / (12 * 100);
            double pago = (principal * tasaInteresMensual) / (1 - Math.Pow(1 + tasaInteresMensual, -totalPagos));
            txtResultado.Text = pago.ToString();
        }
        private void calcularAmortizacioAmericano()
        {
            double años = double.Parse(txtTiempo.Text);
            double tasaInteresAnual = double.Parse(txtTasaInteresAnual.Text);
            double principal = double.Parse(txtPrincipal.Text);
            double totalPagos = años * 12;
            double tasaInteresMensual = tasaInteresAnual / (12 * 100);
            double pago = (principal * tasaInteresMensual) / (1 - Math.Pow(1 + tasaInteresMensual, -totalPagos));
            txtResultado.Text = pago.ToString();
        }



        private void btnPreguntaCosto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El Costo Adquisitivo de Amortización se refiere al valor total que una empresa paga por obtener un bien o servicio, " +
                "y luego se distribuye o se 'amortiza' a lo largo de la vida útil del activo.");
        }

        private void btnPreguntaTiempo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" es el plazo del préstamo en años.");
        }

        private void btnPreguntaValorResidual_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La Tasa de Interés Anual es el porcentaje de dinero que se debe pagar o que se puede ganar sobre el monto total de un préstamo o inversión en un año.");
        }

        private void btnPreguntaTasa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El Principal de Amortización es la cantidad de dinero que se devuelve del préstamo, sin contar los intereses..");
        }

        private void lineShape3_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTiempo.Text = "0";
            txtTasaInteresAnual.Text = "0";
            txtResultado.Text = "0";
            lblResultFormula.Text = "";
            cmbTiempo.Text = "Seleccionar";
            cmbCalcular.Text = "Seleccionar";
            lblTiempo.Visible = true;
            btnPreguntaTiempo.Visible = true;
            lineTiempo.Visible = true;
            txtTiempo.Visible = true;
            cmbTiempo.Visible = true;
            lblCapitalFinal.Visible = true;
            btnPreguntaValorResidual.Visible = true;
            lblDolarCF.Visible = true;
            lineCF.Visible = true;
            txtTasaInteresAnual.Visible = true;

            cmbCalcular.Focus();
        }
    }
}
