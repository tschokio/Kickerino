using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kickerino
{
   

    public partial class Form1 : Form
    {
        public Project _project { get; set; }


        string standardPath = "lastProject.txt";
        string lastProjectFilePath = String.Empty;
        int jerseyCount;

        public Form1()
        {
            newProject();
            InitializeComponent();
            this.BackColor = Color.Beige;
            menuStrip1.BackColor = Color.Beige;


            if (File.Exists(standardPath))
            {
                lastProjectFilePath = File.ReadAllText(standardPath);
                using (StreamReader sr = new StreamReader(lastProjectFilePath))
                {
                    string deserializedJsonString = sr.ReadToEnd();
                    _project = JsonConvert.DeserializeObject<Project>(deserializedJsonString);
                    if (_project.Squad != null)
                    {

                        _project.Squad.Clear();
                    }
                   
                }
                updateComboBoxes();
                updatelistBox1();
                updatelistBox2();
        }
    }
        private void newProject()
        {
            _project = new Project();
            _project.startingNumber = 1;
            _project.endingNumber = 99;
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
            updatelistBox1();
            updatelistBox2();
        }

        private void updateComboBoxes()
        {
            comboBox1.Text = Convert.ToString(_project.startingNumber);
            comboBox2.Text = Convert.ToString(_project.endingNumber);
        }

        private void updatelistBox1()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _project.Players;


        }

        private void updatelistBox2()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = _project.Squad;
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
                    sr.Close();
                }
                updatelistBox1();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (listBox1.SelectedItems.Count >= 0)
            {
                jerseyCount = _project.startingNumber;

                foreach (int li in listBox1.SelectedIndices)
                {
                   

                    if (_project.Squad.Contains(_project.Players[li]))
                    {
                        //do nothing if it exists already
                    }
                    else
                    {
                        //add player to the squad if not existing already

                        if (_project.Players[li].JerseyNumberLastGame.Equals(0)) //this whole if condition needs to be tested
                        {
                            _project.Squad.Add(_project.Players[li]);
                            var lastInList = _project.Squad.Last();
                            

                        
                         foreach(Player inListBox2 in listBox2.Items)
                                do
                                {
                                    //if (_project.Squad.Any(inListBox2 => inListBox2.JerseyNumberLastGame <= jerseyCount))
                                    if (_project.Squad.Any(jerseyCount)
                                    {
                                        lastInList.JerseyNumber = jerseyCount;
                                        break;
                                        
                                    }
                                    else
                                    {
                                        jerseyCount++;
                                    }
                                    
                                }
     
                            while (true) ;
                           

                            
                            
                        }
                        else
                        {
                            _project.Squad.Add(_project.Players[li]);
                            var lastInList = _project.Squad.Last();
                            lastInList.JerseyNumber = _project.Players[li].JerseyNumber;
                        }


                    }

                    
                }
                updatelistBox2();
                checkForDuplicatesInListBox2();
            } 

        }

        private void checkForDuplicatesInListBox2()
        {

            List<String> listOfDuplicates = new List<String>();

            foreach (Player listBoxItem in listBox2.Items)
            {
                int getIndexInSquad = _project.Squad.IndexOf(listBoxItem);

                List<Player> results = _project.Squad.FindAll(listBoxItem => listBoxItem.JerseyNumber == _project.Squad[getIndexInSquad].JerseyNumber);

                if(results.Count > 1)
                {

                    foreach (Player nameOfPlayer in results)
                    {
                        listOfDuplicates.Add(nameOfPlayer.Name);
                    }

                }


            }
            duplicatesFound(listOfDuplicates);
        }

        private void duplicatesFound(List<String> duplicates)
        {
            var hasDuplicates = duplicates.GroupBy(x => x).Any(x => x.Skip(1).Any());
            //var newList = duplicates.FindAll(duplicates => duplicates.Equals(duplicates[0]));

            for (int i = 0; i < duplicates.Count / 2; i++)
            {
                //MessageBox.Show(duplicates[i]);   // deactivated for now !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }

            /*foreach(string name in duplicates)
            {
                MessageBox.Show(name);
            }*/


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItems.Count != 0)
            {
                _project.Squad[listBox2.SelectedIndex].JerseyNumber = Convert.ToInt32(textBox1.Text);
                updatelistBox2();
            }
            
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

            bool trueornot = _project.Squad.Contains(listBox1.SelectedItem);

            MessageBox.Show(Convert.ToString(trueornot));

        }

        private void comboBox2_Click_1(object sender, EventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                comboBox2.Items.Add(i);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _project.Squad.Add(new Player { Name = "Siggi" });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            MessageBox.Show(curItem);
            int index = listBox2.FindString(curItem);

            if (index == -1)
                MessageBox.Show("Item is not available in ListBox2");
            else
                listBox2.SetSelected(index, true);

            //_project.Squad.Add(new Player listBox1.SelectedItem);
        }

        private void listBox2_Format(object sender, ListControlConvertEventArgs e)
        {
            string name = ((Player)e.ListItem).Name;
            int lastJerseyNumber = ((Player)e.ListItem).JerseyNumber;
            e.Value = lastJerseyNumber + " " + name;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newProject();
            updateComboBoxes();
            updatelistBox1();
            updatelistBox2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                int getIndex = _project.Players.IndexOf(_project.Squad[i]);

                if(getIndex != -1)
                {
                    _project.Squad[i].JerseyNumberLastGame = _project.Squad[i].JerseyNumber;
                    _project.Players[getIndex] = _project.Squad[i];
                }
            }


            foreach(Player playerSquad in listBox2.Items)
            {
               // playerSquad
                int getIndexInPlayers = _project.Players.IndexOf(playerSquad);

            }

            if (File.Exists(standardPath))
            {
                lastProjectFilePath = File.ReadAllText(standardPath);
                using (StreamWriter sw = new StreamWriter(lastProjectFilePath))
                {
                    string jsonStringx;
                    jsonStringx = JsonConvert.SerializeObject(_project);
                    sw.WriteLine(jsonStringx);
                    sw.Close();
                }

                updateComboBoxes();
                updatelistBox1();
                updatelistBox2();
            }

        }
    }

    internal class Property
    {
    }

    internal class property
    {
    }
}
