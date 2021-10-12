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
                item.Click += ClickButtonEvent;
                SetButtonInit(item);
            }
        }

        private void SetButtonInit(Button button)
        {
            button.Name = button.Text;
        }

        void ClickButtonEvent(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
