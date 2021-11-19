using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kickerino
{
   

    public partial class Form1 : Form
    {
        public Project _project { get; set; }

        //Person person = new Person();
        int jerseyRange = 21;
        int jerseySimpleCount = 2;
        //List<Person> personList = new List<Person>();
        public Form1()
        {
            
            

            _project = new Project();
            InitializeComponent();
            updatelistBox1();
        }

        private void Button_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void managePlayersButton_Click(object sender, EventArgs e)
        {
            ManagePlayers ManagePlayersForm = new ManagePlayers();
            ManagePlayersForm.CallingForm = this;
            if (ManagePlayersForm.ShowDialog() == DialogResult.OK)
            {
                updatelistBox1();
            }
            //ManagePlayersForm.ShowDialog();

            
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_project.Players.Add(new Player { Name = Input.Text });
            Input.Text = "";

            updatelistBox1();
        }

        private void updatelistBox1()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _project.Players;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Name";
        }

        private void updatelistBox2()
        {
            listBox2.DataSource = null;
            //listBox2.DataSource = _project.Players;
            listBox2.DisplayMember = "Name";
            listBox2.ValueMember = "Name";
        }

        void ManagePlayersForm_FormClosed(object sender, FormClosedEventArgs e){
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;
                saveDialog.RestoreDirectory = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    {
                        string jsonString;
                        jsonString = JsonConvert.SerializeObject(_project);
                        System.IO.StreamWriter file = new System.IO.StreamWriter(saveDialog.FileName.ToString());
                        file.WriteLine(jsonString);
                        file.Close();
                    }
                }
                updatelistBox1();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    var sr = new StreamReader(openDialog.FileName);
                    string deserializedJsonString = sr.ReadToEnd();
                    _project = JsonConvert.DeserializeObject<Project>(deserializedJsonString);
                }
                updatelistBox1();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            foreach(Player selected in listBox1.SelectedItems)
            {
               
                listBox2.Items.Add(jerseySimpleCount + " " + selected.Name);
                jerseySimpleCount++;
            }

            //listBox1.DataSource = null;
           // listBox1.DataSource = _project.Players;
           // listBox1.DisplayMember = "Name";
           // listBox1.ValueMember = "Name";
        }
    }
}
