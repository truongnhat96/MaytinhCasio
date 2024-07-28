using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaytinhCasio
{
    public partial class Casio : Form
    {
        public Casio()
        {
            InitializeComponent();
            ans = 0;
        }
        private double gcd(double a, double b)
        {
            while (b != 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        private void btnXoapheptinh_Click(object sender, EventArgs e)
        {
            if(lblOutput.Text != "" && lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
            {
                if (lblOutput.Text[lblOutput.Text.Length - 1] == ' ')
                    lblOutput.Text = lblOutput.Text.Remove(lblOutput.Text.Length - 3, 3);
                else
                lblOutput.Text = lblOutput.Text.Remove(lblOutput.Text.Length - 1);
            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if(lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
            lblOutput.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "0";
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "²";
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            lblKetqua.Visible = true;
            lblKetqua.Text = "0";
            lblOutput.ResetText();
            lblOutput.TextAlign = ContentAlignment.TopLeft;
            ans = 0;
        }

        private void btnRemoveTop_Click(object sender, EventArgs e)
        {
            lblKetqua.Visible = true;
            lblOutput.ResetText();
            lblOutput.TextAlign = ContentAlignment.TopLeft;
            ans = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            bool check = true;
            string tmp = lblOutput.Text;
            char c = '?';
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == '+' || tmp[i] == '—' || tmp[i] == '×' || tmp[i] == '÷')
                {
                    c = tmp[i]; break;
                }
            }

            //Xử lý Số Pi
            if (tmp.Contains('π'))
            {
                check = false;
                if (c == '?')
                {
                    tmp = tmp.Replace("π", Math.PI.ToString());
                    lblKetqua.Text = tmp;
                }
                else tmp = tmp.Replace("π", Math.PI.ToString());
            }


            //Xử lý Số E
            if (tmp.Contains('e'))
            {
                check = false;
                if (c == '?')
                {
                    tmp = tmp.Replace("e", Math.E.ToString());
                    lblKetqua.Text = tmp;
                }
                else tmp = tmp.Replace("e", Math.E.ToString());
            }


            //Xử lý căn bậc 2
            if (tmp.Contains('√'))
            {
                check = false;
                int FidxOfPow = tmp.IndexOf('√');
                int LidxOfPow = tmp.LastIndexOf('√');
                //Căn ? Căn
                if(FidxOfPow != LidxOfPow && FidxOfPow == 0 && LidxOfPow != tmp.Length - 1 && char.IsDigit(tmp[LidxOfPow + 1]) && !char.IsDigit(tmp[LidxOfPow - 1]))
                {
                    try
                    {
                        //tham số 1, tham số 2
                         string s1 = "", s2 = "";
                         for (int i = FidxOfPow + 1; i < LidxOfPow; i++)
                         {
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                            s1 += tmp[i];
                            if (tmp[i] == '√')
                            {
                                throw new Exception();
                            }
                         }
                        for (int i = LidxOfPow + 1; i < tmp.Length; i++)
                        {
                            if (tmp[i] == '√')
                            {
                                throw new Exception();
                            }
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s2 += tmp[i];
                        }

                        //Xử lý Pow
                        if (tmp.Contains('²'))
                        {
                            int FirstP1 = s1.IndexOf('²'), FirstP2 = s2.IndexOf('²');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if(FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) * double.Parse(s1);
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) * double.Parse(s2);
                                s2 = kq.ToString();
                            }
                        }

                        // Xử lý percent
                        if(tmp.Contains('%'))
                        {
                            int FirstP1 = s1.IndexOf('%'), FirstP2 = s2.IndexOf('%');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) / 100;
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) / 100; 
                                s2 = kq.ToString();
                            }
                        }
                         
                         double can1 = Math.Sqrt(double.Parse(s1));
                         double can2 = Math.Sqrt(double.Parse(s2));
                         tmp = $"{can1.ToString()} {c.ToString()} {can2.ToString()}"; 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        lblKetqua.ResetText();
                        lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                        lblOutput.Text = "Syntax Error";
                        lblKetqua.Visible = false;
                    }
                }
                //Căn ? số / số ? căn
                else if(FidxOfPow == LidxOfPow)
                {
                    if(c == '?')
                    {
                        try
                        {
                            string s = tmp.Substring(LidxOfPow + 1);
                            //Xử lý Pow
                            if (tmp.Contains('²'))
                            {
                                int FirstP1 = s.IndexOf('²');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else  
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) * double.Parse(s);
                                    s = kqa.ToString();
                                }
                            }

                            // Xử lý percent
                            if (tmp.Contains('%'))
                            {
                                int FirstP1 = s.IndexOf('%');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else 
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) / 100;
                                    s = kqa.ToString();
                                }
                            }

                            double kq = Math.Sqrt(double.Parse(s));
                            lblKetqua.Text = kq.ToString();
                            return;
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] tok = tmp.Split(' ');
                            if (tok[0].Contains('√'))
                            {
                                tok[0] = tok[0].Substring(1);
                                //Xử lý Pow
                                if (tmp.Contains('²'))
                                {
                                    int FirstP1 = tok[0].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) * double.Parse(tok[0]);
                                        tok[0] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[0].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) / 100;
                                        tok[0] = kqa.ToString();
                                    }
                                }
                                double kq = Math.Sqrt(double.Parse(tok[0]));
                                tmp = $"{kq.ToString()} {tok[1]} {tok[2]}";
                            }

                            else if (tok[2].Contains('√'))
                            {
                                tok[2] = tok[2].Substring(1);
                                //Xử lý Pow
                                if (tmp.Contains('²'))
                                {
                                    int FirstP1 = tok[2].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) * double.Parse(tok[2]);
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[2].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) / 100;
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                double kq = Math.Sqrt(double.Parse(tok[2]));
                                tmp = $"{tok[0]} {tok[1]} {kq.ToString()}";
                            }
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                }else check = true;
            }
           // Console.WriteLine(tmp);


            //Xử lý Logarit base e
            if (tmp.Contains("ln"))
            {
                check = false;
                int FidxOfPow = tmp.IndexOf("ln");
                int LidxOfPow = tmp.LastIndexOf("ln");
                
                if (FidxOfPow != LidxOfPow && FidxOfPow == 0 && LidxOfPow != tmp.Length - 2 && char.IsDigit(tmp[LidxOfPow + 2]) && !char.IsDigit(tmp[LidxOfPow - 1]))
                {
                    try
                    {
                        //tham số 1, tham số 2
                        string s1 = "", s2 = "";
                        for (int i = FidxOfPow + 2; i < LidxOfPow; i++)
                        {
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s1 += tmp[i];
                            if (tmp[i] == 'l')
                            {
                                throw new Exception();
                            }
                        }
                        for (int i = LidxOfPow + 2; i < tmp.Length; i++)
                        {
                            if (tmp[i] == 'l')
                            {
                                throw new Exception();
                            }
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s2 += tmp[i];
                        }

                        //Xử lý Pow
                        if (tmp.Contains('²'))
                        {
                            int FirstP1 = s1.IndexOf('²'), FirstP2 = s2.IndexOf('²');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) * double.Parse(s1);
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) * double.Parse(s2);
                                s2 = kq.ToString();
                            }
                        }

                        // Xử lý percent
                        if (tmp.Contains('%'))
                        {
                            int FirstP1 = s1.IndexOf('%'), FirstP2 = s2.IndexOf('%');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) / 100;
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) / 100;
                                s2 = kq.ToString();
                            }
                        }

                        double can1 = Math.Log(double.Parse(s1));
                        double can2 = Math.Log(double.Parse(s2));
                        tmp = $"{can1.ToString()} {c.ToString()} {can2.ToString()}";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        lblKetqua.ResetText();
                        lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                        lblOutput.Text = "Syntax Error";
                        lblKetqua.Visible = false;
                    }
                }
                
                else if (FidxOfPow == LidxOfPow)
                {
                    if (c == '?')
                    {
                        try
                        {
                            string s = tmp.Substring(LidxOfPow + 2);
                            //Xử lý Pow
                            if (tmp.Contains('²'))
                            {
                                int FirstP1 = s.IndexOf('²');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) * double.Parse(s);
                                    s = kqa.ToString();
                                }
                            }

                            // Xử lý percent
                            if (tmp.Contains('%'))
                            {
                                int FirstP1 = s.IndexOf('%');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) / 100;
                                    s = kqa.ToString();
                                }
                            }

                            double kq = Math.Log(double.Parse(s));
                            lblKetqua.Text = kq.ToString();
                            return;
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] tok = tmp.Split(' ');
                            if (tok[0].Contains("ln"))
                            {
                                tok[0] = tok[0].Substring(2);
                                //Xử lý Pow
                                if (tmp.Contains('²'))
                                {
                                    int FirstP1 = tok[0].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) * double.Parse(tok[0]);
                                        tok[0] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[0].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) / 100;
                                        tok[0] = kqa.ToString();
                                    }
                                }
                                double kq = Math.Log(double.Parse(tok[0]));
                                tmp = $"{kq.ToString()} {tok[1]} {tok[2]}";
                            }

                            else if (tok[2].Contains("ln"))
                            {
                                tok[2] = tok[2].Substring(2);
                                //Xử lý Pow
                                if (tmp.Contains('²'))
                                {
                                    int FirstP1 = tok[2].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) * double.Parse(tok[2]);
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[2].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if(FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) / 100;
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                double kq = Math.Log(double.Parse(tok[2]));
                                tmp = $"{tok[0]} {tok[1]} {kq.ToString()}";
                            }
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                }
                else check = true;
            }


            //Xử lý lượng giác 
            // sin
            if (tmp.Contains("sin"))
            {
                check = false;
                int FidxOfSin = tmp.IndexOf("sin");
                int LidxOfSin = tmp.LastIndexOf("sin");
                Console.WriteLine($"{FidxOfSin}  {LidxOfSin}");
                if (FidxOfSin != LidxOfSin && FidxOfSin == 0 && LidxOfSin != tmp.Length - 3 && char.IsDigit(tmp[LidxOfSin + 3]) && !char.IsDigit(tmp[LidxOfSin - 1]))
                {
                    try
                    {
                        //tham số 1, tham số 2
                        string s1 = "", s2 = "";
                        for (int i = FidxOfSin + 3; i < LidxOfSin; i++)
                        {
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s1 += tmp[i];
                            if (tmp[i] == 's')
                            {
                                throw new Exception();
                            }
                        }
                        for (int i = LidxOfSin + 3; i < tmp.Length; i++)
                        {
                            if (tmp[i] == 's')
                            {
                                throw new Exception();
                            }
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s2 += tmp[i];
                        }

                        //Xử lý Pow
                        if (tmp.Contains('²'))
                        {
                            int FirstP1 = s1.IndexOf('²'), FirstP2 = s2.IndexOf('²');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) * double.Parse(s1);
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) * double.Parse(s2);
                                s2 = kq.ToString();
                            }
                        }

                        // Xử lý percent
                        if (tmp.Contains('%'))
                        {
                            int FirstP1 = s1.IndexOf('%'), FirstP2 = s2.IndexOf('%');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) / 100;
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) / 100;
                                s2 = kq.ToString();
                            }
                        }

                        double can1 = Math.Sin(double.Parse(s1));
                        double can2 = Math.Sin(double.Parse(s2));
                        tmp = $"{can1.ToString()} {c.ToString()} {can2.ToString()}";
                    }
                    catch (Exception)
                    {
                        lblKetqua.ResetText();
                        lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                        lblOutput.Text = "Syntax Error";
                        lblKetqua.Visible = false;
                    }
                }
                else if (FidxOfSin == LidxOfSin)
                {
                    if (c == '?')
                    {
                        try
                        {
                            string s = tmp.Substring(LidxOfSin + 3);
                            //Xử lý Pow
                            if (tmp.Contains('²'))
                            {
                                int FirstP1 = s.IndexOf('²');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) * double.Parse(s);
                                    s = kqa.ToString();
                                }
                            }

                            // Xử lý percent
                            if (tmp.Contains('%'))
                            {
                                int FirstP1 = s.IndexOf('%');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) / 100;
                                    s = kqa.ToString();
                                }
                            }

                            double kq = Math.Sin(double.Parse(s));
                            lblKetqua.Text = kq.ToString();
                            return;
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] tok = tmp.Split(' ');
                            if (tok[0].Contains("sin"))
                            {
                                tok[0] = tok[0].Substring(3);
                                //Xử lý Pow
                                if (tmp.Contains('²'))
                                {
                                    int FirstP1 = tok[0].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) * double.Parse(tok[0]);
                                        tok[0] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[0].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) / 100;
                                        tok[0] = kqa.ToString();
                                    }
                                }
                                double kq = Math.Sin(double.Parse(tok[0]));
                                tmp = $"{kq.ToString()} {tok[1]} {tok[2]}";
                            }

                            else if (tmp.Contains("sin"))
                            {
                                tok[2] = tok[2].Substring(3);
                                //Xử lý Pow
                                if (tok[2].Contains('²'))
                                {
                                    int FirstP1 = tok[2].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) * double.Parse(tok[2]);
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[2].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) / 100;
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                double kq = Math.Sin(double.Parse(tok[2]));
                                tmp = $"{tok[0]} {tok[1]} {kq.ToString()}";
                            }
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                }
                else check = true;
            }
            // Console.WriteLine(c);

            // cos
            if (tmp.Contains("cos"))
            {
                check = false;
                int FidxOfSin = tmp.IndexOf("cos");
                int LidxOfSin = tmp.LastIndexOf("cos");
                Console.WriteLine($"{FidxOfSin}  {LidxOfSin}");
                if (FidxOfSin != LidxOfSin && FidxOfSin == 0 && LidxOfSin != tmp.Length - 3 && char.IsDigit(tmp[LidxOfSin + 3]) && !char.IsDigit(tmp[LidxOfSin - 1]))
                {
                    try
                    {
                        //tham số 1, tham số 2
                        string s1 = "", s2 = "";
                        for (int i = FidxOfSin + 3; i < LidxOfSin; i++)
                        {
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s1 += tmp[i];
                            if (tmp[i] == 'c')
                            {
                                throw new Exception();
                            }
                        }
                        for (int i = LidxOfSin + 3; i < tmp.Length; i++)
                        {
                            if (tmp[i] == 'c')
                            {
                                throw new Exception();
                            }
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s2 += tmp[i];
                        }

                        //Xử lý Pow
                        if (tmp.Contains('²'))
                        {
                            int FirstP1 = s1.IndexOf('²'), FirstP2 = s2.IndexOf('²');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) * double.Parse(s1);
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) * double.Parse(s2);
                                s2 = kq.ToString();
                            }
                        }

                        // Xử lý percent
                        if (tmp.Contains('%'))
                        {
                            int FirstP1 = s1.IndexOf('%'), FirstP2 = s2.IndexOf('%');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) / 100;
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) / 100;
                                s2 = kq.ToString();
                            }
                        }

                        double can1 = Math.Cos(double.Parse(s1));
                        double can2 = Math.Cos(double.Parse(s2));
                        tmp = $"{can1.ToString()} {c.ToString()} {can2.ToString()}";
                    }
                    catch (Exception)
                    {
                        lblKetqua.ResetText();
                        lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                        lblOutput.Text = "Syntax Error";
                        lblKetqua.Visible = false;
                    }
                }
                else if (FidxOfSin == LidxOfSin)
                {
                    if (c == '?')
                    {
                        try
                        {
                            string s = tmp.Substring(LidxOfSin + 3);
                            //Xử lý Pow
                            if (tmp.Contains('²'))
                            {
                                int FirstP1 = s.IndexOf('²');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) * double.Parse(s);
                                    s = kqa.ToString();
                                }
                            }

                            // Xử lý percent
                            if (tmp.Contains('%'))
                            {
                                int FirstP1 = s.IndexOf('%');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) / 100;
                                    s = kqa.ToString();
                                }
                            }

                            double kq = Math.Cos(double.Parse(s));
                            lblKetqua.Text = kq.ToString();
                            return;
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] tok = tmp.Split(' ');
                            if (tok[0].Contains("cos"))
                            {
                                tok[0] = tok[0].Substring(3);
                                //Xử lý Pow
                                if (tmp.Contains('²'))
                                {
                                    int FirstP1 = tok[0].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) * double.Parse(tok[0]);
                                        tok[0] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[0].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) / 100;
                                        tok[0] = kqa.ToString();
                                    }
                                }
                                double kq = Math.Cos(double.Parse(tok[0]));
                                tmp = $"{kq.ToString()} {tok[1]} {tok[2]}";
                            }

                            else if (tmp.Contains("cos"))
                            {
                                tok[2] = tok[2].Substring(3);
                                //Xử lý Pow
                                if (tok[2].Contains('²'))
                                {
                                    int FirstP1 = tok[2].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) * double.Parse(tok[2]);
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[2].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) / 100;
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                double kq = Math.Cos(double.Parse(tok[2]));
                                tmp = $"{tok[0]} {tok[1]} {kq.ToString()}";
                            }
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                }
                else check = true;
            }

            // tan
            if (tmp.Contains("tan"))
            {
                check = false;
                int FidxOfSin = tmp.IndexOf("tan");
                int LidxOfSin = tmp.LastIndexOf("tan");
                Console.WriteLine($"{FidxOfSin}  {LidxOfSin}");
                if (FidxOfSin != LidxOfSin && FidxOfSin == 0 && LidxOfSin != tmp.Length - 3 && char.IsDigit(tmp[LidxOfSin + 3]) && !char.IsDigit(tmp[LidxOfSin - 1]))
                {
                    try
                    {
                        //tham số 1, tham số 2
                        string s1 = "", s2 = "";
                        for (int i = FidxOfSin + 3; i < LidxOfSin; i++)
                        {
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s1 += tmp[i];
                            if (tmp[i] == 't')
                            {
                                throw new Exception();
                            }
                        }
                        for (int i = LidxOfSin + 3; i < tmp.Length; i++)
                        {
                            if (tmp[i] == 't')
                            {
                                throw new Exception();
                            }
                            if (char.IsDigit(tmp[i]) || tmp[i] == '²' || tmp[i] == '%')
                                s2 += tmp[i];
                        }

                        //Xử lý Pow
                        if (tmp.Contains('²'))
                        {
                            int FirstP1 = s1.IndexOf('²'), FirstP2 = s2.IndexOf('²');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) * double.Parse(s1);
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) * double.Parse(s2);
                                s2 = kq.ToString();
                            }
                        }

                        // Xử lý percent
                        if (tmp.Contains('%'))
                        {
                            int FirstP1 = s1.IndexOf('%'), FirstP2 = s2.IndexOf('%');
                            //s1
                            if (FirstP1 != -1 && FirstP1 != s1.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP1 != -1)
                            {
                                s1 = s1.Substring(0, s1.Length - 1);
                                double kq = double.Parse(s1) / 100;
                                s1 = kq.ToString();
                            }
                            //s2
                            if (FirstP2 != -1 && FirstP2 != s2.Length - 1)
                            {
                                throw new Exception();
                            }
                            else if (FirstP2 != -1)
                            {
                                s2 = s2.Substring(0, s2.Length - 1);
                                double kq = double.Parse(s2) / 100;
                                s2 = kq.ToString();
                            }
                        }

                        double can1 = Math.Tan(double.Parse(s1));
                        double can2 = Math.Tan(double.Parse(s2));
                        tmp = $"{can1.ToString()} {c.ToString()} {can2.ToString()}";
                    }
                    catch (Exception)
                    {
                        lblKetqua.ResetText();
                        lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                        lblOutput.Text = "Syntax Error";
                        lblKetqua.Visible = false;
                    }
                }
                else if (FidxOfSin == LidxOfSin)
                {
                    if (c == '?')
                    {
                        try
                        {
                            string s = tmp.Substring(LidxOfSin + 3);
                            //Xử lý Pow
                            if (tmp.Contains('²'))
                            {
                                int FirstP1 = s.IndexOf('²');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) * double.Parse(s);
                                    s = kqa.ToString();
                                }
                            }

                            // Xử lý percent
                            if (tmp.Contains('%'))
                            {
                                int FirstP1 = s.IndexOf('%');
                                //s
                                if (FirstP1 != -1 && FirstP1 != s.Length - 1)
                                {
                                    throw new Exception();
                                }
                                else
                                {
                                    s = s.Substring(0, s.Length - 1);
                                    double kqa = double.Parse(s) / 100;
                                    s = kqa.ToString();
                                }
                            }

                            double kq = Math.Tan(double.Parse(s));
                            lblKetqua.Text = kq.ToString();
                            return;
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] tok = tmp.Split(' ');
                            if (tok[0].Contains("tan"))
                            {
                                tok[0] = tok[0].Substring(3);
                                //Xử lý Pow
                                if (tmp.Contains('²'))
                                {
                                    int FirstP1 = tok[0].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) * double.Parse(tok[0]);
                                        tok[0] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[0].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[0].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[0] = tok[0].Substring(0, tok[0].Length - 1);
                                        double kqa = double.Parse(tok[0]) / 100;
                                        tok[0] = kqa.ToString();
                                    }
                                }
                                double kq = Math.Tan(double.Parse(tok[0]));
                                tmp = $"{kq.ToString()} {tok[1]} {tok[2]}";
                            }

                            else if (tmp.Contains("tan"))
                            {
                                tok[2] = tok[2].Substring(3);
                                //Xử lý Pow
                                if (tok[2].Contains('²'))
                                {
                                    int FirstP1 = tok[2].IndexOf('²');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) * double.Parse(tok[2]);
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                // Xử lý percent
                                if (tmp.Contains('%'))
                                {
                                    int FirstP1 = tok[2].IndexOf('%');
                                    //s
                                    if (FirstP1 != -1 && FirstP1 != tok[2].Length - 1)
                                    {
                                        throw new Exception();
                                    }
                                    else if (FirstP1 != -1)
                                    {
                                        tok[2] = tok[2].Substring(0, tok[2].Length - 1);
                                        double kqa = double.Parse(tok[2]) / 100;
                                        tok[2] = kqa.ToString();
                                    }
                                }

                                double kq = Math.Tan(double.Parse(tok[2]));
                                tmp = $"{tok[0]} {tok[1]} {kq.ToString()}";
                            }
                        }
                        catch (Exception)
                        {
                            lblKetqua.ResetText();
                            lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                            lblOutput.Text = "Syntax Error";
                            lblKetqua.Visible = false;
                        }
                    }
                }
                else check = true;
            }


            //Xử lý bình phương
            if (tmp.Contains('²'))
            {
                string[] tok = tmp.Split(' ');
                if(tok.Length < 2)
                {
                  double kq = double.Parse(tok[0].Substring(0, tok[0].Length - 1)) * double.Parse(tok[0].Substring(0, tok[0].Length - 1));
                  lblKetqua.Text = kq.ToString();
                    return;
                }
                int idx1 = tok[0].IndexOf('²');
                int idx2 = tok[2].IndexOf('²');
                double kq1 = 0, kq2 = 0;
                try
                {
                    if (idx1 != -1)
                        kq1 = double.Parse(tok[0].Substring(0, tok[0].Length - 1)) * double.Parse(tok[0].Substring(0, tok[0].Length - 1));
                    if (idx2 != -1)
                        kq2 = double.Parse(tok[2].Substring(0, tok[2].Length - 1)) * double.Parse(tok[2].Substring(0, tok[2].Length - 1));
                }
                catch (Exception)
                {
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Syntax Error";
                    lblKetqua.Visible = false;
                }
                if (kq1 == 0) tmp = $"{tok[0]} {tok[1]} {kq2.ToString()}";
                else if(kq2 == 0) tmp = $"{kq1.ToString()} {tok[1]} {tok[2]}";
                else tmp = $"{kq1.ToString()} {tok[1]} {kq2.ToString()}";
            }


            //Xử lý phần trăm
            if (tmp.Contains('%'))
            {
                string[] tok = tmp.Split(' ');
                if (tok.Length < 2)
                {
                    double kq = double.Parse(tok[0].Substring(0, tok[0].Length - 1)) / 100;
                    lblKetqua.Text = kq.ToString();
                    return;
                }
                int idx1 = tok[0].IndexOf('%');
                int idx2 = tok[2].IndexOf('%');
                double kq1 = 0, kq2 = 0;
                try
                {
                    if (idx1 != -1)
                        kq1 = double.Parse(tok[0].Substring(0, tok[0].Length - 1)) / 100;
                    if (idx2 != -1)
                        kq2 = double.Parse(tok[2].Substring(0, tok[2].Length - 1)) / 100;
                }
                catch (Exception)
                {
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Syntax Error";
                    lblKetqua.Visible = false;
                }
                if (kq1 == 0) tmp = $"{tok[0]} {tok[1]} {kq2.ToString()}";
                else if (kq2 == 0) tmp = $"{kq1.ToString()} {tok[1]} {tok[2]}";
                else tmp = $"{kq1.ToString()} {tok[1]} {kq2.ToString()}";
            }


            #region Operator Solve
            // Xử lý Phân số
            if (tmp.Contains('/'))
            {
                check = false;
                try
                {
                    if(c == '?')
                    {
                        string[] t = tmp.Split('/');
                        if (!t[0].Contains('.') && !t[1].Contains('.'))
                        {
                            double ucln = gcd(double.Parse(t[0]), double.Parse(t[1]));
                            double ts = double.Parse(t[0]) / ucln;
                            double ms = double.Parse(t[1]) / ucln;
                            if(ms == 1) lblKetqua.Text = ts.ToString();
                            if(ms == 0) throw new DivideByZeroException();
                            else lblKetqua.Text = $"{ts.ToString()}/{ms.ToString()}";
                        }
                        else lblKetqua.Text = tmp;
                        return;
                    }
                    if (c == '+')
                    {
                        string[] w = tmp.Split(new char[] { ' ', '+' }, StringSplitOptions.RemoveEmptyEntries);
                        // Console.WriteLine(w[0] + " " + w[1]);
                        if (!w[0].Contains('/')) w[0] += ("/1");
                        if (!w[1].Contains('/')) w[1] += ("/1");
                        string[] ps1 = w[0].Split('/'), ps2 = w[1].Split('/');
                        Console.WriteLine(ps1[0] + " " + ps1[1] + " " + ps2[0] + " " + ps2[1]);
                        if (ps1.Length > 2 || ps2.Length > 2)
                        {
                            MessageBox.Show("404 NOT FOUND X﹏X\nSyntax Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnRemoveAll.PerformClick();
                            return;
                        }
                        double ts = (double.Parse(ps1[0]) * double.Parse(ps2[1])) + (double.Parse(ps1[1]) * double.Parse(ps2[0]));
                        double ms = double.Parse(ps1[1]) * double.Parse(ps2[1]);
                        ans = ts / ms;
                        if (ms == 0) throw new DivideByZeroException();
                        if (ts % ms != 0)
                            lblKetqua.Text = $"{ts.ToString()}/{ms.ToString()}";
                        else lblKetqua.Text = $"{ans.ToString()}";
                    }
                    else if (c == '—')
                    {
                        string[] w = tmp.Split(new char[] { ' ', '—' }, StringSplitOptions.RemoveEmptyEntries);
                         Console.WriteLine(w[0] + " " + w[1]);
                        if (!w[0].Contains('/')) w[0] += ("/1");
                        if (!w[1].Contains('/')) w[1] += ("/1");
                        string[] ps1 = w[0].Split('/'), ps2 = w[1].Split('/');
                        Console.WriteLine(ps1[0] + " " + ps1[1] + " " + ps2[0] + " " + ps2[1]);
                        if (ps1.Length > 2 || ps2.Length > 2)
                        {
                            MessageBox.Show("404 NOT FOUND X﹏X\nSyntax Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnRemoveAll.PerformClick();
                            return;
                        }
                        double ts = (double.Parse(ps1[0]) * double.Parse(ps2[1])) - (double.Parse(ps1[1]) * double.Parse(ps2[0]));
                        double ms = double.Parse(ps1[1]) * double.Parse(ps2[1]);
                        ans = ts / ms;
                        if (ms == 0) throw new DivideByZeroException();
                        if (ts % ms != 0)
                            lblKetqua.Text = $"{ts.ToString()}/{ms.ToString()}";
                        else lblKetqua.Text = $"{ans.ToString()}";
                    }
                    else if (c == '×')
                    {
                        string[] w = tmp.Split(new char[] { ' ', '×' }, StringSplitOptions.RemoveEmptyEntries);
                        // Console.WriteLine(w[0] + " " + w[1]);
                        if (!w[0].Contains('/')) w[0] += ("/1");
                        if (!w[1].Contains('/')) w[1] += ("/1");
                        string[] ps1 = w[0].Split('/'), ps2 = w[1].Split('/');
                        Console.WriteLine(ps1[0] + " " + ps1[1] + " " + ps2[0] + " " + ps2[1]);
                        if (ps1.Length > 2 || ps2.Length > 2)
                        {
                            MessageBox.Show("404 NOT FOUND X﹏X\nSyntax Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnRemoveAll.PerformClick();
                            return;
                        }
                        double ts = (double.Parse(ps1[0]) * double.Parse(ps2[0]));
                        double ms = double.Parse(ps1[1]) * double.Parse(ps2[1]);
                        ans = ts / ms;
                        if (ms == 0) throw new DivideByZeroException();
                        if (ts % ms != 0)
                            lblKetqua.Text = $"{ts.ToString()}/{ms.ToString()}";
                        else lblKetqua.Text = $"{ans.ToString()}";
                    }
                    else if (c == '÷')
                    {
                        string[] w = tmp.Split(new char[] { ' ', '÷' }, StringSplitOptions.RemoveEmptyEntries);
                        // Console.WriteLine(w[0] + " " + w[1]);
                        if (!w[0].Contains('/')) w[0] += ("/1");
                        if (!w[1].Contains('/')) w[1] += ("/1");
                        string[] ps1 = w[0].Split('/'), ps2 = w[1].Split('/');
                        Console.WriteLine(ps1[0] + " " + ps1[1] + " " + ps2[0] + " " + ps2[1]);
                        if (ps1.Length > 2 || ps2.Length > 2)
                        {
                            MessageBox.Show("404 NOT FOUND X﹏X\nSyntax Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnRemoveAll.PerformClick();
                            return;
                        }
                        double ts = (double.Parse(ps1[0]) * double.Parse(ps2[1]));
                        double ms = double.Parse(ps1[1]) * double.Parse(ps2[0]);
                        ans = ts / ms;
                        if (ms == 0) throw new DivideByZeroException();
                        if (ts % ms != 0)
                            lblKetqua.Text = $"{ts.ToString()}/{ms.ToString()}";
                        else lblKetqua.Text = $"{ans.ToString()}";
                    }
                    else check = true;
                }
                catch (DivideByZeroException)
                {
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Math Error";
                    lblKetqua.Visible = false;
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Syntax Error";
                    lblKetqua.Visible = false;
                }
            }

            //Xử lý dấu '+'
            else if (c == '+')
            {
               check = false;
               int idx = tmp.IndexOf('+'); 
               
               tmp = tmp.Remove(idx, 1);
               string[] tok = tmp.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
               Console.WriteLine(tok[0] + " " + tok[1]);
                try
                {
                    if (tok[0].Contains('.') || tok[1].Contains('.'))
                    {
                        
                        ans = (double.Parse(tok[0]) + double.Parse(tok[1]));
                        lblKetqua.Text = ans.ToString();
                    }
                    else
                    {
                        ans = (long.Parse(tok[0]) + long.Parse(tok[1]));
                        lblKetqua.Text = ans.ToString();
                    }
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Syntax Error";
                    lblKetqua.Visible = false;
                }
            }

            //Xử lý dấu '-'
            else if (c == '—')
            {
                check = false;
                int idx = tmp.IndexOf('—');
                tmp = tmp.Remove(idx, 1);
                string[] tok = tmp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(tok[0] + " " + tok[1]);
                try
                {
                    if (tok[0].Contains('.') || tok[1].Contains('.'))
                    {

                        ans = (double.Parse(tok[0]) - double.Parse(tok[1]));
                        lblKetqua.Text = ans.ToString();
                    }
                    else
                    {
                        ans = (long.Parse(tok[0]) - long.Parse(tok[1]));
                        lblKetqua.Text = ans.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Syntax Error";
                    lblKetqua.Visible = false;
                }
            }

            //Xử lý dấu 'x'
            else if(c == '×')
            {
                check = false;
                int idx = tmp.IndexOf('×');
                tmp = tmp.Remove(idx, 1);
                string[] tok = tmp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(tok[0] + " " + tok[1]);
                try
                {
                    if (tok[0].Contains('.') || tok[1].Contains('.'))
                    {

                        ans = (double.Parse(tok[0]) * double.Parse(tok[1]));
                        lblKetqua.Text = ans.ToString();
                    }
                    else
                    {
                        ans = (long.Parse(tok[0]) * long.Parse(tok[1]));
                        lblKetqua.Text = ans.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Syntax Error";
                    lblKetqua.Visible = false;
                }
            }

            //Xử lý dấu '/'
            else if(c == '÷')
            {
                check = false;
                int idx = tmp.IndexOf('÷');
                tmp = tmp.Remove(idx, 1);
                string[] tok = tmp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(tok[0] + " " + tok[1]);
                try
                {
                    if (double.Parse(tok[1]) == 0)
                    {
                        int r = int.Parse(tok[0]) / int.Parse(tok[1]);
                    }
                    ans = (double.Parse(tok[0]) / double.Parse(tok[1]));
                    lblKetqua.Text = ans.ToString();
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Math Error";
                    lblKetqua.Visible = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lblKetqua.ResetText();
                    lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                    lblOutput.Text = "Syntax Error";
                    lblKetqua.Visible = false;
                }
            }
            #endregion

            if (check)
            {
                lblKetqua.ResetText();
                lblOutput.TextAlign = ContentAlignment.MiddleCenter;
                lblOutput.Text = "Syntax Error";
                lblKetqua.Visible = false;
            }

        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += " + ";
            string tmp = lblOutput.Text;
            for (int i = tmp.Length - 3; i >= 0; i--)
            {
                if (tmp[i] == '+' || tmp[i] == '—' || tmp[i] == '×' || tmp[i] == '÷') return;
                if (char.IsDigit(tmp[i])) break;
            }
            int cnt = lblOutput.Text.Count(c => c == '+' || c == '—' || c == '×' || c == '÷');
            if (!lblOutput.Text[0].Equals(' ') && cnt > 1)
            {
                btnEqual.PerformClick();
                if (!lblOutput.Text.Equals("Syntax Error") && !lblOutput.Text.Equals("Math Error")) lblOutput.Text = ans.ToString() + " + "; 
            }
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += " — ";
            string tmp = lblOutput.Text;
            for (int i = tmp.Length - 3; i >= 0; i--)
            {
                if (tmp[i] == '+' || tmp[i] == '—' || tmp[i] == '×' || tmp[i] == '÷') return;
                if (char.IsDigit(tmp[i])) break;
            }
            int cnt = lblOutput.Text.Count(c => c == '+' || c == '—' || c == '×' || c == '÷');
            if (!lblOutput.Text[0].Equals(' ') && cnt > 1)
            {
                btnEqual.PerformClick();
                if (!lblOutput.Text.Equals("Syntax Error") && !lblOutput.Text.Equals("Math Error")) lblOutput.Text = ans.ToString() + " — ";
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += " × ";
            string tmp = lblOutput.Text;
            for (int i = tmp.Length - 3; i >= 0; i--)
            {
                if (tmp[i] == '+' || tmp[i] == '—' || tmp[i] == '×' || tmp[i] == '÷') return;
                if (char.IsDigit(tmp[i])) break;
            }
            int cnt = lblOutput.Text.Count(c => c == '+' || c == '—' || c == '×' || c == '÷');
            if (!lblOutput.Text[0].Equals(' ') && cnt > 1)
            {
                btnEqual.PerformClick();
                if (!lblOutput.Text.Equals("Syntax Error") && !lblOutput.Text.Equals("Math Error")) lblOutput.Text = ans.ToString() + " × ";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += ".";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += " ÷ ";
            string tmp = lblOutput.Text;
            for (int i = tmp.Length - 3; i >= 0; i--)
            {
                if (tmp[i] == '+' || tmp[i] == '—' || tmp[i] == '×' || tmp[i] == '÷') return;
                if (char.IsDigit(tmp[i])) break;
            }
            int cnt = lblOutput.Text.Count(c => c == '+' || c == '—' || c == '×' || c == '÷');
            if (!lblOutput.Text[0].Equals(' ') && cnt > 1)
            {
                btnEqual.PerformClick();
                if (!lblOutput.Text.Equals("Syntax Error") && !lblOutput.Text.Equals("Math Error")) lblOutput.Text = ans.ToString() + " ÷ ";
            }
        }

        private void btnSoAm_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "-";
        }

        private void btnPhanso_Click(object sender, EventArgs e)
        {
            if (lblKetqua.Text.Contains('/'))
            {
                string tmp = lblKetqua.Text;
                string[] tok = tmp.Split('/');
                double kq = double.Parse(tok[0]) / double.Parse(tok[1]);
                lblKetqua.Text = kq.ToString();
            }
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "/";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "%";
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "√";
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "π";
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "ln";
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "sin";
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "cos";
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "tan";
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text != "Syntax Error" && lblOutput.Text != "Math Error")
                lblOutput.Text += "e";
        }
    }
}
