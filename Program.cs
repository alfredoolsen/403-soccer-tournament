using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// PROGRAM DESCRIPTION
// This Program will ask the user how many teams will be in the tournament and then it will take down their team and the
//team score. It will then rank each team in order of best to worst (1 being the best), and display the results.

namespace OlympicSoccerTournament
{

    // Creating the classes:game class is extra

    public class Program
    {
        public class game
        {

        }
        public class team
        {
            public string name;
            public int wins;
            public int loss;
        }

        public class soccerteam : team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int points;
            public game soccerGame;

            // this soccerteam contructor is needed so that it can be used  
            public soccerteam(int points, string name)
            {
                this.points = points;
                this.name = name;
            }
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {

            //initialize variables
            int NumberofTeams = 0;
            int teamPoints = 0;
            bool bteam = false;
            bool bteamPoints = false;

            while (!bteam || NumberofTeams == 0)
            {

                try
                {
                    Console.WriteLine("How many Teams?");


                    //console.read means that whatever the user input, it is being taken in and read as a string, even if it's a number
                    // this is converting the input into an int because all inputs are strings initially

                    NumberofTeams = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    bteam = true;

                    if (NumberofTeams == 0)
                    {
                        Console.WriteLine("Zero is not a valid entry \n");
                    }
                }
                catch (Exception) { Console.WriteLine("\nEnter a valid number please. \n"); }

            }
            // creating an empty list that holds soccer teams and starts out empty
            List<soccerteam> SoccerList = new List<soccerteam>();


            for (int i = 1; i <= NumberofTeams; i++)
            {


                
                    Console.WriteLine("Enter Team " + i + "'s name:");
                // setting it false so that it can re enter the while loop
                    bteamPoints = false;
                    string userInput = Console.ReadLine();// reads user input
                    Console.WriteLine();
                    string teamName = UppercaseFirst(userInput); // teamName = "United states"

                //if teampoints entered is anything but the points you will need to enter a vaild number again

               
                    while (!bteamPoints)
                    {

                        try
                        {
                            Console.WriteLine("Enter " + teamName + "'s points:");
                           
                            teamPoints = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            bteamPoints = true;

                            
               
                        }
                        catch (Exception) { Console.WriteLine("\nEnter a valid number please. \n"); }

                    }
                    
                    
                    Console.WriteLine();


                    // creating an instance of soccerteam class
                    soccerteam team = new soccerteam(teamPoints, teamName);

                    //adds teams to the soccer list
                    SoccerList.Add(team);
                
            }

            //sorting the teams (the second part can be named anything
            List<soccerteam> sortedTeams = SoccerList.OrderByDescending(team => team.points).ToList();

            //displaying the top of the table
            Console.WriteLine("Here is the sorted list: \n");

            Console.WriteLine("Position\t\t" + "Name\t\t\t\t" + "Points");

            //needs string so that padding method can be used
            String dummy = "";

            //padright is the method that can do something for the dummy string object
            //found the number of padding because ots's the same number as number of characters in each name
            Console.WriteLine(dummy.PadRight(8, '-') + "\t\t" + dummy.PadRight(4, '-') + "\t\t\t\t" + dummy.PadRight(6, '-'));


            int iCount = 1;
            foreach (soccerteam team in sortedTeams)
            {
                Console.Write(iCount + "\t\t\t" + team.name + "\t\t\t\t" + team.points + "\n");
                iCount++;
            }






            // leaves the program running until a key is pressed
            Console.ReadKey();

        }
    }
}
