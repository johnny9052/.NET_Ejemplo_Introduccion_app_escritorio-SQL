using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Imports adicionales
using Platform.Object.Model;

namespace Platform.Service.Services
{
    public class EstudianteDAO : ClsConexion
    {

        ClsEstudiante estudiante = new ClsEstudiante();


        public bool guardarEstudiante(ClsEstudiante estudiante)
        {
            String consulta = "exec guardarEstudiante '" + estudiante.codigo +
                "','" + estudiante.nombre + "','" + estudiante.apellido + "'," +
                estudiante.edad + ",'" + estudiante.carrera + "'," +
                estudiante.semestre + ";";
            return ejecutar(consulta);
        }


        public ClsEstudiante buscarEstudiante(String codigo)
        {
            String consulta = "exec buscarEstudiante '" + codigo + "';";
            ejecutarRetorno(consulta);
           
            if (dataset.Tables[0].Rows.Count == 0)
            {
                dataset.Dispose();                
            }
            else
            {
                estudiante.codigo = dataset.Tables[0].Rows[0]["codigo"].ToString();
                estudiante.nombre = dataset.Tables[0].Rows[0]["nombre"].ToString();
                estudiante.apellido = dataset.Tables[0].Rows[0]["apellido"].ToString();
                estudiante.edad = Convert.ToInt32(dataset.Tables[0].Rows[0]["edad"].ToString());
                estudiante.carrera = dataset.Tables[0].Rows[0]["carrera"].ToString();
                estudiante.semestre = Convert.ToInt32(dataset.Tables[0].Rows[0]["semestre"].ToString());
                dataset.Dispose();                
            }

                     
            return estudiante;
        }


        public bool modificarEstudiante(ClsEstudiante estudiante)
        {
            String consulta = "exec modificarEstudiante '" + estudiante.codigo + "','" + estudiante.nombre + "','" + estudiante.apellido + "'," + estudiante.edad + ",'" + estudiante.carrera + "'," + estudiante.semestre + ";";
            return ejecutar(consulta);
        }

        public bool eliminarEstudiante(String codigo)
        {
            String consulta = "exec eliminarEstudiante '" + codigo + "';";
            return ejecutar(consulta);
        }
    }
}
