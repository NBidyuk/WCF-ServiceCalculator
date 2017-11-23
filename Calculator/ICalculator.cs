using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Calculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Sum(double a, double b);

        [OperationContract]
        double Minus(double a, double b);

        [OperationContract]
        double Mult(double a, double b);

        [OperationContract]
        double Div(double a, double b);

        [OperationContract]
        double SquareRoot(double a);

        [OperationContract]
        double Percent(double a, double b);
    }

    [ServiceContract (Name ="IEngineerCalculator")]
    public interface IEngineerCalculator
    {
        [OperationContract]
         double Sin(double a);

        [OperationContract]
         double Cos(double a);

        [OperationContract]
         double Square(double a);

        [OperationContract]
        double Triple(double a);

        [OperationContract]
        double Pow(double a, double b);

        [OperationContract]
         double Tan(double a);

        [OperationContract]
        long Factorial(int n);

        [OperationContract]
        double Log(double n);
    }
}
