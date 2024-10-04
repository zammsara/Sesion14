using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivosForm.models
{
    public class Estudiante
    {
        
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Nota { get; set; }
        public char Genero { get; set; }

        // Constructor 
        public Estudiante() { }

        // Constructor para inicializar el estudiante con valores
        public Estudiante(string nombre, int edad, int nota, char genero)
        {
            Nombre = nombre;
            Edad = edad;
            Nota = nota;
            Genero = genero;
        }

        // Metodo ToString para presentar los datos en un formato adecuado
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, Nota: {Nota}, Género: {Genero}";
        }

        // Metodo para guardar los datos en formato binario
        public void EscribirEnBinario(BinaryWriter escritor)
        {
            escritor.Write(Nombre.Length); // Escribimos la longitud del nombre
            escritor.Write(Nombre.ToCharArray()); // Escribimos el nombre como arreglo de caracteres
            escritor.Write(Edad); // Escribimos la edad
            escritor.Write(Nota); // Escribimos la nota
            escritor.Write(Genero); // Escribimos el genero
        }

        // Metodo estatico para leer los datos de un archivo binario
        public static Estudiante LeerDeBinario(BinaryReader lector)
        {
            int length = lector.ReadInt32(); // Leemos la longitud del nombre
            char[] nombreArray = lector.ReadChars(length); // Leemos el nombre como un arreglo de caracteres
            string nombre = new string(nombreArray); // Convertimos a string
            int edad = lector.ReadInt32(); // Leemos la edad
            int nota = lector.ReadInt32(); // Leemos la nota
            char genero = lector.ReadChar(); // Leemos el genero

            // Retornamos un nuevo objeto Estudiante con los datos leidos
            return new Estudiante(nombre, edad, nota, genero);
        }
    }
}
