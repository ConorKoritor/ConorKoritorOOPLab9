using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ConorKoritorOOPLab9
{
    internal class Player
    {

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private Position PreferredPosition { get; set; }
        private DateTime DateOfBirth { get; set; }
        private int Age {  get; set; }

        public Player(string firstName, string lastName, DateTime dateOfBirth, Position prefferedpos)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PreferredPosition = prefferedpos;
            //Checks Age by subtracting the DOB year from the current year
            Age = (int)DateTime.Now.Year - (int)DateOfBirth.Year;

            //because someone doesn't go up in age until their birthday this checks if their birthday has passed yet
            if(DateTime.Now.Month < DateOfBirth.Month)
            {
                Age--;
            }
            else if(DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day)
            {
                Age--;
            }
        }

        public override string ToString() 
        {
            return $"{FirstName} {LastName} ({Age}) {PreferredPosition} ";
        }

    }
}
