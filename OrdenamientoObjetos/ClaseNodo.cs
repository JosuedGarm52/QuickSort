using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenamientoObjetos
{
    public class ClaseNodo<Tipo>
    {
        public ClaseNodo()
        {

        }
        Tipo _ObjetoConDatos;

        public Tipo ObjetoConDatos
        {
            get { return _ObjetoConDatos; }
            set { _ObjetoConDatos = value; }
        }
        private ClaseNodo<Tipo> _Siguente;

        public ClaseNodo<Tipo> Siguiente
        {
            get { return _Siguente; }
            set { _Siguente = value; }
        }
        private ClaseNodo<Tipo> _Previo;

        public ClaseNodo<Tipo> Previo
        {
            get { return _Previo; }
            set { _Previo = value; }
        }
        ~ClaseNodo()
        {
            ObjetoConDatos = default(Tipo);
        }
    }
}
