using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace compiler_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            dgvTokens.Rows.Clear();

            string input = txtCode.Text;

            string keywords = @"\b(num|text|check|otherwise|repeat|until)\b";
            string identifiers = @"\b[a-zA-Z][a-zA-Z0-9_]*\b";
            string numbers = @"\b[0-9]+\b";
            string operators = @":=|==|[+\-*/<>]";
            string symbols = @"[;{}()]";

            string masterPattern = $"{keywords}|{identifiers}|{numbers}|{operators}|{symbols}";

            MatchCollection matches = Regex.Matches(input, masterPattern);

            foreach (Match m in matches)
            {
                string lexeme = m.Value;
                string token = "";

                if (Regex.IsMatch(lexeme, keywords))
                    token = "Keyword";

                else if (Regex.IsMatch(lexeme, numbers))
                    token = "Number";

                else if (Regex.IsMatch(lexeme, identifiers))
                    token = "Identifier";

                else if (lexeme == ":=")
                    token = "Assignment_Op";

                else if (lexeme == "==")
                    token = "Equality_Op";

                else if (lexeme == "+")
                    token = "Plus_Op";

                else if (lexeme == "-")
                    token = "Minus_Op";

                else if (lexeme == "*")
                    token = "Multiply_Op";

                else if (lexeme == "/")
                    token = "Divide_Op";

                else if (lexeme == "<")
                    token = "LessThan_Op";

                else if (lexeme == ">")
                    token = "GreaterThan_Op";

                else if (lexeme == ";")
                    token = "Semicolon";

                else if (lexeme == "(")
                    token = "Left_Paren";

                else if (lexeme == ")")
                    token = "Right_Paren";

                else if (lexeme == "{")
                    token = "Left_Brace";

                else if (lexeme == "}")
                    token = "Right_Brace";

                else token = "Unknown";

                    dgvTokens.Rows.Add(lexeme, token);
            }
        }
    }
}
