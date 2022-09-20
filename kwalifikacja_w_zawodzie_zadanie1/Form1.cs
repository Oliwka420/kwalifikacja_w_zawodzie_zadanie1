using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kwalifikacja_w_zawodzie_zadanie1
{
    public partial class Form1 : Form
    {
        bool czy_poprawny_email = false;
        bool czy_poprawny_imie = false;
        bool czy_poprawny_nazwisko = false;
        bool czy_poprawny_pesel = false;
        bool czy_poprawny_kod_pocztowy = false;
        bool czy_poprawny_ulica = false;
        bool czy_poprawny_miejscowosc = false;
        bool czy_poprawny_poczta = false;
        bool czy_poprawny_telefon = false;
        bool czy_poprawy_miejsceuro = false;
        Regex regex = new Regex("^[A-Z]+$");
        Regex peselregex = new Regex("^[0-9]{11}$");
        Regex kod_pocztowyregex = new Regex("[0-9]{2}-[0-9]{3}");
        Regex ulicainrdomu = new Regex("(^[A-ZŹ]+ )+\\d+[A-Z]?(\\/\\d+)?$");
        Regex nrtelefonuregex = new Regex(@"^\+[0-9]{2} ?[0-9]{2} ?\d{7}$");
        Regex emailregex = new Regex(@"^[^@]+@{1}[^@]*\.[^@]+$");
        string kod, informacja_klasyfikacja,ktoryraz,specjalizacja,kwalifikacja;
        
        public Form1()
        {
            InitializeComponent();
            combox_termin.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            Nazwisko.BackColor = Color.White;
            if (nrtel.Focus())
            {
                nrtel.BackColor = Color.Pink;
            }
        }
        //imię (imiona), miejsce urodzenia, miejscowość,oraz poczta 
        private void button1_Click(object sender, EventArgs e)
        {
            //wyświetleniem odpowiedniego komunikatu w oknie dialogowym.
            //Próba poprawienia błędu – przywraca biły kolor tła


            if (!emailregex.IsMatch(emai.Text))
            {
                emai.BackColor = Color.Red;
                czy_poprawny_email = false;
                DialogResult res = MessageBox.Show("Wprowadzono niepoprawny email", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            else
            {
                emai.BackColor = Color.White;
                czy_poprawny_email = true;
            }
            if (!nrtelefonuregex.IsMatch(nrtel.Text))
            {
                nrtel.BackColor = Color.Red;
                czy_poprawny_telefon = false;
            }
            else
            {
                nrtel.BackColor = Color.White;
                czy_poprawny_telefon = true;
            }
            if (!regex.IsMatch(Nazwisko.Text.Trim()))
            {
                Nazwisko.BackColor = Color.Red;
                czy_poprawny_nazwisko = false;
            }
            else
            {
                Nazwisko.BackColor = Color.White;
                czy_poprawny_nazwisko = true;
            }
            if (!regex.IsMatch(Imie.Text.Trim()))
            {
                Imie.BackColor = Color.Red;
                czy_poprawny_imie = false;
            }
            else
            {
                Imie.BackColor = Color.White;
                czy_poprawny_imie = true;
            }
            if (!regex.IsMatch(miejsceuro.Text.Trim()))
            {
                miejsceuro.BackColor = Color.Red;
                czy_poprawy_miejsceuro = false;
            }
            else
            {
                miejsceuro.BackColor = Color.White;
                czy_poprawy_miejsceuro = true;
            }
            if (!regex.IsMatch(miejscowosc.Text.Trim()))
            {
                miejscowosc.BackColor = Color.Red;
                czy_poprawny_miejscowosc = false;
            }
            else
            {
                miejscowosc.BackColor = Color.White;
                czy_poprawny_miejscowosc = true;
            }
            if (!regex.IsMatch(poczta.Text.Trim()))
            {
                poczta.BackColor = Color.Red;
                czy_poprawny_poczta = false;
            }
            else
            {
                poczta.BackColor = Color.White;
                czy_poprawny_poczta = true;
            }
            if (!ulicainrdomu.IsMatch(domek.Text.Trim()))
            {
                domek.BackColor = Color.Red;
                czy_poprawny_ulica = false;
            }
            else
            {
                domek.BackColor = Color.White;
                czy_poprawny_ulica = true;
            }
            if (!peselregex.IsMatch(pesel.Text.Trim()))
            {
                pesel.BackColor = Color.Red;
                czy_poprawny_pesel = false;
            }
            else
            {
                pesel.BackColor = Color.White;
                czy_poprawny_pesel = true;
            }
            if (!kod_pocztowyregex.IsMatch(kodpocztowy.Text.Trim()))
            {
                kodpocztowy.BackColor = Color.Red;
                czy_poprawny_kod_pocztowy = false;
            }
            else
            {
                kodpocztowy.BackColor = Color.White;
                czy_poprawny_kod_pocztowy = true;
            }
            if (pierwszy.Checked)
            {
                ktoryraz = "pierwszy";
            }else if (kolejny.Checked)
            {
                
                if (praktyka.Checked && pisemna.Checked)
                {
                    ktoryraz = "kolejny do części: praktycznej i pisemnej";
                    
                }
                else if (pisemna.Checked)
                {
                    ktoryraz = "kolejny do części: pisemnej";
                }
                else  if(praktyka.Checked)
                {
                    ktoryraz = "kolejny do części: praktycznej";
                }
                
            }

            if (czy_poprawny_email &&
                czy_poprawny_imie &&
                czy_poprawny_nazwisko &&
                czy_poprawny_pesel &&
                czy_poprawny_kod_pocztowy &&
                czy_poprawny_ulica &&
                czy_poprawny_miejscowosc &&
                czy_poprawny_poczta &&
                czy_poprawny_telefon &&
                czy_poprawy_miejsceuro)
            {
                if (informatyk.Checked)
                {
                    kod = "351203";
                    specjalizacja = "technik informatyk";
                }
                else if (programista.Checked)
                {
                    kod = "351406";
                    specjalizacja = "technik programista";
                }
                richTextBox1.Text = "Deklaruję przystąpienie do egzaminu potwierdzającego klasyfikacje w zawodzie przeprowadzanego w terminie: " + combox_termin.Text +
                    "\n\nDane osobowe ucznia\n\n" +
                    "Nazwisko:                              " + Nazwisko.Text +
                    "\nImię(imiona):                         " + Imie.Text +
                    "\nData i miejsce urodzenia:     "+ dateTimePicker1.Value + " "+ miejsceuro.Text +
                    "\nNumer PESEL:                        " + pesel.Text +
                    "\n\nAdres korenspondencyjny\n" +
                    "Miejscowość:                          " + miejscowosc.Text +
                    "\nUlica i numer domu:              " + domek.Text +
                    "\nKod pocztowy i poczta:          " + kodpocztowy.Text +" "+ poczta.Text +
                    "\nNr telefonu z kierunkowym:  " +nrtel.Text +
                    "\nEmail:                                        " + emai.Text +
                    "\n\nDeklaruje przystąpienie do egzaminu po raz " +ktoryraz + ""+
                    "\n\nOznaczenie kwalifikacji zgodne z podstawąprogramową: " +kwalifikacja+
                    "\nNazwa kwalifikacji:             \n" + informacja_klasyfikacja +
                    "\n\nSymbol cyfrowy zawodu: " + kod +
                    "\nNazwa zawodu:                 "+ specjalizacja;
            }
            else
            {
                richTextBox1.Text = "";
            }
        }
        private void informatyk_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Items[0] = "INF.02";
            comboBox2.Items[1] = "INF.03";

        }

        private void programista_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Items[0] = "INF.03";
            comboBox2.Items[1] = "INF.04";


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = comboBox2.SelectedItem;
            if (selectedItem.ToString() == "INF.02")
            {
                kwalifikacja = "INF.02";
                informacja_klasyfikacja = "INF.02 – Administracja i eksploatacja systemów komputerowych, urządzeń peryferyjnych i lokalnych sieci komputerowych";
            }
            if (selectedItem.ToString() == "INF.03")
            {
                kwalifikacja = "INF.03";
                informacja_klasyfikacja = "INF.03 – Tworzenie i administrowanie stronami i aplikacjami internetowymi oraz bazami danych";
            }
            if (selectedItem.ToString() == "INF.04")
            {
                kwalifikacja = "INF.04";
                informacja_klasyfikacja = "INF.04 – Projektowanie, programowanie i testowanie aplikacji.";
            }
            label12.Text = informacja_klasyfikacja;

        }

        private void pierwszy_CheckedChanged(object sender, EventArgs e)
        {
            pisemna.Checked = true;
            pisemna.Enabled = false;

            praktyka.Checked = true;
            praktyka.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file|*.txt";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void kolejny_CheckedChanged(object sender, EventArgs e)
        {
            pisemna.Checked = false;
            pisemna.Enabled = true;

            praktyka.Checked = false;
            praktyka.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nazwisko.Text = "";
            Imie.Text = "";
            miejsceuro.Text = "";
            pesel.Text = "";
            miejscowosc.Text = "";
            domek.Text = "";
            kodpocztowy.Text = "";
            poczta.Text = "";
            nrtel.Text = "";
            emai.Text = "";

        }

        private void Nazwisko_TextChanged(object sender, EventArgs e)
        {
            Nazwisko.BackColor = Color.White;

        }

        private void Nazwisko_Enter(object sender, EventArgs e)
        {

            Control a = (TextBox)sender;
            a.BackColor = Color.White;
        }
    }
}
