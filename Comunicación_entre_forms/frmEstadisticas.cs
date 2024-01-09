using Proyecto_Sistema_de_Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comunicación_entre_forms
{
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas()
        {
            InitializeComponent();
        }

        private void btnSociosTotales_Click(object sender, EventArgs e)
        {
            List<Socies> nomina;
            nomina = Socies_ADO.TraerTodos();
            int cantidadid = 0;


            cantidadid = nomina.Count;

            MessageBox.Show($"la cantidad de socios es de: {cantidadid}");

        }

        private void btnFacturacionTotal_Click(object sender, EventArgs e)
        {
            List<Socies> nomina;
            nomina = Socies_ADO.TraerTodos();

            int cantidadTotalSocios = 0;

            cantidadTotalSocios += nomina.Count;
            int facturacionAnual;

            int costoServicioIndividual = 5000;

            facturacionAnual = (cantidadTotalSocios * costoServicioIndividual);

            MessageBox.Show($"La facturación anual es de: $ {facturacionAnual}");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
