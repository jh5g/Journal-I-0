using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        static string fileName = "Untitled";
        public Dictionary<string, string> diaryContents = new Dictionary<string, string>();
        //public Dictionary<string, string> diaryContents {get; set;}
        public Main()
        {
            InitializeComponent();
            this.Text = "Journal I/O - " + fileName;
            this.diaryContents = new Dictionary<string, string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateEntry.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
        }
        public void formatNewEntry()
        {
            var entry =  NewEntry.Text;
            string date = dateEntry.Text;
            diaryContents.Add(date, entry);
            //var b = "";
        }
        public string formatJournal()//to be saved
        {
            string toReturn = "";
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            List<DateTime> datesList = new List<DateTime>();
            foreach (KeyValuePair<string, string> kvp in diaryContents)
            {
                datesList.Add(Convert.ToDateTime(kvp.Key));
            }
            var diaryContentsSorted = diaryContents.Keys.OrderByDescending(d => d);
            foreach (string a in diaryContentsSorted)
            {
                pairs.Add(new KeyValuePair<string, string>(a, diaryContents[a]));
            }
            foreach(KeyValuePair<string, string> kvp in pairs)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                toReturn = toReturn + "{" + key + ":" + value + "}";
            }
            return toReturn;
        }
        public string formatJournalString(string unformatted) //to be displayed based off of string from file
        {
            Dictionary<string, string> toReturnDict = new Dictionary<string, string>();
            string pat = "{(.*?):(.*?)}";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(unformatted);
            while (m.Success)
            {
                string key = "";
                string value = "";
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    if (i == 1)
                    {
                        key = g.Value;
                    }
                    else if (i == 2)
                    {
                        value = g.Value;
                    }
                }
                toReturnDict.Add(key, value);
                m = m.NextMatch();
            }
            return formatJournalOut(toReturnDict);
        }
        public string formatJournalOut(Dictionary<string, string> unformatted) //to be displayed from dictionary
        {
            return JsonConvert.SerializeObject(unformatted, Formatting.Indented);
        }
        public Dictionary<string, string> formatJournalDict (string unformatted)// to be turned into dictionary from file 
        {
            Dictionary<string, string> toReturn = new Dictionary<string,string>();
            string pat = "{(.*?):(.*?)}"; 
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(unformatted);
            while (m.Success)
            {
                string key = "";
                string value = "";
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    if (i == 1)
                    {
                        key = g.Value;
                    }
                    else if (i == 2)
                    {
                        value = g.Value;
                    }
                }
                toReturn.Add(key, value);
                m = m.NextMatch();
            }
            return toReturn;
        }
        public void SaveAs()
        {
            string Contents = formatJournal();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Journal I/O File (*.jour)|*.jour"; //txt files (*.txt)|*.txt|All files (*.*)|*.*
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {


                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName.ToString());
                fileName = saveFileDialog1.FileName.ToString();
                using (StringReader reader = new StringReader(Contents))
                {
                    string line = string.Empty;
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            file.WriteLine(line);
                        }

                    } while (line != null);
                }
                file.Close();
                this.Text = "Journal I/O - " + fileName;
            }

        }
        public void Save()
        {
            if (fileName != "Untitled")
            {
                string Contents = formatJournal();
                StreamWriter file = new StreamWriter(fileName);
                using (StringReader reader = new StringReader(Contents))
                {
                    string line = string.Empty;
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            file.WriteLine(line);
                        }

                    } while (line != null);
                }
                file.Close();
                this.Text = "Journal I/O - " + fileName;
            }
            else
            {
                SaveAs();
            }
        }
        private void Open()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Journal I/O File (*.jour)|*.jour";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName.ToString();
                
                ExistingJournal.Text = formatJournalString(File.ReadAllText(fileName));
                NewEntry.Text = "";
                this.Text = "Journal I/O " + fileName;
                diaryContents = formatJournalDict(File.ReadAllText(fileName));
            }
            

        }
        public void New()
        {
            NewEntry.Text = "";
            ExistingJournal.Text = "";
            diaryContents = new Dictionary<string, string>();
            fileName = "Untitled";
            this.Text = "Journal I/O - " + fileName;
        }
        public void Add()
        {
            formatNewEntry();
            ExistingJournal.Text = formatJournalOut(diaryContents);
            //var b = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void NewEntry_TextChanged(object sender, EventArgs e)
        {
            this.Text = "Journal I/O - " + fileName + "*";
            //ExistingJournal.Enabled = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text.Substring(this.Text.Length - 1) == "*")
            {
                DialogResult saveQuery = MessageBox.Show(fileName + " is has not been saved.\nDo you want to save it?", "Unsaved Work", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (saveQuery == DialogResult.Yes)
                {
                    e.Cancel = true;
                    Save();
                    this.Close();
                }
                else if (saveQuery == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (diaryContents.ContainsKey(dateEntry.Text))
            {
                DialogResult overwriteQuery = MessageBox.Show("This date already has an entry\n Pressing Ok will overwrite", "Existing entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (overwriteQuery == DialogResult.OK)
                {
                    diaryContents.Remove(dateEntry.Text);
                    Add();
                }
            }
            else
            {
                Add();
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JournalIO.Form2 f2 = new JournalIO.Form2();
            f2.Show();
            f2.diaryContents = diaryContents;
        }
    }
}
