namespace Commons.Models
{
    public class Nokia : Smartphone
    {
        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria) { }

        public override void InstalarAplicativo(string nomeAplicativo)
        {
            Console.WriteLine($"Instalando aplicativo {nomeAplicativo} no Smartphone Nokia.");
        }
    }
}