using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /************************* PLEASE COMMENT OUT THE OTHER 3 SECTIONS TO CHECK CODE *****************************************************
             * For this one, I provided two answers, one in line with his reccommending a for loop, and the charArray */
            //Reverse your name
            string name = "Bob Tabor";
            // In his case the result would be:
            // robaT boB

            string nameB = new string(name.ToCharArray().Reverse().ToArray()); 
            /*     
                for (int j = name.Length - 1; j >= 0; j--) // more in line with what he is probably thinking, but creates new string each time
                {
                    nameB += name[j]; //+ k;
                }
            */
            resultLabel.Text = nameB;

/*
            //2. Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke
            string result = "";
            string[] namesSplit = names.Split(',');
           
            string[] namesRev = new string[namesSplit.Length];
            
            for (int i = namesSplit.Length - 1, j=0; i >=0; i--, j++)
            {
                result = namesSplit[i];
                namesRev[j] = result;
            }
            string nameString = String.Join(",", namesRev);
            resultLabel.Text = nameString;
            

            //3. Use the sequence to create ascii art:  ************* FOR THIS ONE, PLZ LEAVE #2 UNCOMMENTED TO USE THE string result and namesSplit, can comment out the for loop ********
            // ***** 14 chars in total, 5 on each side
            // *****leia, (5,5) i have 5,6 for both
            //*****han 5,6 (i have 6,7
            // **Chewbacca*** //2,3
            int leftPad = 0;
            int rightPad = 0;
            string[] asciiArt = new string[4];
            int charCount = 0;

            for (int i = 0; i < namesSplit.Length; i++)
            {
                charCount = (namesSplit[i]).Length;
                if ((14 - charCount) % 2 != 0)
                {
                    leftPad = (14 - charCount) / 2; //round down
                    rightPad = ((14 - charCount) / 2) + 1; //round up
                }
                else
                {
                    leftPad = (14 - charCount) / 2;
                    rightPad = leftPad;
                }

                asciiArt[i] = namesSplit[i].PadLeft(leftPad + charCount, '*').PadRight(leftPad + charCount + rightPad, '*');
                result += asciiArt[i] + "<br/>";
            }
            resultLabel.Text = result;

            //4. Solve this puzzle:
            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNTRY";

            // Once you fix it with the string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.
            // use a for statement for first 3
            // remove (remove-me)
            string value = "remove-me";
            int index = puzzle.IndexOf(value);
            puzzle = puzzle.Remove(index, value.Length);
            puzzle = puzzle.ToLower();
            puzzle = puzzle.Replace('z', 't');
            resultLabel.Text = char.ToUpper(puzzle[0]) + puzzle.Substring(1) + '.';
           */


        }
    }
}