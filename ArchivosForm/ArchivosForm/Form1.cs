using ArchivosForm.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchivosForm
{
    public partial class lbResultados : Form
    {
        public static object Items { get; private set; }

        public lbResultados()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream mArchivoEscritor = new FileStream("datos.dat", FileMode.OpenOrCreate, FileAccess.Write))
                using (BinaryWriter escritor = new BinaryWriter(mArchivoEscritor))
                {
                    // Leemos los valores de los TextBoxes
                    string nombre = tbNombre.Text;
                    int edad = int.Parse(tbEdad.Text);
                    int nota = int.Parse(tbNota.Text);
                    char genero = char.Parse(tbGenero.Text);

                    // Escribimos los valores en el archivo binario
                    escritor.Write(nombre.Length); // Escribimos la longitud del nombre
                    escritor.Write(nombre.ToCharArray()); // Escribimos el nombre como arreglo de caracteres
                    escritor.Write(edad); // Escribimos la edad
                    escritor.Write(nota); // Escribimos la nota
                    escritor.Write(genero); // Escribimos el genero
                }

                MessageBox.Show("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}");
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear(); // Limpiamos el listbox

            using (FileStream mArchivoLector = new FileStream("datos.dat", FileMode.Open, FileAccess.Read))
            using (BinaryReader lector = new BinaryReader(mArchivoLector))
            {
                while (mArchivoLector.Position != mArchivoLector.Length)
                {
                    int length = lector.ReadInt32(); // Leemos la longitud del nombre
                    char[] nombreArray = lector.ReadChars(length); // Leemos el nombre
                    string nombre = new string(nombreArray); // Convertimos a string
                    int edad = lector.ReadInt32();
                    int nota = lector.ReadInt32();
                    char genero = lector.ReadChar();

                    // Agregamos los datos al listbox
                    lbResultados.Items.Add($"Nombre: {nombre}, Edad: {edad}, Nota: {nota}, Género: {genero}");
                }
            }

            MessageBox.Show("Datos leídos correctamente.");
        }
    }
    }