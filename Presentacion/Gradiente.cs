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
    public partial class Gradiente : Form
    {
        public Gradiente()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            switch (cmbCalcular.Text)
            {
                case "Seleccionar":
                    MessageWarning("Seleccionar una de las opciones que quiera calcular...");
                    break;
                case "Gradiente Lineal Creciente":
                    if (txtPrimeraCuota.Text == "0" || txtTipoInteres.Text == "0" || txtIngresos.Text == "0" || txtConstante.Text == "0")
                    {
                        MessageWarning("Un campo se encuentra vacío");
                    }
                    else
                    {
                        CalcularGradienteLinealCreciente();

                    }
                    break;
                case "Gradiente Lineal Decreciente":
                    if (txtPrimeraCuota.Text == "0" || txtTipoInteres.Text == "0" || txtIngresos.Text == "0" || txtConstante.Text == "0")
                    {
                        MessageWarning("Un campo se encuentra vacío");
                    }
                    else
                    {
                        CalcularGradienteLinealDecreciente();

                    }
                    break;
                case "Gradiente Geometrico Creciente":
                    if (txtPrimeraCuota.Text == "0" || txtTipoInteres.Text == "0" || txtIngresos.Text == "0" || txtConstante.Text == "0" || txtVariacionPorcentual.Text == "0")
                    {
                        MessageWarning("Un campo se encuentra vacío");
                    }
                    else
                    {
                        CalcularGradienteGeometricoCreciente();
                    }
                    break;
                case "Gradiente Geometrico Decreciente":
                    if (txtPrimeraCuota.Text == "0" || txtTipoInteres.Text == "0" || txtIngresos.Text == "0" || txtConstante.Text == "0" || txtVariacionPorcentual.Text == "0")
                    {
                        MessageWarning("Un campo se encuentra vacío");
                    }
                    else
                    {
                        CalcularGradienteGeometricoDecreciente();
                    }
                    break;
                case "Gradiente Escalonado o en Escalera":
                    if (txtPrimeraCuota.Text == "0" || txtTipoInteres.Text == "0" || txtIngresos.Text == "0" || txtConstante.Text == "0" || txtTEA.Text == "0")
                    {
                        MessageWarning("Un campo se encuentra vacío");
                    }
                    else
                    {
                        CalcularGradienteEscalonadooEscalera();
                    }
                    break;
                default:
                    MessageWarning("Seleccionar una opcion valida...!");
                    cmbCalcular.Text = "Seleccionar";
                    break;
            }
        }

        private void MessageWarning(string str)
        {
            MessageBox.Show(str, "Interes Compuesto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtConstante.Text = "0";
            txtIngresos.Text = "0";
            txtPrimeraCuota.Text = "0";
            txtResultado.Text = "0";
            txtTipoInteres.Text = "0";
            cmbCalcular.Text = "Seleccionar";
            cmbTiempo.Text = "Seleccionar";
            lblResultFormula.Text = "";
        }

        private void cmbCalcular_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCalcular.Text)
            {
                case "Gradiente Lineal Creciente":
                    lblVariacionPorcentual.Visible = false;
                    txtVariacionPorcentual.Visible = false;
                    lineShapeVariacionPorcentual.Visible = false;
                    lblTEA.Visible = false;
                    txtTEA.Visible = false;
                    lineShapeTEA.Visible = false;
                    lblCapitalFinal.Visible = true;
                    lblDolarCF.Visible = true;
                    txtConstante.Visible = true;
                    btnConstante.Visible = true;
                    lineCF.Visible = true;

                    lblResultadoFormula.Text = "P = A * ((1+i)^n-1 / i*(1+i)^n) + (g/i) ....";
                    break;
                case "Gradiente Lineal Decreciente":
                    lblVariacionPorcentual.Visible = false;
                    txtVariacionPorcentual.Visible = false;
                    lineShapeVariacionPorcentual.Visible = false;
                    lblTEA.Visible = false;
                    txtTEA.Visible = false;
                    lineShapeTEA.Visible = false;
                    lblCapitalFinal.Visible = true;
                    lblDolarCF.Visible = true;
                    txtConstante.Visible = true;
                    btnConstante.Visible= true;
                    lineCF.Visible = true;

                    lblResultadoFormula.Text = "P = A * ((1+i)^n-1 / i*(1+i)^n) - (g/i) ....";
                    break;
                case "Gradiente Geometrico Creciente":
                    lblVariacionPorcentual.Visible = true;
                    txtVariacionPorcentual.Visible = true;
                    lineShapeVariacionPorcentual.Visible = true;
                    lblTEA.Visible = false;
                    txtTEA.Visible = false;
                    lineShapeTEA.Visible = false;
                    lblCapitalFinal.Visible = false;
                    lblDolarCF.Visible = false;
                    txtConstante.Visible = false;
                    btnConstante.Visible = false;
                    lineCF.Visible = false;

                    lblResultadoFormula.Text = "P = A*(((1+j)^n-(1+i)^n)/(j-i)*(1+i)^n)";
                    break;
                case "Gradiente Geometrico Decreciente":
                    lblVariacionPorcentual.Visible = true;
                    txtVariacionPorcentual.Visible = true;
                    lineShapeVariacionPorcentual.Visible = true;
                    lblTEA.Visible = false;
                    txtTEA.Visible = false;
                    lineShapeTEA.Visible = false;
                    lblCapitalFinal.Visible = false;
                    lblDolarCF.Visible = false;
                    txtConstante.Visible = false;
                    btnConstante.Visible = false;
                    lineCF.Visible = false;

                    lblResultadoFormula.Text = "P = A*(((1+i)^n-(1-j)^n)/(j+i)*(1+i)^n)";
                    break;
                case "Gradiente Escalonado o en Escalera":
                    lblVariacionPorcentual.Visible = false;
                    txtVariacionPorcentual.Visible = false;
                    lineShapeVariacionPorcentual.Visible = false;
                    lblTEA.Visible = true;
                    txtTEA.Visible = true;
                    lineShapeTEA.Visible = true;
                    lblCapitalFinal.Visible = false;
                    lblDolarCF.Visible = false;
                    txtConstante.Visible = false;
                    btnConstante.Visible= false;
                    lineCF.Visible = false;
                    break;
            }
        }

        private void Gradiente_Load(object sender, EventArgs e)
        {

            lblVariacionPorcentual.Visible = false;
            lblTEA.Visible = false;
            txtVariacionPorcentual.Visible = false;
            txtTEA.Visible = false;
            lineShapeTEA.Visible = false;
            lineShapeVariacionPorcentual.Visible = false;
        }

        public void CalcularGradienteLinealCreciente()
        {
            double a = double.Parse(txtPrimeraCuota.Text);
            double i = double.Parse(txtTipoInteres.Text) / 100;
            double n = double.Parse(txtIngresos.Text);
            double g = double.Parse(txtConstante.Text);

            double p = a * ((Math.Pow(1 + i, n) - 1) / (i * Math.Pow(1 + i, n))) + (g / i) * (((Math.Pow(1 + i, n) - 1) / (i * Math.Pow(1 + i, n))) - ((n) / (Math.Pow(1 + i, n))));
            txtResultado.Text = p.ToString("N2");
        }

        public void CalcularGradienteLinealDecreciente()
        {
            double a = double.Parse(txtPrimeraCuota.Text);
            double i = double.Parse(txtTipoInteres.Text) / 100;
            double n = double.Parse(txtIngresos.Text);
            double g = double.Parse(txtConstante.Text);

            double p = a * ((Math.Pow(1 + i, n) - 1) / (i * Math.Pow(1 + i, n))) + (g / i) * (((Math.Pow(1 + i, n) - 1) / (i * Math.Pow(1 + i, n))) - ((n) / (Math.Pow(1 + i, n))));
            txtResultado.Text = p.ToString("N2");
        }

        public void CalcularGradienteGeometricoCreciente()
        {
            double a = double.Parse(txtPrimeraCuota.Text);
            double i = double.Parse(txtTipoInteres.Text) / 100;
            double n = double.Parse(txtIngresos.Text);
            double j = double.Parse(txtVariacionPorcentual.Text);

            // formula cambiarla en un ciclo
            double p = a * (Math.Pow(1 + j, n) - Math.Pow(1 + i, n) / (j-i)* Math.Pow(1 + i, n));
            txtResultado.Text = p.ToString("N2");
        }

        public void CalcularGradienteGeometricoDecreciente()
        {
            double a = double.Parse(txtPrimeraCuota.Text);
            double i = double.Parse(txtTipoInteres.Text) / 100;
            double n = double.Parse(txtIngresos.Text);
            double j = double.Parse(txtVariacionPorcentual.Text);

            // formula cambiarla en un ciclo
            double G = a * (1 - Math.Pow((1 + j), n)) / (1 - (1 + j) / (1 + i));
            txtResultado.Text = G.ToString("N2");
        }

        public void CalcularGradienteEscalonadooEscalera()
        {
            double a = double.Parse(txtPrimeraCuota.Text);
            double i = double.Parse(txtTipoInteres.Text) / 100;
            double n = double.Parse(txtIngresos.Text);
            double TEA = double.Parse(txtTEA.Text);

            // formula cambiarla en un ciclo
            // add mas campos
            double G = a * (1 - Math.Pow((1 + TEA), n)) / (1 - (1 + TEA) / (1 + i));
            txtResultado.Text = G.ToString("N2");
        }

        private void btnPrimeraCuota_Click(object sender, EventArgs e)
        {
            MessageWarning("La Primera Cuota de Gradientes es el valor inicial o el primer pago en una serie de pagos que aumentan o disminuyen de manera constante.");
        }

        private void btnTasaInteres_Click(object sender, EventArgs e)
        {
            MessageWarning("Es el precio del dinero, esto es, lo que se paga por emplear una cantidad de dinero durante un plazo determinado");
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageWarning("Los Ingresos de Gradientes se refieren a una serie de pagos o ingresos que aumentan o disminuyen de manera constante en cada período.");
        }

        private void btnConstante_Click(object sender, EventArgs e)
        {
            MessageWarning("La Constante de Gradientes se refiere al valor que cambia de manera constante en cada período en una serie de pagos o ingresos.");
        }

        private void btnTEA_porcentaje_Click(object sender, EventArgs e)
        {
            MessageWarning("TEA (Tasa Efectiva Anual) es la tasa de interés que se capitaliza una vez al año. Es el porcentaje de dinero que se debe pagar o " +
                "que se puede ganar sobre el monto total de un préstamo o inversión en un año");

            MessageWarning("La Variación Porcentual de Gradientes es el cambio que experimenta una variable expresado en forma de porcentaje.");
        }
    }
}