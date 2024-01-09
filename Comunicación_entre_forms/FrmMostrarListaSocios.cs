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
    public partial class FrmMostrarListaSocios : Form
    {
        List<Socies> lista; 

        public FrmMostrarListaSocios(List<Socies> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FrmMostrarListaSocios_Load_1(object sender, EventArgs e)
        {
            CargarListBox();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = lstSocies.SelectedIndex;
                Socies socioModificar = lista[indice];
                FrmSocio formModificar = new FrmSocio(socioModificar);

                if (formModificar.ShowDialog() == DialogResult.OK)
                {
                       lista[indice] = formModificar.SocioFormulario;
                       Socies_ADO.Modificar(lista[indice]);
                       MessageBox.Show("Datos del socio actualizados correctamente");

                }
                else
                {
                    MessageBox.Show("Acción cancelada");
                }

                CargarListBox();

                Socies_ADO.Modificar(socioModificar);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error");
            }
        }

        public void CargarListBox()
        {
            try
            {
                lstSocies.Items.Clear();

                foreach (Socies socies in lista)
                {
                    lstSocies.Items.Add(socies.ToString());

                }                

            }
            catch (Exception ex)
            {

               MessageBox.Show("Error al cargar la lista de socios");
            }

                      

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstSocies.SelectedIndex;
                Socies socioModificar = lista[index];

                FrmSocio formModificar = new FrmSocio(socioModificar);

                
                if (MessageBox.Show("Seguro desea eliminar el socio?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                     if (formModificar.ShowDialog() == DialogResult.OK)
                     {
                        lista.RemoveAt(index);
                        
                        Socies_ADO.Eliminar(socioModificar.IdSocie);
                        CargarListBox();
                     }
                }   
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
