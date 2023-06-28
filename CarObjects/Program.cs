namespace CarObjects
{
    using System;

    class Veiculo
    {
        private string Nome { get; set; }
        private double Peso { get; set; }
        private double Aceleracao { get; set; }
        private double VelocidadeMaxima { get; set; }
        private double Gasolina { get; set; }

        public Veiculo(string nome, double peso, double aceleracao, double velocidadeMaxima, double gasolina)
        {
            Nome = nome;
            Peso = peso;
            Aceleracao = aceleracao;
            VelocidadeMaxima = velocidadeMaxima;
            Gasolina = gasolina;
        }

        public void MostrarDetalhes()
        {
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
            Console.WriteLine($"Consumo de gasolina: {consumo} litros");
            Console.WriteLine($"Gasolina restante: {Gasolina} litros");
        }

        public double CalcularTorque()
        {
            return Aceleracao * Peso;
        }

        public virtual void UsarEquipamento(Equipamento equipamento)
        {
            Console.WriteLine($"Usando {equipamento.Nome} no {Nome}");
        }
    }

    class Equipamento
    {
        private string Nome { get; set; }
        private double PesoExtra { get; set; }
        private double TorqueExtra { get; set; }

        public Equipamento(string nome, double pesoExtra, double torqueExtra)
        {
            Nome = nome;
            PesoExtra = pesoExtra;
            TorqueExtra = torqueExtra;
        }

        public void Equipar(Veiculo veiculo)
        {
            veiculo.Peso += PesoExtra;
            Console.WriteLine($"{veiculo.Nome} equipado com {Nome}");
            Console.WriteLine($"Peso atualizado: {veiculo.Peso} kg");
            veiculo.UsarEquipamento(this);
        }
    }

    class ExemploVeiculos
    {
        static void Main()
        {
            Veiculo fordMustang = new Veiculo("Ford Mustang", 1600, 7, 250, 80);
            Veiculo nissanSkyline = new Veiculo("Nissan Skyline", 1450, 6, 280, 85);
            Veiculo toyotaSupra = new Veiculo("Toyota Supra", 1550, 6.5, 270, 90);
            Veiculo mazdaRX7 = new Veiculo("Mazda RX-7", 1300, 6.8, 260, 75);
            Veiculo chevroletCamaro = new Veiculo("Chevrolet Camaro", 1700, 7.2, 255, 85);

            Equipamento lancadorMissoes = new Equipamento("Lançador de Mísseis", 300, 200);
            Equipamento nitroBoost = new Equipamento("Nitro Boost", 50, 100);
            Equipamento spoilersAerodinamicos = new Equipamento("Spoilers Aerodinâmicos", 80, 50);
            Equipamento sistemaTurbo = new Equipamento("Sistema de Turbo", 70, 80);
            Equipamento escapeEsportivo = new Equipamento("Escape Esportivo", 40, 60);
            Equipamento kitSuspensaoEsportiva = new Equipamento("Kit de Suspensão Esportiva", 120, 90);

            Console.WriteLine("Ford Mustang:");
            fordMustang.MostrarDetalhes();
            Console.WriteLine($"Torque: {fordMustang.CalcularTorque()} Nm");
            fordMustang.ConsumirGasolina();
            nitroBoost.Equipar(fordMustang);

            Console.WriteLine("\nNissan Skyline:");
            nissanSkyline.MostrarDetalhes();
            Console.WriteLine($"Torque: {nissanSkyline.CalcularTorque()} Nm");
            nissanSkyline.ConsumirGasolina();
            spoilersAerodinamicos.Equipar(nissanSkyline);

            Console.WriteLine("\nToyota Supra:");
            toyotaSupra.MostrarDetalhes();
            Console.WriteLine($"Torque: {toyotaSupra.CalcularTorque()} Nm");
            toyotaSupra.ConsumirGasolina();
            sistemaTurbo.Equipar(toyotaSupra);

            Console.WriteLine("\nMazda RX-7:");
            mazdaRX7.MostrarDetalhes();
            Console.WriteLine($"Torque: {mazdaRX7.CalcularTorque()} Nm");
            mazdaRX7.ConsumirGasolina();
            escapeEsportivo.Equipar(mazdaRX7);

            Console.WriteLine("\nChevrolet Camaro:");
            chevroletCamaro.MostrarDetalhes();
            Console.WriteLine($"Torque: {chevroletCamaro.CalcularTorque()} Nm");
            chevroletCamaro.ConsumirGasolina();
            kitSuspensaoEsportiva.Equipar(chevroletCamaro);
        }
    }

}