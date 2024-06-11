using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Monitor
{
    // Базовий клас для моніторів
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public double Diagonal { get; set; }
    public string Resolution { get; set; }
    public double Price { get; set; }

    public virtual double CalculatePayment()
    {
        return Price;
    }
}

// Клас для LCD моніторів, похідний від базового класу Monitor
public class LCDMonitor : Monitor
{
    public bool HasTVTuner { get; set; }
    public string MatrixType { get; set; }

    // Метод обчислення вартості купівлі для LCD моніторів
    public override double CalculatePayment()
    {
        if (HasTVTuner && Price > 50000)
            return Price * 0.95; // Знижка 5% для моніторів з TV-тюнером та ціною більше 50000
        else
            return Price;
    }
}

// Клас для сенсорних моніторів, похідний від базового класу Monitor
public class TouchScreenMonitor : Monitor
{
    public string TouchScreenType { get; set; }
    public int HDDSizeGB { get; set; }
    
    // Метод обчислення вартості купівлі для сенсорних моніторів
    public override double CalculatePayment()
    {
        return Price / 12 * 1.03;
    }
}

class Program
{
    static List<Monitor> monitors = new List<Monitor>(); // Список моніторів

    static void Main(string[] args)
    {
        // Додавання декількох моніторів для прикладу
        monitors.Add(new LCDMonitor
        {
            Model = "VS239H-P",
            Manufacturer = "ASUS",
            Diagonal = 23,
            Resolution = "1920x1080",
            Price = 15000,
            HasTVTuner = false,
            MatrixType = "IPS"
        });

        monitors.Add(new LCDMonitor
        {
            Model = "24MK600M-B",
            Manufacturer = "LG",
            Diagonal = 24,
            Resolution = "1920x1080",
            Price = 20000,
            HasTVTuner = true,
            MatrixType = "IPS"
        });

        monitors.Add(new TouchScreenMonitor
        {
            Model = "P2314T",
            Manufacturer = "Dell",
            Diagonal = 23,
            Resolution = "1920x1080",
            Price = 40000,
            TouchScreenType = "Capacitive",
            HDDSizeGB = 1000
        });

        monitors.Add(new LCDMonitor
        {
            Model = "XG270HU",
            Manufacturer = "Acer",
            Diagonal = 27,
            Resolution = "2560x1440",
            Price = 30000,
            HasTVTuner = false,
            MatrixType = "TN"
        });

        monitors.Add(new LCDMonitor
        {
            Model = "C24G1",
            Manufacturer = "AOC",
            Diagonal = 24,
            Resolution = "1920x1080",
            Price = 18000,
            HasTVTuner = false,
            MatrixType = "VA"
        });

        monitors.Add(new TouchScreenMonitor
        {
            Model = "TD2230",
            Manufacturer = "ViewSonic",
            Diagonal = 22,
            Resolution = "1920x1080",
            Price = 35000,
            TouchScreenType = "Optical",
            HDDSizeGB = 500
        });

        while (true)
        {
            // Виведення меню опцій програми
            Console.Clear();

            Console.WriteLine("1. Додати монітор");
            Console.WriteLine("2. Видалити монітор");
            Console.WriteLine("3. Редагувати дані монітора");
            Console.WriteLine("4. Показати список сенсорних моніторів, відсортований за ціною");
            Console.WriteLine("5. Показати тільки LCD монітори");
            Console.WriteLine("6. Пошук LCD моніторів фірми ASUS");
            Console.WriteLine("7. Обчислити вартість LCD монітора");
            Console.WriteLine("8. Обчислити вартість оплати за 1 місяць сенсорного монітора");
            Console.WriteLine("9. Вийти з програми");

            Console.Write("Оберіть опцію: ");
            string option = Console.ReadLine(); // Зчитування опції користувача

            switch (option)
            {
                case "1":
                    AddMonitor(); // Додавання монітора
                    break;
                case "2":
                    RemoveMonitor(); // Видалення монітора
                    break;
                case "3":
                    EditMonitor(); // Редагування монітора
                    break;
                case "4":
                    ShowSortedTouchScreenMonitors(); // Показати список сенсорних моніторів, відсортований за ціною
                    break;
                case "5":
                    ShowOnlyLCDMonitors(); // Показати тільки LCD монітори
                    break;
                case "6":
                    SearchASUSLCDMonitors(); // Пошук LCD моніторів фірми ASUS
                    break;
                case "7":
                    CalculateLCDDisplayCost(); // Обчислити вартість LCD монітора
                    break;
                case "8":
                    CalculateMonthlyPayment(); // Обчислити вартість оплати за 1 місяць сенсорного монітора
                    break;
                case "9":
                    Console.WriteLine("Програма завершена.");
                    return; // Вихід з програми
                default:
                    Console.WriteLine("Невідома опція. Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        }
    }

    static void AddMonitor()
    {
        Console.WriteLine("Оберіть тип монітору:");
        Console.WriteLine("1. LCD монітор");
        Console.WriteLine("2. Сенсорний монітор");
        Console.Write("Введіть номер опції: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddLCDMonitor();
                break;
            case "2":
                AddTouchScreenMonitor();
                break;
            default:
                Console.WriteLine("Невідома опція.");
                break;
        }
    }

    static void AddLCDMonitor()
    {
        Console.WriteLine("Введіть модель монітора:");
        string model = Console.ReadLine();

        Console.WriteLine("Введіть виробника монітора:");
        string manufacturer = Console.ReadLine();

        Console.WriteLine("Введіть діагональ монітора:");
        double diagonal = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть роздільну здатність монітора:");
        string resolution = Console.ReadLine();

        Console.WriteLine("Введіть ціну монітора:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("Чи є у монітора TV-тюнер? (так/ні):");
        bool hasTVTuner = Console.ReadLine().ToLower() == "так";

        Console.WriteLine("Введіть тип матриці монітора:");
        string matrixType = Console.ReadLine();

        monitors.Add(new LCDMonitor
        {
            Model = model,
            Manufacturer = manufacturer,
            Diagonal = diagonal,
            Resolution = resolution,
            Price = price,
            HasTVTuner = hasTVTuner,
            MatrixType = matrixType
        });

        Console.WriteLine("Монітор додано.");
    }

    static void AddTouchScreenMonitor()
    {
        Console.WriteLine("Введіть модель монітора:");
        string model = Console.ReadLine();

        Console.WriteLine("Введіть виробника монітора:");
        string manufacturer = Console.ReadLine();

        Console.WriteLine("Введіть діагональ монітора:");
        double diagonal = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть роздільну здатність монітора:");
        string resolution = Console.ReadLine();

        Console.WriteLine("Введіть ціну монітора:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть тип сенсорного екрану монітора:");
        string touchScreenType = Console.ReadLine();

        Console.WriteLine("Введіть об'єм HDD монітора (у гігабайтах):");
        int hddSizeGB = int.Parse(Console.ReadLine());

        monitors.Add(new TouchScreenMonitor
        {
            Model = model,
            Manufacturer = manufacturer,
            Diagonal = diagonal,
            Resolution = resolution,
            Price = price,
            TouchScreenType = touchScreenType,
            HDDSizeGB = hddSizeGB
        });

        Console.WriteLine("Монітор додано.");
    }

    static void RemoveMonitor()
    {
        if (monitors.Any())
        {
            Console.WriteLine("Оберіть номер монітора, який ви хочете видалити:");
            for (int i = 0; i < monitors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {monitors[i].Manufacturer} {monitors[i].Model}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < monitors.Count)
            {
                monitors.RemoveAt(index);
                Console.WriteLine("Монітор видалено.");
            }
            else
            {
                Console.WriteLine("Невірний номер монітора.");
            }
        }
        else
        {
            Console.WriteLine("Список моніторів порожній.");
        }
    }

    static void EditMonitor()
    {
        if (monitors.Any())
        {
            Console.WriteLine("Оберіть номер монітора, який ви хочете відредагувати:");
            for (int i = 0; i < monitors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {monitors[i].Manufacturer} {monitors[i].Model}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < monitors.Count)
            {
                Monitor selectedMonitor = monitors[index];
                Console.WriteLine("Введіть нові дані для монітора:");

                Console.WriteLine("Введіть нову модель:");
                selectedMonitor.Model = Console.ReadLine();

                Console.WriteLine("Введіть нового виробника:");
                selectedMonitor.Manufacturer = Console.ReadLine();

                Console.WriteLine("Введіть нову діагональ:");
                selectedMonitor.Diagonal = double.Parse(Console.ReadLine());

                Console.WriteLine("Введіть нову роздільну здатність:");
                selectedMonitor.Resolution = Console.ReadLine();

                Console.WriteLine("Введіть нову ціну:");
                selectedMonitor.Price = double.Parse(Console.ReadLine());

                if (selectedMonitor is LCDMonitor lcdMonitor)
                {
                    Console.WriteLine("Чи є у монітора TV-тюнер? (так/ні):");
                    lcdMonitor.HasTVTuner = Console.ReadLine().ToLower() == "так";

                    Console.WriteLine("Введіть новий тип матриці:");
                    lcdMonitor.MatrixType = Console.ReadLine();
                }
                else if (selectedMonitor is TouchScreenMonitor touchScreenMonitor)
                {
                    Console.WriteLine("Введіть новий тип сенсорного екрану:");
                    touchScreenMonitor.TouchScreenType = Console.ReadLine();

                    Console.WriteLine("Введіть новий об’єм HDD:");
                    touchScreenMonitor.HDDSizeGB = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Дані монітора відредаговано.");
            }
            else
            {
                Console.WriteLine("Невірний номер монітора.");
            }
        }
        else
        {
            Console.WriteLine("Список моніторів порожній.");
        }
    }

    static void ShowSortedTouchScreenMonitors()
    {
        var sortedTouchScreenMonitors = monitors
            .OfType<TouchScreenMonitor>()
            .OrderBy(m => m.Price)
            .ToList();

        Console.WriteLine("Список сенсорних моніторів, відсортований за ціною:");
        foreach (var monitor in sortedTouchScreenMonitors)
        {
            Console.WriteLine($"{monitor.Manufacturer} {monitor.Model} - {monitor.Price}");
        }
    }

    static void ShowOnlyLCDMonitors()
    {
        var lcdMonitors = monitors.OfType<LCDMonitor>().ToList();

        Console.WriteLine("Список LCD моніторів:");
        foreach (var monitor in lcdMonitors)
        {
            Console.WriteLine($"{monitor.Manufacturer} {monitor.Model}");
        }
    }

    static void SearchASUSLCDMonitors()
    {
        var asusLcdMonitors = monitors
            .OfType<LCDMonitor>()
            .Where(m => m.Manufacturer.ToLower() == "asus")
            .ToList();

        Console.WriteLine("Список LCD моніторів виробника ASUS:");
        foreach (var monitor in asusLcdMonitors)
        {
            Console.WriteLine($"{monitor.Model} - {monitor.Price}");
        }
    }

    static void CalculateLCDDisplayCost()
    {
        var lcdMonitors = monitors.OfType<LCDMonitor>().ToList();

        if (lcdMonitors.Any())
        {
            Console.WriteLine("Оберіть номер LCD монітора:");
            for (int i = 0; i < lcdMonitors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lcdMonitors[i].Manufacturer} {lcdMonitors[i].Model}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < lcdMonitors.Count)
            {
                double cost = lcdMonitors[index].CalculatePayment();
                Console.WriteLine($"Вартість LCD монітора: {cost}");
            }
            else
            {
                Console.WriteLine("Невірний номер монітора.");
            }
        }
        else
        {
            Console.WriteLine("Список LCD моніторів порожній.");
        }
    }

    static void CalculateMonthlyPayment()
    {
        var touchScreenMonitors = monitors.OfType<TouchScreenMonitor>().ToList();

        if (touchScreenMonitors.Any())
        {
            Console.WriteLine("Оберіть номер сенсорного монітора:");
            for (int i = 0; i < touchScreenMonitors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {touchScreenMonitors[i].Manufacturer} {touchScreenMonitors[i].Model}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < touchScreenMonitors.Count)
            {
                double monthlyPayment = touchScreenMonitors[index].CalculatePayment();
                Console.WriteLine($"Вартість оплати за 1 місяць: {monthlyPayment}");
            }
            else
            {
                Console.WriteLine("Невірний номер монітора.");
            }
        }
        else
        {
            Console.WriteLine("Список сенсорних моніторів порожній.");
        }
    }
}
