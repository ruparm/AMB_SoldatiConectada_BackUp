using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Sistema_de_Gestion;

namespace Comunicación_entre_forms
{
    public partial class FrmSocio : Form
    //CREO UN OBJETO DENTRO DEL FORMULARIO PRINCIPAL DEL TIPO SOCIO, PúBLICO, PARA QUE EL OBJETO ENCAPSULADO
    //EN EL FORMULARIO PUEDA VERSE DESDE AFUERA
    {
        Socies socioFormulario;
        public FrmSocio()
        {
            InitializeComponent();
            socioFormulario = null;
        }

        //AGREGO NUEVO CTOR PARA MODIFICAR LOS DATOS DEL EMPLEADO

        public FrmSocio (Socies modifica)
        {
            InitializeComponent();
            socioFormulario = modifica;            
            txtApellido.Text = socioFormulario.Apellido;
            txtNombre.Text = socioFormulario.Nombre;
            txtPlan.Text = socioFormulario.Plan;
            txtFechaAlta.Text = socioFormulario.FechaAlta;
        }
        public Socies SocioFormulario
        { 
            get
            {
                return socioFormulario; 
            }

        }

        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //CREO UNA NUEVA INSTANCIA SI Y SOLO SI ESTA VACIO EL FORM, SINO ES UN MODIFICAR 
            try
            {
                if (socioFormulario==null)
                {
                    int idSocie = Socies_ADO.LeerSiguienteID();                    
                    string apellido = txtApellido.Text;
                    string nombre = txtNombre.Text;
                    string plan = txtPlan.Text;
                    string fechaAlta = txtFechaAlta.Text;

                    socioFormulario = new Socies(idSocie,  apellido, nombre, plan, fechaAlta);                  

                }
                else
                {
                    
                    socioFormulario.Apellido = txtApellido.Text;
                    socioFormulario.Nombre = txtNombre.Text;
                    socioFormulario.Plan = txtPlan.Text;
                    socioFormulario.FechaAlta = txtFechaAlta.Text;
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }          
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlan_Validating(object sender, CancelEventArgs e)
        { 
            string plan = txtPlan.Text;   //VER VALIDACIÓN 

            //try
            //{
            //    if (string.IsNullOrEmpty(plan)) && (plan != "30MB"||"100MB"))
            //    {
            //        e.Cancel = true;
            //        MessageBox.Show("Los Planes válidos son 30MB o 100MB", "Error", MessageBoxButtons.OK);

            //    }

            //}
            //catch (FormatException ex)
            //{
            //    MessageBox.Show(ex.Message);
                
            //}
        }
    }
}
