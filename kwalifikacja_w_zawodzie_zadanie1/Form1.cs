using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kwalifikacja_w_zawodzie_zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            combox_termin.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

        }
//imię (imiona), miejsce urodzenia, miejscowość,oraz poczta 
        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[A-Z]+$");
            Regex peselregex = new Regex("^[0-9]{11}$");
            Regex kod_pocztowyregex = new Regex("[0-9]{2}-[0-9]{3}");
            Regex ulicainrdomu = new Regex("(^[A-ZŹ]+ )+\\d+[A-Z]?(\\/\\d+)?$");
            if (!regex.IsMatch(Nazwisko.Text.Trim()))
            {
                Nazwisko.BackColor = Color.Red;
            }
            else
            {
                Nazwisko.BackColor = Color.White;
            }
            if (!regex.IsMatch(Imie.Text.Trim()))
            {
                Imie.BackColor = Color.Red;
            }
            else
            {
                Imie.BackColor = Color.White;
            }
            if (!regex.IsMatch(miejsceuro.Text.Trim()))
            {
                miejsceuro.BackColor = Color.Red;
            }
            else
            {
                miejsceuro.BackColor = Color.White;
            }
            if (!regex.IsMatch(miejscowosc.Text.Trim()))
            {
                miejscowosc.BackColor = Color.Red;
            }
            else
            {
                miejscowosc.BackColor = Color.White;
            }
            if (!regex.IsMatch(poczta.Text.Trim()))
            {
                poczta.BackColor = Color.Red;
            }
            else
            {
                poczta.BackColor = Color.White;
            }
            if (!ulicainrdomu.IsMatch(domek.Text.Trim()))
            {
                domek.BackColor = Color.Red;
            }
            else
            {
                domek.BackColor = Color.White;
            }
            if (!peselregex.IsMatch(pesel.Text.Trim()))
            {
                pesel.BackColor = Color.Red;
            }
            else
            {
                pesel.BackColor = Color.White;
            }
            if (!kod_pocztowyregex.IsMatch(kodpocztowy.Text.Trim()))
            {
                kodpocztowy.BackColor = Color.Red;
            }
            else
            {
                kodpocztowy.BackColor = Color.White;
            }

        }//comboBox2.Items[0] = "INF2";— technik informatyk – INF.02 i INF.03,
//— technik programista – INF.03 i INF.04.

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
                label12.Text = "INF.02 – Administracja i eksploatacja systemów komputerowych, urządzeń\r\nperyferyjnych i lokalnych sieci komputerowych";
            }
            if (selectedItem.ToString() == "INF.03")
            {
                label12.Text = "INF.03 – Tworzenie i administrowanie stronami i aplikacjami internetowymi oraz\r\nbazami danych";
            }
            if (selectedItem.ToString() == "INF.04")
            {
                label12.Text = "INF.04 – Projektowanie, programowanie i testowanie aplikacji.";
            }
        }
    }
}
