using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kickerino
{
    public partial class ManagePlayers : Form
    {
        public Form1 CallingForm { get; set; }

        public ManagePlayers()
        {
            InitializeComponent();
            //CallingForm._project.Players;
            //updatelistBox1();

        }

        private void updatelistBox1()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = CallingForm._project.Players;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Name";
            label2.Text = Convert.ToString(CallingForm._project.Players.Count);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void newPlayerButton_Click(object sender, EventArgs e)
        {

            CallingForm._project.Players.Add(new Player { Name = newPlayerInputTextBox.Text });
            newPlayerInputTextBox.Text = "";

            updatelistBox1();
            

            //listBox1.DataSource = CallingForm._project.Players;
        }

        private void ManagePlayers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CallingForm._project.Players.RemoveAt(listBox1.SelectedIndex);

            updatelistBox1();
            label2.Text = Convert.ToString(CallingForm._project.Players.Count);


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatelistBox1();
        }
    }
}
