using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            SetImage();
            SetHex();

        }
        void SetHex()
        {
            textBox4.Text = ColorTranslator.ToHtml(Color.FromArgb(pictureBox1.BackColor.ToArgb()));
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            SetImage();
            SetHex();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
            SetImage();
            SetHex();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }
        void SetImage()
        {
            try
            {
                progressBar1.Value = Convert.ToInt32(textBox1.Text);
                progressBar2.Value = Convert.ToInt32(textBox2.Text);
                progressBar3.Value = Convert.ToInt32(textBox3.Text);
                pictureBox1.BackColor = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
            catch
            {
                MessageBox.Show("Неверный формат данных");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
               
                try
                {
                    Color myColor = ColorTranslator.FromHtml(textBox4.Text.ToString());
                    if(myColor.R<0 || myColor.G < 0 || myColor.B<0)
                    {
                        throw new Exception("Eror Color!!!");
                    }
                    textBox1.Text = myColor.R.ToString();
                    textBox2.Text = myColor.G.ToString();
                    textBox3.Text = myColor.B.ToString();
                    trackBar1.Value = int.Parse( textBox1.Text);
                    trackBar2.Value = int.Parse(textBox2.Text);
                    trackBar3.Value = int.Parse(textBox3.Text);
                    progressBar1.Value = trackBar1.Value;
                    progressBar2.Value = trackBar2.Value;
                    progressBar3.Value = trackBar3.Value;
                    pictureBox1.BackColor = myColor;

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Notifications", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
           

               
            }
        }
    }
}
