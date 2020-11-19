using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace OrdenamientoObjetos
{
    public partial class Form1 : Form
    {
        ClaseListaDoble<Estudiante> lista, temporal;
        Estudiante estudiante = new Estudiante();
        public Form1()
        {
            InitializeComponent();
            lista = new ClaseListaDoble<Estudiante>(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Estudiante es = new Estudiante();
                es.Nombre = txtNombre.Text;
                es.ID = int.Parse(txtId.Text);
                es.Grado = $"{txtGrado.Text}";
                es.Grupo = $"{txtGrupo.Text}";
                if(rdbMasculino.Checked)
                {
                    es.Genero = "Masculino";
                }else
                {
                    es.Genero = "Femenino";
                }
                lista.AgregarNodo(es);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void AgregarTabla(ClaseListaDoble<Estudiante> x)
        {
            Tabla.Rows.Clear();
            foreach (Estudiante es in x)
            {
                Tabla.Rows.Add(es.Nombre,es.ID,es.Genero,es.Grado,es.Grupo);
            }
        }

        private void btnAleatorio_Click(object sender, EventArgs e)
        {
            try
            {
                var random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var value = random.Next(1, 200);
                    var opc = random.Next(1, 4);
                    Estudiante Aux = new Estudiante();
                    Aux.Nombre = RandomString(4);
                    Aux.ID = value;
                    Aux.Genero = "Masculino";
                    Aux.Grado = $"{opc}";
                    Aux.Grupo = "a";
                    lista.AgregarNodo(Aux);
                    AgregarTabla(lista);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex}");
            }
        }
        string RandomString(int lengt)
        {
            var random = new Random();

            string cadena = "";

            for (int i = 0; i < lengt; i++)
            {
                var value = random.Next(1, 26);
                cadena += $"{NextLetra(value)}";
            }
            return cadena;

        }
        string NextLetra(int letra)
        {
            switch (letra)
            {
                case 1:
                    return "a";
                case 2:
                    return "b";
                case 3:
                    return "c";
                case 4:
                    return "d";
                case 5:
                    return "e";
                case 6:
                    return "f";
                case 7:
                    return "g";
                case 8:
                    return "h";
                case 9:
                    return "i";
                case 10:
                    return "j";
                case 11:
                    return "k";
                case 12:
                    return "l";
                case 13:
                    return "m";
                case 14:
                    return "n";
                case 15:
                    return "o";
                case 16:
                    return "p";
                case 17:
                    return "q";
                case 18:
                    return "r";
                case 19:
                    return "s";
                case 20:
                    return "t";
                case 21:
                    return "u";
                case 22:
                    return "v";
                case 23:
                    return "w";
                case 24:
                    return "x";
                case 25:
                    return "y";
                case 26:
                    return "z";
                default:
                    throw new Exception("Fuera del rango");
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            Stopwatch tim = new Stopwatch();
            tim.Start();
            int c = lista.ContarNodos();
            int[] Numero = new int[c];
            int i=0;
            foreach (Estudiante es in lista)
            {
                Numero[i] = es.ID;
                i++;
            }
            try
            {
                temporal = new ClaseListaDoble<Estudiante>(true);
                OrdenamientoRapido(Numero, c);
                for (int j = 0; j < Numero.Length; j++)
                {
                    Estudiante estudiante = new Estudiante();
                    estudiante.ID = Numero[j];
                    temporal.AgregarNodo(lista.BuscarNodo(estudiante));
                }
                tim.Stop();AgregarTabla(temporal);
                MessageBox.Show($"Tiempo: {tim.Elapsed.TotalMilliseconds} ms");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static int cont;
        private static int OrdenamientoRapido(int[] datos, int numero)
        {
            cont = 0;
            OrdenamientoRapido(datos, 0, numero - 1);
            return cont;
        }
        public static void OrdenamientoRapido(int[] datos, int inf, int sup)
        {
            if (sup > inf)
            {
                int pivote = datos[sup];
                int i = inf - 1;
                int j = sup;
                do
                {
                    while (datos[++i] < pivote) ;
                    while (datos[--j] > pivote) ;
                    if (i < j)
                        swap(datos, i, j);
                }
                while (i < j);
                swap(datos, i, sup);
                OrdenamientoRapido(datos, inf, i - 1);
                OrdenamientoRapido(datos, i + 1, sup);
            }
        }
        public static void swap(int[] datos, int i, int j)
        {
            int aux = datos[i];
            datos[i] = datos[j];
            datos[j] = aux;
            cont++; // variable global
        }
    }
}
