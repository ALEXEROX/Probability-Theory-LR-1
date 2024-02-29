using System.Diagnostics; //Podklyuchenie biblioteki dlya zapuska processov (Process)

namespace ProbabilityTheoryLR1
{
    public partial class Form1 : Form
    {
        public float ready = 0; //Peremennaya, hranyashaya gotovnost viychisleniy
        public XeroNumber a; //Bolshoe chislo, hranyashee rezultat
        public Thread numeration; //Potok viychisleniya

        public Form1()
        {
            InitializeComponent();
        }

        //Taymer, obnovlyayushiy polosu progremma
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ready < 1) //Esli viychislenie ne zaversheno
            {
                ProgressBar.Value = (int)(ready * 100); //Dayom polose progressa znachenie
                Percentage.Text = (ready * 100).ToString() + "%"; //I zapisiyvaem ego procentniyy variant
            }
            else
            {
                timer1.Stop(); //Ostanavlivaem taymer
                ProgressBar.Value = 100; //Zapolnyaem polosu
                Percentage.Text = "100%"; //Viychisleniya zaversheniy

                if (a.Size < 1000) //Esli chislo ne slishkom bolshoe
                    MessageBox.Show(a.ToString(), "Rezultat"); // Viyvodim ego v okno soobsheniya
                else //Inache viyvodim preduprezhdenie, chto rezultat zapisan v results.txt
                    MessageBox.Show("Iz-za velichiniy rezultata, on pomeshyon tolko v results.txt", "Rezultat");

                using (FileStream fs = new FileStream("results.txt", FileMode.OpenOrCreate)) //Otkriyvaem ili sozdayom results.txt
                using (StreamWriter sw = new StreamWriter(fs)) //Sozdayom process zapisi
                {
                    fs.Position = fs.Length == 0 ? 0 : fs.Length - 1; //Perenosim kursor v konec fayla

                    switch (ComboBox.SelectedIndex) //Smotrim na viybranniyy variant kombinacii i viyvodim v stroku usloviya
                    {
                        case 0: //Sochetanie bez povtoriy
                            sw.WriteLine("C n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                        case 1: //Razmeshenie bez povtora
                            sw.WriteLine("A n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                        case 2: //Razmeshenie s povtorom
                            sw.WriteLine("~A n=" + Number_n.Value.ToString() + " m=" + Number_m.Value.ToString());
                            break;
                    }

                    sw.WriteLine(a.ToString() + "\n"); //Viyvodim rezultat na novoy stroke i eshyo odin perenos stroki
                }

                ProgressBar.Visible = Percentage.Visible = false; //Pryachem polosu progressa iz procentnoe znachenie
                Number_n.Enabled = Number_m.Enabled = ComboBox.Enabled = Button.Enabled = true; //Vklyuchaem viybor kombinacii i chisel
            }
        }

        //Proizoshyol viybor kombinacii
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Viyvodim vse elementiy interfeysa, krome polosiy progressa
            Information.Visible = ClearResults.Visible = Label_n.Visible = Label_m.Visible = Number_n.Visible = Number_m.Visible = Button.Visible = true;

            switch (ComboBox.SelectedIndex) //Smotrim na viybranniyy variant kombinacii i otobrazhaem kartinku s formuloy
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

        //Knopka nazhata
        private void Button_Click(object sender, EventArgs e)
        {
            Percentage.Visible = ProgressBar.Visible = true; //Viyvodim polosu progressa 
            Number_n.Enabled = Number_m.Enabled = ComboBox.Enabled = Button.Enabled = false; //Blokiruem viybor chisel i kombinaci
            timer1.Start(); //Zapuskaem taymer

            switch (ComboBox.SelectedIndex) //Smotrim na viybranniyy variant kombinacii i dayom potoku viychisleniya funkciyu raschyota kombinacii
            {
                case 0: //Sochetanie bez povtora
                    numeration = new Thread(CWoR);
                    break;
                case 1: //Razmeshenie bez povtora
                    numeration = new Thread(AWoR);
                    break;
                case 2: //Razmeshenie s povtorom
                    numeration = new Thread(AWR);
                    break;
            }

            numeration.Start(); //Zapusk potoka
        }

        private void CWoR()
        {
            //Bibliotcheniyy metod raschyota sochetaniya bez povtora
            a = XeroNumber.CombinationWithoutRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        private void AWoR()
        {
            //Bibliotcheniyy metod raschyota razmesheniya bez povtora
            a = XeroNumber.ArrangementWithoutRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        private void AWR()
        {
            //Bibliotcheniyy metod raschyota razmesheniya s povtorom
            a = XeroNumber.ArrangementWithRepeat((int)Number_n.Value, (int)Number_m.Value, ref ready);
        }

        //Znachenie chisla n izmeneno
        private void Number_n_ValueChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = Number_n.Value > Number_m.Value; //Esli n > m, viyvodim stroku, ukaziyvayushuyu na oshibku
            Button.Enabled = Number_n.Value <= Number_m.Value; //Esli n <= m, razblokiruem knopku
        }

        //Znachenie chisla m izmeneno
        private void Number_m_ValueChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = Number_n.Value > Number_m.Value; //Esli n > m, viyvodim stroku, ukaziyvayushuyu na oshibku
            Button.Enabled = Number_n.Value <= Number_m.Value; //Esli n <= m, razblokiruem knopku
        }

        //Knopka "Ochistit results.txt" nazhata
        private void ClearResults_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("results.txt", FileMode.Create)) ;//Sozdayom results.txt Zanovo
        }

        //Knopka "Otkriyt results.txt" nazhata
        private void OpenResults_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("results.txt", FileMode.OpenOrCreate)) //Otkriyvaem ili sozdayom results.txt
                Process.Start("notepad.exe", "results.txt"); //Otkriyvaem ego v bloknote
        }

        //Kogda prilozhenie gotovo zakriytsya
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Eta stroka viyklyuchaet prilozhenie s zaversheniem vseh viychisleniy
            Environment.Exit(0);
        }
    }
}
