using System;
using System.Windows.Forms;

namespace Write_Test_Template
{
    public partial class TemplateGenerator : Form
    {
        //public string newFilePath(object sender,EventArgs e) => TextBox4_TextChanged(sender, e);

        public TemplateGenerator()
        {
            InitializeComponent();
            this.Text = "Test Template Generator";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
            textBox4.Text = @"C:\Library_TestAutomation\Tests\TestTemplates";
        }
        public async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            string filePath = textBox4.Text;
            try
            {
                WriteTestTemplates testBuilder = new WriteTestTemplates();
                await testBuilder.WriteFile(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text),filePath);
            }
            catch (Exception exception)
            {
                if (exception.ToString().Contains("IOException"))
                {
                    textBox3.Text = "System.IO Exception: failed to write file.  Can occur when writing to the same file consecutively during a single instance of this application.  If file is blank, restart application and try again.";
                }
                else if(exception.ToString().Contains("HttpRequestException"))
                {
                    textBox3.Text = "HttpRequestException: check Test Suite Id, Test Plan Id, and Azure DevOps authorization token.";
                }
                else
                {
                    string exceptionText = exception.ToString().Substring(0, Math.Min(2000,exception.ToString().Length));
                    textBox3.Text = exceptionText;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1_Click(sender,e);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
        }

        public void TextBox4_TextChanged(object sender, EventArgs e)
        {
            //string filePath = textBox4.Text;
            button1.Enabled = true;
        }
    }
}
