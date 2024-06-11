using System.Threading;
using static kursova.Form1;
using System.Collections.Generic;
using System.Windows.Forms;


namespace kursova
{
    public partial class Form1 : Form
    {
        LinkedList<LCDMonitor> monitors = new LinkedList<LCDMonitor>(); // ���������� ����� monitors
        LinkedList<TouchScreenMonitor> touchScreenMonitors = new LinkedList<TouchScreenMonitor>(); // ���������� ����� touchScreenMonitors
        public Form1()
        {
            InitializeComponent();

            //LCD �������
            monitors.AddLast(new LCDMonitor
            {
                Model = "Samsung S24F350FH",
                Manufacturer = "Samsung",
                Diagonal = "24 �����",
                HasTuner = true,
                Resolution = "1920x1080",
                PanelType = "IPS",
                Price = "40000"
            });

            monitors.AddLast(new LCDMonitor
            {
                Model = "LG 27UL550-W",
                Manufacturer = "LG",
                Diagonal = "27 �����",
                HasTuner = false,
                Resolution = "3840x2160",
                PanelType = "IPS",
                Price = "70000"
            });

            monitors.AddLast(new LCDMonitor
            {
                Model = "Asus 7GMF",
                Manufacturer = "ASUS",
                Diagonal = "24 �����",
                HasTuner = true,
                Resolution = "3840x2160",
                PanelType = "IPS",
                Price = "70000"
            });

            //������� �������
            touchScreenMonitors.AddLast(new TouchScreenMonitor
            {
                Model = "Dell P2418HT",
                Manufacturer = "Dell",
                Diagonal = "23.8 �����",
                Resolution = "1920x1080",
                ScreenType = "�������",
                HDDVolume = "1024",
                Price = "90000"
            });

            touchScreenMonitors.AddLast(new TouchScreenMonitor
            {
                Model = "HP EliteDisplay E230t",
                Manufacturer = "HP",
                Diagonal = "23 �����",
                Resolution = "1920x1080",
                ScreenType = "��������",
                HDDVolume = "500",
                Price = "20000"
            });
        }
        // ������� ���� Monitor
        public class Monitor
        {
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string Diagonal { get; set; }
            public string Resolution { get; set; }
            public string Price { get; set; }

            // ³��������� ����� ��� ���������� ������� �����
            public virtual decimal CalculatePurchaseCost()
            {
                return decimal.Parse(Price);
            }

            // �������������� ������ ToString ��� ��������� ����� ��� ������ � ListBox
            public override string ToString()
            {
                return $"{Model}, {Manufacturer}, {Diagonal}, {Resolution}, {Price}";
            }
        }

        // �������� ���� ��� LCD �������
        public class LCDMonitor : Monitor
        {
            public bool HasTuner { get; set; }
            public string PanelType { get; set; }

            // �������������� ������ ��� ���������� ������� ����� LCD �������
            public override decimal CalculatePurchaseCost()
            {
                decimal price = base.CalculatePurchaseCost();

                // �������� �������� ������ �� ������������ ������
                if (HasTuner && price > 50000)
                {
                    price *= 0.95m; // ������ 5%
                }

                return price;
            }

            // �������������� ������ ToString ��� ��������� ����� ��� ������ � ListBox
            public override string ToString()
            {
                return $"{base.ToString()}, TV-�����: {(HasTuner ? "���" : "ͳ")}, {PanelType}";
            }
        }

        // �������� ���� ��� ��������� �������
        public class TouchScreenMonitor : Monitor
        {
            public string ScreenType { get; set; }
            public string HDDVolume { get; set; }

            // �������������� ������ ToString ��� ��������� ����� ��� ������ � ListBox
            public override string ToString()
            {
                return $"{base.ToString()}, {ScreenType}, HDD: {HDDVolume}";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //��������� �������
        {
            // ��������� ������ ��'���� LCDMonitor � ��������� ������
            LCDMonitor monitor = new LCDMonitor();
            monitor.Model = textBox1.Text;
            monitor.Manufacturer = textBox2.Text;
            monitor.Diagonal = textBox3.Text;
            monitor.HasTuner = radioButton1.Checked;
            monitor.Resolution = textBox5.Text;
            monitor.PanelType = textBox6.Text;
            monitor.Price = textBox4.Text;

            // ��������� ������ ������� �� ������ �������
            monitors.AddLast(monitor);

            // ��������� ����� ListBox
            UpdateListBoxDisplay(monitors);
        }

        // ����� ��� ��������� ����� ListBox � ���������� ���������
        private void UpdateListBoxDisplay(LinkedList<LCDMonitor> monitorList)
        {
            // �������� ����� ListBox
            listBox1.Items.Clear();

            // ��������� ������� ������� � ListBox
            foreach (LCDMonitor monitor in monitorList)
            {
                listBox1.Items.Add(monitor);
            }
        }
        private void UpdateListBoxDisplay(LinkedList<TouchScreenMonitor> monitorList)
        {
            // �������� ����� ListBox
            listBox1.Items.Clear();

            // ��������� ������� ������� � ListBox
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
            // ����������, �� � �������� ������� � ������ ListBox
            if (listBox1.SelectedIndex != -1)
            {
                // �������� �������� ������ � ������ ListBox
                object selectedMonitor = listBox1.SelectedItem;

                // ���������� ��� ������� � ��������� ������� ������� ���� ��� �����������
                if (selectedMonitor is LCDMonitor)
                {
                    LCDMonitor lcdMonitor = (LCDMonitor)selectedMonitor;
                    // ��������� ��������� ���� � ������ ��� LCD ������
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
                    // ��������� ��������� ���� � ������ ��� ��������� ������
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
            // �������� ����� ListBox
            listBox1.Items.Clear();

            // ��������� ������� ������� � ������ ������� LCD
            foreach (LCDMonitor monitor in monitors)
            {
                listBox1.Items.Add(monitor);
            }

            // ��������� ������� ���������� ������� � ������
            foreach (TouchScreenMonitor monitor in touchScreenMonitors)
            {
                listBox1.Items.Add(monitor);
            }
        }


        private void button2_Click(object sender, EventArgs e) //���������
        {
            // ����������, �� �������� ����-������ ������� � ������ ListBox
            if (listBox1.SelectedIndex != -1)
            {
                // ��������� �������� ������� � ������ ������� � ��������� �� ���� ����
                if (listBox1.SelectedItem is LCDMonitor)
                {
                    monitors.Remove((LCDMonitor)listBox1.SelectedItem);
                }
                else if (listBox1.SelectedItem is TouchScreenMonitor)
                {
                    touchScreenMonitors.Remove((TouchScreenMonitor)listBox1.SelectedItem);
                }

                // ��������� �������� ������� � ������ ListBox
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

        private void button4_Click(object sender, EventArgs e) //��������� �������
        {
            // ��������� ������ ��'���� TouchScreenMonitor � ��������� ������
            TouchScreenMonitor monitor = new TouchScreenMonitor();
            monitor.Model = textBox7.Text;
            monitor.Manufacturer = textBox8.Text;
            monitor.Diagonal = textBox9.Text;
            monitor.Resolution = textBox13.Text;
            monitor.ScreenType = textBox10.Text;
            monitor.HDDVolume = textBox11.Text;
            monitor.Price = textBox12.Text;

            // ��������� ������ ������� �� ������ ��������� �������
            touchScreenMonitors.AddLast(monitor);

            // ��������� ����� ListBox
            UpdateListBoxDisplay(touchScreenMonitors);
        }

        private void button5_Click(object sender, EventArgs e) //���� ������ �������
        {
            // ������� ���� listBox1
            listBox1.Items.Clear();

            // ������ �� ������� � ������ monitors
            foreach (LCDMonitor monitor in monitors)
            {
                listBox1.Items.Add(monitor);
            }

            // ������ �� ������� � ������ touchScreenMonitors
            foreach (TouchScreenMonitor monitor in touchScreenMonitors)
            {
                listBox1.Items.Add(monitor);
            }
        }

        private void button3_Click(object sender, EventArgs e) //�����������
        {
            // ����������, �� � �������� ������� � ������ ListBox
            if (listBox1.SelectedIndex != -1)
            {
                // �������� �������� ������ � ������ ListBox
                object selectedMonitor = listBox1.SelectedItem;

                // ���������� ��� ������� � ��������� ������� ���
                if (selectedMonitor is LCDMonitor)
                {
                    LCDMonitor lcdMonitor = (LCDMonitor)selectedMonitor;
                    // ��������� ����� ��� LCD ������ � ��������� ����
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
                    // ��������� ����� ��� ��������� ������ � ��������� ����
                    touchScreenMonitor.Model = textBox7.Text;
                    touchScreenMonitor.Manufacturer = textBox8.Text;
                    touchScreenMonitor.Diagonal = textBox9.Text;
                    touchScreenMonitor.Resolution = textBox13.Text;
                    touchScreenMonitor.ScreenType = textBox10.Text;
                    touchScreenMonitor.HDDVolume = textBox11.Text;
                    touchScreenMonitor.Price = textBox12.Text;
                }

                // ϳ��� ����������� ��������� ���� ListBox
                UpdateListBoxDisplay();
            }
        }

        // ����� ���������� ������� �� �����
        private void SortTouchScreenMonitorsByPrice()
        {
            // ��������� ������ ��� ��������� ���������� �������
            List<TouchScreenMonitor> sortedMonitors = new List<TouchScreenMonitor>(touchScreenMonitors);

            // ���������� �� �����
            sortedMonitors.Sort((x, y) => decimal.Compare(decimal.Parse(x.Price), decimal.Parse(y.Price)));

            // �������� ��������� ������
            touchScreenMonitors.Clear();

            // ��������� ������������ ������� ����� � �������� ������
            foreach (var monitor in sortedMonitors)
            {
                touchScreenMonitors.AddLast(monitor);
            }

            // ��������� ����� ListBox
            UpdateListBoxDisplay(touchScreenMonitors);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // ������� ������� ������� �� �����
            SortTouchScreenMonitorsByPrice();

            // ��������� ���� ListBox � ���������� ���������
            UpdateListBoxDisplay(touchScreenMonitors);
        }

        private void button7_Click(object sender, EventArgs e) //Lcd ������� (������)
        {
            UpdateListBoxDisplay(monitors);
        }

        private void SearchLCDMonitorsByManufacturer(string manufacturer)
        {
            // ������� ���� ListBox
            listBox1.Items.Clear();

            // ������ LCD ������� ������� �����
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
            string selectedManufacturer = "ASUS"; // ������� ����� ��� ������ (� ����� ������� ASUS)
            SearchLCDMonitorsByManufacturer(selectedManufacturer);
        }

        private void button9_Click(object sender, EventArgs e) //�����
        {
            Close();
        }

        private decimal CalculateMonitorPrice(LCDMonitor monitor)
        {
            decimal price = decimal.Parse(monitor.Price);

            // ����������, �� �� ������ TV-����� � �� ���� ������� ����� 50 ���. ���.
            if (monitor.HasTuner && price > 50000)
            {
                price *= 0.95m; // ������ 5%
            }

            return price;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            // �������� ������ � ������ ��� ��������� ����� ��'��� LCDMonitor � ��������� ���������� ����
            LCDMonitor selectedMonitor = new LCDMonitor();
            selectedMonitor.Model = textBox1.Text;
            selectedMonitor.Manufacturer = textBox2.Text;
            selectedMonitor.Diagonal = textBox3.Text;
            selectedMonitor.HasTuner = radioButton1.Checked;
            selectedMonitor.Resolution = textBox5.Text;
            selectedMonitor.PanelType = textBox6.Text;
            selectedMonitor.Price = textBox4.Text;

            // ���������� ������� �������
            decimal totalPrice = CalculateMonitorPrice(selectedMonitor);

            // �������� ������� �������
            MessageBox.Show($"������� �������: {totalPrice} ���.");
        }

        private void CalculateMonthlyPayment(decimal totalPrice)
        {
            // ³�������� ������ �� ������
            decimal interestRate = 0.03m; // 3%

            // ʳ������ ������ �������
            int months = 12;

            // ���������� ������� ������ ������� �����
            decimal monthlyPayment = totalPrice / months;

            // �������� ������� ������� �� ������
            decimal interestPayment = 0;

            // ���������� ������� ���������� ������ ������� �� ������
            for (int i = 0; i < months; i++)
            {
                // ��������� ������� ������� ������� �� �������� ����
                interestPayment += totalPrice * interestRate / months;
            }

            // ��������� ������� ������ ������� �� �������� ����
            decimal totalPayment = totalPrice + interestPayment;

            // ���������� ���������� �� ���� ������� ���� ����
            monthlyPayment = Math.Round(monthlyPayment, 2);
            totalPayment = Math.Round(totalPayment, 2);

            // ��������� ����������
            MessageBox.Show($"̳����� ������: {monthlyPayment} ���.\n�������� ���� ������ �� ������: {totalPayment} ���.");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            // �������� ������ � ������ ��� ��������� ����� ��'��� TouchScreenMonitor � ��������� ���������� ����
            TouchScreenMonitor selectedMonitor = new TouchScreenMonitor();
            selectedMonitor.Model = textBox7.Text;
            selectedMonitor.Manufacturer = textBox8.Text;
            selectedMonitor.Diagonal = textBox9.Text;
            selectedMonitor.Resolution = textBox13.Text;
            selectedMonitor.ScreenType = textBox10.Text;
            selectedMonitor.HDDVolume = textBox11.Text;
            selectedMonitor.Price = textBox12.Text;

            // ���������� ������� ������ ������� ����� �� ������
            decimal totalPrice = decimal.Parse(selectedMonitor.Price);
            CalculateMonthlyPayment(totalPrice);
        }
    }
}
    