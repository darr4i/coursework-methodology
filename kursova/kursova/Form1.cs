using System.Threading;
using static kursova.Form1;
using System.Collections.Generic;
using System.Windows.Forms;


namespace kursova
{
    public partial class Form1 : Form
    {
        LinkedList<LCDMonitor> monitors = new LinkedList<LCDMonitor>(); // Оголошення змінної monitors
        LinkedList<TouchScreenMonitor> touchScreenMonitors = new LinkedList<TouchScreenMonitor>(); // Оголошення змінної touchScreenMonitors
        public Form1()
        {
            InitializeComponent();

            //LCD монітори
            monitors.AddLast(new LCDMonitor
            {
                Model = "Samsung S24F350FH",
                Manufacturer = "Samsung",
                Diagonal = "24 дюймів",
                HasTuner = true,
                Resolution = "1920x1080",
                PanelType = "IPS",
                Price = "40000"
            });

            monitors.AddLast(new LCDMonitor
            {
                Model = "LG 27UL550-W",
                Manufacturer = "LG",
                Diagonal = "27 дюймів",
                HasTuner = false,
                Resolution = "3840x2160",
                PanelType = "IPS",
                Price = "70000"
            });

            monitors.AddLast(new LCDMonitor
            {
                Model = "Asus 7GMF",
                Manufacturer = "ASUS",
                Diagonal = "24 дюйма",
                HasTuner = true,
                Resolution = "3840x2160",
                PanelType = "IPS",
                Price = "70000"
            });

            //сенсорні монітори
            touchScreenMonitors.AddLast(new TouchScreenMonitor
            {
                Model = "Dell P2418HT",
                Manufacturer = "Dell",
                Diagonal = "23.8 дюйма",
                Resolution = "1920x1080",
                ScreenType = "Ємнісний",
                HDDVolume = "1024",
                Price = "90000"
            });

            touchScreenMonitors.AddLast(new TouchScreenMonitor
            {
                Model = "HP EliteDisplay E230t",
                Manufacturer = "HP",
                Diagonal = "23 дюйми",
                Resolution = "1920x1080",
                ScreenType = "Оптичний",
                HDDVolume = "500",
                Price = "20000"
            });
        }
        // Базовий клас Monitor
        public class Monitor
        {
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string Diagonal { get; set; }
            public string Resolution { get; set; }
            public string Price { get; set; }

            // Віртуальний метод для обчислення вартості купівлі
            public virtual decimal CalculatePurchaseCost()
            {
                return decimal.Parse(Price);
            }

            // Перевизначення методу ToString для виведення даних про монітор у ListBox
            public override string ToString()
            {
                return $"{Model}, {Manufacturer}, {Diagonal}, {Resolution}, {Price}";
            }
        }

        // Похідний клас для LCD моніторів
        public class LCDMonitor : Monitor
        {
            public bool HasTuner { get; set; }
            public string PanelType { get; set; }

            // Перевизначення методу для обчислення вартості купівлі LCD монітора
            public override decimal CalculatePurchaseCost()
            {
                decimal price = base.CalculatePurchaseCost();

                // Перевірка наявності тюнера та застосування знижки
                if (HasTuner && price > 50000)
                {
                    price *= 0.95m; // Знижка 5%
                }

                return price;
            }

            // Перевизначення методу ToString для виведення даних про монітор у ListBox
            public override string ToString()
            {
                return $"{base.ToString()}, TV-тюнер: {(HasTuner ? "Так" : "Ні")}, {PanelType}";
            }
        }

        // Похідний клас для сенсорних моніторів
        public class TouchScreenMonitor : Monitor
        {
            public string ScreenType { get; set; }
            public string HDDVolume { get; set; }

            // Перевизначення методу ToString для виведення даних про монітор у ListBox
            public override string ToString()
            {
                return $"{base.ToString()}, {ScreenType}, HDD: {HDDVolume}";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //додавання моніторів
        {
            // Створення нового об'єкту LCDMonitor з введеними даними
            LCDMonitor monitor = new LCDMonitor();
            monitor.Model = textBox1.Text;
            monitor.Manufacturer = textBox2.Text;
            monitor.Diagonal = textBox3.Text;
            monitor.HasTuner = radioButton1.Checked;
            monitor.Resolution = textBox5.Text;
            monitor.PanelType = textBox6.Text;
            monitor.Price = textBox4.Text;

            // Додавання нового монітора до списку моніторів
            monitors.AddLast(monitor);

            // Оновлення вмісту ListBox
            UpdateListBoxDisplay(monitors);
        }

        // Метод для оновлення вмісту ListBox з сенсорними моніторами
        private void UpdateListBoxDisplay(LinkedList<LCDMonitor> monitorList)
        {
            // Очищення вмісту ListBox
            listBox1.Items.Clear();

            // Додавання кожного монітора у ListBox
            foreach (LCDMonitor monitor in monitorList)
            {
                listBox1.Items.Add(monitor);
            }
        }
        private void UpdateListBoxDisplay(LinkedList<TouchScreenMonitor> monitorList)
        {
            // Очищення вмісту ListBox
            listBox1.Items.Clear();

            // Додавання кожного монітора у ListBox
            foreach (TouchScreenMonitor monitor in monitorList)
            {
                listBox1.Items.Add(monitor);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Перевіряємо, чи є вибраний елемент у списку ListBox
            if (listBox1.SelectedIndex != -1)
            {
                // Отримуємо вибраний монітор зі списку ListBox
                object selectedMonitor = listBox1.SelectedItem;

                // Перевіряємо тип монітора і оновлюємо відповідні текстові поля для редагування
                if (selectedMonitor is LCDMonitor)
                {
                    LCDMonitor lcdMonitor = (LCDMonitor)selectedMonitor;
                    // Оновлення текстових полів з даними про LCD монітор
                    textBox1.Text = lcdMonitor.Model;
                    textBox2.Text = lcdMonitor.Manufacturer;
                    textBox3.Text = lcdMonitor.Diagonal;
                    radioButton1.Checked = lcdMonitor.HasTuner;
                    textBox5.Text = lcdMonitor.Resolution;
                    textBox6.Text = lcdMonitor.PanelType;
                    textBox4.Text = lcdMonitor.Price;
                }
                else if (selectedMonitor is TouchScreenMonitor)
                {
                    TouchScreenMonitor touchScreenMonitor = (TouchScreenMonitor)selectedMonitor;
                    // Оновлення текстових полів з даними про сенсорний монітор
                    textBox7.Text = touchScreenMonitor.Model;
                    textBox8.Text = touchScreenMonitor.Manufacturer;
                    textBox9.Text = touchScreenMonitor.Diagonal;
                    textBox13.Text = touchScreenMonitor.Resolution;
                    textBox10.Text = touchScreenMonitor.ScreenType;
                    textBox11.Text = touchScreenMonitor.HDDVolume;
                    textBox12.Text = touchScreenMonitor.Price;
                }
            }
        }
        private void UpdateListBoxDisplay()
        {
            // Очищення вмісту ListBox
            listBox1.Items.Clear();

            // Додавання кожного монітора зі списку моніторів LCD
            foreach (LCDMonitor monitor in monitors)
            {
                listBox1.Items.Add(monitor);
            }

            // Додавання кожного сенсорного монітора зі списку
            foreach (TouchScreenMonitor monitor in touchScreenMonitors)
            {
                listBox1.Items.Add(monitor);
            }
        }


        private void button2_Click(object sender, EventArgs e) //видалення
        {
            // Перевіряємо, чи вибраний який-небудь елемент у списку ListBox
            if (listBox1.SelectedIndex != -1)
            {
                // Видаляємо вибраний елемент зі списку моніторів в залежності від його типу
                if (listBox1.SelectedItem is LCDMonitor)
                {
                    monitors.Remove((LCDMonitor)listBox1.SelectedItem);
                }
                else if (listBox1.SelectedItem is TouchScreenMonitor)
                {
                    touchScreenMonitors.Remove((TouchScreenMonitor)listBox1.SelectedItem);
                }

                // Видаляємо вибраний елемент зі списку ListBox
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //додавання моніторів
        {
            // Створення нового об'єкту TouchScreenMonitor з введеними даними
            TouchScreenMonitor monitor = new TouchScreenMonitor();
            monitor.Model = textBox7.Text;
            monitor.Manufacturer = textBox8.Text;
            monitor.Diagonal = textBox9.Text;
            monitor.Resolution = textBox13.Text;
            monitor.ScreenType = textBox10.Text;
            monitor.HDDVolume = textBox11.Text;
            monitor.Price = textBox12.Text;

            // Додавання нового монітора до списку сенсорних моніторів
            touchScreenMonitors.AddLast(monitor);

            // Оновлення вмісту ListBox
            UpdateListBoxDisplay(touchScreenMonitors);
        }

        private void button5_Click(object sender, EventArgs e) //Весь список моніторів
        {
            // Очищаємо вміст listBox1
            listBox1.Items.Clear();

            // Додаємо всі монітори зі списку monitors
            foreach (LCDMonitor monitor in monitors)
            {
                listBox1.Items.Add(monitor);
            }

            // Додаємо всі монітори зі списку touchScreenMonitors
            foreach (TouchScreenMonitor monitor in touchScreenMonitors)
            {
                listBox1.Items.Add(monitor);
            }
        }

        private void button3_Click(object sender, EventArgs e) //Редагування
        {
            // Перевіряємо, чи є вибраний елемент у списку ListBox
            if (listBox1.SelectedIndex != -1)
            {
                // Отримуємо вибраний монітор зі списку ListBox
                object selectedMonitor = listBox1.SelectedItem;

                // Перевіряємо тип монітора і оновлюємо відповідні дані
                if (selectedMonitor is LCDMonitor)
                {
                    LCDMonitor lcdMonitor = (LCDMonitor)selectedMonitor;
                    // Оновлення даних про LCD монітор з текстових полів
                    lcdMonitor.Model = textBox1.Text;
                    lcdMonitor.Manufacturer = textBox8.Text;
                    lcdMonitor.Diagonal = textBox3.Text;
                    lcdMonitor.HasTuner = radioButton1.Checked;
                    lcdMonitor.Resolution = textBox5.Text;
                    lcdMonitor.PanelType = textBox6.Text;
                    lcdMonitor.Price = textBox4.Text;
                }
                else if (selectedMonitor is TouchScreenMonitor)
                {
                    TouchScreenMonitor touchScreenMonitor = (TouchScreenMonitor)selectedMonitor;
                    // Оновлення даних про сенсорний монітор з текстових полів
                    touchScreenMonitor.Model = textBox7.Text;
                    touchScreenMonitor.Manufacturer = textBox8.Text;
                    touchScreenMonitor.Diagonal = textBox9.Text;
                    touchScreenMonitor.Resolution = textBox13.Text;
                    touchScreenMonitor.ScreenType = textBox10.Text;
                    touchScreenMonitor.HDDVolume = textBox11.Text;
                    touchScreenMonitor.Price = textBox12.Text;
                }

                // Після редагування оновлюємо вміст ListBox
                UpdateListBoxDisplay();
            }
        }

        // Метод сортування моніторів за ціною
        private void SortTouchScreenMonitorsByPrice()
        {
            // Створення списку для зберігання сортованих моніторів
            List<TouchScreenMonitor> sortedMonitors = new List<TouchScreenMonitor>(touchScreenMonitors);

            // Сортування за ціною
            sortedMonitors.Sort((x, y) => decimal.Compare(decimal.Parse(x.Price), decimal.Parse(y.Price)));

            // Очищення вихідного списку
            touchScreenMonitors.Clear();

            // Додавання відсортованих моніторів назад у вихідний список
            foreach (var monitor in sortedMonitors)
            {
                touchScreenMonitors.AddLast(monitor);
            }

            // Оновлення вмісту ListBox
            UpdateListBoxDisplay(touchScreenMonitors);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // Сортуємо сенсорні монітори за ціною
            SortTouchScreenMonitorsByPrice();

            // Оновлюємо вміст ListBox зі сенсорними моніторами
            UpdateListBoxDisplay(touchScreenMonitors);
        }

        private void button7_Click(object sender, EventArgs e) //Lcd монітори (список)
        {
            UpdateListBoxDisplay(monitors);
        }

        private void SearchLCDMonitorsByManufacturer(string manufacturer)
        {
            // Очищаємо вміст ListBox
            listBox1.Items.Clear();

            // Шукаємо LCD монітори вказаної фірми
            foreach (LCDMonitor monitor in monitors)
            {
                if (monitor.Manufacturer.Equals(manufacturer, StringComparison.OrdinalIgnoreCase))
                {
                    listBox1.Items.Add(monitor);
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string selectedManufacturer = "ASUS"; // Вказуємо фірму для пошуку (у цьому випадку ASUS)
            SearchLCDMonitorsByManufacturer(selectedManufacturer);
        }

        private void button9_Click(object sender, EventArgs e) //вихід
        {
            Close();
        }

        private decimal CalculateMonitorPrice(LCDMonitor monitor)
        {
            decimal price = decimal.Parse(monitor.Price);

            // Перевіряємо, чи має монітор TV-тюнер і чи його вартість більше 50 тис. грн.
            if (monitor.HasTuner && price > 50000)
            {
                price *= 0.95m; // Знижка 5%
            }

            return price;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            // Вибираємо монітор зі списку або створюємо новий об'єкт LCDMonitor з поточними значеннями полів
            LCDMonitor selectedMonitor = new LCDMonitor();
            selectedMonitor.Model = textBox1.Text;
            selectedMonitor.Manufacturer = textBox2.Text;
            selectedMonitor.Diagonal = textBox3.Text;
            selectedMonitor.HasTuner = radioButton1.Checked;
            selectedMonitor.Resolution = textBox5.Text;
            selectedMonitor.PanelType = textBox6.Text;
            selectedMonitor.Price = textBox4.Text;

            // Обчислюємо вартість монітора
            decimal totalPrice = CalculateMonitorPrice(selectedMonitor);

            // Виводимо вартість монітора
            MessageBox.Show($"Вартість монітора: {totalPrice} грн.");
        }

        private void CalculateMonthlyPayment(decimal totalPrice)
        {
            // Відсоткова ставка за кредит
            decimal interestRate = 0.03m; // 3%

            // Кількість місяців кредиту
            int months = 12;

            // Обчислення вартості оплати кожного місяця
            decimal monthlyPayment = totalPrice / months;

            // Додаткові виплати відсотків за кредит
            decimal interestPayment = 0;

            // Обчислення вартості додаткових виплат відсотків за кредит
            for (int i = 0; i < months; i++)
            {
                // Додавання вартості виплати відсотків до загальної суми
                interestPayment += totalPrice * interestRate / months;
            }

            // Додавання вартості оплати відсотків до загальної суми
            decimal totalPayment = totalPrice + interestPayment;

            // Округлення результатів до двох десятих після коми
            monthlyPayment = Math.Round(monthlyPayment, 2);
            totalPayment = Math.Round(totalPayment, 2);

            // Виведення результату
            MessageBox.Show($"Місячна оплата: {monthlyPayment} грн.\nЗагальна сума сплати за кредит: {totalPayment} грн.");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            // Вибираємо монітор зі списку або створюємо новий об'єкт TouchScreenMonitor з поточними значеннями полів
            TouchScreenMonitor selectedMonitor = new TouchScreenMonitor();
            selectedMonitor.Model = textBox7.Text;
            selectedMonitor.Manufacturer = textBox8.Text;
            selectedMonitor.Diagonal = textBox9.Text;
            selectedMonitor.Resolution = textBox13.Text;
            selectedMonitor.ScreenType = textBox10.Text;
            selectedMonitor.HDDVolume = textBox11.Text;
            selectedMonitor.Price = textBox12.Text;

            // Обчислення вартості оплати кожного місяця за кредит
            decimal totalPrice = decimal.Parse(selectedMonitor.Price);
            CalculateMonthlyPayment(totalPrice);
        }
    }
}
    