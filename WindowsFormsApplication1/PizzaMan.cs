using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaManDelivery
{
    public partial class PizzaMan : Form

    {
        private List<Adress> adresses = new List<Adress>();
        private DistanceFinder distanceFinder = new DistanceFinder();
        private List<Task> tasks = new List<Task>();
        private List<List<int>> perms = new List<List<int>>();
        private int cMax;

        public PizzaMan()
        {
            InitializeComponent();
            adresses.Add(new Adress("Wyspianskiego", 27));
        }

        private void PizzaMan_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Adress adress = new Adress(textBoxStreet.Text, int.Parse(textBoxNumber.Text));
                adresses.Add(adress);
                listBoxActual.Items.Add(adress.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Niewłaściwy format adresu");
            }
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxNumber_Enter(object sender, EventArgs e)
        {
            if (textBoxNumber.Text.Equals("Nr"))
            {
                textBoxNumber.Text = "";
            }
        }

        private void textBoxNumber_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNumber.Text))
            {
                textBoxNumber.Text = "Nr";
            }
        }

        private void textBoxStreet_Enter(object sender, EventArgs e)
        {
            if (textBoxStreet.Text.Equals("Ulica"))
            {
                textBoxStreet.Text = "";
            }
        }

        private void textBoxStreet_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxStreet.Text))
            {
                textBoxStreet.Text = "Ulica";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            for (int i = listBoxActual.Items.Count - 1; i >= 0; i--)
            {
                if (listBoxActual.GetSelected(i))
                {
                    adresses.RemoveAt(i);
                    listBoxActual.Items.RemoveAt(i);
                }
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            textBoxResults.Clear();
            
            adresses.Add(new Adress("Wietrzna", 22)); //0
            adresses.Add(new Adress("Piwna", 25)); //1
            adresses.Add(new Adress("Reja", 16)); //2
            adresses.Add(new Adress("Hirszfelda", 1)); //3
            adresses.Add(new Adress("Teczowa", 1)); //4
            adresses.Add(new Adress("Dworcowa", 1)); //5
            adresses.Add(new Adress("Hubska", 1)); //6
            adresses.Add(new Adress("Dubois", 1));  //7
            adresses.Add(new Adress("Swidnicka", 1)); //8
            adresses.Add(new Adress("Ladna", 1)); //9
            adresses.Add(new Adress("Ruska", 1)); //10
            textBoxCount.Text = "3";
            foreach(Adress adress in adresses)
            {
                int index = adresses.IndexOf(adress);
                for (int i = 0; i < adresses.Count(); i++)
                {
                    if (i != index)
                    {
                        tasks.Add(new Task(adress, adresses[i], (int)distanceFinder.getDistanceBetweenLocations(adress, adresses[i])));
                    }
                    
                }
                System.Threading.Thread.Sleep(1000);
            }
            if(textBoxCount.Text == "")
            {
                textBoxCount.Text = "1";
            }
            SA sA = new SA(tasks, int.Parse(textBoxCount.Text), adresses.Count());
            sA.execute();
            perms = sA.getPermList();
            cMax = sA.getCMax();

            int deliverer = 1;
            bool flag;
            foreach(List<int> perm in perms)
            {
                textBoxResults.AppendText("Dostawca " + deliverer.ToString() + ": ");
                flag = true;
                foreach(int i in perm)
                {
                    if(flag)
                    {
                        textBoxResults.AppendText(adresses[i].ToString());
                        flag = false;
                    }
                    else textBoxResults.AppendText(" -> " + adresses[i].ToString());               
                }
                deliverer++;
                textBoxResults.AppendText(Environment.NewLine);
            }
            textBoxResults.AppendText("Powrót ostatniego dostawcy po: " + cMax.ToString() + " min od wyjazdu.");
            int a = 1;
            adresses.Clear();
            adresses.Add(new Adress("Wyspianskiego", 27));
            
        }

        private void textBoxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
