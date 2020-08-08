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
        enum Operator
        {
            scit,
            odcit,
            del,
            nasob,
        }

        string line;
        string ln;

        double dCurrent;
        double dPrevDigit;

        Operator? operatorLast = null;
        bool bNeedToClear = false;

        void OutputDigit(string n) // ВВЫВОД ЧИСЕЛ
        {
            string strInput = line + n;
            double r;
            if (double.TryParse(bNeedToClear? n : strInput, out r))
            {
                if (bNeedToClear == true)
                {
                    dPrevDigit = dCurrent;
                    dCurrent = r;
                    line = n;
                    tbInput.Text = line;

                    bNeedToClear = false;
                }
                else
                {
                    dCurrent = r;
                    line += n;
                    tbInput.Text = line;
                }
            }
        } // ctrl + k + d

        void OutputResult(string strValue, string strOperation)
        {
            if (strOperation == null)
            {
                tbOutput.Text += strValue;
            }
            else
            {
                tbOutput.Text = strValue + strOperation;
            }
        }

        //public void math()
        //{
        //    switch (cond)
        //        {
        //            case Operator.scit:  x = x + Convert.ToDouble(line); break;
        //            case Operator.odcit: x = x - Convert.ToDouble(line); break;
        //            case Operator.nasob: x = x * Convert.ToDouble(line); break;
        //            case Operator.del:   x = x / Convert.ToDouble(line); break;
        //            default: { 
        //                ClearInput(); break; 
        //            }
        //        }

        //}
        // ----------------------------------------------------------числа


        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbInput.BackColor = double.TryParse(tbInput.Text, out dCurrent) ? Color.White : Color.Red;
            }
            catch
            {
                tbInput.ForeColor = SystemColors.ControlText;
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void ClearInput()
        {
            tbInput.Text = tbOutput.Text = "";
            dCurrent = dPrevDigit = 0;
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            Operation(Operator.odcit);
        }

        private void Operation(Operator oper)
        {
            switch (oper)
            {
                case Operator.scit:
                    OutputResult(line, " + ");
                    break;
                case Operator.odcit:
                    OutputResult(line, " - ");
                    break;
                case Operator.nasob:
                    OutputResult(line, " * ");
                    break;
                case Operator.del:
                    OutputResult(line, " / ");
                    break;
                default:
                    {
                        ClearInput(); break;
                    }
            }

            operatorLast = oper;
            bNeedToClear = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Operation(Operator.scit);
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            Operation(Operator.nasob);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            Operation(Operator.del);
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            switch (operatorLast)
            {
                case Operator.scit:
                    OutputResult(line + string.Format(" = {0}", dPrevDigit + dCurrent), null);
                    dPrevDigit = dPrevDigit + dCurrent;
                    tbInput.Text = dPrevDigit.ToString();
                    break;
                case Operator.odcit:
                    OutputResult(line, $" = {dPrevDigit - dCurrent}");
                    break;
                case Operator.nasob:
                    OutputResult(line, $" = {dPrevDigit * dCurrent}");
                    break;
                case Operator.del:
                    OutputResult(line, $" = {dPrevDigit / dCurrent}");
                    break;
                default:
                    {
                        ClearInput(); break;
                    }
            }
        }

        private void buttonDigit_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button button = (Button)sender;
                OutputDigit(button.Text);
            }
        }
    }
}

