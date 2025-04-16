using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            int element =0; 
            bool a = true; //является ли цифрой
            if (string.IsNullOrEmpty(Input))
            {
                return;
            }
            foreach (char el in Input)
            {
                if (el >= '0' && el <= '9')
                {
                    
                    element = element * 10 + (int)(el - '0');
                    a = true;
                }
                else
                {
                    _output += element;
                    a = false;
                    element = 0;
                    
                }
            }
            if (a)
            {
                _output += element;
            }
            
        }
        public override string ToString()
        {
            return ($"{_output}");
        }
    }
    
}
