using System;
using System.Windows.Forms;

namespace WidExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProcess();
        }

        private void ListProcess()
        {
            System.Diagnostics.Process[] listprocess = System.Diagnostics.Process.GetProcesses();

            foreach (System.Diagnostics.Process theprocess in listprocess)
            {
                comboBox1.Items.Add(theprocess.ProcessName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (KillProcess(comboBox1.Text))
            {
                MessageBox.Show("Процесс завершен", "Завершение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                comboBox1.Items.Clear();
                comboBox1.Text = "";

                ListProcess();
            }
        }

        private bool KillProcess(string text)
        {
            try
            {
                foreach (System.Diagnostics.Process clsProcess in  System.Diagnostics.Process.GetProcesses())
                {
                    
                    if (clsProcess.ProcessName.StartsWith(text))
                    {
                        clsProcess.Kill();
                        clsProcess.WaitForExit();   
                        
                        if (clsProcess.HasExited)
                            return true;
                        else
                            return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
