namespace Commons.Models
{
    public class VeiculoEstacionamento
    {
        public string Placa { get; set; }
        public DateTime DataEntrada { get; set; }

        public VeiculoEstacionamento(string placa)
        {
            Placa = placa;
            DataEntrada = DateTime.Now;
        }
    }
}