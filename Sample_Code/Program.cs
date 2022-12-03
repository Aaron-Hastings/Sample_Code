using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;

namespace Sample_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables
            // structure and enumerations types are value types 
            // (simple types) char, bool, and all numerics are structs and therefore value types
            // tuples are a simple struct and therefore also value types
            // built-in object and string types as well as arrays, classes, delegates, and interfaces are reference types
            // note, records can be either value or reference types 


            char varOne = 'a'; // The char keyword is an alias in the C# language for the type System.Char
                               // You can always use the char keyword. To use Char you need a using System
            string varTwo = "Words Words";  // The string keyword is an alias in the C# language for the type System.String
                                            // You can always use the string keyword. To use String you need a using System
            String varThree = "Words Words Words";

            int varFour = 42;
            float varFive = 1.0F;       // float (the C# alias for System.Single) float is 32-bit floating binary point type
            double varSix = 42.0D;      // double (the C# alias for System.Double) double is a 64-bit floating binary point type
            decimal varSeven = 42.0M;   // decimal (the C# alias for System.Decimal) is a floating decimal point type

            // Float - 7 digits (32 bit) precision
            // Double - 15 - 16 digits(64 bit) precision
            // Decimal - 28 - 29 significant digits(128 bit) precision ~ 20x slower computations

            int? varEight = null; // Allows value types to be nullable
            var varNine = 3;  // Let's C# decide the type

            (int, float, float) varTen = (1, 2f, 3f);  // Define a tuple with three elements, field name is Item#
            (double real, double imag) varEleven = (1.0, 0.0); // Define a tuple with three elements and explicity field names


            // Screen Output
            Console.Write(1);       // No carriage return
            Console.Write(2);       // No space between previous write
            Console.Write(" " + 3); // Add a space before next write
            Console.WriteLine();    // Just a carriage return
            Console.WriteLine("Sample Console Ouptut");

            Console.WriteLine(varOne);
            Console.WriteLine(varTwo);
            Console.WriteLine(varThree);
            Console.WriteLine(varFour);
            Console.WriteLine(varFive);
            Console.WriteLine(varSix);
            Console.WriteLine(varSeven);

            Console.WriteLine();
            Console.WriteLine(varThree.ToString()); // Explicit type conversion
            Console.WriteLine(varThree);            // .ToString() is implied
            Console.WriteLine();

            Console.WriteLine("Tuple with three elements: " + varTen.Item1 + ", " + varTen.Item2 + ", " + varTen.Item3);
            Console.WriteLine("Tuple with real and imaginary values: " + varEleven.real + " + i" + varEleven.imag);
            Console.WriteLine();


            // Constants
            // Cannot be changed
            const double pi = 3.14;
            const float e = 2.71F;
            const int numberOfMonths = 12;


            // Type Casting
            string convertedValue1 = 'a'.ToString(); // Char to String
            Console.WriteLine("Conversion from Char to String, 'a': " + convertedValue1.GetType());

            string convertedValue2 = 42.ToString();
            Console.WriteLine("Conversion from Numeric to String, 42: " + 42.ToString());
            Console.WriteLine("Conversion from Numeric to String, 42: " + 42); // ToString() is implied

            var varTwelve = 9;
            Console.WriteLine("Original type for 9: " + varTwelve.GetType());
            double convertedValue3 = (double)varTwelve;
            Console.WriteLine("Conversion from int to double, 9: " + convertedValue3.GetType());
            Console.WriteLine();


            // Command Line User Input
            Console.Write("Enter user input: ");
            String input = Console.ReadLine();
            Console.WriteLine("You typed " + input);
            Console.WriteLine();


            // String Literals
            // String literals are of type string and can be written in three forms: quoted, raw, and verbatim.
            //
            // Quoted literals are the basic form
            string quotedStringLiteral1 = "This is a string";
            //
            // Raw string literals can contain arbitrary text without requiring escape sequences.
            // Raw string literals are enclosed in a minimum of three double quotation marks (""")
            string rawStringLiteral1 =  """
                                        This is a multi-line
                                             string literal with the second line indented.
                                        """;
            // There must be more start/stop double quotes then are contiguous inside the literal (This example uses 5 since there are 4 inside)
            string rawStringLiteral2 = """""
                                        This raw string literal has four """", count them: """" four!
                                        embedded quote characters in a sequence. That's why it starts and ends
                                        with five double quotes.
                                        
                                        You could extend this example with as many embedded quotes as needed for your text.
                                        """"";
            //
            // Verbatim string literals start with @ and are also enclosed in double quotation marks.
            // The advantage of verbatim strings is that escape sequences aren't processed.
            string verbatimStringLiteral1 = @"c:\Docs\Source\a.txt";  // rather than "c:\\Docs\\Source\\a.txt"
            //
            // UTF-8 string literals are sometimes used for compatibility with the web. They are not really strings(?)
            ReadOnlySpan<byte> utfStringLiteral = "Words words words"u8;
            Console.WriteLine("String Literal Examples:");
            Console.WriteLine();
            Console.WriteLine(quotedStringLiteral1);
            Console.WriteLine();
            Console.WriteLine(rawStringLiteral1);
            Console.WriteLine();
            Console.WriteLine(rawStringLiteral2);
            Console.WriteLine();
            Console.WriteLine();

            // String Interpolation
            // The $ special character identifies a string literal as an interpolated string.
            // An interpolated string is a string literal that might contain interpolation expressions.
            // When an interpolated string is resolved to a result string, items with interpolation expressions
            // are replaced by the string representations of the expression results.
            string name = "Mark";
            var date = DateTime.Now;
            Console.WriteLine("String Interpolation Example:"); 
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            Console.WriteLine();


            // String Methods





            // If Statements

            // Swith Statements

            // While Loops

            // For Loops

            // Arrays

            // Foreach Loops

            // Methods

            // Method Overloading

            // Params Keyword

            // Exception Handling

            // Conditional Operator



            // Multi-Dimensional Arrays

            // Classes

            // Objects

            // Constructors

            // Static

            // Overloaded Constructors

            // Inheritance

            // Abstract Classes

            // Array of Objects

            // Objects as Arguments

            // Method Overriding

            // ToString Method

            // Polymorphism

            // Interfaces

            // Lists

            // Lists of Objects

            // Getters and Setters

            // Auto Implemented Properties

            // Enums

            // Generics

            // Multi-Threading


            // Closing Out Console
            Console.WriteLine("Press any key to close window.");
            Console.ReadKey(); // Wait for user before ending program



        }
    }
}