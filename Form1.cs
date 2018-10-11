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
using System.Diagnostics;
namespace fix_hidden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] dirs = Directory.GetDirectories(f.SelectedPath);
                foreach (string d in dirs) {
                    DirectoryInfo dir = new DirectoryInfo(d);
                    if ((dir.Attributes & FileAttributes.Hidden) != 0)
                        listBox1.Items.Add(d);
                }
                if (listBox1.Items.Count == 0) 
                    MessageBox.Show("لايوجد مجلدات مخفية Empty");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string i in listBox1.Items)
            {
                DirectoryInfo dir = new DirectoryInfo(i);
                if ((dir.Attributes & FileAttributes.Hidden) != 0)
                {
                    dir.Attributes &= ~FileAttributes.ReadOnly;
                    dir.Attributes &= ~FileAttributes.System;
                    dir.Attributes &= ~FileAttributes.Hidden;
                    dir.Attributes &= ~FileAttributes.Archive;
                    
                }
            }
            if (listBox1.Items.Count != 0) 
                MessageBox.Show("تم done");    
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
                ProcessStartInfo sInfo = new ProcessStartInfo("http://www.tahasoft.com");
                Process.Start(sInfo);
        }
    }
}
