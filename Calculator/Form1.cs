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
        List<Button> allButtons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            allButtons.Add(button0);
            allButtons.Add(button1);
            allButtons.Add(button2);
            allButtons.Add(button3);
            allButtons.Add(button4);
            allButtons.Add(button5);
            allButtons.Add(button6);
            allButtons.Add(button7);
            allButtons.Add(button8);
            allButtons.Add(button9);
            allButtons.Add(buttonPlus);
            allButtons.Add(buttonEqual);
            allButtons.Add(buttonClear);
            allButtons.Add(buttonMinus);
            allButtons.Add(buttonMultiply);
            allButtons.Add(buttonDivide);
            allButtons.Add(buttonRemainder);
            allButtons.Add(buttonDelete);
            allButtons.Add(buttonDot);
            allButtons.Add(buttonPlusMinus);

            foreach (var item in allButtons)
            {
                item.Click += OnClickButton;
                SetButtonInit(item);
            }
        }

        private void SetButtonInit(Button button)
        {
            if (IsOperator(button.Text) == false)
                button.Name = button.Text;
        }

        bool flagSetNextNumberToGroup1 = false;
        double numberGroup1;
        double numberGroup2;
        void OnClickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // 숫자 눌렀는지 판단
            if (int.TryParse(button.Name, out int temp))
            {
                if (labelResult.Text == "0")
                    labelResult.Text = string.Empty;

                if (flagSetNextNumberToGroup1)
                {
                    numberGroup1 = double.Parse(labelResult.Text);
                    labelResult.Text = button.Name;
                    flagSetNextNumberToGroup1 = false;
                    return;
                }

                labelResult.Text += button.Name;
                labelResult.Text = CutCommaString(labelResult.Text);
                double number = double.Parse(labelResult.Text);
                labelResult.Text = $"{number:N0}";
                //labelResult.Text += $"{string.Format("{0:N0}", number)}";
                return;
            }

            if (button.Name == buttonEqual.Name)
            { // 이퀄 버튼
                // 눌린 숫자들 가지고 계산
                numberGroup2 = double.Parse(labelResult.Text);
                double resultNumber = Calculator(numberGroup1, numberGroup2, operatorStr);
                labelResult.Text = $"{resultNumber:N0}";
                return;
            }
            else if (button.Name == buttonClear.Name)
            { // 초기화 버튼
                labelResult.Text = "0";
                flagSetNextNumberToGroup1 = false;
                numberGroup1 = 0;
                numberGroup2 = 0;
                return;
            }
            else if (button.Name == buttonPlusMinus.Name)
            {
                labelResult.Text = CutCommaString(labelResult.Text);
                double number = double.Parse(labelResult.Text);
                number *= -1;
                labelResult.Text = $"{number:N0}";
                return;
            }

            if (IsOperator(button.Text))
            { // 연산자 버튼
                // 다음에 숫자 버튼 누르면 labelResult에 있는 숫자를 숫자그룹1에 넣고 label 지우기 
                flagSetNextNumberToGroup1 = true;
                operatorStr = button.Text;
                return;
            }
        }

        string operatorStr;
        private double Calculator(double numberGroup1, double numberGroup2, string operatorStr)
        {
            switch(operatorStr)
            {
                case "+": return numberGroup1 + numberGroup2;
                case "-": return numberGroup1 - numberGroup2;
                case "X": return numberGroup1 * numberGroup2;
                case "÷": return numberGroup1 / numberGroup2;
                case "%": return numberGroup1 % numberGroup2;
            }

            return 0;
        }

        string CutCommaString(string str)
        {
            return str.Replace(",", "");
        }
        bool IsOperator(string inputChar)
        {
            return (inputChar == "+")
                || (inputChar == "-")
                || (inputChar == "÷")
                || (inputChar == "%")
                || (inputChar == "X")
                || (inputChar == "±");
        }
    }
}
