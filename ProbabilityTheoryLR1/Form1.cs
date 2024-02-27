using System.Diagnostics; //����������� ���������� ��� ������� ��������� (Process)

namespace ProbabilityTheoryLR1
{
    public partial class Form1 : Form
    {
        public float ready = 0; //����������, �������� ���������� ����������
        public XeroNumber a; //������� �����, �������� ���������
        public Thread numeration; //����� ����������

        public Form1()
        {
            InitializeComponent();
        }

        //������, ����������� ������ ���������
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ready < 1) //���� ���������� �� ���������
            {
                ProgressBar.Value = (int)(ready * 100); //��� ������ ��������� ��������
                Percentage.Text = (ready * 100).ToString() + "%"; //� ���������� ��� ���������� �������
            }
            else
            {
                timer1.Stop(); //������������� ������
                ProgressBar.Value = 100; //��������� ������
                Percentage.Text = "100%"; //���������� ���������

                if (a.Size < 1000) //���� ����� �� ������� �������
                    MessageBox.Show(a.ToString(), "���������"); // ������� ��� � ���� ���������
                else //����� ������� ��������������, ��� ��������� ������� � results.txt
                    MessageBox.Show("��-�� �������� ����������, �� ������� ������ � results.txt", "���������");

                using (FileStream fs = new FileStream("results.txt", FileMode.OpenOrCreate)) //��������� ��� ������ results.txt
                using (StreamWriter sw = new StreamWriter(fs)) //������ ������� ������
                {
                    fs.Position = fs.Length == 0 ? 0 : fs.Length - 1; //��������� ������ � ����� �����

                    switch (ComboBox.SelectedIndex) //������� �� ��������� ������� ���������� � ������� � ������ �������
                    {
                        case 0: //��������� ��� �������
                            sw.WriteLine("C n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                        case 1: //���������� ��� �������
                            sw.WriteLine("A n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                        case 2: //���������� � ��������
                            sw.WriteLine("~A n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                    }
                    
                    sw.WriteLine(a.ToString() + "\n"); //������� ��������� �� ����� ������ � ��� ���� ������� ������
                }

                ProgressBar.Visible = Percentage.Visible = false; //������ ������ ��������� �� ���������� ��������
                Number_n.Enabled = Number_m.Enabled = ComboBox.Enabled = Button.Enabled = true; //�������� ����� ���������� � �����
            }
        }

        //��������� ����� ����������
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //������� ��� �������� ����������, ����� ������ ���������
            Information.Visible = ClearResults.Visible = Label_n.Visible = Label_m.Visible = Number_n.Visible = Number_m.Visible = Button.Visible = true;

            switch (ComboBox.SelectedIndex) //������� �� ��������� ������� ���������� � ���������� �������� � ��������
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

        //������ ������
        private void Button_Click(object sender, EventArgs e)
        {
            Percentage.Visible = ProgressBar.Visible = true; //������� ������ ��������� 
            Number_n.Enabled = Number_m.Enabled = ComboBox.Enabled = Button.Enabled = false; //��������� ����� ����� � ���������
            timer1.Start(); //��������� ������

            switch (ComboBox.SelectedIndex) //������� �� ��������� ������� ���������� � ��� ������ ���������� ������� ������� ����������
            {
                case 0: //��������� ��� �������
                    numeration = new Thread(CWoR);
                    break;
                case 1: //���������� ��� �������
                    numeration = new Thread(AWoR);
                    break;
                case 2: //���������� � ��������
                    numeration = new Thread(AWR);
                    break;
            }

            numeration.Start(); //������ ������
        }

        private void CWoR()
        {
            //������������ ����� ������� ��������� ��� �������
            a = XeroNumber.CombinationWithoutRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        private void AWoR()
        {
            //������������ ����� ������� ���������� ��� �������
            a = XeroNumber.ArrangementWithoutRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        private void AWR()
        {
            //������������ ����� ������� ���������� � ��������
            a = XeroNumber.ArrangementWithRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        //�������� ����� n ��������
        private void Number_n_ValueChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = Number_n.Value > Number_m.Value; //���� n > m, ������� ������, ����������� �� ������
            Button.Enabled = Number_n.Value <= Number_m.Value; //���� n <= m, ������������ ������
        }

        //�������� ����� m ��������
        private void Number_m_ValueChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = Number_n.Value > Number_m.Value; //���� n > m, ������� ������, ����������� �� ������
            Button.Enabled = Number_n.Value <= Number_m.Value; //���� n <= m, ������������ ������
        }

        //������ "�������� results.txt" ������
        private void ClearResults_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("results.txt", FileMode.Create)) ;//������ results.txt ������
        }

        //������ "������� results.txt" ������
        private void OpenResults_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("results.txt", FileMode.OpenOrCreate)) //��������� ��� ������ results.txt
                Process.Start("notepad.exe", "results.txt"); //��������� ��� � ��������
        }

        //����� ���������� ������ ���������
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //��� ������ ��������� ���������� � ����������� ���� ����������
            Environment.Exit(0);
        }
    }
}
