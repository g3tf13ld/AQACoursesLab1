using System;
using System.Linq;
using System.Threading.Channels;

/*
    Задание 1
    .Net Основы и синтаксис
    Проинициализировать переменные всех типов.
    Написать примеры использования всех операторов из лекции.
*/

namespace ConsoleApp1
{
    class Program
    {
        delegate int myIntDelegate(int a, int b);
        public class MyClass
        {
            private string name;

            private string GetName()
            {
                return name;
            }
        }
        
        static void Main(string[] args)
        {
            bool myBool = true;
            
            // 1-byte type --> 0 .. 255.
            byte myByte = 255;
            // Signed byte -128 .. 127 .
            sbyte mySbyte = -128;
            
            char myChar1 = 'h';      
            char myChar2 = '\u00A3';
            char myChar3 = '\xA3';
            
            // 16-byte type.
            decimal myDecimal = 0.213897461m;
            // 8-byte.
            double myDouble = 12345.678e-1;   
            // 4-byte.
            float myFloat1 = 11.11f;   
            float myFloat2 = 123.45E-3F;

            // 32-bit.
            int myInt = -1034524;  
            // Binary from of number.
            int myIntBinary = 0b10011101;  
            // Hexadecimal form of number.
            int myIntHexadecimal = 0x1ADEF;
            // 32-bit unsigned int.
            uint myUint = 1452701111;
            // 64-bit.
            long myLong = -2311111111141111113;
            ulong myUlong = 2341111115345136413; 
            // 2-byte. 
            short myShort = -32768;
            ushort myUshort = 182;

            object myObj = true;
            myObj = -123;
            myObj = 'f';
            myObj = "Text";
            
            string myString = "Hello\v \t \"everybody\"!129*(&^$@){} \\ ";
            myString = "";
            
            dynamic myDynamic = 112m;
            myDynamic = myObj;
            myDynamic = "1723";
            /*
                Differences between "var" and "dynamic": 
                    for a var-variable the type is determined with initialization and can't be changed in the future
                    the type of dynamic-variable is (surprise) dynamic and changes with changing data type in it.
            
                Differences between "object" and "dynamic": 
                    work with an object-variable require exciplit manual type conversion
                    but CLR do it automatically with dynamic-variable .
            */

            // Arithmetic operations.
            for (int i = 0; i < 10; i++)
            {
                myByte *= 2;
            }
            
            // Comparison.
            myBool = myInt == myByte;
            
            // Logical operation.
            myBool = !myBool & true;
            myBool |= myBool.GetType().Equals(myDynamic.GetType());
            
            // Type checking operators and cast expressions.
            if (myDynamic is MyClass)
            {
                Console.WriteLine("Variable myDynamic is string");
            }
            else
            {
                Console.WriteLine("Variable myDynamic isn't string");
            }

            // Cast.
            myDecimal = (decimal) myDouble;

            myDynamic = myObj as MyClass;
            if (myDynamic == null)
            {
                Console.WriteLine("Can't cast myObj to MyClass");
            }
            else
            {
                Console.WriteLine("myObj can be casted to MyClass");
            }
            
            // Composite string formatting.
            Console.WriteLine("myInt = {1}, \vmyDynamic = {0}", myDynamic, myInt);
            
            // String interpolation.
            myString = $"myInt = {myInt}";
            
            // Monkey-symbol "@".
            String @string = @"D:\Books\";
            myString = @string + "Scrum-Guide.pdf";

            // Lambda-expressions.
            myIntDelegate intDelegate = (a, b) =>
            {
                a %= b;
                Console.WriteLine("Delegate WriteLine");
                return a * b + 2 * a;
            };
            
            // Query expressions.
            int[] myIntArray = {0, 1, 3, 6, -2, 1234};
            var myQueryResult1 = myIntArray.Select(i => (double) i % 10);
            var myQueryResult2 = from i in myIntArray where i % 2 == 0 select i;
            
            // Bitwise and shifting operations.
            Console.WriteLine("Bitwise");
            myIntBinary = 0b00011101;
            Console.WriteLine("myIntBinary = {0}", myIntBinary);
            myIntBinary = ~myIntBinary;
            Console.WriteLine("myIntBinary = {0} (inverted)", myIntBinary);
            myIntBinary = myIntBinary << 2;
            Console.WriteLine("myIntBinary = {0} (left-shifted by 2 bits)", myIntBinary);
            myIntBinary = myIntBinary >> 1;
            Console.WriteLine("myIntBinary = {0} (right-shifted by a bit)", myIntBinary);
            
            // Switch-case expression.
            switch (myInt)
            {
                case 0:
                    Console.WriteLine("myInt == 0");
                    break;
                case 3:
                    Console.WriteLine("myInt == 3");
                    myInt *= 3;
                    break;
                default:
                    Console.WriteLine("myInt != 0\vmyInt !=3");
                    break;
            }
            
            // For, while and do-while cycle-expressions.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("For cycle: iteration {0}", i + 1);
            }

            int j = 0;
            while (j < 10)
            {
                Console.WriteLine("While cycle: iteration {0}", j + 1); 
                j++;
            }

            j = 0;
            do
            {
                Console.WriteLine("Do-while cycle: iteration {0}", j + 1);
                j++;
            } while (j < 10);
        }
    }
}