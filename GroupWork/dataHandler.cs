using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupWork
{
    class dataHandler
    {
        int fractBinaryLen;
        decimal fractvalInDecimal = 0;
        int letter;
        decimal fractvalInDecimalLast;
        int numbersOffractions = 8;
        public string convertToOctal(int binaryNum)
        {
            //octalNumber = Convert.ToInt32(intNumber, 8);

            return Convert.ToString(binaryNum, 8);
        }

        public string FractConvertToBinary()
        {

            decimal internalDecimalFract = fractvalInDecimalLast;
            //fractBinaryLen = fractBinaryNum.Length;
            int i = 0;
            string octalFractions = "";
            while (i < numbersOffractions)
            {
                String[] elements = (internalDecimalFract * 2).ToString().Split('.');
                octalFractions = octalFractions + elements[0];

                internalDecimalFract = Convert.ToDecimal("0." + elements[1]);
                if (internalDecimalFract.Equals(0))
                {
                    break;
                }
                i++;
            }
            return octalFractions;
        }
        public string FractConvertToOctal()
        {
            decimal internalDecimalFract = fractvalInDecimalLast;
            //fractBinaryLen = fractBinaryNum.Length;
            int i = 0;
            string octalFractions = "";
            while (i < numbersOffractions)
            {
                String[] elements = (internalDecimalFract * 8).ToString().Split('.');
                octalFractions = octalFractions + elements[0];

                internalDecimalFract = Convert.ToDecimal("0." + elements[1]);
                if (internalDecimalFract.Equals(0))
                {
                    break;
                }
                i++;
            }
            return octalFractions;
        }
        public string FractConvertToHexadecimal()
        {
            decimal internalDecimalFract = fractvalInDecimalLast;
            //fractBinaryLen = fractBinaryNum.Length;
            int i = 0;
            string octalFractions = "";
            while (i < numbersOffractions)
            {
                String[] elements = (internalDecimalFract * 16).ToString().Split('.');
                if (elements[0].Length == 2)
                {
                    if (elements[0] == "10") { elements[0] = "a"; }
                    else if (elements[0] == "11") { elements[0] = "b"; }
                    else if (elements[0] == "12") { elements[0] = "c"; }
                    else if (elements[0] == "13") { elements[0] = "d"; }
                    else if (elements[0] == "14") { elements[0] = "e"; }
                    else { elements[0] = "f"; }
                }

                octalFractions = octalFractions + elements[0];
                internalDecimalFract = Convert.ToDecimal("0." + elements[1]);
                if (internalDecimalFract.Equals(0))
                {
                    break;
                }
                i++;
            }
            return octalFractions;
        }
        public string FractConvertToDecimal(char[] fractBinaryNum, int type)
        {
            fractBinaryLen = fractBinaryNum.Length;
            if (type == 2)
            {

                for (int i = -1, k = 0; i >= -fractBinaryLen && k < fractBinaryLen; i--, k++)
                {

                    letter = Convert.ToInt32(fractBinaryNum[k].ToString());


                    fractvalInDecimal = fractvalInDecimal + (((decimal)Math.Pow(2, i)) * letter);
                    //fractBinaryNum = fractBinaryNum % 10;


                }
                // String splitter = ".";
                // String[] elements = fractvalInDecimal.ToString().Split(fractvalInDecimal.ToString(), splitter);
                String[] elements = fractvalInDecimal.ToString().Split('.');
                fractvalInDecimalLast = fractvalInDecimal;
                fractvalInDecimal = 0;

                return elements[1];
            }
            else if (type == 8)
            {

                for (int i = -1, k = 0; i >= -fractBinaryLen && k < fractBinaryLen; i--, k++)
                {

                    letter = Convert.ToInt32(fractBinaryNum[k].ToString());


                    fractvalInDecimal = fractvalInDecimal + (((decimal)Math.Pow(8, i)) * letter);
                    //fractBinaryNum = fractBinaryNum % 10;


                }
                // String splitter = ".";
                // String[] elements = fractvalInDecimal.ToString().Split(fractvalInDecimal.ToString(), splitter);
                String[] elements = fractvalInDecimal.ToString().Split('.');
                fractvalInDecimalLast = fractvalInDecimal;
                fractvalInDecimal = 0;

                return elements[1];
            }
            else if (type == 16)
            {

                for (int i = -1, k = 0; i >= -fractBinaryLen && k < fractBinaryLen; i--, k++)
                {
                    if (fractBinaryNum[k] == 'a' || fractBinaryNum[k] == 'A') { letter = 10; }
                    else if (fractBinaryNum[k] == 'b' || fractBinaryNum[k] == 'B') { letter = 11; }
                    else if (fractBinaryNum[k] == 'c' || fractBinaryNum[k] == 'C') { letter = 12; }
                    else if (fractBinaryNum[k] == 'd' || fractBinaryNum[k] == 'D') { letter = 13; }
                    else if (fractBinaryNum[k] == 'e' || fractBinaryNum[k] == 'E') { letter = 14; }
                    else if (fractBinaryNum[k] == 'f' || fractBinaryNum[k] == 'F') { letter = 15; }
                    else
                    {
                        letter = Convert.ToInt32(fractBinaryNum[k].ToString());
                    }

                    fractvalInDecimal = fractvalInDecimal + (((decimal)Math.Pow(16, i)) * letter);
                    //fractBinaryNum = fractBinaryNum % 10;


                }
                String[] elements = fractvalInDecimal.ToString().Split('.');
                fractvalInDecimalLast = fractvalInDecimal;
                fractvalInDecimal = 0;

                return elements[1];
            }
            else if (type == 10)
            {
                string x = "";
                //       int x=(int)Char.GetNumericValue(fractBinaryNum);
                foreach (var item in fractBinaryNum)
                {
                    x = x + item;
                }
                //fractvalInDecimalLast=Convert.ToDecimal(""+fractBinaryNum.ToString());
                fractvalInDecimalLast = Convert.ToDecimal(x);
                string y = "0." + fractvalInDecimalLast;
                string pass = fractvalInDecimalLast.ToString();
                fractvalInDecimalLast = Convert.ToDecimal(y);


                return pass;

            }
            else
            {
                return fractBinaryNum.ToString();
            }


        }
        public string convertToDecimal(int binaryNum)
        {
            //octalNumber = Convert.ToInt32(intNumber, 8);
            fractvalInDecimalLast = Convert.ToDecimal(binaryNum);
            return fractvalInDecimalLast.ToString();
        }
        public string convertTohexadecimal(int binaryNum)
        {
            //octalNumber = Convert.ToInt32(intNumber, 8);

            return Convert.ToString(binaryNum, 16);
        }
        public string convertToBinary(int binaryNum)
        {
            return Convert.ToString(binaryNum, 2);
        }
        public bool OnlyHexInString(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
