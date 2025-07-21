namespace Commons.Models
{
    public class Estacionamento
    {
        public decimal PrecoEntrada { get; set; }
        public decimal PrecoHora { get; set; }
        public List<VeiculoEstacionamento> Veiculos { get; set; } = new List<VeiculoEstacionamento>();

        public Estacionamento(decimal precoEntrada, decimal precoHora)
        {
            PrecoEntrada = precoEntrada;
            PrecoHora = precoHora;
        }

        public void CadastrarVeiculo(string placa)
        {
            Veiculos.Add(new VeiculoEstacionamento(placa));
        }

        public bool RemoverVeiculo(VeiculoEstacionamento veiculo)
        {
            return Veiculos.Remove(veiculo);
        }

        public void ListarVeiculos()
        {
            if (!Veiculos.Any())
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
            }
            else
            {
                Console.WriteLine("Veículos cadastrados:");
                foreach (VeiculoEstacionamento veiculo in Veiculos)
                {
                    Console.WriteLine($"{veiculo.Placa}");
                }
            }
        }

        public decimal CalcularValorTotal(DateTime dataEntrada)
        {
            //Utilizado os segundos como teste, para que o valor fique maior
            int segundosEstacionado = (DateTime.Now - dataEntrada).Seconds;
            return PrecoEntrada + (PrecoHora * segundosEstacionado);
        }
    }
}