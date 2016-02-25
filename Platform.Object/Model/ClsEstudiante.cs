using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Object.Model
{
    public class ClsEstudiante
    {

        #region definicion atributos

        public String codigo { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }
        public String carrera { get; set; }
        public int semestre { get; set; }

        #endregion 


        #region constructores

        public ClsEstudiante()
        {
            codigo = "";
        }

        public ClsEstudiante(String codigo, String nombre, String apellido, int edad, String carrera, int semestre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.carrera = carrera;
            this.semestre = semestre;
        }

        #endregion 

    }
}
