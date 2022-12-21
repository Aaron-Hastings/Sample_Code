using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

// The following youtube links provide good tutorials
// https://www.youtube.com/@BroCodez = very succinct videos that cover a wide range of c# programming
// https://www.youtube.com/@Dani_Krossing = not as many examples, but longer videos

namespace Sample_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // structure and enumerations types are value types 
            // (simple types) char, bool, and all numerics are structs and therefore value types
            // tuples are a simple struct and therefore also value types
            // built-in object and string types as well as arrays, classes, delegates, and interfaces are reference types
            // note, records can be either value or reference types 
            char varOne = 'a'; // The char keyword is an alias in the C# language for the type System.Char
                               // You can always use the char keyword. To use Char you need a using System
            string varTwo = "Words Words";  // The string keyword is an alias in the C# language for the type System.String
                                            // You can always use the string keyword. To use String you need a using System
            System.String varThree = "Words Words Words";

            int varFour = 42;
            float varFive = 1.0F;       // float (the C# alias for System.Single) float is 32-bit floating binary point type
            double varSix = 42.0D;      // double (the C# alias for System.Double) double is a 64-bit floating binary point type
            decimal varSeven = 42.0M;   // decimal (the C# alias for System.Decimal) is a floating decimal point type

            // Float - 7 digits (32 bit) precision
            // Double - 15 - 16 digits(64 bit) precision
            // Decimal - 28 - 29 significant digits(128 bit) precision ~ 20x slower computations

            int? varEight = null; // Allows value types to be nullable
            var varNine = 3;  // Let's C# decide the type

            // Tuple
            // Tuples can be used to store a finite sequence of homogeneous or heterogeneous data of fixed sizes and can
            // be used to return multiple values from a method
            (int, float, float) varTen = (1, 2f, 3f);  // Define a tuple with three elements, field name is Item#
            (double real, double imag) varEleven = (1.0, 0.0); // Define a tuple with three elements and explicity field names


            // Screen Output
            //------------------------------------------------------------------------------------------------------------------------------------------------------
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
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // Only be applied to the primitive data types(such as ints, floats, chars, and booleans) and strings
            // Cannot be changed
            // Must be assigned a value at compile
            const double pi = 3.14;
            const float e = 2.71F;
            const int numberOfMonths = 12;


            // Type Casting
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // Can be done either implied or explicit
            //
            // Implied example --  Can be done if information is not lost
            int varTwelve = 3;
            double varThirteen = varTwelve; // No information lost
            // int varFourteen = varThirteen; // This throws an error since converting from double to int could lose information
            // float varFourteen = varThirteen; // This throws an error since converting from double to int could lose information

            // Explicit examples -- can be done whether information is lost or not
            int varFourteen = 9;
            var convertedValue1 = Convert.ToDouble(varFourteen); // Most explicit method, using the Convert class
            Console.WriteLine("Conversion from int to double, 9: " + convertedValue1.GetType()); // double
            var convertedValue2 = (double)varFourteen; // Using alias to Convert method(?)
            Console.WriteLine("Conversion from int to double, 9: " + convertedValue2.GetType()); // double
            Console.WriteLine();

            string convertedValue3 = 'a'.ToString(); // Char to String
            Console.WriteLine("Conversion from Char to String, 'a': " + convertedValue3.GetType());

            string convertedValue4 = 42.ToString();
            Console.WriteLine("Conversion from Numeric to String, 42: " + 42.ToString());
            Console.WriteLine("Conversion from Numeric to String, 42: " + 42); // ToString() is implied


            // Command Line User Input
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            Console.Write("Enter user input: ");
            string input = Console.ReadLine();
            Console.WriteLine("You typed " + input);
            Console.WriteLine();


            // String Literals
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // String literals are of type string and can be written in three forms: quoted, raw, and verbatim.
            //
            // Quoted literals are the basic form
            string quotedStringLiteral1 = "This is a string";
            //
            // Raw string literals can contain arbitrary text without requiring escape sequences.
            // Raw string literals are enclosed in a minimum of three double quotation marks (""")
            string rawStringLiteral1 = """
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
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // The $ special character identifies a string literal as an interpolated string.
            // An interpolated string is a string literal that might contain interpolation expressions.
            // When an interpolated string is resolved to a result string, items with interpolation expressions
            // are replaced by the string representations of the expression results.
            string name = "Mark";
            var date = DateTime.Now;
            Console.WriteLine("String Interpolation Example:");
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            Console.WriteLine();


            // String Operators and Methods
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // A String object is an immutable sequential collection of System.Char objects that represent a string; a System.Char object corresponds to a UTF-16 code unit.
            string varFifteen = "123456";
            int stringLength = varFifteen.Length; // Property of the string object
            string varSixteen = "12345";
            var varSeventeen = varFifteen; // Implicit operator
            Console.WriteLine($"String \"{varFifteen}\" equals String \"{varSixteen}\"?: {System.String.Equals(varFifteen, varSixteen)}"); // static method. performs ordinal comparison.
            Console.WriteLine($"String \"{varFifteen}\" equals String \"{varSixteen}\"?: {varFifteen == varSixteen}"); // equality operator calls Equals method

            // Some useful methods (no examples written, just listed)
            // Clone - Returns a reference to this instance of String.
            // Compare - Compares two specified String objects and returns an integer that indicates their relative position in the sort order.
            // Concat - Concatenates one or more instances of String, or the String representations of the values of one or more instances of Object.
            // Contains - Returns a value indicating whether a specified character occurs within this string.
            // Copy - Creates a new instance of String with the same value as a specified String.
            // EndsWith - Creates a new instance of String with the same value as a specified String.
            // Equals - Determines whether two String objects have the same value.
            // Format - Converts the value of objects to strings based on the formats specified and inserts them into another string.
            //          e.g. string s = String.Format("It is now {0:d} at {0:t}", DateTime.Now);
            // IndexOf - Reports the zero-based index of the first occurrence of a specified Unicode character or string within this instance. The method returns -1 if the character or string is not found in this instance
            // IndexOfAny - Reports the index of the first occurrence in this instance of any character in a specified array of Unicode characters. The method returns -1 if the characters in the array are not found in this instance.
            // Insert - Returns a new string in which a specified string is inserted at a specified index position in this instance.
            // Intern - Retrieves the system's reference to the specified String.
            // IsNullOrEmpty - Indicates whether the specified string is null or an empty string ("").
            // IsNullOrWhiteSpace - Indicates whether a specified string is null, empty, or consists only of white-space characters.
            // Join - Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.
            // LastIndexOf - Reports the zero-based index position of the last occurrence of a specified Unicode character or string within this instance. The method returns -1 if the character or string is not found in this instance.
            // PadLeft - Returns a new string of a specified length in which the beginning of the current string is padded with spaces or with a specified Unicode character.
            // PadRight - Returns a new string of a specified length in which the end of the current string is padded with spaces or with a specified Unicode character.
            // Remove - Returns a new string in which a specified number of characters from the current string are deleted.
            // Replace - Returns a new string in which all occurrences of a specified Unicode character or String in the current string are replaced with another specified Unicode character or String.
            // Split - Returns a string array that contains the substrings in this instance that are delimited by elements of a specified string or Unicode character array.
            // StartsWith - Determines whether this string instance starts with the specified character.
            // ToLower - Returns a copy of this string converted to lowercase.
            // ToUpper - Returns a copy of this string converted to uppercase.
            // Trim - Returns a new string in which all leading and trailing occurrences of a set of specified characters from the current string are removed.
            // TrimEnd - Removes all the trailing occurrences of a set of characters specified in an array from the current string.
            // TrimStart - Removes all the leading occurrences of a set of characters specified in an array from the current string.


            // If Statements
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            int value = 10;
            if (value < 0)
            {
                Console.WriteLine("value is negative");
            }
            else if (value == 0)
            {
                Console.WriteLine("value is zero");
            }
            else
            {
                Console.WriteLine("value is positive");
            }

            if (value >= 1 && value <= 10)
            {
                Console.WriteLine("The value has a 10% chance of occuring. This is a conceit");
            }
            Console.WriteLine();

            string strValue = "Carrot";
            if (System.String.IsNullOrEmpty(strValue))
            {
                Console.WriteLine("String is empty");
            }
            else if (System.String.Equals("Karet", strValue))
            {
                Console.WriteLine("String is a Karet");
            }
            else if (strValue == "Carrot")
            {
                Console.WriteLine("String is a Carrot");
            }
            else
            {
                Console.WriteLine("String is something else");
            }
            Console.WriteLine();

            // Switch Statements
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            string choice = "Pineapple";
            switch (choice)
            {
                case "Apple":
                    Console.WriteLine("Fruit is an apple");
                    break;
                case "Banana":
                    Console.WriteLine("Fruit is a banana");
                    break;
                case "Pineapple":
                    Console.WriteLine("Fruit is a pineapple");
                    break;
                default:
                    Console.WriteLine("Maybe its a vegetable!");
                    break;
            }
            Console.WriteLine();

            // While Loops
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            string usrName = "";
            while (usrName == "")
            {
                Console.Write("Enter your name: ");
                usrName = Console.ReadLine();
            }
            Console.WriteLine($"Hello {usrName}");


            // For Loops
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            for (int i = 0; i <= 10; i += 3)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();


            // Arrays
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // Can't change size but can change values
            int[] dates = { 1, 2, 3, 4, };
            string[] cars = { "Ford", "Toyota", "Honda" };
            cars[1] = "BMW";
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }
            Console.WriteLine();


            // Foreach Loops
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();

            // Exception Handling
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            double x;
            double y;
            double result;

            bool invalidInput = true;
            while( invalidInput )
            {
                invalidInput = false;
                try
                {
                    Console.Write("Enter Number 1: ");
                    x = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Number 2: ");
                    y = Convert.ToInt32(Console.ReadLine());

                    result = x / y;

                    Console.WriteLine("result: " + result);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Entries must be numbers.");
                    invalidInput = true;
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Denominator cannot be 0");
                    invalidInput = true;
                }
            }

            // Conditional Operator
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            double temp = 40;
            string message = (temp > 70) ? "It's warm" : "It's cold";
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();


            // Multi-Dimensional Arrays
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            string[,] parkingLot = { { "F150", "Mustang", "Escape" }, 
                                     { "Prius", "Camry", "Rav4" } };

            parkingLot[0, 2] = "Explorer";
            foreach (string parkedCar in parkingLot)
            {
                Console.WriteLine(parkedCar);
            }
            Console.WriteLine();
            for (int i = 0; i < parkingLot.GetLength(0); i++)
            {
                for (int j = 0; j < parkingLot.GetLength(1); j++)
                {
                    Console.Write(parkingLot[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // This bit makes calls to code outside Main
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            CallSomeStuffMethod();


            // Closing Out Console
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine("\n\n");
            Console.WriteLine("Press any key to close window.");
            Console.ReadKey(); // Wait for user before ending program


        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        // Outside Main function, but inside class definition
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Methods
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //     <Access Specifier> <Return Type> <Method Name>(Parameter list)
        //     {
        //         Body
        //     }
        //
        // Access Specifiers: public, private, internal (default), protected, protected internal -- see https://1drv.ms/u/s!AjGqgsPFws85heI_oazaJnoTW6Ulag?e=ufVyqb
        //                  : static -- belongs to the class, not the object
        // 
        // public: The type or member can be accessed by any other code in the same assembly or another assembly that references it.The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
        // private: The type or member can be accessed only by code in the same class or struct.
        // protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
        // internal: The type or member can be accessed by any code in the same assembly, but not from another assembly.In other words, internal types or members can be accessed from code that is part of the same compilation.
        // protected internal: The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
        // private protected: The type or member can be accessed by types derived from the class that are declared within its containing assembly.
        //
        // Interfaces declared directly within a namespace can be public or internal and, just like classes and structs, interfaces default to internal access. Interface
        // members are public by default because the purpose of an interface is to enable other types to access a class or struct. Interface member declarations may
        // include any access modifier. This is most useful for static methods to provide common implementations needed by all implementors of a class. Enumeration
        // members are always public, and no access modifiers can be applied. Delegates behave like classes and structs.By default, they have internal access when
        // declared directly within a namespace, and private access when nested.
        // REF: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
        static void CallSomeStuffMethod()
        {
            // Call simple method and overloaded versions
            SimpleMethod();
            SimpleMethod("Fred");
            bool ofAge = SimpleMethod("Fred", 19);
            Console.WriteLine("You can drink: " + ofAge);
            Console.WriteLine();

            // Call method that uses params keyword
            double total = AddNumbers(2.3, 4.5, 3.7);
            Console.WriteLine($"Total is {total}");
            Console.WriteLine();

            // Create a human object
            Human human1 = new Human();
            human1.Name = "Rick";
            human1.age = 65;
            human1.Eat();
            human1.Sleep();

            // Create some car objects
            Console.WriteLine("The number of cars before creating any cars");
            Car.PrintNumerofCars();
            Car car1 = new Car("Ford", "F150", 2017, "Grey", 55);
            car1.PrintVehicleDetails();
            Car car2 = new Car("Ford", "F150", 2017, "Grey", 55);
            car2.PrintVehicleDetails();
            Car car3 = new Car(); // Uses overloaded constructor
            car3.PrintVehicleDetails();
            Console.WriteLine($"Number of Cars: {Car.numberOfCars}");
            Console.WriteLine("The number of cars after creating some cars");
            // Alternate (static method option)
            Car.PrintNumerofCars();
        }

        static void SimpleMethod()
        {
            // This method is accessed through the class (not an object of the class), does not return anything and takes no input parameters. By default it is "internal"
            Console.WriteLine("This is a simple method");
            Console.WriteLine();
        }
        private double AnotherSimpleMethod(double a, double b)
        {
            return a + b;
        }


        // Method OverLOADING
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        static void SimpleMethod(string name)
        {
            Console.WriteLine("This is an overloaded simple method");
            Console.WriteLine($"Your name is {name}");
            Console.WriteLine();
        }
        static bool SimpleMethod(string name, int age)
        {
            Console.WriteLine("This is another overloaded simple method");
            Console.WriteLine($"Your name is {name}");
            Console.WriteLine($"You are {age} old");
            Console.WriteLine();

            bool ofAge = false;
            if (age >= 21)
            {
                ofAge = true;
            }
            return ofAge;
        }


        // Params Keyword
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        // By using the params keyword, you can specify a method parameter that takes a variable number of arguments. The parameter type must be a single-dimensional array.
        // No additional parameters are permitted after the params keyword in a method declaration, and only one params keyword is permitted in a method declaration.
        static double AddNumbers(params double[] numbers)
        {
            double sum = 0;
            foreach (double number in numbers) 
            { 
                sum+= number;
            }
            return sum;
        }
        static double SEL(double dt, params double[] levelSamples)
        {
            /// double dt = time resolution in seconds
            /// levelSamples = SPL samples in dB(A)
            double sum = 0;
            double time = 0;
            foreach (double levelSample in levelSamples)
            {
                sum += Math.Pow(10.0, levelSample / 10);
                time += dt; // Sum up the time in seconds 
            }
            return 10.0 * Math.Log10(sum / time); 
        }


        // Classes and Objects
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        class Human
        {
            // Very simple class (and not secure)
            public string? Name; // not secure, but good for example
            public int age; // not secure, but good for example

            public void Eat()  // not secure, but good for example
            {
                Console.WriteLine(Name + " is eating");
            }
            public void Sleep()  // not secure, but good for example
            {
                Console.WriteLine(Name + " is sleeping");
            }
        }
        class Car
        {
            // Fields - what an object has
            string make;
            string model;
            int year;
            string color;
            private int speed; // This one will only be accessible by the getter / setter
            public static int numberOfCars = 0; // Belongs to class not an instance

            // Constructor
            public Car(string make, string model, int year, string color, int userSpeed)
            {
                this.make = make;
                this.model = model;
                this.year = year;
                this.color = color;
                Speed = userSpeed; // Becomes value in the setter
                numberOfCars++;
            }
            // Overlaoded Constructor
            public Car() // Default Case
            {
                this.make = "ACME";
                this.model = "SEDAN";
                this.year = 1970;
                this.color = "WHITE";
                Speed = 0;// Becomes value in the setter
                numberOfCars++;
            }

            // Property = combine aspects of both fields and methods (share name with a field)
            public int Speed // Define property assciated with speed (same name, except uses a capital letter to start)
            {
                // getters & setters = add security to fields by encapsulation
                //                    They're accessors found within properties
                get { return speed; }
                set { speed = value; } // value keyword = defines the value being assigned by the set (parameter)
            }

            // Methods - what an object can do
            public void PrintVehicleDetails()
            {
                Console.WriteLine();
                Console.WriteLine($"The {color}, {year}, {make} {model} is traveling at {speed} mph.");
                Console.WriteLine();
            }
            static public void PrintNumerofCars()
            { 
                // Note, to get the counting correct, this relise on a static field
                Console.WriteLine($"Number of Cars: {Car.numberOfCars}");
            }
        }



        // Static
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        // Can be applied to:
        // Class -- in which case the class cannot be instantiated
        // Field -- in which case belongs to class, not object
        // Method -- in which case belongs to class, not object

        // Overloaded Constructors
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Inheritance
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Abstract Classes
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        // The C# programming language provides support for both virtual and abstract methods, each of which has distinct advantages.
        // You use virtual methods to implement late binding, whereas abstract methods enable you to force the subclasses of the type
        // to have the method explicitly overridden. 

        // Array of Objects
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Objects as Arguments
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Method OverRIDING
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // ToString Method
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Polymorphism
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Interfaces
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Lists
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Lists of Objects
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Auto Implemented Properties
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Enums
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Generics
        //------------------------------------------------------------------------------------------------------------------------------------------------------

        // Multi-Threading
        //------------------------------------------------------------------------------------------------------------------------------------------------------

    }

}