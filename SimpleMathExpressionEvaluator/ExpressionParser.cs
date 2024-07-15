using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathExpressionEvaluator
{
    // this class for obtain tokens from the source code and I define it as static jsut for simplecity
    /*
     * # All Possible Cases:
     *   5 + 6
     *   5+6
     *   5+ 6
     *   5 +6
     *   55555           +         6
     *   -5-6
     *   10--5
     *   5 - 2
     *   10 mod 3
     *   10 % 3
     *   5 ^ 2
     *   5 pow 2
     *   sin 90
     *   cos            90
     *   
     *   # We will terate the minus as special case because it may be sign
     *   for variable or operation. (-5-6)
     *   
     *   # We have four possibilites for the tokens that exist in input
     *     may be digit,leter, math sympols(+*^%), minus or white space.
     *   
     */
    public static class ExpressionParser
    {
        public const string mathSymbols = "+*^/%";
        public static MathExpression Parse(string input) // The return type of this method is MathExpression, because we wanna retun (leftSideOperand,RightSideOperand,Operation) that exist on MathExpression class after assigned value for them.
        {
            input = input.Trim();
            var expr = new MathExpression(); // This obj to access the properties that exist at MathExpression Class.
            string token = "";               // If input (123+ 456) token must be 123 else store token in the LeftSideOperand property.
            bool leftSideInitialized = false;

            for (int i = 0; i < input.Length; i++) // This loop to obtain tokens and we will store it in AST.
            {
                var currentChar = input[i];

                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                    if (leftSideInitialized && i == input.Length - 1 ) // We assign value for RightSideOperand when the char IsDigit only and the LeftOperandSide is initialized and we arrive to last number in the input.
                    {
                        expr.RightSideOperand = double.Parse(token);
                    }

                }
                else if (char.IsLetter(currentChar))
                {
                    leftSideInitialized = true; // Because in this cases (Tan 90,Cos 90,Sin 90) there is no left side, but there is right side only.
                    token += currentChar; 
                }
                else if (mathSymbols.Contains(currentChar)) // Test Case: (5+6), (5 + 6) or any other case
                {
                    if (!leftSideInitialized) // We msut ensure that the leftSideOperand is not intialized before assign value, because if the leftSide once intialized the token is reset (empty) and therfore exception will occur.
                    {
                        expr.LeftSideOperand = double.Parse(token);                  // We make parsing because the token is string and property is double.    
                        leftSideInitialized = true;
                    }
                    expr.Operation = ParseMathOperation(currentChar.ToString()); // This line to assign value for Operation property that exist in MathExpression class and the data type of this property is (MathOperation) enum type.
                    token = "";                                                  // U must reset the token if the char is not Digit

                }
                else if (currentChar == '-' && i > 0) // Test Case: (5-6) & (5--6), I define (i > 0) condition, because if minus in index 0 that's mean negative number like (-5) .
                {
                    if (expr.Operation == MathOperation.None) 
                    {
                        expr.Operation = MathOperation.Subtraction;
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else 
                    {
                        token += currentChar;
                    }
                }
                else if (currentChar == ' ') // Test Cases : (5 + 6),(5      + 6). if there is space after space the compiler will ignore them.
                {
                    if (!leftSideInitialized) // If the compiler found space and leftSide operand is not initialized that's mean the token conatains leftSide operand.
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else if (expr.Operation == MathOperation.None) // If the compiler found space and leftSide operand is initialized and Operation property is = None, then the token contain operation operand.
                    {
                        expr.Operation = ParseMathOperation(token); // To parse token (char type) into MathOperation (enum type) to correctly assigned token to Operation property, because the type of Operation property (isMathOperation) enum.
                        token = "";

                    }
                }
                else // In this case (-5-6) there is no condition of the previous will be true, so I write else statement
                {
                    token += currentChar;
                }
            }



            return expr; // Will return MathExpression (leftSideOperand,RightSideOperand,Operation) after assigned value for them.

        }

        private static MathOperation ParseMathOperation(string token) // The type of this method from MathOperation enum because the aim from this method is to return the Operation from that enum. 
        {
            switch (token.ToLower())
            {
                case "+":
                    return MathOperation.Addition; // If token = (+) we return addition attribute form MathOperation enum and we use enum because the property that accept this value has (MathOperaion) enum as data type.
                case "*":
                    return MathOperation.Multiplication;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "/":
                    return MathOperation.Division;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;
            }
        }
    }
}
