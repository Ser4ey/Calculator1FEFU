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
        private double memory_number = 0;

        public void Set_Current_Number(double number)
        {
            current_number = number;
        }

        public void Set_Memory_Number(double number)
        {
            memory_number = number;
        }

        public void Clear_All_Numbers()
        {
            current_number = 0;
            memory_number = 0;
        }

        public void Clear_Memory_Number()
        {
            memory_number = 0;
        }

        public void Clear_Current_Number()
        {
            current_number = 0;
        }

        public double Read_Memory_Number()
        {
            return memory_number;
        }

        public void Save_number_in_Memory(double number)
        {
            memory_number = number;
        }

        public void Plus_Number_to_Memory(double number)
        {
            memory_number += number;
        }

        public void Minus_Number_to_Memory(double number)
        {
            memory_number -= number;
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

        public double PercentFromNumber(double number, double pers)
        {
            return (number / 100) * pers;
        }

        public double SquareRoot()
        {
            if (current_number < 0)
            {
                return -1;
            }
            return Math.Sqrt(current_number);
        }

        public double Divide_1_on_X()
        {
            if (current_number == 0)
            {
                return 0;
            }
            return 1/current_number;
        }

        public double GetCurrentDoubleNumber()
        {
            return current_number;
        }

        public string GetStringNumber()
        {
            return Convert.ToString(current_number);
        }

        public string GetStringMemoryNumber()
        {
            return Convert.ToString(memory_number);
        }
    }

}

