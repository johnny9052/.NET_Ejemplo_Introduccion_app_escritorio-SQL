using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Imports adicionales
using Platform.Object.Model;
using Platform.Service.Services;

namespace Platform.Comunication.Controllers
{
    public class CtlEstudiante
    {

        public bool SolicitudGuardar(String codigo, String nombre, String apellido, 
            int edad, String carrera, int semestre)
        {
            ClsEstudiante estudiante = new ClsEstudiante(codigo, nombre, apellido, edad, carrera, semestre);
            EstudianteDAO estDAO = new EstudianteDAO();
            return estDAO.guardarEstudiante(estudiante);
        }


        public ClsEstudiante SolicitudBuscar(String codigo)
        {
            EstudianteDAO estDAO = new EstudianteDAO();
            return estDAO.buscarEstudiante(codigo);
        }


        public bool SolicitudModificar(String codigo, String nombre, String apellido, int edad, String carrera, int semestre)
        {
            ClsEstudiante estudiante = new ClsEstudiante(codigo, nombre, apellido, edad, carrera, semestre);
            EstudianteDAO estDAO = new EstudianteDAO();
            return estDAO.modificarEstudiante(estudiante);
        }


        public bool solicitudEliminar(String codigo)
        {
            EstudianteDAO estDAO = new EstudianteDAO();
            return estDAO.eliminarEstudiante(codigo);
        }
    }
}
