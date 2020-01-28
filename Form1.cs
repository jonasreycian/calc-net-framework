using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LblAnswer.Text = ToMultiply(textBox1.Text).ToString();
        }

        private int ToMultiply(string temp)
        {
            string[] args = temp.Split('*');
            
            if(args.Length == 1)
            {
                return ToDivide(args[0]);
            }

            int div = ToMultiply(args[0]);
            for (int i = 1; i < args.Length; i++)
            {
                div *= ToMultiply(args[i]);
            }

            return div;
        }

        private int ToDivide(string temp)
        {
            string[] args = temp.Split('/');

            if(args.Length == 1)
            {
                return ToAdd(args[0]);
            }

            int div = ToDivide(args[0]);
            for (int i = 1; i < args.Length; i++)
            {
                div /= ToDivide(args[i]);
            }

            return div;
        }

        private int ToAdd(string temp)
        {
            string[] args = temp.Split('+');

            if (args.Length == 1)
            {
                return ToSubtract(args[0]);
            }

            int sum = 0;
            foreach(string arg in args)
            {
                sum += ToAdd(arg);
            }

            return sum;
        }

        private int ToSubtract(string temp)
        {
            string[] args = temp.Split('-');

            if(args.Length == 1)
            {
                return int.Parse(args[0]);
            }

            int diff = int.Parse(args[0]);
            for(int i=1; i<args.Length; i++)
            {
                diff -= int.Parse(args[i]);
            }

            return diff;
         }
    }
}
