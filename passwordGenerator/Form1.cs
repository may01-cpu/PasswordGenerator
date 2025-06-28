using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum enCharType
        {
            SamallLetter = 0, CapitalLetter = 1,
            Digit = 2, MixChars = 3, SpecialCharacter = 4
        };

        private static readonly Random rand = new Random();
        static int RandomNumber(int From, int To)
        {
     
             return rand.Next(From, To + 1); 
       
        }
        static char GetRandomCharacter(enCharType CharType)
        {

            //updated this method to accept mixchars
            if (CharType==enCharType.MixChars)
            {
                //Capital/Samll/Digits only
                CharType = (enCharType)RandomNumber(1, 3);

            }

            switch (CharType)
            {

                case enCharType.SamallLetter:
                    {
                        return (char)(RandomNumber(97, 122));
                       
                    }
                case enCharType.CapitalLetter:
                    {
                        return (char)(RandomNumber(65, 90));
                        
                    }
                case enCharType.SpecialCharacter:
                    {
                        return (char)(RandomNumber(33, 47));
                       
                    }
                case enCharType.Digit:
                    {
                        return (char)(RandomNumber(48, 57));
                       
                    }
          
                default:
                    {
                        return (char)(RandomNumber(65, 90));
                       
                    }
            }
        }
        static string GenerateWord(enCharType CharType, int Length)

        {

            string Word = "";
           
                for (int i = 1; i <= Length; i++)

                {

                    Word += GetRandomCharacter(CharType);

                }
            
         
            return Word;
        }
        static string GenerateKey(enCharType CharType =enCharType.CapitalLetter)
        {

            string Key = "";


            Key = GenerateWord(CharType, 4) + "-";
            Key = Key + GenerateWord(CharType, 4) + "-";
            Key = Key + GenerateWord(CharType, 4) + "-";
            Key = Key + GenerateWord(CharType, 4);


            return Key;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != null)
            {
                lbPwd.Text = GenerateWord((enCharType)comboBox1.SelectedIndex, Convert.ToInt32( maskedTextBox1.Text));
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            lbPwd.Text = GenerateKey((enCharType)comboBox1.SelectedIndex);
        }

       

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                e.Cancel = true;
               maskedTextBox1.Focus();
                errorProvider1.SetError(maskedTextBox1, "the length should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox1, "");
            }
        }
    }
}
