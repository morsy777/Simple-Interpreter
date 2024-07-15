using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathExpressionEvaluator
{
    // this class that contains the operand and operation operand.
    public class MathExpression
    {
        public double LeftSideOperand {get; set;}
        public double RightSideOperand {get; set; }
        public MathOperation Operation { get; set; }


    }
}
