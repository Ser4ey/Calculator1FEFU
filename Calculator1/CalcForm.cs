using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class CalcForm : Form
    {
        private NumberInput number_input = new NumberInput();
        private Calc main_calculator = new Calc();

        private string top_panel = "";
        private string current_operation = "";
        private bool wait_second_number = false; /*ожидаем ввежение нового числа*/

        public CalcForm()
        {
            InitializeComponent();
        }

        private void Number_Button_Click(object sender, EventArgs e)
        {
            if (!wait_second_number)
            {
                history_label.Text = "0";
            }
            if (number_input.CurrentNumber.Length >= 20)
            {
                return;
            }
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Text;
            number_input.add_numeric_character(buttonText);
            main_label.Text = number_input.CurrentNumber;
        }

        private void Comma_Button_Click(object sender, EventArgs e)
        {
            if (number_input.CurrentNumber.Length >= 20)
            {
                return;
            }
            number_input.add_comma();
            main_label.Text = number_input.CurrentNumber;
        }

        private void Plus_Minus_Button_Click(object sender, EventArgs e)
        {
            number_input.set_current_number(main_label.Text);
            number_input.add_plus_or_minus();
            main_label.Text = number_input.CurrentNumber;
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            number_input.delete_last_character();
            main_label.Text = number_input.CurrentNumber;
        }

        private void CE_Button_Click(object sender, EventArgs e)
        {
            number_input.clear_current_number();
            main_label.Text = number_input.CurrentNumber;
        } 

        private void C_Button_Click(object sender, EventArgs e)
        {
            number_input.clear_current_number();
            main_calculator.clear_all_numbers();
            main_label.Text = number_input.CurrentNumber;
            wait_second_number = false;
            history_label.Text = "0";
        }

        private void Two_Number_Operation_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Text;

            if (wait_second_number)
            {
                if (main_label.Text != "0")
                {
                    return;
                }
                top_panel = top_panel.Substring(0, top_panel.Length-1) + $"{buttonText}";
                history_label.Text = top_panel;
                return;
            }
            current_operation = buttonText;

            number_input.set_current_number(main_label.Text);
            top_panel = number_input.CurrentNumber + $"{buttonText}";
            history_label.Text = top_panel;

            main_label.Text = "0";
            main_calculator.Set_Current_Number(number_input.get_double_number());

            number_input.clear_current_number();
            wait_second_number = true;
        }

        private void Equally_Button_Click(Object sender, EventArgs e)
        {
            if (!wait_second_number)
            {
                history_label.Text = main_label.Text+"=";
                return;
            }
            double second_number = number_input.get_double_number();
            history_label.Text += second_number + "=";
            if (current_operation == "+")
            {
                main_calculator.Addition(second_number);
            } else if (current_operation == "-") {
                main_calculator.Subtraction(second_number);
            } else if (current_operation == "*")
            {
                main_calculator.Multiplication(second_number);
            } else if(current_operation == "/")
            {
                if (second_number == 0)
                {
                    wait_second_number=false;
                    main_calculator.clear_all_numbers();
                    number_input.clear_current_number();
                    main_label.Text = "Нельзя делить на 0!";
                    history_label.Text = "0";
                    return;
                }
                main_calculator.Division(second_number);
            }

            main_label.Text = main_calculator.GetStringNumber();
            wait_second_number = false;
            number_input.clear_current_number();
            current_operation = "";
        }
    }
}
