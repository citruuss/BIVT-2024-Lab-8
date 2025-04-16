using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;

        public Blue_1(string input) : base(input) 
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new string[0];
                return;
            }

            //посчитаем кол-во строк по 50
            int count = 0, start=0;
            string text = Input;
            while (start< text.Length)
            {
                count++;
                int end = start + 50;
                if (end >= text.Length)
                {
                    start = text.Length;
                    continue;
                }
                //найдем пробел чтобы сделать перенос
                int Space = -1;
                for (int i =end; i>= start; i--)
                {
                    if (i<text.Length && text[i] == ' ')
                    {
                        Space = i; break;
                    }
                }
                if (Space == -1) start = end;
                else start = Space + 1;
            }
            //заполнение массива строками
            _output =new string[count];
            start = 0;
            int number = 0;
            while (start< text.Length)
            {
                int end = start + 50;
                if (end >= text.Length)
                {
                    _output[number] = text.Substring(start); break;
                }

                //найдем пробел чтобы сделать перенос
                int Space = -1;
                for (int i = end; i >= start; i--)
                {
                    if (i < text.Length && text[i] == ' ')
                    {
                        Space = i; break;
                    }
                }
                if (Space == -1) 
                {
                    _output[number]= text.Substring(start, 50);
                    start += 50;
                }
                else
                {
                    _output[number]=text.Substring(start, Space-start);
                    start = Space + 1;
                }
                number++;
            }
        }

        public override string ToString()
        {
            if (_output == null) return null; 
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += _output[i];
                if (i < _output.Length - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }


    }
}
