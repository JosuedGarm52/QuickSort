using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenamientoObjetos
{
    public class Estudiante: IComparable<Estudiante>, IEquatable<Estudiante>
    { 
        public Estudiante()
        {
            
        }
        private int _intID;

        public int ID
        {
            get { return _intID; }
            set { _intID = value; }
        }
        
        private string _strNombreEmpleado;

        public string Nombre
        {
            get { return _strNombreEmpleado; }
            set { _strNombreEmpleado = value; }
        }
        
        private string _strGrupo;

        public string Grupo
        {
            get { return _strGrupo; }
            set { _strGrupo = value; }
        }
        private string _strGrado;

        public string Grado
        {
            get { return _strGrado; }
            set { _strGrado = value; }
        }


        private string _strGenero;

        public string Genero
        {
            get { return _strGenero; }
            set { _strGenero = value; }
        }


        ~Estudiante()
        {

        }
        public override string ToString()
        {
            return $"Nombre: {this.Nombre} \nNumero ID: {this.ID}\nGenero: {this.Genero}\nGrupo: {this.Grupo}\nGrado: {this.Grado}";     
        }

        public int CompareTo(Estudiante other)
        {
            if (this.ID < other.ID)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public bool Equals(Estudiante obj)
        {
            if ((obj.ID == this.ID))//|| !this.GetType().Equals(obj.GetType()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
