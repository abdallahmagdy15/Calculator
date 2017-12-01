using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Calculator : Form
    {
        public string screen_
        {
            get { return screen.Text; }
        }
        public Calculator()
        {
            InitializeComponent();
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            screen.Text += two.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void cos_Click(object sender, EventArgs e)
        {
            screen.Text += cos.Text+"(";
        }

        private void ac_Click(object sender, EventArgs e)
        {
            screen.Text = null;
        }

        private void six_Click(object sender, EventArgs e)
        {
            screen.Text += six.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            screen.Text += add.Text;
        }

        private void del_Click(object sender, EventArgs e)
        {
            
            screen.Text = screen.Text.Substring(0,screen.Text.Length-1);
        }

        private void zero_Click(object sender, EventArgs e)
        {
            screen.Text += zero.Text;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            screen.Text += dot.Text;
        }

        private void one_Click(object sender, EventArgs e)
        {
            screen.Text += one.Text;
        }

        private void three_Click(object sender, EventArgs e)
        {
            screen.Text += three.Text;
        }

        private void four_Click(object sender, EventArgs e)
        {
            screen.Text += four.Text;
        }

        private void five_Click(object sender, EventArgs e)
        {
            screen.Text += five.Text;
        }

        private void seven_Click(object sender, EventArgs e)
        {
            screen.Text += seven.Text;
        }

        private void eight_Click(object sender, EventArgs e)
        {
            screen.Text += eight.Text;
        }

        private void nine_Click(object sender, EventArgs e)
        {
            screen.Text += nine.Text;
        }

        private void substract_Click(object sender, EventArgs e)
        {
            screen.Text += substract.Text;
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            screen.Text += multiply.Text;
        }

        private void divide_Click(object sender, EventArgs e)
        {
            screen.Text += divide.Text;
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            screen.Text += sqrt.Text;
        }

        private void sin_Click(object sender, EventArgs e)
        {
            screen.Text += sin.Text+"(";
        }

        private void tan_Click(object sender, EventArgs e)
        {
            screen.Text += tan.Text+"(";
        }

        private void screen_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Lparenthesis_Click(object sender, EventArgs e)
        {
            screen.Text += "(";
        }

        private void Rparenthesis_Click(object sender, EventArgs e)
        {
            screen.Text += ")";
        }

        private void pow_Click(object sender, EventArgs e)
        {
            screen.Text += "^";
        }

        private void answer_Click(object sender, EventArgs e)
        {
            screen.Text += "ans";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            run.runCalc ob = new run.runCalc(screen.Text);
            ob.first_check();
            result.Text = run.runCalc.ans = ob.output.ToString();
        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
