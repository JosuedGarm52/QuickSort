using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoForma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Fila, Columna;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                Fila = int.Parse(txtFila.Text);
                Columna = int.Parse(txtColumna.Text);
                if(Fila<=0||Columna<=0)
                {
                    throw new Exception("Los valores deben ser mayores a 0");
                }
                Form2 fm = new Form2(Fila,Columna);
                fm.Show();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Debe llenar todos los recuadros", "Error");
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduce un valor valido");
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex, "");
            }
        }
    }
}
