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

            foreach (var item in allButtons)
            {
                item.Click += OnClickButton;
                SetButtonInit(item);
            }
        }

        private void SetButtonInit(Button button)
        {
            button.Name = button.Text;
        }

        bool flagSetNextNumberToGroup1 = false;
        int numberGroup1;
        int numberGroup2;
        void OnClickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string currentButtonName = button.Name;
            // 숫자 눌렀는지 판단
            if (int.TryParse(currentButtonName, out int temp))
            {
                if (labelResult.Text == "0")
                    labelResult.Text = string.Empty;

                if (flagSetNextNumberToGroup1)
                {
                    numberGroup1 = int.Parse(labelResult.Text);
                    labelResult.Text = button.Name;
                    flagSetNextNumberToGroup1 = false;
                    return;
                }

                labelResult.Text += button.Name;
                labelResult.Text = CutCommaString(labelResult.Text);
                int number = int.Parse(labelResult.Text);
                labelResult.Text = $"{number:N0}";
                //labelResult.Text += $"{string.Format("{0:N0}", number)}";
                return;
            }
            else if (currentButtonName == buttonPlus.Name)
            { // 플러스 버튼

                // 다음에 숫자 버튼 누르면 labelResult에 있는 숫자를 숫자그룹1에 넣고 label 지우기 
                flagSetNextNumberToGroup1 = true;
                return;
            }
            else if (currentButtonName == buttonEqual.Name)
            { // 이퀄 버튼

                numberGroup2 = int.Parse(labelResult.Text);
                int resultNumber = numberGroup1 + numberGroup2;
                labelResult.Text = $"{resultNumber:N0}";
                return;
            }
        }

        string CutCommaString(string str)
        {
            return str.Replace(",", "");
        }
    }
}
