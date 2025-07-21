namespace Commons.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; } = new();
        public Suite Suite { get; set; } = new();
        public int DiasReservados { get; set; }

        public Reserva(int diasReservados, Suite suite, List<Pessoa> hospedes)
        {
            DiasReservados = diasReservados;
            Suite = suite;
            Hospedes = hospedes;
        }

        public void CadastrarHospede(Pessoa hospede)
        {
            Hospedes.Add(hospede);
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorReserva()
        {
            // A partir de 10 dias de hospedagem, é gerado um desconto de 10% no valor total final
            if (DiasReservados >= 10)
            {
                // Calcula 10% do valor total usando Math.Round para duas casas decimais
                decimal desconto = Math.Round(Suite.ValorDiaria * DiasReservados * 0.10m, 2);
                // Retorna o valor total com o desconto
                return (Suite.ValorDiaria * DiasReservados) - desconto;
            }
            else
            {
                return Suite.ValorDiaria * DiasReservados;
            }
        }
    }
}