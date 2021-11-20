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
        string standardPath = "lastProject.txt";
        string lastProjectFilePath = String.Empty;
        //List<Person> personList = new List<Person>();
        public Form1()
        {
            _project = new Project();
            _project.startingNumber = 1;
            _project.endingNumber = 99;
            InitializeComponent();
            this.BackColor = Color.Turquoise;



            if (File.Exists(standardPath))
            {
                lastProjectFilePath = File.ReadAllText(standardPath);
                using (StreamReader sr = new StreamReader(lastProjectFilePath))
                {
                    string deserializedJsonString = sr.ReadToEnd();
                    _project = JsonConvert.DeserializeObject<Project>(deserializedJsonString);
                }

                updateComboBoxes();
                updatelistBox1();
        }

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
        }

        private void updateComboBoxes()
        {
            comboBox1.Text = Convert.ToString(_project.startingNumber);
            comboBox2.Text = Convert.ToString(_project.endingNumber);
        }

        private void updatelistBox1()
        {
            listBox1.DataSource = null;
            //listBox1.Update();
            listBox1.DataSource = _project.Players;

            //listBox1.DisplayMember = "Name" + "JerseyNumber";
            //listBox1.ValueMember = "Name";

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

        private void openToolStripMenuItem_Click(object sender, EventArgs e) //save
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
                        File.WriteAllText(standardPath, saveDialog.FileName.ToString());
                    }
                }
                updatelistBox1();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //open
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
                //if check unique jerseynumberslastgame?

                listBox2.Items.Add(selected.JerseyNumber + " " + selected.Name);
                selected.JerseyNumber = jerseySimpleCount;
                jerseySimpleCount++;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((Player)e.ListItem).Name;
            int lastJerseyNumber = ((Player)e.ListItem).JerseyNumberLastGame;
            e.Value = lastJerseyNumber + " " + name;
        }

        private void listBox1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _project.startingNumber = Convert.ToInt32(comboBox1.SelectedItem);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _project.endingNumber = Convert.ToInt32(comboBox2.SelectedItem);
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(_project.startingNumber) + Convert.ToString(_project.endingNumber));
        }

        private void comboBox2_Click_1(object sender, EventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                comboBox2.Items.Add(i);
            }
        }
    }
}
