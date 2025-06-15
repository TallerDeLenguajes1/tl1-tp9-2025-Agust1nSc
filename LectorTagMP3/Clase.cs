namespace EspacioCancion
{
    public class cancion
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Anio { get; set; }

        public cancion(string titulo, string artista, string album, string anio)
        {
            Titulo = titulo;
            Artista = artista;
            Album = album;
            Anio = anio;
        }

        public void mostrar()
        {
            Console.WriteLine("Informacion del archivo MP3");
            Console.WriteLine("Titulo: " + Titulo);
            Console.WriteLine("Artista: " + Artista); 
            Console.WriteLine("Album: " + Album); 
            Console.WriteLine("Anio: " + Anio); 
        }
    }
}