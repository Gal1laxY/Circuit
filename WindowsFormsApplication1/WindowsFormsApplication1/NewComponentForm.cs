using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Model;


namespace WindowsFormsApplication1
{
    public partial class NewComponentForm : Form
    {
        public  ICircuit Circuit 
        {
            get
            {
                if (radioButton1.Checked)
                {
                    return new Resistor() { Resistance = Convert.ToInt32(textBox1.Text) };
                }
                else if (radioButton2.Checked)
                {
                    return new Capacitor() { Capacitance = Convert.ToInt32(textBox2.Text) };
                }
                else if (radioButton3.Checked)
                {
                    return new Induct() { Inductance = Convert.ToInt32(textBox4.Text) };
                }
                else
                { throw new Exception("Сбой в выборе класса."); }                        
            }
           set
            {
                if (value is Resistor)
                {
                    radioButton1.Checked = true;
                    textBox1.Text = ((Resistor)value).Resistance.ToString();
                }
                else
                    if (value is Capacitor)
                    {
                        radioButton2.Checked = true;
                        textBox1.Text = ((Capacitor)value).Capacitance.ToString();
                    }
                    else
                        if (value is Induct)
                        {
                            radioButton3.Checked = true;
                            textBox1.Text = ((Induct)value).Inductance.ToString();
                        }
                        else
                        { throw new Exception("Сбой в выборе класса."); }
            }
     
        }

        public NewComponentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton1.Checked = true;
                groupBox1.Enabled = true;
                radioButton2.Checked = false;
                groupBox2.Enabled = false;
                radioButton3.Checked = false;
                groupBox3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            { 
            radioButton2.Checked = true;
            groupBox2.Enabled = true;
            radioButton1.Checked = false;
            groupBox1.Enabled = false;
            radioButton3.Checked = false;
            groupBox3.Enabled = false;

        }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioButton3.Checked = true;
                groupBox3.Enabled = true;
                radioButton2.Checked = false;
                groupBox2.Enabled = false;
                radioButton1.Checked = false;
                groupBox1.Enabled = false;

            }
        }
    }
    
}
