using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Imports adicionales
using Platform.Comunication.Controllers;
using Platform.Object.Model;

namespace EjemploConexionBasicaBD
{
    public partial class FormEstudiante : Form
    {

        CtlEstudiante controller;
        ClsValidaciones validacion;


        public FormEstudiante()
        {
            InitializeComponent();
            controller = new CtlEstudiante();
            validacion = new ClsValidaciones();
        }


        #region control de eventos click

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            String carrera = txtCarrera.Text;
            int edad = Convert.ToInt32((!txtEdad.Text.Equals("")) ? txtEdad.Text : "0");
            int semestre = Convert.ToInt32((!txtSemestre.Text.Equals("")) ? txtSemestre.Text : "0");

            if (!nombre.Equals("") && !codigo.Equals(""))
            {

                if (controller.SolicitudGuardar(codigo, nombre, apellido, edad, carrera, semestre))
                {
                    MessageBox.Show("Almacenado con exito");
                    limpiar();
                    listarEstudiantes();
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
            }
            else
            {
                MessageBox.Show("Ingrese como minimo el codigo y el nombre del estudiante");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Equals(""))
            {
                String codigo = txtCodigo.Text;

                ClsEstudiante estudiante = controller.SolicitudBuscar(codigo);

                if (!estudiante.codigo.Equals(""))
                {
                    txtCodigo.Enabled = false;
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    cargarInformacion(estudiante);
                }
                else
                {
                    limpiar();
                    MessageBox.Show("El registro no existe");
                    txtCodigo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el valor de busqueda");
            }
        }
        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            String carrera = txtCarrera.Text;
            int edad = Convert.ToInt32((!txtEdad.Text.Equals("")) ? txtEdad.Text : "0");
            int semestre = Convert.ToInt32((!txtSemestre.Text.Equals("")) ? txtSemestre.Text : "0");

            if (controller.SolicitudModificar(codigo, nombre, apellido, edad, carrera, semestre))
            {
                MessageBox.Show("Actualizado con exito");
                limpiar();
                listarEstudiantes();
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;

            if (controller.solicitudEliminar(codigo))
            {
                MessageBox.Show("Eliminado con exito");
                limpiar();
                listarEstudiantes();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        #endregion

        #region funciones varias


        public void cargarInformacion(ClsEstudiante estudiante)
        {
            txtCodigo.Text = estudiante.codigo;
            txtNombre.Text = estudiante.nombre;
            txtApellido.Text = estudiante.apellido;
            txtEdad.Text = estudiante.edad.ToString();
            txtCarrera.Text = estudiante.carrera;
            txtSemestre.Text = estudiante.semestre.ToString();
        }



        public void limpiar()
        {
            txtCodigo.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtCarrera.Text = "";
            txtSemestre.Text = "";
        }


        public void listarEstudiantes()
        {
            //ESTO SE GENERA AUTOMATICAMENTE AL AGREGAR EL GRID
            // TODO: esta línea de código carga datos en la tabla 'ejemploConexionBDDataSet.estudiante' Puede moverla o quitarla según sea necesario.
            this.estudianteTableAdapter.Fill(this.ejemploConexionBDDataSet.estudiante);
        }

        #endregion

        #region validaciones de los campos

        private void txtInput_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { // si es enter
                e.Handled = true; //no ponga el enter en el campo de text
                SendKeys.Send("{TAB}");//se manda un TAB a la interfaz
            }
            else
            {
                e.Handled = false; //ponga el valor ingresado en el campo de text
            }
        }

        private void txtInputNumber_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { // si es enter
                e.Handled = true; //no ponga el enter en el campo de text
                SendKeys.Send("{TAB}");//se manda un TAB a la interfaz
            }
            else
            {
                e.Handled = validacion.numeros(e.KeyChar); //ponga el valor ingresado en el campo de text
            }
        }

        #endregion 

        

        private void FormEstudiante_Load(object sender, EventArgs e)
        {
            listarEstudiantes();
        }
    }
}
