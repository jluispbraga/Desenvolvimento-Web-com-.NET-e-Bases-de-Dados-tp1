using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    public delegate decimal CalculateDiscount(decimal price);

    static void Main(string[] args)
    {
        string response;

        Console.WriteLine("Olá! Bem-vindo ao TP1 de C#");
        while (true)
        {
            Console.WriteLine("\nEscolha o exercício que deseja executar:");
            Console.WriteLine("1 - Desconto com Delegate");
            Console.WriteLine("2 - Mensagem Multilíngue");
            Console.WriteLine("3 - Cálculo de Área com Func");
            Console.WriteLine("4 - Evento de Temperatura");
            Console.WriteLine("5 - Notificação de Download");
            Console.WriteLine("6 - Log com Multicast Delegate");
            Console.WriteLine("7 - Log com Invocação Segura");
            Console.WriteLine("11 - Manipulação de Strings com Delegates Encadeados");
            Console.WriteLine("Pressione Enter para sair.");

            response = Console.ReadLine();

            switch (response)
            {
                case "1": Ex_1(); break;
                case "2": Ex_2(); break;
                case "3": Ex_3(); break;
                case "4": Ex_4(); break;
                case "5": Ex_5(); break;
                case "6": Ex_6(); break;
                case "7": Ex_7(); break;
                case "11": Ex_11(); break;
                case "":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    // EXERCÍCIO 1
    public static decimal AplicarDescontoDezPorCento(decimal precoOriginal) => precoOriginal * 0.90m;

    public static void Ex_1()
    {
        Console.WriteLine("=== Calculadora de Desconto ===");
        Console.Write("Preço original: R$ ");
        string input = Console.ReadLine();

        if (decimal.TryParse(input, out decimal precoOriginal) && precoOriginal > 0)
        {
            CalculateDiscount desconto = AplicarDescontoDezPorCento;
            decimal precoFinal = desconto(precoOriginal);
            Console.WriteLine($"Preço com desconto: R$ {precoFinal:F2}");
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }

        Console.ReadKey();
    }

    // EXERCÍCIO 2
    public static void Ex_2()
    {
        Console.WriteLine("=== Sistema Multilíngue ===");
        Console.WriteLine("1 - Português\n2 - Inglês\n3 - Espanhol");
        Console.Write("Opção: ");
        string idioma = Console.ReadLine();

        Console.Write("Seu nome: ");
        string nome = Console.ReadLine();

        Dictionary<string, Action<string>> mensagens = new()
        {
            { "1", n => Console.WriteLine($"Olá, {n}! Bem-vindo.") },
            { "2", n => Console.WriteLine($"Hello, {n}! Welcome.") },
            { "3", n => Console.WriteLine($"¡Hola, {n}! Bienvenido.") }
        };

        if (mensagens.TryGetValue(idioma, out Action<string> msg))
            msg(nome);
        else
            Console.WriteLine("Idioma inválido.");

        Console.ReadKey();
    }

    // EXERCÍCIO 3
    public static void Ex_3()
    {
        Console.WriteLine("=== Cálculo de Área ===");
        Console.Write("Base: ");
        string b = Console.ReadLine();
        Console.Write("Altura: ");
        string h = Console.ReadLine();

        if (double.TryParse(b, out double baseR) && double.TryParse(h, out double altura) && baseR > 0 && altura > 0)
        {
            Func<double, double, double> calcArea = (x, y) => x * y;
            Console.WriteLine($"Área: {calcArea(baseR, altura):F2} m²");
        }
        else
        {
            Console.WriteLine("Valores inválidos.");
        }

        Console.ReadKey();
    }

    // EXERCÍCIO 4
    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; }
        public TemperatureEventArgs(double temp) => Temperature = temp;
    }

    public class TemperatureSensor
    {
        public event EventHandler<TemperatureEventArgs> TemperatureExceeded;

        public void LerTemperatura(double temp)
        {
            Console.WriteLine($"Temperatura lida: {temp}°C");
            if (temp > 100) OnTemperatureExceeded(new TemperatureEventArgs(temp));
        }

        protected virtual void OnTemperatureExceeded(TemperatureEventArgs e) =>
            TemperatureExceeded?.Invoke(this, e);
    }

    private static void Sensor_TemperatureExceeded(object sender, TemperatureEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ALERTA] Temperatura crítica: {e.Temperature}°C!");
        Console.ResetColor();
    }

    public static void Ex_4()
    {
        Console.WriteLine("=== Monitoramento de Temperatura ===");
        TemperatureSensor sensor = new();
        sensor.TemperatureExceeded += Sensor_TemperatureExceeded;

        while (true)
        {
            Console.Write("Informe temperatura (ou 'sair'): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "sair") break;
            if (double.TryParse(input, out double temp))
                sensor.LerTemperatura(temp);
            else
                Console.WriteLine("Valor inválido.");
        }
    }

    // EXERCÍCIO 5
    public class DownloadManager
    {
        public event EventHandler DownloadCompleted;
        public void IniciarDownload(string nome)
        {
            Console.WriteLine($"Baixando {nome}...");
            Thread.Sleep(2000);
            DownloadCompleted?.Invoke(this, EventArgs.Empty);
        }
    }

    private static void Manager_DownloadCompleted(object sender, EventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[✔] Download finalizado!");
        Console.ResetColor();
    }

    public static void Ex_5()
    {
        Console.Write("Nome do arquivo: ");
        string nome = Console.ReadLine();
        DownloadManager manager = new();
        manager.DownloadCompleted += Manager_DownloadCompleted;
        manager.IniciarDownload(nome);
        Console.ReadKey();
    }

    // EXERCÍCIO 6 E 7
    public class Logger
    {
        private const string LogFile = "log.txt";
        public void LogToConsole(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[Console] {msg}");
            Console.ResetColor();
        }

        public void LogToFile(string msg) =>
            File.AppendAllText(LogFile, $"[Arquivo] {msg}{Environment.NewLine}");

        public void LogToDatabase(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[BD] {msg} (simulado)");
            Console.ResetColor();
        }
    }

    public static void Ex_6()
    {
        Logger logger = new();
        Action<string> multiLogger = logger.LogToConsole;
        multiLogger += logger.LogToFile;
        multiLogger += logger.LogToDatabase;

        Console.Write("Mensagem para log: ");
        string msg = Console.ReadLine();
        multiLogger(msg);

        Console.WriteLine("Registro feito.");
        Console.ReadKey();
    }

    public static void Ex_7()
    {
        Logger logger = new();
        Action<string> multiLogger = logger.LogToConsole;
        multiLogger += logger.LogToFile;
        multiLogger += logger.LogToDatabase;

        Console.Write("Mensagem para log seguro: ");
        string msg = Console.ReadLine();
        multiLogger?.Invoke(msg);

        Console.WriteLine("Log seguro concluído.");
        Console.ReadKey();
    }

    public static void Ex_11()
    {
        Func<string, string, string> concat = (nome, sobrenome) =>
        {
            var resultado = $"{nome} {sobrenome}";
            Console.WriteLine($"[Concatenação] {resultado}");
            return resultado;
        };

        Func<string, string, string> paraMaiusculas = (nome, sobrenome) =>
        {
            var resultado = $"{nome} {sobrenome}".ToUpper();
            Console.WriteLine($"[Maiúsculas] {resultado}");
            return resultado;
        };

        Func<string, string, string> removerEspacos = (nome, sobrenome) =>
        {
            var resultado = $"{nome}{sobrenome}".Replace(" ", "");
            Console.WriteLine($"[Sem espaços] {resultado}");
            return resultado;
        };

        Func<string, string, string> pipeline = concat + paraMaiusculas + removerEspacos;

        string resultadoFinal = pipeline("João", "Silva");

        Console.WriteLine($"\n🔹 Resultado final retornado pelo delegate: {resultadoFinal}");
    }
}
