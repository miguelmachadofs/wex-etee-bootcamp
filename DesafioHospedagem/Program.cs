using Commons.Models;

Pessoa p1 = new(nome: "Hospede", sobrenome: "1");
Pessoa p2 = new(nome: "Hospede", sobrenome: "2");

Suite suite = new(tipoSuite: "Premium", capacidade: 5, valorDiaria: 300M);

Reserva reserva = new(suite: suite, diasReservados: 10);
reserva.CadastrarHospede(hospede: p1);
reserva.CadastrarHospede(hospede: p2);

Console.WriteLine($"Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor total da Hospedagem: {reserva.CalcularValorReserva()}");
