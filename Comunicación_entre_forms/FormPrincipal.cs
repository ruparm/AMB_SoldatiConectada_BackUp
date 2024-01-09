using Proyecto_Sistema_de_Gestion;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using System.Xml.Serialization;



namespace Comunicación_entre_forms
{
    public partial class FormPrincipal : Form
    {
        //ATRIBUTO

        List<Socies> nomina;


        // CONSTRUCTOR
        public FormPrincipal()
        {
            InitializeComponent();
            nomina = new List<Socies>();
        }

        //METODOS

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSocio altaSocio = new FrmSocio();
                if (altaSocio.ShowDialog() == DialogResult.OK)
                {
                    nomina.Add(altaSocio.SocioFormulario);
                    Socies_ADO.Guardar(altaSocio.SocioFormulario);
                    MessageBox.Show("Socio cargado con éxito");

                }
                else
                {
                    MessageBox.Show("El usuario canceló la acción");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void leerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMostrarListaSocios mostrar = new FrmMostrarListaSocios(nomina);

                mostrar.Show();
                nomina = Socies_ADO.TraerTodos();

                Serializadora.Escribir(nomina, "misSocios.xml"); //ACTUALIZA LA NOMINA en el XML

            }
            catch (Exception)
            {
                MessageBox.Show("Problemas para escribir en archivo XML");
                this.Close();
            }


        }

        // UTILIZO INTERFAZ Y MODALES 
        private void FormPrincipal_Load(object sender, EventArgs e)
        {


            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            try
            {
                nomina = Socies_ADO.TraerTodos();
            }
            catch (Exception)
            {
                nomina = Serializadora.Leer("misSocios.xml");
                //nomina= Texto.LeerTexto(directorio, nombreArchivo);

            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string path = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\misSocios.xml";
            List<Socies> nominaXML = Serializadora.Leer(path);

            FrmMostrarListaSocios mostrar = new FrmMostrarListaSocios(nominaXML);
            mostrar.Show();

        }



        //PARA GUARDAR NOMINA en XML
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Serializadora.Escribir(nomina, "misSocios.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void btnTxt_Click(object sender, EventArgs e)
        {

                try
                {
                    string directorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    string nombreArchivo = @"\misSocios.txt";
                    string path = directorio + nombreArchivo;
                    
                    MessageBox.Show("Archivo creado con exito");

                    //while (nomina != null)
                    {
                        //nomina.Clear();
                        //nomina= Socies_ADO.TraerTodos();
                        Texto.EscribirTexto(directorio, nombreArchivo, nomina);
                        Texto.LeerTexto(directorio, nombreArchivo);
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el TXT");
                }
        }       

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticas misEstadisticas = new frmEstadisticas();
            misEstadisticas.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    
}





