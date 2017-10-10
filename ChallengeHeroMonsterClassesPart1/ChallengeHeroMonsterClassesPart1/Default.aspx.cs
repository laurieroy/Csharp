using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            hero.Name = "Hero";
            hero.Health = 100;
            hero.DamageMaximum = 20;
            hero.AttackBonus = false; 

            infoLabel.Text = String.Format("Greetings, O Formidable {0}! Your starting " +
            "health is {1}, your attack bonus is {2}, and the most damage you can " +
            "inflict is {3}. Your people are counting on you! Good luck. <br/>",
            hero.Name, hero.Health, hero.AttackBonus, hero.DamageMaximum);

            Character monster = new Character();
            monster.Name = "Monster";
            monster.Health = 100;
            monster.DamageMaximum = 17;
            monster.AttackBonus = true; 

            infoLabel.Text += String.Format("<br/>Greetings, O despicable {0}! " +
             "Your starting health is {1}, your attack bonus is {2}, and your defense " +
             "bonus is {3}. I'm sure you have a reason for fighting--Good luck.<br/><br/>  ", monster.Name, monster.Health.ToString(), monster.AttackBonus.ToString(), monster.DamageMaximum.ToString());

            Dice dice = new Dice();
            int round = 0;

            // Give bonus attack if either is true.
            int damage = (hero.AttackBonus == true) ? hero.PerformAttack(dice) : monster.PerformAttack(dice);
            if (hero.AttackBonus == true) monster.Defend(damage);
            else hero.Defend(damage);

            displayRoundHeader(round, hero, monster);

            while (hero.Health > 0 && monster.Health > 0)
            {
                round++;
                // monster attacks first
                damage = monster.PerformAttack(dice);
                hero.Defend(damage);

                // hero attacks second
                damage = hero.PerformAttack(dice);
                monster.Defend(damage);
               
                displayRoundHeader(round, hero, monster);
                
            }
            displayResult(monster, hero, round);
        }

        private void displayResult(Character character1, Character character2, int round) 
        {
            int Round = round;
            displayRoundHeader(round, character1, character2);
            if (character1.Health <= 0 && character2.Health <= 0)
                infoLabel.Text += "Both fighters have succumbed to their wounds. Neither is victorious. <br/>";

            //huh! you can do a ternary inside a ternary! test for health < 0, return the other's name as winner
            string winner = (character2.Health <= 0) ? character1.Name : (character1.Health <= 0) ? character2.Name:character1.Name;
            string loser = (winner == character1.Name) ? character2.Name : character1.Name;

            infoLabel.Text += String.Format("After {0} excruciating rounds, {1} has emerged victorious over {2}, " +
                "who fought to the death. <br/>", Round, winner, loser);
        }

        private void displayRoundHeader(int round, Character character1, Character character2) 
        {
            resultLabel.Text += String.Format("Round {0}: ", round);
            CurrentStats(character1);
            CurrentStats(character2);
        }

        private void CurrentStats(Character character)
        {
            resultLabel.Text += String.Format("Name: {0} Health: {1}.<br/>", character.Name, character.Health);
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; } 
        
        public int PerformAttack(Dice dice) // gets instance of Dice
        {
            dice.Sides = this.DamageMaximum;
            dice.Roll(); // sets Sides prop

            // int attack_damage = random.Next(dice); // then call Roll method
            // use return valueas ret val of attack method also

            return dice.Roll();
        }
        
        public void Defend(int attack_damage)
        // - deducts the damage from this Character's health
        {
            this.Health -= attack_damage;
        }
    }
    
    class Dice
    {
        public int Sides { get; set; } // the max is supposed to be the char DamageMaximum
        Random random = new Random();

        public int Roll(    )
        {
            return random.Next(this.Sides);
        }
    }
    
}