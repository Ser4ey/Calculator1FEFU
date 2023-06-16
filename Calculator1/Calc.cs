using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    public class Calc
    {
        private double current_number = 0;
        private double history_number = 0;

        public void Set_Current_Number(double number)
        {
            current_number = number;
        }

        public void clear_all_numbers()
        {
            current_number = 0;
            history_number = 0;
        }
        public double Addition(double number)
        {
            current_number = current_number + number;
            return current_number;
        }

        public double Subtraction(double number) 
        { 
            current_number = current_number - number;
            return current_number;
        }
        public double Multiplication(double number)
        {
            current_number = current_number * number;
            return current_number;
        }

        public double Division(double number)
        {
            current_number = current_number / number;
            return current_number;
        }

        public string GetStringNumber()
        {
            return Convert.ToString(current_number);
        }

        

    }

}

