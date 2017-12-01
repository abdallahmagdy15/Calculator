using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2.run
{
    public class runCalc
    {
        string input;
        string sub;
        string x;
        double sub_out;
        public double output;
        public static string ans;
        public static string[,] r=new string[5,2];
        public int i_r;
        public runCalc(string Input)
        {
            i_r = 0;
            input = Input;
            input = input.Replace("ans",ans);
            //assign substitutes of neg num
            r[0, 1] = "a";
            r[1, 1] = "b";
            r[2, 1] = "c";
            r[3, 1] = "d";
            r[4, 1] = "e";
        }
        public void set_sub(string input)
        {
            int s,e;
            if (input.IndexOf(")") != -1)
            {
                s = input.IndexOf("(");
                e = input.IndexOf(")");
                x = input.Substring(s + 1, e - s - 1);
            }
            else
            {
                s = input.LastIndexOf("(");
                x = input.Substring(s + 1);
            }
            
            sub = "(" + x + ")";
        }
        public void sub_check()
        {
            
            if (x.IndexOf("(") != -1)//contains () ?
            {
                set_sub(x);
                sub_check();
            }
            else
            {
                sub_check2();
            }
        }
        public void sub_check2()
        {
            switch (x) {
                case "a": sub_out = double.Parse(r[0, 0]); input = input.Replace(sub, sub_out.ToString());
                    first_check(); break;
                case "b": sub_out = double.Parse(r[1, 0]); input = input.Replace(sub, sub_out.ToString());
                    first_check(); break;
                case "c": sub_out = double.Parse(r[2, 0]); input = input.Replace(sub, sub_out.ToString());
                    first_check(); break;
                case "d": sub_out = double.Parse(r[3, 0]); input = input.Replace(sub, sub_out.ToString());
                    first_check(); break;
                case "e": sub_out = double.Parse(r[4, 0]); input = input.Replace(sub, sub_out.ToString());
                    first_check(); break;
                default:
                if (double.TryParse(x, out sub_out))
            {
                input = input.Replace(sub, sub_out.ToString());
                first_check();
            }
            else
            {
                //calc operation
                calc_operation obj = new calc_operation();
                string ov;
                double res_op = obj.do_op(x, out ov);
                x = x.Replace(ov, res_op.ToString());
                sub_check2();
            }break;
        }
        }
        
        public void hide_negative_nums()
        {
            if (input.IndexOf("-") != -1)
            {
                if (input.IndexOf("-") == 0 || char.IsDigit(input, input.IndexOf("-") - 1) != true)
                {
                    string num = null;
                    foreach (char c in input.Substring(input.IndexOf("-") + 1))//search the num after "-"
                    {
                        if (char.IsDigit(c) || c == '.')
                        { num += c; }
                        else { break; }
                    }
                    r[i_r, 0] = "-" + num;
                    input = input.Replace(r[i_r, 0], r[i_r, 1]);
                    i_r++;
                    hide_negative_nums();
                }
            }
            
        }
        int ctamo = 1;
        string ReplaceFirst(string text, char search, string replace)
        {
            int pos = text.IndexOf(search,ctamo);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + 1);
        }

        public void check_to_add_mult_op(char b, char inverse_b, string ne, int i)
        {
            if (input.IndexOf(b, ctamo) != input.Length-1)
            {
                if (char.IsDigit(input[input.IndexOf(b, ctamo) + i]))// to solve 5(...) bug! to be 5×(...)
                {
                    input = ReplaceFirst(input, b, ne);
                    ctamo = input.IndexOf(b, ctamo) + 2;
                }

                else if (input[input.IndexOf(b, ctamo) + i] == inverse_b)
                {
                    input = input = ReplaceFirst(input, b, ne);
                    ctamo = input.IndexOf(b, ctamo) + 2;
                }
                else
                {
                    switch (input[input.IndexOf(b, ctamo) + i])
                    {
                        case 'a':
                        case 'b':
                        case 'c':
                        case 'd':
                        case 'e': input = ReplaceFirst(input, b, ne); ctamo = input.IndexOf(b, ctamo) + 2; break;
                    }
                }
            }
        }
        public void first_check()
        {
            //check and replace negative number with "r"
            hide_negative_nums();
            string source=input.Substring(1,input.Length-1);
            int count = source.Length - source.Replace("(", "").Length;// to count char of ( *thisfaster way than others*
            if (input.IndexOf("(") != -1)//contains () ?
            {
                for (int i = 0; i < count; i++)
                {
                    check_to_add_mult_op('(', ')', "×(", -1);
                }

                count = source.Length - source.Replace(")", "").Length;// to count 
                for (int i = 0; i < count; i++)
                {
                    check_to_add_mult_op(')', '(', ")×", 1);
                }

                set_sub(input);
                sub_check();
            }
            else
            {
                check_input();
            }
        }
        public void check_input()
        {
            switch (input)
            {
                case "a": output = double.Parse(r[0, 0]); break;
                case "b": output = double.Parse(r[1, 0]); break;
                case "c": output = double.Parse(r[2, 0]); break;
                case "d": output = double.Parse(r[3, 0]); break;
                case "e": output = double.Parse(r[4, 0]); break;
                default:

                    if (double.TryParse(input, out output))
                    {

                    }
                    else
                    {
                        //calc operation
                        calc_operation obj = new calc_operation();
                        string ov;
                        double res_op = obj.do_op(this.input, out ov);
                        this.input = this.input.Replace(ov, res_op.ToString());
                        check_input();
                    }break;
            }
        }
    }
    public class calc_operation
    {
        public string[] operators = new string[] { "√", "^", "sin", "cos", "tan", "×", "÷", "+", "-" };
        public string op;
        public string OV;//old value
        double no1, no2;
        public void recognize_operator(string inp)
        {
            foreach (string o in operators)
            {
                if (inp.IndexOf(o) != -1)
                {
                    op = o; break;
                }
            }

        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public void specify_numbers(string inp)
        {
            string num1 = "";
            string num2 = "";

            foreach (char c in Reverse(inp).Substring(Reverse(inp).LastIndexOf(Reverse(op)) + op.Length))//reverse string to search reversly for numbers before op
            {
                switch (c)
                {
                    case 'a': num1 = "a"; break;
                    case 'b': num1 = "b"; break;
                    case 'c': num1 = "c"; break;
                    case 'd': num1 = "d"; break;
                    case 'e': num1 = "e"; break;
                    default:
                        if (char.IsDigit(c) || c == '.')
                        { num1 += c; }
                        else
                        { goto break_loop; }
                        break;
                }
            }
            break_loop:
            num1 = Reverse(num1);//reverse again
            foreach (char c in inp.Substring(inp.IndexOf(op) + op.Length))//searching starts from operator
            {
                switch (c)
                {
                    case 'a': num2 = "a"; break;
                    case 'b': num2 = "b"; break;
                    case 'c': num2 = "c"; break;
                    case 'd': num2 = "d"; break;
                    case 'e': num2 = "e"; break;
                    default:
                        if (char.IsDigit(c) || c == '.')
                        { num2 += c; }
                        else { goto break_loop2; }break;
                }
            }
            break_loop2:
            OV = num1 + op + num2;
            if (num1 == "")
                num1 = "1";

            switch (num1)
            {
                case "a": no1 = double.Parse(runCalc.r[0, 0]); break;
                case "b": no1 = double.Parse(runCalc.r[1, 0]); break;
                case "c": no1 = double.Parse(runCalc.r[2, 0]); break;
                case "d": no1 = double.Parse(runCalc.r[3, 0]); break;
                case "e": no1 = double.Parse(runCalc.r[4, 0]); break;
                default: no1 = double.Parse(num1); break;
            }
            switch (num2)
            {
                case "a": no2 = double.Parse(runCalc.r[0, 0]); break;
                case "b": no2 = double.Parse(runCalc.r[1, 0]); break;
                case "c": no2 = double.Parse(runCalc.r[2, 0]); break;
                case "d": no2 = double.Parse(runCalc.r[3, 0]); break;
                case "e": no2 = double.Parse(runCalc.r[4, 0]); break;
                default: no2 = double.Parse(num2); break;
            }
        }

        public double calc_()
        {
            switch (op)
            {
                case "×": return (no1 * no2);
                case "÷": return (no1 / no2);
                case "+": return (no1 + no2);
                case "-": return (no1 - no2);
                case "√": return Math.Round((no1 * Math.Sqrt(no2)), 1, MidpointRounding.AwayFromZero);
                case "^": return Math.Pow(no1, no2);
                case "sin": return Math.Round(no1 * Math.Sin((Math.PI / 180) * no2), 1, MidpointRounding.AwayFromZero);
                case "cos": return Math.Round(no1 * Math.Cos((Math.PI / 180) * no2), 1, MidpointRounding.AwayFromZero);
                case "tan": return Math.Round(no1 * Math.Tan((Math.PI / 180) * no2), 1, MidpointRounding.AwayFromZero);
                default: return 0;
            }
        }
        public double do_op(string inp,out string ov)
        {
            recognize_operator(inp);
            specify_numbers(inp);
            ov = OV;
           return calc_();
        }
    }
}
