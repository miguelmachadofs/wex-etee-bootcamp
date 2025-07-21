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
                    if (ObtemEValidaPlacaVeiculo(ref placa))
                    {
                        // Verifica se o veículo já está cadastrado
                        // Se não estiver, cadastra o veículo no estacionamento
                        if (BuscaVeiculo(placa, estacionamento.Veiculos) == null)
                        {
                            estacionamento.CadastrarVeiculo(placa);
                            Console.WriteLine($"Veículo com placa {placa} cadastrado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Veículo já cadastrado.");
                        }
                    }
                    break;
                case "2":
                    // Obtém e Valida a placa do veículo a ser retirado
                    if (ObtemEValidaPlacaVeiculo(ref placa))
                    {
                        // Verifica se o veículo está cadastrado
                        // Se estiver, calcula o valor total a pagar e remove o veículo do estacionamento
                        var veiculo = BuscaVeiculo(placa, estacionamento.Veiculos);
                        if (veiculo != null)
                        {
                            // Calcular o valor total a pagar
                            decimal valorTotal = estacionamento.CalcularValorTotal(veiculo.DataEntrada);
                            Console.WriteLine($"Valor total a pagar: R$ {valorTotal:F2}");
                            Console.ReadLine(); // Espera o usuário pressionar Enter para continuar
                            Console.WriteLine($"Veículo com placa {placa} disponível para retirada.");

                            // Remover o veículo do estacionamento
                            if (estacionamento.RemoverVeiculo(veiculo))
                            {
                                Console.WriteLine($"Veículo com placa {placa} removido com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine($"Não foi possível remover o veículo com placa {placa} do sistema.");
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
        Console.WriteLine("\n1 - Cadastrar veículo");
        Console.WriteLine("2 - Pagar e Retirar veículo");
        Console.WriteLine("3 - Listar veículos");
        Console.WriteLine("4 - Encerrar");
        Console.WriteLine("Digite a opção escolhida, abaixo:");
    }

    private static VeiculoEstacionamento? BuscaVeiculo(string placa, List<VeiculoEstacionamento> veiculos)
    {
        return veiculos.FirstOrDefault(v => v.Placa == placa);
    }

    private static bool ObtemEValidaPlacaVeiculo(ref string placa)
    {
        string retornoUsuario;
        do
        {
            // Obtém a placa do veículo informada pelo usuário
            Console.WriteLine("Digite a placa do veículo ou '0' para voltar ao menu:");
            retornoUsuario = Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;

            // Verifica se a placa é válida (não pode ser vazia)
            if (string.IsNullOrEmpty(retornoUsuario))
            {
                Console.WriteLine("Placa inválida. A placa não pode ser vazia.");
            }
            // Se o usuário digitar '0', retorna false e volta para o menu
            else if (retornoUsuario == "0")
            {
                return false;
            }

            // Loop continua até que uma placa válida seja informada
        } while (string.IsNullOrEmpty(retornoUsuario));

        // Atribui o valor recebido e validado
        placa = retornoUsuario;
        return true;
    }
}