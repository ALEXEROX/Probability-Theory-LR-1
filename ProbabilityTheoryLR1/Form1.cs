using System.Diagnostics; //Подключение библиотеки для запуска процессов (Process)

namespace ProbabilityTheoryLR1
{
    public partial class Form1 : Form
    {
        public float ready = 0; //Переменная, хранящая готовность вычислений
        public XeroNumber a; //Большое число, хранящее результат
        public Thread numeration; //Поток вычисления

        public Form1()
        {
            InitializeComponent();
        }

        //Таймер, обновляющий полосу прогремма
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ready < 1) //Если вычисление не завершено
            {
                ProgressBar.Value = (int)(ready * 100); //Даём полосе прогресса значение
                Percentage.Text = (ready * 100).ToString() + "%"; //И записываем его процентный вариант
            }
            else
            {
                timer1.Stop(); //Останавливаем таймер
                ProgressBar.Value = 100; //Заполняем полосу
                Percentage.Text = "100%"; //Вычисления завершены

                if (a.Size < 1000) //Если число не слишком большое
                    MessageBox.Show(a.ToString(), "Результат"); // Выводим его в окно сообщения
                else //Иначе выводим предупреждение, что результат записан в results.txt
                    MessageBox.Show("Из-за величины результата, он помещён только в results.txt", "Результат");

                using (FileStream fs = new FileStream("results.txt", FileMode.OpenOrCreate)) //Открываем или создаём results.txt
                using (StreamWriter sw = new StreamWriter(fs)) //Создаём процесс записи
                {
                    fs.Position = fs.Length == 0 ? 0 : fs.Length - 1; //Переносим курсор в конец файла

                    switch (ComboBox.SelectedIndex) //Смотрим на выбранный вариант комбинации и выводим в строку условия
                    {
                        case 0: //Сочетание без повторы
                            sw.WriteLine("C n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                        case 1: //Размещение без повтора
                            sw.WriteLine("A n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                        case 2: //Размещение с повтором
                            sw.WriteLine("~A n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                    }
                    
                    sw.WriteLine(a.ToString() + "\n"); //Выводим результат на новой строке и ещё один перенос строки
                }

                ProgressBar.Visible = Percentage.Visible = false; //Прячем полосу прогресса из процентное значение
                Number_n.Enabled = Number_m.Enabled = ComboBox.Enabled = Button.Enabled = true; //Включаем выбор комбинации и чисел
            }
        }

        //Произошёл выбор комбинации
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Выводим все элементы интерфейса, кроме полосы прогресса
            Information.Visible = ClearResults.Visible = Label_n.Visible = Label_m.Visible = Number_n.Visible = Number_m.Visible = Button.Visible = true;

            switch (ComboBox.SelectedIndex) //Смотрим на выбранный вариант комбинации и отображаем картинку с формулой
            {
                case 0:
                    PictureBox.Image = Properties.Resources.C;
                    break;
                case 1:
                    PictureBox.Image = Properties.Resources.A;
                    break;
                case 2:
                    PictureBox.Image = Properties.Resources.An;
                    break;
            }
        }

        //Кнопка нажата
        private void Button_Click(object sender, EventArgs e)
        {
            Percentage.Visible = ProgressBar.Visible = true; //Выводим полосу прогресса 
            Number_n.Enabled = Number_m.Enabled = ComboBox.Enabled = Button.Enabled = false; //Блокируем выбор чисел и комбинаци
            timer1.Start(); //Запускаем таймер

            switch (ComboBox.SelectedIndex) //Смотрим на выбранный вариант комбинации и даём потоку вычисления функцию расчёта комбинации
            {
                case 0: //Сочетание без повтора
                    numeration = new Thread(CWoR);
                    break;
                case 1: //Размещение без повтора
                    numeration = new Thread(AWoR);
                    break;
                case 2: //Размещение с повтором
                    numeration = new Thread(AWR);
                    break;
            }

            numeration.Start(); //Запуск потока
        }

        private void CWoR()
        {
            //Библиотченый метод расчёта сочетания без повтора
            a = XeroNumber.CombinationWithoutRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        private void AWoR()
        {
            //Библиотченый метод расчёта размещения без повтора
            a = XeroNumber.ArrangementWithoutRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        private void AWR()
        {
            //Библиотченый метод расчёта размещения с повтором
            a = XeroNumber.ArrangementWithRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        //Значение числа n изменено
        private void Number_n_ValueChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = Number_n.Value > Number_m.Value; //Если n > m, выводим строку, указывающую на ошибку
            Button.Enabled = Number_n.Value <= Number_m.Value; //Если n <= m, разблокируем кнопку
        }

        //Значение числа m изменено
        private void Number_m_ValueChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = Number_n.Value > Number_m.Value; //Если n > m, выводим строку, указывающую на ошибку
            Button.Enabled = Number_n.Value <= Number_m.Value; //Если n <= m, разблокируем кнопку
        }

        //Кнопка "Очистить results.txt" нажата
        private void ClearResults_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("results.txt", FileMode.Create)) ;//Создаём results.txt Заново
        }

        //Кнопка "Открыть results.txt" нажата
        private void OpenResults_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("results.txt", FileMode.OpenOrCreate)) //Открываем или создаём results.txt
                Process.Start("notepad.exe", "results.txt"); //Открываем его в блокноте
        }

        //Когда приложение готово закрыться
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Эта строка выключает приложение с завершением всех вычислений
            Environment.Exit(0);
        }
    }
}
