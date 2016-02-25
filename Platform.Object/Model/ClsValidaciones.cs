using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Object.Model
{
    public class ClsValidaciones
    {
        public bool numeros(char e)
        {
            String correctos = "1234567890\b";
            bool status;
            status = correctos.Contains(e);

            return !status;
        }
    }
}
