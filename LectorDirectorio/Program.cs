Console.WriteLine("Ingrese un path para validar");
string path = Console.ReadLine() ?? "";

while (!Directory.Exists(path))
{
    Console.WriteLine("El path ingresado es invalido");
    path = Console.ReadLine() ?? "";
}

string[] carpetas = Directory.GetDirectories(path);

foreach (string carpeta in carpetas)
{
    Console.WriteLine("Carpeta: " + Path.GetFileName(carpeta));
}

string[] archivos = Directory.GetFiles(path);
List<string> lineasCSV = new List<string>();

foreach (string archivo in archivos)
{
    FileInfo informacionArchivo = new FileInfo(archivo);
    long tamanioBytes = informacionArchivo.Length;
    double tamanio = tamanioBytes / 1024;

    Console.WriteLine("Archivo: " + Path.GetFileName(archivo) + " KB: " + tamanio);

    string nombreArchivo = Path.GetFileName(archivo);
    string tamanioArchivo = tamanio.ToString();
    string fecha = Directory.GetLastWriteTime(archivo).ToString();

    lineasCSV.Add($"{nombreArchivo},{tamanioArchivo},{fecha}");
}

string rutaRelativa = Path.Combine(path, "reporte_archivos.csv");

if (!File.Exists(rutaRelativa))
{
    File.Create(rutaRelativa).Close();
}

File.WriteAllLines(rutaRelativa, lineasCSV);