using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorString
{

    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(string value) : base(value)
        {
            //this.list = list;
            // "negatives not allowed" + string.Format(", ", list);

        }

    }

    public class Calculator
    {
        char c = ',';

        public int Add(string data)
        {
            int result = 0;
         //   string delimiter = ",";
            List<int> NumberNegative = new List<int>();
          
            bool isNegative = false;
            if (string.IsNullOrEmpty(data))
                return result;
            //if (data.IndexOf("//") != -1)
            //    c = ChooseDelimiter(data)[0];
            Setdelimiter(ref data);

            data = data.Replace('\n', c);
            string[] list = data.Split(c);
            foreach (string numer in list)
            {
                int numberTry;
                if (int.TryParse(numer, out numberTry))
                {
                    if (numberTry < 0)
                    {
                        NumberNegative.Add(numberTry);
                        isNegative = true;
                    }
                    else
                    {
                        if (numberTry <= 1000)
                            result += numberTry;
                    }
                };
            }
            if (isNegative)
            {
                string strNegative = "";
                foreach (int n in NumberNegative)
                {
                    strNegative += " " + n.ToString() + ",";
                }
                throw new NegativesNotAllowedException("negatives not allowed" + strNegative);
            }
            return result;

        }
        private void Setdelimiter(ref string  data)
        {
            int index = 0;
            index = data.IndexOf("//");
            if (index != -1)
            {
                c = data[index + 2];
                data = data.Remove(index, 3);
                data = data.Replace(',', c);
            }
   
        }
        private string[] ChooseDelimiter(string numbers)
        {
            string[] delimiters = { "" };
            string[] beginDelimiter = numbers.Split("//");
            string[] endDelimiter = beginDelimiter[1].Split("\n");
            string delimiter = endDelimiter[0];
            if (delimiter.StartsWith('[') &&
                delimiter.EndsWith(']'))
            {
                delimiter.Remove(0, 1);
                int indexEnd = delimiter.Count() - 1;
                delimiter.Remove(indexEnd, 1);

                delimiters = delimiter.Split("][");


                //foreach (string deli in delimiters)
                //{
                //    deli.Replace("[", "").Replace("]", "");
                //    numbers.Replace(deli, c.ToString());
                //}


            }
            else
                delimiters[0] = delimiter;
            return delimiters;
        }

    }
}
