using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace JournalIO
{
    public partial class Form2 : Form
    {
        public Dictionary<string, string> diaryContents { get; set; }
        List<KeyValuePair<string, string>> contentsList { get; set; }
        //Dictionary<string, string> reultsDictionary { get; set; }
        int currResult = 0;
        int noResults = 0;
        public Form2()
        {
            InitializeComponent();
            this.diaryContents = new Dictionary<string, string>();
            this.contentsList = new List<KeyValuePair<string, string>>();
            //this.reultsDictionary = new Dictionary<string, string>();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void StartSearch_Click(object sender, EventArgs e)
        {
            string date = DateEntry.Text;
            string contents = ContentsEntry.Text;
            //MessageBox.Show(DateEntry.Text);
            if (date != "")
            {
                foreach (KeyValuePair<string, string> kvp in this.diaryContents)
                {
                    if (kvp.Key.Contains(date))
                    {
                        this.contentsList.Add(kvp);
                    }
                }
            }
            else if (contents != "")
            {
                foreach(KeyValuePair<string, string> kvp in this.diaryContents)
                {
                    if (kvp.Value.Contains(contents))
                    {
                        this.contentsList.Add(kvp);
                    }
                }
            }
            else
            {
                MessageBox.Show("No search method was found", "Search method", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (contentsList.Any())
            {
                //reultsDictionary = contentsList.ToDictionary(pair => pair.Key, pair => pair.Value);
                //Results.Text = JsonConvert.SerializeObject(reultsDictionary, Formatting.Indented);
                noResults = contentsList.Count();
                currResult = 1;
                this.NumResults.Text = currResult.ToString();
                this.NumResults.Text += " / ";
                this.NumResults.Text += noResults.ToString();
                this.Results.Text = contentsList[0].Value;
                this.DateDisplayer.Text = contentsList[0].Key;
                
            }
            else
            {
                MessageBox.Show("No results were found", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } //fills list with kvps then if possible displays first result 

        private void Next_Click(object sender, EventArgs e) 
        {
            if (contentsList.Any())
            {
                if (contentsList.Any())
                {
                    if (noResults >= currResult + 1) //noResults >= currResult + 1 
                    {
                        //if (currResult -1 < contentsList.)
                        currResult += 1;
                        this.NumResults.Text = currResult.ToString();
                        this.NumResults.Text += " / ";
                        this.NumResults.Text += noResults.ToString();
                        this.Results.Text = contentsList[currResult - 1].Value;
                        this.DateDisplayer.Text = contentsList[currResult - 1].Key;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
