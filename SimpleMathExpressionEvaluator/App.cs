using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * I set a public access modefiers for the class app and Run function to be
 * avaliable outside the SimpleMathExpressionEvaluator namespace.
 * 
 * (10 + 5) -> 10 is left side operand, + is operation and 5 is right side operand.
 */

namespace SimpleMathExpressionEvaluator
{
    public static class App
    {
        public static void Run(string[] args)
        {
            while (true)
            {
                Console.Write("Please Enter Math Expression: ");
                var input = Console.ReadLine(); // After enter Sin,Cos,Tan and Pow u must make space before enter the numbers. -> (sin 90) is true, but (sin90) is not true.
                var expr = ExpressionParser.Parse(input); // This function will return (leftSideOperand,RightSideOperand,Operation) because the return type of Purse() is MathExpression class that containts (leftSideOperand,RightSideOperand,Operation).
                Console.WriteLine($"The left side operand  = {expr.LeftSideOperand}, The operation = {expr.Operation}, The right side operand = {expr.RightSideOperand}");
                Console.WriteLine($"{input} = {EvaluateExpression(expr)}");


            }

        }

        private static object EvaluateExpression(MathExpression expr) // (MathExpression expr) because the expr in Run() is variable contain the implementaion of Parse() and the return type of Parse() is MathExpression.
        {
            if (expr.Operation == MathOperation.Addition)
                return expr.LeftSideOperand + expr.RightSideOperand;
            else if (expr.Operation == MathOperation.Subtraction)
                return expr.LeftSideOperand - expr.RightSideOperand;
            else if (expr.Operation == MathOperation.Multiplication)
                return expr.LeftSideOperand * expr.RightSideOperand;
            else if (expr.Operation == MathOperation.Division)
                return expr.LeftSideOperand / expr.RightSideOperand;
            else if (expr.Operation == MathOperation.Modulus)
                return expr.LeftSideOperand % expr.RightSideOperand;
            else if (expr.Operation == MathOperation.Power)
                return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);
            else if (expr.Operation == MathOperation.Sin)
                return Math.Sin(expr.RightSideOperand);    // Because in Tan,Sin and Cos there is no leftSideOperand.
            else if (expr.Operation == MathOperation.Cos)
                return Math.Cos(expr.RightSideOperand);
            else if (expr.Operation == MathOperation.Tan)
                return Math.Tan(expr.RightSideOperand);

            return 0;

             
        }
    }
}
