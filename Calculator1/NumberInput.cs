using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    internal class NumberInput
    /*Класс отвечающий за ввод числа от пользователя*/
    {
        private string _current_number = "0";
        public string CurrentNumber { get { return _current_number; } }

        public void add_numeric_character(string number)
        {
            if (_current_number == "0")
            {
                _current_number = number;
                return;
            }
            _current_number += number;
        }

        public void add_comma()
        {
            if (_current_number.Contains(",")) 
            {
                return;
            }
            _current_number += ",";
        }

        public void add_plus_or_minus()
        {
            if (_current_number == "0") { return; }

            if (_current_number.Contains("-"))
            {
                _current_number = _current_number.Substring(1);
                return;
            }
            _current_number = "-" + _current_number;
        }
        public void delete_last_character()
        {
            _current_number = _current_number.Substring(0, _current_number.Length - 1);
            if(_current_number == "" || _current_number == "-" || _current_number == ",")
            {
                _current_number = "0";
            }
        }

        public void clear_current_number()
        {
            _current_number = "0";
        }

        public void set_current_number(string number)
        {
            _current_number = number;
        }

        public double get_double_number()
        {
            string number = _current_number;
            if (number[number.Length-1] == ',')
            {
                number = number.Substring(0, number.Length - 1);
            }

            return Double.Parse(number); 
        }
    }
}





