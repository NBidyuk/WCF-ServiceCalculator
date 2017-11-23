using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Calculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Calculator : ICalculator, IEngineerCalculator
    {
        public double Sum(double a, double b)
        {
            return a + b;
        }


        public double Minus(double a, double b)
        {
            return a - b;
        }

        public double Mult(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            if (b == 0)
                throw new System.DivideByZeroException();
            return a / b;

        }

        public double SquareRoot(double a)
        {
            return Math.Sqrt(a);
        }


        public double Percent(double a, double b)
        {
            return b*a/100;
        }

        public double Sin(double a)
        {
            return Math.Sin(a);
        }


        public double Cos(double a)
        {
            return Math.Cos(a);
        }

            public double Square(double a)
        {
            return Math.Pow(a, 2);
        }


        public double Pow(double a, double b)
        {
            return Math.Pow(a, b);
        }
        
            public double Tan(double a)
        {
            return Math.Tan(a);
        }


        public long Factorial(int n)
        {

            if (n == 0) return 1;
            else
                return n * Factorial(n - 1);
        }

        public double Triple(double a)
        {
            return Math.Pow(a, 3);
        }

      
        public double Log(double n)
        {
            return Math.Log(n);
        }

    }
   }



   


