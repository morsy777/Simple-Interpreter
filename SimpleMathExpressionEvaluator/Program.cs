namespace SimpleMathExpressionEvaluator
{
    /*
     * # Compiler consist of 5 phases the first 2 phases is Lexical and Syntax analysis. (Exist in Geeks for Geeks)
     * # Lexical Analysis Phase : in this phase the compiler take the text (code) and scaning it to obtain the tokens.
     * # Syntax Analysis Phase  : in this phase the compiler checks the token that received from Lexical phase and checks
     *                            whether they conform to the grammar of the programming language after that the compiler
     *                            make parsing for this toking to obtain the output, the output in this phase AST (Abstract Syntax Tree) 
     *                            that consist of group of tokens after parsing that will in the next compiler phases to obtain the final result.
     *                            
     * # The compiler traverses your code char by char to obtains the tokens. -> (5+6) the 5,6 and + are called tokens.
     * # All compilers ignores the white space except the languages that dependent on the indentation like python and F#.
     * 
     */
    public class Program
    {
        static void Main(string[] args)
        {
            App.Run(args);
            
        }
    }
}