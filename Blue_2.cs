using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _seq;
        public string Output => _output;


        public Blue_2(string input, string seq) : base(input)
        {
            _output = null;
            _seq = seq;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_seq))
            {
                _output = string.Empty;
                return;
            }
            string[] words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string res = "";
            _output = Input;
            foreach (string w in words)
            {
                if (w != null)
                {
                    if (w.Contains( _seq))
                    {
                        if (w.Contains(".") || w.Contains(",") || w.Contains(";"))
                        {
                            char[] el = new char[w.Length];
                            for (int i = 0; i < w.Length; i++)
                            {
                                el[i] = w[i];
                            }
                            if (w.Contains("\""))
                            {
                                res = _output.Replace(w + " ", "\"\"" + el[el.Length - 1] + " "); //заменяем слово 
                            }
                            else
                            {
                                res = _output.Replace(" " + w, "" + el[el.Length- 1]);
                            }
                            _output= res;
                        }
                        else
                        {
                            res =_output.Replace(w + " ", "");
                            _output= res;
                        }

                    }
                }
            }
        }
        
        //содержится ли комбинация
        //private bool ContainComb(string word, string combinatoin)
        //{
        //    if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(combinatoin) || word.Length < combinatoin.Length)
        //    {
        //        return false;
        //    }
        //    for (int i = 0; i <= word.Length - combinatoin.Length; i++)
        //    {
        //        bool f = true;
        //        for (int j = 0; j < combinatoin.Length; j++)
        //        {
        //            if (word[i + j] != combinatoin[j])
        //            {
        //                f = false;
        //                break;
        //            }
        //        }
        //        if (f) return true;
        //    }
        //    return false;
        //}
        public override string ToString()
        {
            return _output;
        }
    }
}
