using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GroupWork
{
    public partial class Form1 : Form
    {
        dataHandler data = new dataHandler();
        bool haveDot = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            if (radioButton1.Checked)
            {
                int binaryVal;
               
                try
                {
                    String[] fullInput = new String[2];
                    char[] binaryfract;
                    if (haveDot)
                    {
   
                        fullInput = (textBox1.Text).Split('.');
                        binaryfract = fullInput[1].ToCharArray();
                        if ((textBox1.Text).ToLowerInvariant().IndexOf('.') == 0 )
                        {
                            fullInput[0] = "0";
                        }
                        else if((textBox1.Text).ToLowerInvariant().IndexOf('.') == (textBox1.Text).Length-1)
                        {
                            binaryfract = "0".ToArray();
                        }
                    }
                    else
                    {
                        fullInput[0] = textBox1.Text;
                        binaryfract = "0".ToCharArray();
                    }



                        binaryVal = Convert.ToInt32(fullInput[0], 2);
                        textBox3.Text = (data.convertToDecimal(binaryVal)) + "." + (data.FractConvertToDecimal(binaryfract, 2));


                        binaryVal = Convert.ToInt32(fullInput[0], 2);
                        textBox2.Text = (data.convertToOctal(binaryVal)) + "." + (data.FractConvertToOctal());

                        binaryVal = Convert.ToInt32(fullInput[0], 2);
                        textBox4.Text = (data.convertTohexadecimal(binaryVal)) + "." + (data.FractConvertToHexadecimal());

                }
                catch (NotSupportedException)
                {

                    MessageBox.Show("Enter a  Number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NoNullAllowedException)
                {
                    MessageBox.Show("Null Value", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("No Number Found", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured,Please Check your Inputs", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    //String[] fullInput = (textBox2.Text).Split('.');
                    String[] fullInput = new String[2];
                    char[] octalfract;
                    if (haveDot)
                    {
                        fullInput = (textBox2.Text).Split('.');
                        octalfract = fullInput[1].ToCharArray();
                        if ((textBox2.Text).ToLowerInvariant().IndexOf('.') == 0)
                        {
                            fullInput[0] = "0";
                        }
                        else if ((textBox2.Text).ToLowerInvariant().IndexOf('.') == (textBox2.Text).Length - 1)
                        {
                            octalfract = "0".ToArray();
                        }
                    }
                    else
                    {
                        fullInput[0] = textBox2.Text;
                        octalfract = "0".ToCharArray();
                    }
                    textBox1.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    int OctalLen;
                    int OctalVal;
                    OctalLen =fullInput[0].Length;
                    OctalVal = Convert.ToInt32(fullInput[0]);
                    
                   // char[] octalfract = fullInput[1].ToCharArray();



                        OctalVal = Convert.ToInt32(fullInput[0], 8);
                        // int FactPara=BinaryValOfOctalFract(octalfract);
                        textBox3.Text = (data.convertToDecimal(OctalVal)) + "." + (data.FractConvertToDecimal(octalfract, 8));
                       // textBox7.Text = (data.FractConvertToDecimal(octalfract, 8));

                        OctalVal = Convert.ToInt32(fullInput[0], 8);
                        textBox1.Text = (data.convertToBinary(OctalVal)) + "." + (data.FractConvertToBinary());
                       // textBox5.Text = (data.FractConvertToBinary());

                        OctalVal = Convert.ToInt32(fullInput[0], 8);
                        textBox4.Text = (data.convertTohexadecimal(OctalVal)) + "." + (data.FractConvertToHexadecimal());
                        //textBox8.Text = (data.FractConvertToHexadecimal());
                        //convert to octal

                }
                catch (Exception)
                {

                    MessageBox.Show("Enter a Relevant Number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButton3.Checked)
            {
                try
                {
                   // String[] fullInput = (textBox3.Text).Split('.');
                    textBox2.Enabled = false;
                    textBox1.Enabled = false;
                    textBox4.Enabled = false;
        
                    int DecimalVal;
                    String[] fullInput = new String[2];
                    char[] FracDecimalVal ;
                    if (haveDot)
                    {
                        fullInput = (textBox3.Text).Split('.');
                        FracDecimalVal = fullInput[1].ToCharArray();
                        if ((textBox3.Text).ToLowerInvariant().IndexOf('.') == 0)
                        {
                            fullInput[0] = "0";
                        }
                        else if ((textBox3.Text).ToLowerInvariant().IndexOf('.') == (textBox3.Text).Length - 1)
                        {
                            FracDecimalVal = "0".ToArray();
                        }
                    }
                    else {
                        fullInput[0] = textBox3.Text;
                        FracDecimalVal = "0".ToCharArray();
                    }

                        DecimalVal = Convert.ToInt32(fullInput[0], 10);
                        // int FactPara=BinaryValOfOctalFract(octalfract);
                        textBox3.Text = (data.convertToDecimal(DecimalVal)) + "." + (data.FractConvertToDecimal(FracDecimalVal, 10));
                       // textBox7.Text = (data.FractConvertToDecimal(FracDecimalVal, 10));

                        DecimalVal = Convert.ToInt32(fullInput[0], 10);
                        textBox1.Text = (data.convertToBinary(DecimalVal)) + "." + (data.FractConvertToBinary());
                        //textBox5.Text = (data.FractConvertToBinary());

                        DecimalVal = Convert.ToInt32(fullInput[0], 10);
                        textBox2.Text = (data.convertToOctal(DecimalVal)) + "." + (data.FractConvertToOctal());
                        //textBox6.Text = (data.FractConvertToOctal());

                        DecimalVal = Convert.ToInt32(fullInput[0], 10);
                        textBox4.Text = (data.convertTohexadecimal(DecimalVal)) + "." + (data.FractConvertToHexadecimal());
                        //textBox8.Text = (data.FractConvertToHexadecimal());

                }
                catch (Exception)
                {

                    MessageBox.Show("Enter a  Relevant Number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    String[] fullInput = new String[2];
                    char[] FracDecimalVal ;
                    if (haveDot)
                    {
                        fullInput = (textBox4.Text).Split('.');
                        FracDecimalVal = fullInput[1].ToCharArray();
                        if ((textBox4.Text).ToLowerInvariant().IndexOf('.') == 0)
                        {
                            fullInput[0] = "0";
                        }
                        else if ((textBox4.Text).ToLowerInvariant().IndexOf('.') == (textBox4.Text).Length - 1)
                        {
                            FracDecimalVal = "0".ToArray();
                        }
                    }
                    else {
                        fullInput[0] = textBox4.Text;
                        FracDecimalVal = "0".ToCharArray();
                    }
                    

                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox1.Enabled = false;
               
                    int HexaDecimalVal;

                        HexaDecimalVal = Convert.ToInt32(fullInput[0], 16);
                        textBox3.Text = (data.convertToDecimal(HexaDecimalVal)) + "." + (data.FractConvertToDecimal(FracDecimalVal, 16));

                        HexaDecimalVal = Convert.ToInt32(fullInput[0], 16);
                        textBox1.Text = (data.convertToBinary(HexaDecimalVal)) + "." + (data.FractConvertToBinary());

                        HexaDecimalVal = Convert.ToInt32(fullInput[0], 16);
                        textBox2.Text = (data.convertToOctal(HexaDecimalVal)) + "." + (data.FractConvertToOctal());

                }
                catch (Exception)
                {

                    MessageBox.Show("Enter a Relevant Number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        public void resetfields()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            haveDot = false;

        }
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            haveDot = false;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            resetfields();

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = true;
            textBox4.Enabled = false;

            resetfields();
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = true;

            resetfields();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            resetfields();
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

          //  panel_Tab_about.Visible = false;
         //   panel_settings.Visible = false;
            panel_Tab_convert.Visible = false;
            panel1.Visible = true;
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Contains('.'))
            {
                haveDot = true;
            }
            else
            {
                haveDot = false;
            }
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[0-1\b\.]"))
            {
                if (e.KeyChar == '.')
                {

                    if (haveDot)
                    { e.Handled = true; }
                    haveDot = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Contains('.'))
            {
                haveDot = true;
            }
            else
            {
                haveDot = false;
            }
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[0-7\b\.]"))
            {
                if (e.KeyChar == '.')
                {

                    if (haveDot)
                    { e.Handled = true; }
                    haveDot = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }



        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Contains('.'))
            {
                haveDot = true;
            }
            else
            {
                haveDot = false;
            }
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b\.]"))
            {
                if (e.KeyChar == '.')
                {

                    if (haveDot)
                    { e.Handled = true; }
                    haveDot = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }


        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Contains('.'))
            {
                haveDot = true;
            }
            else
            {
                haveDot = false;
            } 
            if (Regex.IsMatch(e.KeyChar.ToString(), @"[0-9\b\.,a-fA-F]"))
            {
                if (e.KeyChar == '.')
                {

                    if (haveDot)
                    { e.Handled = true; }
                    haveDot = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void actionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
         //   panel_settings.Visible = false;
            panel_Tab_convert.Visible = true;
        }



        private void converterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_Tab_convert.Visible = true;
            panel1.Visible = false;
           // panel_settings.Visible = false;
        }




    }
}

