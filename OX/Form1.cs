using System;
using System.Windows.Forms;

namespace OX
{
    public partial class Form1 : Form
    {
        bool czyKolko = true;
        Button[] wszystkiePrzyciski;
        public Form1()
        {
            InitializeComponent();
            lblCzyjRuch.Text = "O";
            wszystkiePrzyciski = new Button[] {btn1, btn2, btn3,
                btn4, btn5, btn6, btn7, btn8, btn9};
        }

        private void btn_click(object sender, EventArgs e)
        {
            WstawZnak(sender);
            if (!SprawdzWygrana())
            {
                AktualizujGracza();
            }
        }

        private void AktualizujGracza()
        {
            czyKolko = !czyKolko;
            if (czyKolko)
            {
                lblCzyjRuch.Text = "O";
            }
            else
            {
                lblCzyjRuch.Text = "X";
            }
        }

        private void WstawZnak(object przycisk)
        {
            Button wcisnietyPrzycisk = przycisk as Button;

            if (czyKolko)
            {
                wcisnietyPrzycisk.Text = "O";
            }
            else
            {
                wcisnietyPrzycisk.Text = "X";
            }

            wcisnietyPrzycisk.Enabled = false;
        }

        private bool SprawdzWygrana()
        {
            bool wynik = SprawdzCzyKtosWygral();

            if (wynik)
            {
                string tekstWygranej = "Wygrał gracz ";
                if (czyKolko)
                {
                    tekstWygranej += "O!";
                }
                else
                {
                    tekstWygranej += "X!";
                }
                tekstWygranej += " Rozpocząć jeszce raz?";

                DialogResult odpowiedz =
                    MessageBox.Show(tekstWygranej, "Wygrana",
                    MessageBoxButtons.YesNo);

                if (odpowiedz == DialogResult.Yes)
                {
                    ResetujPlansze();
                }
                else
                {
                    Close();
                }
            }
            return wynik;
        }

        private void ResetujPlansze()
        {
            foreach (Button przycisk in wszystkiePrzyciski)
            {
                przycisk.Text = "";
                przycisk.Enabled = true;
            }
            czyKolko = true;
            lblCzyjRuch.Text = "O";
        }

        private bool SprawdzCzyKtosWygral()
        {
            if (btn1.Text == btn2.Text &&
                btn2.Text == btn3.Text && btn3.Text != "")
            {
                return true;
            }
            if (btn4.Text == btn5.Text &&
                btn5.Text == btn6.Text && btn6.Text != "")
            {
                return true;
            }
            if (btn7.Text == btn8.Text &&
                btn8.Text == btn9.Text && btn9.Text != "")
            {
                return true;
            }
            if (btn1.Text == btn4.Text &&
                btn4.Text == btn7.Text && btn7.Text != "")
            {
                return true;
            }
            if (btn2.Text == btn5.Text &&
                btn5.Text == btn8.Text && btn8.Text != "")
            {
                return true;
            }
            if (btn3.Text == btn6.Text &&
                btn6.Text == btn9.Text && btn9.Text != "")
            {
                return true;
            }
            if (btn1.Text == btn5.Text &&
                btn5.Text == btn9.Text && btn9.Text != "")
            {
                return true;
            }
            if (btn3.Text == btn5.Text &&
                btn5.Text == btn7.Text && btn7.Text != "")
            {
                return true;
            }
            return false;
        }
    }
}
