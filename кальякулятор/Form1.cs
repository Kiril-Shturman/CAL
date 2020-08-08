using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace кальякулятор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        enum Operator {
            scit,
            odcit,
            del,
            nasob,
        }


        string line,ln;
        double x;
        int cond = 0;
        void tablo(string n, string op) // ВВЫВОД ЧИСЕЛ
        {
            line += n;
            tbInput.Text = ln +=n+op;
            tbOutput.Text = "";
        }
         public void math()
        {

            
            switch (cond)
                {
                    
                    case 1: x = x + Convert.ToDouble(line); break;
                    case 2: x = x - Convert.ToDouble(line); break;
                    case 3: x = x * Convert.ToDouble(line); break;
                    case 4: x = x / Convert.ToDouble(line); break;
                    default: { x = Convert.ToDouble(line); line = ""; break; }
                }
            
        }
        // ----------------------------------------------------------числа
         
        private void button3_Click(object sender, EventArgs e)
        {
            tablo(button3.Text,null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tablo(button1.Text,null);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tablo(button2.Text,null);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            tablo(button6.Text,null);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tablo(button5.Text,null);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            tablo(button4.Text,null);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            tablo(button9.Text,null);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            tablo(button8.Text,null);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            tablo(button7.Text,null);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            tablo(button10.Text,null);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            line = "";
            ln = "";
            x = 0;
            cond = 0;
            tbInput.Text = line;
            tbOutput.Text = line;
        } // del
        private void button12_Click(object sender, EventArgs e)
        {
            
            math();
            tablo(null,button12.Text);
            cond = 1;
        }//+
        private void button11_Click(object sender, EventArgs e)
        {
            math();
            tablo(null, button11.Text);
            cond = 2;
            
        }//-
        private void button15_Click(object sender, EventArgs e)
        {
            math();
            tablo(null, button15.Text);
            cond = 3;
        }//x
         private void button16_Click(object sender, EventArgs e)
        {
            math();
            tablo(null, button16.Text);
            cond = 4;
        }// /

        private void button17_Click(object sender, EventArgs e)
        {
            tablo(button17.Text, null);
        }//.

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbInput.BackColor = double.TryParse(tbInput.Text, out x) ? Color.White : Color.Red;
            }
            catch
            {
               tbInput.ForeColor = SystemColors.ControlText;
            }
        }

      

        // -------------------------------------------------------------
        async private void button13_Click(object sender, EventArgs e)
        {
             math();
            cond = 0;
             tbOutput.Text = x.ToString();
            await Task.Delay(10000);
            line = "";
            ln = "";
            tbInput.Text = line;
            tbOutput.Text = line;

        }
    }
}

