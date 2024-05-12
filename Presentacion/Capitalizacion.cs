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
    public partial class Capitalizacion : Form
    {
        public Capitalizacion()
        {
            InitializeComponent();
        }

        private void cmbCalcular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCalcular_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cmbCalcular.Text)
            {
                case "Interes Simple":
                    lblCapitalInicial.Visible = true;
                    lblDolarCI.Visible = true;
                    txtPrincipal.Visible = true;
                    txtPrincipal.Text = "0";
                    lineCI.Visible = true;
                    btnPreguntaCapitalInicial.Visible = true;

                    lblTipoInteres.Visible = true;
                    lblPorcentajeTI.Visible = true;
                    txtTipoInteres.Visible = true;
                    txtTipoInteres.Text = "0";
                    lineTI.Visible = true;
                    btnPreguntaTipoInteres.Visible = true;

                    lblTiempo.Visible = true;
                    txtTiempo.Visible = true;
                    txtTiempo.Text = "0";
                    lineTiempo.Visible = true;
                    cmbTiempo.Visible = true;
                    cmbTiempo.Text = "Seleccionar";
                    btnPreguntaTiempo.Visible = true;

                    lblCapitalFinal.Visible = false;
                    lblDolarCF.Visible = false;
                    txtCapitalizacionFinal.Visible = false;
                    lineCF.Visible = false;
                    btnPreguntaCapitalFinal.Visible = false;

                    lblResultFormula.Text = "I = P * i * t";
                    break;

                case "Interes Compuesto":
                    lblCapitalInicial.Visible = true;
                    lblDolarCI.Visible = true;
                    txtPrincipal.Visible = true;
                    txtPrincipal.Text = "0";
                    lineCI.Visible = true;
                    btnPreguntaCapitalInicial.Visible = true;

                    lblTipoInteres.Visible = true;
                    lblPorcentajeTI.Visible = true;
                    txtTipoInteres.Visible = true;
                    txtTipoInteres.Text = "0";
                    lineTI.Visible = true;
                    btnPreguntaTipoInteres.Visible = true;

                    lblTiempo.Visible = true;
                    txtTiempo.Visible = true;
                    txtTiempo.Text = "0";
                    lineTiempo.Visible = true;
                    cmbTiempo.Visible = true;
                    cmbTiempo.Text = "Seleccionar";
                    btnPreguntaTiempo.Visible = true;

                    lblCapitalFinal.Visible = false;
                    lblDolarCF.Visible = false;
                    txtCapitalizacionFinal.Visible = false;
                    lineCF.Visible = false;
                    btnPreguntaCapitalFinal.Visible = false;

                    lblResultFormula.Text = "I = P * i * t";
                    break;
            }                            
            
            }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPrincipal.Text = "0";
            txtTipoInteres.Text = "0";
            txtTiempo.Text = "0";
            txtCapitalizacionFinal.Text = "0";
            txtResultado.Text = "0";
            lblResultFormula.Text = "";
            cmbTiempo.Text = "Seleccionar";
            cmbCalcular.Text = "Seleccionar";

            lblCapitalInicial.Visible = true;
            btnPreguntaCapitalInicial.Visible = true;
            lblDolarCI.Visible = true;
            lineCI.Visible = true;
            txtPrincipal.Visible = true;
            lblTipoInteres.Visible = true;
            btnPreguntaTipoInteres.Visible = true;
            lineTI.Visible = true;
            txtTipoInteres.Visible = true;
            lblPorcentajeTI.Visible = true;
            lblTiempo.Visible = true;
            btnPreguntaTiempo.Visible = true;
            lineTiempo.Visible = true;
            txtTiempo.Visible = true;
            cmbTiempo.Visible = true;
            lblCapitalFinal.Visible = true;
            btnPreguntaCapitalFinal.Visible = true;
            lblDolarCF.Visible = true;
            lineCF.Visible = true;
            txtCapitalizacionFinal.Visible = true;

            cmbCalcular.Focus();
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            switch (cmbCalcular.Text)
            {
                case "Seleccionar":
                    MessageBox.Show("Seleccionar una de las opciones que quiera calcular...");
                    break;
                case "Interes Simple":
                    if (txtPrincipal.Text == "" || txtTipoInteres.Text == "" || txtTiempo.Text == "" || cmbTiempo.Text == "Seleccionar")
                    {
                        MessageBox.Show("Un campo se encuentra vacio");
                    }
                    else
                    {
                        if (validarInputSimpleInteres(txtPrincipal.Text, txtTipoInteres.Text, txtTiempo.Text))
                        {
                            calcular_interes_simple();
                        }
                    }
                break;

                 case "Interes Compuesto":
                     if (txtPrincipal.Text == "" || txtTipoInteres.Text == "" || txtTiempo.Text == "" || cmbTiempo.Text == "Seleccionar")
                     {
                        MessageBox.Show("Un campo se encuentra vacio");
                     }
                     else
                     {
                          if (validarInputSimpleInteres(txtPrincipal.Text, txtTipoInteres.Text, txtTiempo.Text))
                           {
                                    calcular_interes_compuesto();
                           }
                          }
                 break;
            }


        }
        private bool validarInputSimpleInteres(string c, string r, string t)
        {

            if (validateCapitalInicial(c)) return false;
            if (validateTasaInteres(r)) return false;
            if (validateTiempo(t, cmbTiempo.Text)) return false;

            return true;
        }
        private bool validateCapitalInicial(string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ',' && str[i] != '0' && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5' && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9')
                {
                    MessageBox.Show("El capital inicial solo permite numeros decimales");
                    return true;
                }
            }

            double cp = double.Parse(str);
            if (cp == 0)
            {
                MessageBox.Show("El capital inicial no puede ser 0");
                return true;
            }

            return false;
        }
        private bool validateTasaInteres(string str)
        {
            // Reemplazar la coma por un punto
            str = str.Replace(',', '.');

            // Verificar si se puede convertir el valor de entrada a un número decimal
            if (!float.TryParse(str, out float tasa_interes))
            {
                MessageBox.Show("La tasa de interes solo permite numeros decimales");
                return true;
            }

            if (tasa_interes == 0)
            {
                MessageBox.Show("La tasa de interes no puede ser 0");
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
                    MessageBox.Show("El tiempo de negociacion solo permite numeros decimales");
                    return true;
                }
            }

            double tiempo = double.Parse(str);
            if (tiempo == 0)
            {
                MessageBox.Show("El tiempo de negociacion no puede ser 0");
                return true;
            }
            if (tiempo > 365 && tiStr == "Dias")
            {
                MessageBox.Show("El tiempo de negociacion no puede ser mayor a 365 días");
                return true;
            }

            return false;
        }
        private void calcular_interes_simple()
        {
            double principal = double.Parse(txtPrincipal.Text);
            double tasaInteres = double.Parse(txtTipoInteres.Text) / 100;
            double años = double.Parse(txtTiempo.Text);
            //tener en cuenta 
            double tasaInteresDecimal = tasaInteres / 100;
            double interes = principal * tasaInteresDecimal * años;
            txtResultado.Text = interes.ToString("N2");


            // Calcular interés simple

        }
        private void calcular_interes_compuesto()
        {
            double principal = double.Parse(txtPrincipal.Text);
            double tasaInteres = double.Parse(txtTipoInteres.Text) / 100;
            double años = double.Parse(txtTiempo.Text);
            double periodosCapitalizacionAnual = double.Parse(txtCapitalizacionFinal.Text);
            double tasaInteresDecimal = tasaInteres / 100;
            double tasaInteresPeriodo = tasaInteresDecimal / periodosCapitalizacionAnual;
            double totalPeriodos = años * periodosCapitalizacionAnual;
            double montoFinal = principal * Math.Pow(1 + tasaInteresPeriodo, totalPeriodos);
            txtResultado.Text = montoFinal.ToString("N2");
        }

        private void btnPreguntaCapitalInicial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Representa el monto inicial invertido, Es la base sobre la cual se calculan los intereses");
        }

        private void btnPreguntaTipoInteres_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Es el precio del dinero, esto es, lo que se paga por emplear una cantidad de dinero durante un plazo determinado.");
        }

        private void btnPreguntaTiempo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Representa el periodo que los clientes tienen para pagar un producto de pedido facturado");
        }

        private void btnPreguntaCapitalFinal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Es la base sobre la cual se calculan los intereses, Aumenta el capital disponible para generar más intereses en el futuro, Permite el crecimiento exponencial del capital a largo plazo");
        }
    }
}
