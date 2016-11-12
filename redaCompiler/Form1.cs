using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redaCompiler
{
    public partial class Form1 : Form
    {
        Boolean newCode = true;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            synAnalysis(str);
        }

        private string[] synAnalysis(string str)
        {
            string[] tokenizedStrings;
            string[] tokens = { };

            tokenizedStrings = spaceSplitter(str);

            for(int i = 0; i < tokenizedStrings.Length; i++)
            {
                tokens = tokensCategorization(tokenizedStrings[i]);
                Console.WriteLine(tokens[0]+" "+ tokens[1]);
            }
            
            return tokens;
        }

        private string[] spaceSplitter(string strToBeSplitted)
        {
            string[] strToken;
            strToken = strToBeSplitted.Split(new char[0]);

            return strToken;
            /* for(int i = 0; i < strToken.Length; i++)
             {
                Console.WriteLine(strToken[i]);
             } */ 
        }

        private string[] tokensCategorization(string token)
        {
            string[] keyword = { "if", "else", "while", "for", "int" };
            string[] operators = { "+", "-", ">", "<", "=", "{","}" };
            string[] tokenPair = new string [2];

            if (keyword.Contains(token)) {
                tokenPair[0] = "keyword";
                tokenPair[1] = token;
            }
            else if (operators.Contains(token))
            {
                tokenPair[0] = "operator";
                tokenPair[1] = token;
            }
            return tokenPair;
        }

        private void textBoxClear(object sender,EventArgs e)
        {
            if (newCode)
            {
                textBox1.Clear();
                newCode = false;
            }
        }
    }
}
