using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public (char, double)[] Output
        {
            get
            {
                if (_output == null) 
                {
                    return null; 
                }
                (char, double)[] New = new (char, double)[_output.Length];
                Array.Copy(_output, New, _output.Length);
                return New;
            }
        }

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;  return;
            }
            char[] sep = { ' ', '?', '!', '.', ':', ';', '\"', ',', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            int[] cnt_letter =new int[10000];
            int cnt_words = 0;
            foreach(string w in words)
            {
                if (w.Length != 0)
                {
                    char L_1 = char.ToLower(w[0]);
                    if (char.IsLetter(L_1))
                    {
                        cnt_letter[L_1]++;
                       cnt_words++;
                    }
                }
                
            }
            int unique = 0;
            for (int i = 0; i < cnt_letter.Length; i++)
            {
                if (cnt_letter[i] > 0) unique++;
            }
            _output= new (char,double)[unique];
            int ind = 0;
            for (int i = 0;i <cnt_letter.Length; i++)
            {
                if(cnt_letter[i] > 0)
                {
                    double result =Math.Round(cnt_letter[i] * 100.0 / cnt_words, 4);
                    _output[ind++] = ((char)i,result); //приведение i элемента к виду чар, то есть букве
                }
            }
            //в сортировке сначала сраниваем элементы по значению доли item2, еслиони равны сравниваем по алфавиному порядку
            if (_output == null || _output.Length == 0) return;
            for (int i = 0; i < _output.Length; i++)
            {
                for (int j = 0; j < _output.Length - i - 1; j++)
                {
                    if (_output[j].Item2 < _output[j + 1].Item2)
                    {
                        var a= _output[j];
                        _output[j] = _output[j + 1];
                        _output[j + 1] = a;
                    }
                    else if (_output[j].Item2 == _output[j + 1].Item2)
                    {
                        if (_output[j].Item1 > _output[j + 1].Item1)
                        {
                            var a = _output[j];
                            _output[j] = _output[j + 1];
                            _output[j + 1] =a;
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            if (_output== null|| _output.Length==0) return null;
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += ($"{_output[i].Item1} - {_output[i].Item2:f4}");
                if (i != _output.Length - 1)
                {
                    result += Environment.NewLine;
                }
            }
            return result;
        }
    }

}
