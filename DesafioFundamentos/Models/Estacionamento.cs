using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string novaPlaca;
            Console.WriteLine("Digite a placa do veículo para estacionar -Exemplo: XXX-1234");
            novaPlaca = Console.ReadLine();
            Regex regex = new Regex(@"^[A-Za-z]{3}-\d{4}$", RegexOptions.IgnoreCase);

            if (regex.IsMatch(novaPlaca))
            {
                veiculos.Add(novaPlaca);
                Console.WriteLine("Veículo cadastrado com sucesso!");
            }
            else 
            {
                Console.WriteLine("Formato de placa inválido. A placa deve estar no formato XXX-1234.");
            }
        }

        public void RemoverVeiculo()
        {         
            string placa;
            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();


            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0; 
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (int.TryParse(Console.ReadLine(), out horas))
                {
                    valorTotal = precoInicial + precoPorHora * horas;
                }

                veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int contador = 0; contador < veiculos.Count; contador++)
                {
                    Console.WriteLine($"{contador} - {veiculos[contador]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
