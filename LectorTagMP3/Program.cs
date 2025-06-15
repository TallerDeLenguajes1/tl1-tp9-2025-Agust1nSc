using System.Text;
using EspacioCancion;

string ruta = @"C:\Users\Agustin Saccone\AppData\Documents\My Games\cancion.mp3";

using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
{
    fs.Seek(-128, SeekOrigin.End);

    using (BinaryReader reader = new BinaryReader(fs, Encoding.GetEncoding("latin1")))
    {
        string encabezado = new string(reader.ReadChars(3));

        if (encabezado != "TAG")
        {
            Console.WriteLine("El archivo no contiene una etiqueta ID3v1 válida.");
            return;
        }

        string titulo = new string(reader.ReadChars(30)).Trim();
        string album = new string(reader.ReadChars(30)).Trim();
        string artista = new string(reader.ReadChars(30)).Trim();
        string anio = new string(reader.ReadChars(4)).Trim();

        cancion cancion = new cancion(titulo, album, artista, anio);
        cancion.mostrar(); 

    }
}




