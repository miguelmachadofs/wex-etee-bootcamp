using Commons.Models;

class Program
{
    static void Main()
    {
        const int precoEntradaPadrao = 5; // Preço de entrada padrão
        const int precoHoraPadrao = 2; // Preço por hora padrão
        Estacionamento estacionamento = new Estacionamento(precoEntradaPadrao, precoHoraPadrao);

        Console.WriteLine("Bem-vindo ao sistema de estacionamento!");
        ExibirMenu();

        string opcao = Console.ReadLine() ?? "";
        string placa = string.Empty;

        do
        {
            switch (opcao)
            {
                case "1":
                    // Obtém e Valida a placa do veículo a ser cadastrado
                    if (PlacaVeiculoEhValida(PerguntaPlacaVeiculo(ref placa)))
                    {
                        // Verifica se o veículo já está cadastrado
                        // Se não estiver, cadastra o veículo no estacionamento
                        if (!VeiculoEstaCadastrado(placa, estacionamento.Veiculos))
                        {
                            estacionamento.CadastrarVeiculo(placa);
                        }
                        else
                        {
                            Console.WriteLine("Veículo já cadastrado.");
                        }
                    }
                    break;
                case "2":
                    // Obtém e Valida a placa do veículo a ser retirado
                    if (PlacaVeiculoEhValida(PerguntaPlacaVeiculo(ref placa)))
                    {
                        // Verifica se o veículo está cadastrado
                        // Se estiver, calcula o valor total a pagar e remove o veículo do estacionamento
                        if (VeiculoEstaCadastrado(placa, estacionamento.Veiculos))
                        {
                            var veiculo = estacionamento.Veiculos.FirstOrDefault(v => v.Placa == placa);
                            if (veiculo != null)
                            {
                                // Calcular o valor total a pagar
                                decimal valorTotal = estacionamento.CalcularValorTotal(veiculo.DataEntrada);
                                Console.WriteLine($"Valor total a pagar: R$ {valorTotal:F2}");
                                Console.ReadLine(); // Espera o usuário pressionar Enter para continuar
                                Console.WriteLine($"Veículo com placa {placa} disponível para retirada.");

                                // Remover o veículo do estacionamento
                                estacionamento.RemoverVeiculo(veiculo);
                            }
                            else
                            {
                                Console.WriteLine("ERRO: Veículo não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veículo não encontrado. Verifique a placa e tente novamente.");
                        }
                    }
                    break;
                case "3":
                    estacionamento.ListarVeiculos();
                    break;
                case "4":
                    Console.WriteLine("Encerrando o sistema de estacionamento. Até logo!");
                    return; // Encerra o programa
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            ExibirMenu();
            opcao = Console.ReadLine() ?? "";
        } while (opcao != "4");

    }

    private static void ExibirMenu()
    {
        Console.WriteLine("1 - Cadastrar veículo");
        Console.WriteLine("2 - Pagar e Retirar veículo");
        Console.WriteLine("3 - Listar veículos");
        Console.WriteLine("4 - Encerrar");
        Console.WriteLine("Digite a opção escolhida, abaixo:");
    }

    private static bool VeiculoEstaCadastrado(string placa, List<VeiculoEstacionamento> veiculos)
    {
        return veiculos.Any(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
    }

    private static string PerguntaPlacaVeiculo(ref string placa)
    {
        // Obtém a placa do veículo informada pelo usuário
        Console.WriteLine("Digite a placa do veículo:");
        placa = Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;
        return placa;
    }

    private static bool PlacaVeiculoEhValida(string placa)
    {
        if (string.IsNullOrEmpty(placa))
        {
            Console.WriteLine("Placa inválida. A placa não pode ser vazia.");
            return false;
        }
        return true;
    }
}