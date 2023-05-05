using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace demoProject2
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            // integer variable
            int _variableOne;
            Console.WriteLine("Enter the value for the variableOne");
            _variableOne = int.Parse(Console.ReadLine());
            Console.WriteLine("The variable we inserted is: " + _variableOne);
            
            // decimal variable
            decimal _variableTwo;
            _variableTwo = 25.75m;// to assign values to a decimal variable, we need to
                                  // use m/M at the end of any values
            Console.WriteLine("the const decimal variable value is: " + _variableTwo);

            // Now we are going to ask the user to enter values for decimal variable
            Console.WriteLine("Enter values for variable two/ Decimal variable"); 
            _variableTwo= decimal.Parse(Console.ReadLine()); // this will convert the String
                                                             // value we are reading from the interface to 
                                                             // decimal point values
            Console.WriteLine("The value we inserted for decimal variable is: "+_variableTwo);

            // double variable
            double _variableThree;
            _variableThree = 789.856;
            Console.WriteLine("The double variable we fixed is: " + _variableThree);
            Console.WriteLine("Enter values for double variable/ variable three");
            _variableThree = double.Parse(Console.ReadLine());
            Console.WriteLine("The values you inserted is: " + _variableThree);
            
            // string variable
            string _variableFour;
            _variableFour = "THis is the value for a String variable";
            Console.WriteLine("The string value is: " + _variableFour);
            Console.WriteLine("Enter any values for your String variable");
            _variableFour = Console.ReadLine();
            Console.WriteLine("The string value is: " + _variableFour);
            
            /** Arithmatic Operations **/

            /*
            double num1, num2, total;
            // Lets take input from the user and perform all the arithmatic operations
            // On those two values
            // Addition
            Console.WriteLine("Enter value for Number 1");
            num1= double.Parse(Console.ReadLine()); // this will read first number

            Console.WriteLine("Enter the value for Number 2");
            num2= double.Parse(Console.ReadLine());

            total = num1+ num2;
            Console.WriteLine("The total of the two variables are: "+ total);
            // substraction
            total = num1 - num2;
            Console.WriteLine("The substraction result of two given variables is: " + total);

            // multiplication
            total = num1 * num2;
            Console.WriteLine("THe multiplication of two given variable is: " + total);

            // division 
            total = num1 / num2;
            Console.WriteLine("The division of the two given varibale is: " + total);

            // modulus: the reminder of a division program: percentage sign is the modulus sign
            total = num1 % num2;
            Console.WriteLine("The modulus of the two given variables is: "+ total);
            */
            // Now, I am going to input value integer variable but accidentally put
            // String value. To handle that exception we are going to use exception handling
            // logical interface
            /*
            int num1=25;
            try {
                Console.WriteLine("Enter the value for integer number");
                num1= int.Parse(Console.ReadLine());
                Console.WriteLine("THe values you inserted: "+ num1);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                    }
            */

            // Decision Structure - if-(else if)-else structure

            // Grading System Calculation Program
            /*
            decimal marks;
            Console.WriteLine("Enter Marks for the student");
            marks = decimal.Parse(Console.ReadLine()); 
            try {
                // grading calculation
                if (marks >= 90 && marks <= 100)
                {
                    Console.WriteLine("The Grade is: A");
                }
                else if (marks >= 80 && marks < 90)
                    Console.WriteLine("The Grade is: B");
                else if (marks >= 70 && marks < 80)
                    Console.WriteLine("The Grade is: C");
                else if (marks >= 60 && marks < 70)
                    Console.WriteLine("The Grade is: D");
                else
                    Console.WriteLine("The Student failed");
            }
            catch ( Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Redo the program with switch-case statement

            int choice = (int) marks / 10; // as we are trying to assing the division result
                                           // in a integer varaible, we need to cast the division
                                           // result, which will only take the int part of the
                                           // the division result

            switch (choice)
            {
                case 10:
                case 9:
                    Console.WriteLine("Grade is: A");
                    break;
                case 8:
                    Console.WriteLine("Grade is: B");
                    break;
                case 7:
                    Console.WriteLine("Grade is C");
                    break;
                case 6:
                    Console.WriteLine("Grade is D");
                    break;

                default:
                    Console.WriteLine("Grade is: F");
                    break;

            }
            */
            // Loop: The reason of having a loop in program is to reuse/reexecute the 
            // same code block several times/ more than one

            // IN this program we are going to print the following series (fibonacci)
            // 0 1 1 2 3 5 8 13 21 ....
            // We need first two numbers to be declared
            int num1 = 0, num2 = 1, counter = 1, steps, temp;

            // while loop
            // we need to ask user to enter how many steps they want to see
            Console.WriteLine("Enter the number of steps user wants to see in fibonacci series");
            steps = int.Parse(Console.ReadLine());

            Console.Write(num1.ToString() + " "); // Write() method will never go to the new line, it 
                                        // will print everything in the same line
            Console.Write(num2.ToString() + " ");
            while(counter <= steps)
            {
                temp = num1 + num2; // we need a temporary varibale to swap the values from 
                                    // previous variables to the new one
                Console.Write(temp.ToString() + " ");
                num1= num2;
                num2= temp;
                counter++;
            }
            Console.Write('\n');
            Console.WriteLine("The output from the For loop");
            // For Loop
            num1= 0;
            num2= 1;
            Console.Write(num1.ToString() + " "); // Write() method will never go to the new line, it 
                                                  // will print everything in the same line
            Console.Write(num2.ToString() + " ");
            for (int i=0; i<steps; i++)
            {
                temp = num1 + num2; // we need a temporary varibale to swap the values from 
                                    // previous variables to the new one
                Console.Write(temp.ToString() + " ");
                num1 = num2;
                num2 = temp;
                counter++;
            }

        }
    }
}