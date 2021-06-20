using System;
using System.Windows.Forms;

namespace xTocka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool XRed = true;
        private bool IgrataZavrsi = false;
        private const int xPobedi = 1;
        private const int oPobedi = -1;
        private const int Nereseno = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            btnKlik(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            IgrataZavrsi = false;
            XRed = true;
            Button[] btnIzbor = new Button[] { button1, button2, button3,
                                                   button4, button5, button6,
                                                   button7, button8, button9};
            for (int i = 0; i < btnIzbor.Length; i++)
                btnIzbor[i].Text = "";
            label1.Text = "На ред е играчот X!";
        }
        // za sekoe kliknato kopce
        private void btnKlik(object sender, EventArgs e)
        {
            Button btnKliknat = sender as Button;
            if (btnKliknat.Text == "" && XRed)
            {
                if (IgrataZavrsi)
                    return;
                btnKliknat.Text = "X";
                XRed = false;
                if (isWon("X"))
                {
                    IgrataZavrsi = true;
                    label1.Text = "X победи!";
                    return;
                }
                label1.Text = "Се чека на О...";
            }
            if (!IgrataZavrsi)
            {
                if (button1.Text != "" && button2.Text != "" && button3.Text != "" &&
                    button4.Text != "" && button5.Text != "" && button6.Text != "" &&
                    button7.Text != "" && button8.Text != "" && button9.Text != "")
                {
                    label1.Text = "Нерешено!";
                    IgrataZavrsi = true;
                }
            }
            if (!IgrataZavrsi && !XRed)
                PotegNaKompjuter();
            if (!IgrataZavrsi)
            {
                if (button1.Text != "" && button2.Text != "" && button3.Text != "" &&
                    button4.Text != "" && button5.Text != "" && button6.Text != "" &&
                    button7.Text != "" && button8.Text != "" && button9.Text != "")
                {
                    label1.Text = "Нерешено!";
                    IgrataZavrsi = true;
                }
            }
        }
        // poteg na kompjuterot
        private void PotegNaKompjuter()
        {
            Button[] btnIzbor = new Button[] { button1, button2, button3,
                                                   button4, button5, button6,
                                                   button7, button8, button9};
            int izbor = minimaxOdluka();
            Console.WriteLine("Избор на О =" + izbor);
            btnIzbor[izbor].Text = "O";
            if (isWon("O"))
            {
                IgrataZavrsi = true;
                label1.Text = "О Победи!";
                return;
            }
            XRed = true;
            label1.Text = "На ред е играчот X!";
        }
        // proveruva dali ima pobednik
        private bool isWon(string znak)
        {
            Button[,] kelija = new Button[3, 3] { { button1, button2, button3 },
                                                { button4, button5, button6 },
                                                { button7, button8, button9 } };
            //Po redici
            for (int i = 0; i < 3; i++)
                if ((kelija[i, 0].Text == znak)
                    && (kelija[i, 1].Text == znak)
                    && (kelija[i, 2].Text == znak))
                    return true;
            //Po koloni
            for (int j = 0; j < 3; j++)
                if ((kelija[0, j].Text == znak)
                    && (kelija[1, j].Text == znak)
                    && (kelija[2, j].Text == znak))
                    return true;
            //Po dijagonala
            if ((kelija[0, 0].Text == znak)
                && (kelija[1, 1].Text == znak)
                && (kelija[2, 2].Text == znak))
                return true;
            //Po drugata dijagonala
            if ((kelija[0, 2].Text == znak)
                && (kelija[1, 1].Text == znak)
                && (kelija[2, 0].Text == znak))
                return true;
            //Ako nema pobednik
            return false;
        }

        private int sostojbaRezultat(int[] momentalnaSostojba)
        {
            int[,] momentalnaSostojba3x3 = new int[3, 3];
            int momentalnaSostojbaBroj = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    momentalnaSostojba3x3[i, j] = momentalnaSostojba[momentalnaSostojbaBroj];
                    momentalnaSostojbaBroj++;
                }
            int NEMAPOBEDNIK = 2;
            bool eNereseno = true;
            //Redici za X
            for (int i = 0; i < 3; i++)
                if ((momentalnaSostojba3x3[i, 0] == 1)
                    && (momentalnaSostojba3x3[i, 1] == 1)
                    && (momentalnaSostojba3x3[i, 2] == 1))
                    return xPobedi;
            //Koloni za  X
            for (int j = 0; j < 3; j++)
                if ((momentalnaSostojba3x3[0, j] == 1)
                    && (momentalnaSostojba3x3[1, j] == 1)
                    && (momentalnaSostojba3x3[2, j] == 1))
                    return xPobedi;
            //Dijagonala za X
            if ((momentalnaSostojba3x3[0, 0] == 1)
                && (momentalnaSostojba3x3[1, 1] == 1)
                && (momentalnaSostojba3x3[2, 2] == 1))
                return xPobedi;
            //Drugata dijagonala za X
            if ((momentalnaSostojba3x3[0, 2] == 1)
                && (momentalnaSostojba3x3[1, 1] == 1)
                && (momentalnaSostojba3x3[2, 0] == 1))
                return xPobedi;
            //Redovi za 0 (Tocka)
            for (int i = 0; i < 3; i++)
                if ((momentalnaSostojba3x3[i, 0] == -1)
                    && (momentalnaSostojba3x3[i, 1] == -1)
                    && (momentalnaSostojba3x3[i, 2] == -1))
                    return oPobedi;
            //Koloni za O (Tocka)
            for (int j = 0; j < 3; j++)
                if ((momentalnaSostojba3x3[0, j] == -1)
                    && (momentalnaSostojba3x3[1, j] == -1)
                    && (momentalnaSostojba3x3[2, j] == -1))
                    return oPobedi;
            //Dijagonala za  O (Tocka)
            if ((momentalnaSostojba3x3[0, 0] == -1)
                && (momentalnaSostojba3x3[1, 1] == -1)
                && (momentalnaSostojba3x3[2, 2] == -1))
                return oPobedi;
            //Druga dijagonala za  O (Tocka)
            if ((momentalnaSostojba3x3[0, 2] == -1)
                && (momentalnaSostojba3x3[1, 1] == -1)
                && (momentalnaSostojba3x3[2, 0] == -1))
                return oPobedi;
            //Nereseno
            for (int k = 0; k < 3; k++)
                for (int n = 0; n < 3; n++)
                    if (momentalnaSostojba3x3[k, n] == 0)
                        eNereseno = false;
            if (eNereseno)
                return Nereseno;
            //Nema pobednik
            return NEMAPOBEDNIK;
        }

        private int[] zemiPocetnaSostojba()
        {
            int[] opcii = new int[9];
            Button[] btnIzbor = new Button[] { button1, button2, button3,
                                                   button4, button5, button6,
                                                   button7, button8, button9};
            for (int i = 0; i < 9; i++)
            {
                if (btnIzbor[i].Text == "X")
                    opcii[i] = 1;
                else if (btnIzbor[i].Text == "O")
                    opcii[i] = -1;
                else
                    opcii[i] = 0;
            }
            return opcii;
        }

        private int minNaNizata(int[] array)
        {
            int najmaliot = int.MaxValue;
            int najmaliotBrojElementi = 0; //proizvolno
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < najmaliot)
                {
                    najmaliot = array[i];
                    najmaliotBrojElementi = i;
                }
            }
            Console.WriteLine(najmaliotBrojElementi + " " + najmaliot);
            return najmaliotBrojElementi;
        }

        private int minimaxOdluka()
        {
            int[] sostojba = zemiPocetnaSostojba();
            int odluka = int.MaxValue;
            int[] ListaNaOpcii = new int[9];
            for (int opcija = 0; opcija < sostojba.Length; opcija++)
            {
                int[] potencijalnaSostojba = zemiPocetnaSostojba();
                if (sostojba[opcija] == 0)
                {
                    potencijalnaSostojba[opcija] = -1;
                    odluka = minimum(odluka, maxFunction(potencijalnaSostojba));
                    ListaNaOpcii[opcija] = odluka;
                }
                else
                    ListaNaOpcii[opcija] = int.MaxValue;
            }
            return minNaNizata(ListaNaOpcii);
        }

        private int minFunkcija(int[] momentalnaSostojba)
        {
            if (TestTerminal(momentalnaSostojba))
                return aFunkcija(momentalnaSostojba);
            int best = int.MaxValue;
            int[] potencijalnaSostojba = new int[9];
            for (int newizbor = 0; newizbor < potencijalnaSostojba.Length; newizbor++)
            {
                for (int i = 0; i < potencijalnaSostojba.Length; i++)
                    potencijalnaSostojba[i] = momentalnaSostojba[i];
                if (momentalnaSostojba[newizbor] == 0)
                {
                    potencijalnaSostojba[newizbor] = -1;
                    int move = maxFunction(potencijalnaSostojba);
                    if (move < best)
                        best = move;
                }
            }
            return best;
        }

        private int maxFunction(int[] momentalnaSostojba)
        {
            if (TestTerminal(momentalnaSostojba))
                return aFunkcija(momentalnaSostojba);
            int best = int.MinValue;
            int[] potencijalnaSostojba = new int[9];
            for (int newizbor = 0; newizbor < potencijalnaSostojba.Length; newizbor++)
            {
                for (int i = 0; i < potencijalnaSostojba.Length; i++)
                    potencijalnaSostojba[i] = momentalnaSostojba[i];
                if (momentalnaSostojba[newizbor] == 0)
                {
                    potencijalnaSostojba[newizbor] = 1;
                    int move = minFunkcija(potencijalnaSostojba);
                    if (move > best)
                        best = move;
                }
            }
            return best;
        }

        private bool TestTerminal(int[] momentalnaSostojba)
        {
            if (sostojbaRezultat(momentalnaSostojba) != 2)
                return true;
            else
                return false;
        }

        private int aFunkcija(int[] momentalnaSostojba)
        {
            if (sostojbaRezultat(momentalnaSostojba) == xPobedi)
                return xPobedi;
            else if (sostojbaRezultat(momentalnaSostojba) == oPobedi)
                return oPobedi;
            else if (sostojbaRezultat(momentalnaSostojba) == Nereseno)
                return Nereseno;
            else
                return 10; //greska
        }
        // go naoga pomaliot od dva broja
        private int minimum(int x1, int x2)
        {
            if (x1 > x2)
                return x2;
            else
                return x1;//ne e vazno koj ako se ednakvi
        }
        // go naoga pogolemiot od dva broja
        private int maximum(int y1, int y2)
        {
            if (y1 < y2)
                return y2;
            else
                return y1;//ne e vazno koj ako se ednakvi
        }
    }
}
