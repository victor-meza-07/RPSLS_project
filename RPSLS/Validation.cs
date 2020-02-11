using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Validation
    {
        public Validation()
        {

        }



        
        /// <summary>
        /// returns a non negative integer that is in range of an array size
        /// </summary>
        /// <example>
        /// string[4] if 0 > userchoice > 3 weill return invalid
        /// </example>
        /// <param name="totalChoices"></param>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public virtual int uservalidation(int totalChoices, string userInput)
        {
            int userchoiceasInt = 0;
            bool validinput = false;
            while (validinput == false)
            {
                try { userchoiceasInt = Convert.ToInt32(userInput); validinput = true; }
                catch (FormatException)
                {
                    Console.WriteLine("User Choice was incorrect please input a valid option");
                    userInput = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("User Choice was incorrect please input a valid option");
                    userInput = Console.ReadLine();
                }
                if ((0 > userchoiceasInt) || (userchoiceasInt > totalChoices - 1))
                {
                    validinput = false;
                    Console.WriteLine("User Choice was incorrect please input a valid option");
                    userInput = Console.ReadLine();
                }
            }
            return userchoiceasInt;
        }

        /// <summary>
        /// will return a non negative integer in range of list passed in
        /// </summary>
        /// <example>
        /// if userchoice > list.count, will ask for a new choice, else will return userchoice.
        /// </example>
        /// <param name="listTobeValidatedFrom"></param>
        /// <returns></returns>
        public virtual int uservalidation(System.Collections.IList listTobeValidatedFrom, string userInput) 
        {
            int validateduserchoice = 0;
            bool hasvalidated = false;

            while (hasvalidated == false) 
            {
                try { validateduserchoice = Convert.ToInt32(userInput); hasvalidated = true; }
                catch (FormatException) 
                {
                    Console.WriteLine("User Choice was incorrect please input a valid option");
                    userInput = Console.ReadLine();
                }
                catch (OverflowException) 
                {
                    Console.WriteLine("User Choice was incorrect please input a valid option");
                    userInput = Console.ReadLine();
                }
                if ((0 > validateduserchoice)||( validateduserchoice > (listTobeValidatedFrom.Count - 1))) 
                {
                    hasvalidated = false;
                    Console.WriteLine("User Choice was incorrect please input a valid option");
                    userInput = Console.ReadLine();
                }
            }

            return validateduserchoice;
        }
        /// <summary>
        /// checks if input is contained in list
        /// </summary>
        /// <param name="listofChoices"></param>
        /// <param name="input"></param>
        /// <returns>bool</returns>
        public virtual bool CharuservalidationContained(System.Collections.IList listofChoices, string input) 
        {
            bool validated = false;

            foreach (object a in listofChoices) 
            {
                if (input != a.ToString()) 
                {
                    validated = false;
                }
                if (input == a.ToString()) 
                {
                    validated = true;
                }
            }


            return validated;
        }
    }
}
