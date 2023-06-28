namespace CarObjects
{
    using System;

    class Veiculo
    {
        public string Nome { get; }
        public double Peso { get; set; }
        public double Aceleracao { get; }
        public double VelocidadeMaxima { get; }
        public double Gasolina { get; set; }

        public List<Equipamento> Equipamentos { get; set; }

        public Veiculo(string nome, double peso, double aceleracao, double velocidadeMaxima, double gasolina)
        {
            Nome = nome;
            Peso = peso;
            Aceleracao = aceleracao;
            VelocidadeMaxima = velocidadeMaxima;
            Gasolina = gasolina;
            Equipamentos = new List<Equipamento>();
        }

        public void MostrarDetalhes()
        {
            Console.WriteLine();
            Console.WriteLine($"Detalhes do {Nome}:");
            Console.WriteLine($"Peso: {Peso} kg");
            Console.WriteLine($"Aceleração: {Aceleracao} m/s²");
            Console.WriteLine($"Velocidade Máxima: {VelocidadeMaxima} km/h");
            Console.WriteLine($"Gasolina: {Gasolina} litros");
        }

        public void ConsumirGasolina()
        {
            double consumo = Peso * 0.01; // Exemplo de fórmula de consumo de gasolina baseado no peso
            Gasolina -= consumo;
            Console.WriteLine($"\nConsumo de gasolina: {consumo} litros");
            Console.WriteLine($"Gasolina restante: {Gasolina} litros");
        }
    }

    class Equipamento
    {
        public string Nome { get; }
        public double PesoExtra { get; }
        public double TorqueExtra { get; }

        public Equipamento(string nome, double pesoExtra, double torqueExtra)
        {
            Nome = nome;
            PesoExtra = pesoExtra;
            TorqueExtra = torqueExtra;
        }

        public void Equipar(Veiculo veiculo)
        {
            Equipamento equip = new(this.Nome, this.PesoExtra, this.TorqueExtra);
            veiculo.Peso += PesoExtra;
            veiculo.Equipamentos.Add(equip);
            Console.WriteLine($"\n{veiculo.Nome} equipado com {Nome}");
            Console.WriteLine($"Peso atualizado: {veiculo.Peso} kg");
        }

        public void MostrarDetalhes(Veiculo veiculo)
        {
            Console.WriteLine($"\nDetalhes do veiculo {veiculo.Nome}:");
            foreach (Equipamento v in veiculo.Equipamentos)
            {
                Console.WriteLine($"Equipado com {v.Nome}");
            }
        }
    }

    class ExemploVeiculos
    {
        static void Main()
        {
            var nitro = new Equipamento("Nitro Boost", 50, 100);
            var spoiler = new Equipamento("Spoilers Aerodinâmicos", 80, 50);
            var mustang = new Veiculo("Mustang GT", 1600, 7, 250, 80);

            nitro.Equipar(mustang);
            spoiler.Equipar(mustang);

            mustang.MostrarDetalhes();
        }
    }

}