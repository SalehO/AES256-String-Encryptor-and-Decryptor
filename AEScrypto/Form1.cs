using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AEScrypto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e){}


        private void button1_Click(object sender, EventArgs e) // Encrypt button
        {
            
            if (string.IsNullOrEmpty(textBox1.Text)) // Making sure the user provided a string 
                MessageBox.Show("Please Enter a String to be Encrypted!");
            else
                textBox2.Text = (textBox1.Text).encrypt(); //take the string from the input textbox and print the encypted result in the READONLY ouput text box
        }

        private void button2_Click(object sender, EventArgs e) // Decrypt button
        {

            if (string.IsNullOrEmpty(textBox1.Text)) // Making sure the user provided a string 
                MessageBox.Show("Please Enter a String to be Decrypted!");
            else if ((textBox1.Text.Length % 4 != 0) || (textBox1.Text.Length < 24)) // making sure the string is of the correct size.(segments of 4)
                MessageBox.Show("Invalid string lenght!");
            else
                textBox2.Text = (textBox1.Text).decrypt();//take the string from the input textbox and print the decrypted result in the READONLY ouput text bo
        }
    }
}
