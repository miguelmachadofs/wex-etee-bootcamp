using Commons.Models;

Console.WriteLine("Bem-vindo ao sistema de Hospedagem do Hotel!\n");

// Loop para obtenção de uma quantidade válida de dias para hospedagem
bool quantidadeDiasEhValida;
int diasHospedagem = 0;
do
{
    Console.WriteLine("Serão quantos dias de Hospedagem?");
    string diasHospedagemInformado = Console.ReadLine() ?? string.Empty;
    if (diasHospedagemInformado == string.Empty || !int.TryParse(diasHospedagemInformado, out diasHospedagem) || diasHospedagem == 0)
    {
        quantidadeDiasEhValida = false;
        Console.WriteLine("\nPor favor, informe a quantidade de dias da Hospedagem.");
    }
    else
    {
        quantidadeDiasEhValida = true;
    }

} while (!quantidadeDiasEhValida);

// Loop para obtenção de uma quantidade de hóspedes válida
bool quantidadeHospedesEhValida;
int quantidadeHospedes = 0;
do
{
    Console.WriteLine("\nDeseja realizar uma reserva para quantas pessoas?");
    string quantidadeHospedesInformada = Console.ReadLine() ?? string.Empty;
    if (quantidadeHospedesInformada == string.Empty || !int.TryParse(quantidadeHospedesInformada, out quantidadeHospedes) || quantidadeHospedes == 0)
    {
        quantidadeHospedesEhValida = false;
        Console.WriteLine("\nPor favor, informe a quantidade de pessoas que ficarão no quarto.");
    }
    else
    {
        quantidadeHospedesEhValida = true;
    }

} while (!quantidadeHospedesEhValida);

//Loop para obtenção e validação do Nome e Sobrenome dos Hóspedes
string nomeHospede;
string sobrenomeHospede;
List<Pessoa> hospedes = new();

Console.WriteLine($"\nAbaixo, informe o Nome e Sobrenome {(quantidadeHospedes == 1 ? "do(a) Hóspede que ficará no quarto" : "dos(as) Hóspedes que ficarão no quarto")}.");

for (int contador = 1; contador <= quantidadeHospedes; contador++)
{
    do
    {
        Console.WriteLine($"\n{(quantidadeHospedes == 1 ? "Nome" : $"Nome do(a) {contador}° Hóspede")}: ");
        nomeHospede = Console.ReadLine() ?? string.Empty;
        if (nomeHospede == string.Empty)
        {
            Console.WriteLine("Nome não pode estar vazio.");
        }
    } while (nomeHospede == string.Empty);

    do
    {
        Console.WriteLine($"\n{(quantidadeHospedes == 1 ? "Sobrenome" : $"Sobrenome do(a) {contador}° Hóspede")}: ");
        sobrenomeHospede = Console.ReadLine() ?? string.Empty;
        if (sobrenomeHospede == string.Empty)
        {
            Console.WriteLine("Sobrenome não pode estar vazio.");
        }
    } while (sobrenomeHospede == string.Empty);

    //Cria e Adiciona o novo hóspede
    Pessoa hospede = new(nome: nomeHospede, sobrenome: sobrenomeHospede);
    hospedes.Add(hospede);
}

// Instancia o quarto a ser utilizado pelos hóspedes
Suite suite = new(tipoSuite: "Premium", capacidade: 5, valorDiaria: 300M);

// Cria a reserva com os dados obtidos
Reserva reserva = new(diasReservados: diasHospedagem, suite: suite, hospedes: hospedes);

Console.WriteLine($"\nQuantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor total da Hospedagem: {reserva.CalcularValorReserva()}");