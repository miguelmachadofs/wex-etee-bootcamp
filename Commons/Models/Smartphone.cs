namespace Commons.Models
{
    abstract public class Smartphone
    {
        public string Numero { get; set; }
        public string Modelo { get; set; }
        public string IMEI { get; set; }
        public int Memoria { get; set; }

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }

        static public void Ligar()
        {
            Console.WriteLine("\nFazendo ligação...");
        }

        static public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        abstract public void InstalarAplicativo(string nomeAplicativo);
    }
}