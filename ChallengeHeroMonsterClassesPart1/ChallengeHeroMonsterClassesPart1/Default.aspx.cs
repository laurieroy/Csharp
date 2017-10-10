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
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            // create instance of each. set attr to whatever you want
            hero.Name = "Hero";
            hero.Health = 100;
            hero.DamageMaximum = 20;
            hero.AttackBonus = 2; // he's doing bool so false
            
            //  Iinit stats currently don't show. Assuming will pull the following out of page load and into a loop.
            heroLabel.Text = String.Format("Greetings, O Formidable {0}! Your starting " +
            "health is {1}, your attack bonus is {2}, and the most damage you can " +
            "inflict is {3}. Your people are counting on you! Good luck.",
            hero.Name, hero.Health, hero.AttackBonus, hero.DamageMaximum);

            Character monster = new Character();
            monster.Name = "Monster";
            monster.Health = 100;
            monster.DamageMaximum = 10;
            monster.AttackBonus = 5; // again he has bool so set to true
            
            monsterLabel.Text = String.Format("Greetings, O despicable {0}! " +
             "Your starting health is {1}, your attack bonus is {2}, and your defense " +
             "bonus is {3}. ", monster.Name, monster.Health.ToString(), monster.AttackBonus.ToString(), monster.DamageMaximum.ToString());

            // displayBattleHeader();  // Separate out into rounds**
            //    monster.Health = performAttack();

            // hero attacks first
            int damage = hero.PerformAttack();
            monster.Defend(damage);

            // monster's turn to attack
            damage = monster.PerformAttack();
            hero.Defend(damage);
            
            DisplayStatsHero(hero);
            DisplayStatsMonster(monster);
        }
        
        private void DisplayStatsHero(Character character)
        {
            heroLabel.Text = CurrentStats(character);
        }

        private void DisplayStatsMonster(Character character)
        {
            monsterLabel.Text = CurrentStats(character);
        }

        private string CurrentStats(Character character)
        {
            return String.Format("Name: {0} Health: {1} Attack bonus: {2}, Defense Bonus: {3}. ",
                character.Name, character.Health, character.AttackBonus, character.DamageMaximum);
        }


    }
    /*
            private void displayRoundHeader()
            {
                throw new NotImplementedException();
            }

            private void displayBattleHeader() // ********
            {
                throw new NotImplementedException();
            }
            */

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public int AttackBonus { get; set; } // he set his as a bool

        public int PerformAttack() 
        {
            Random random = new Random();

            int attack_damage = random.Next(this.DamageMaximum);
            return attack_damage;
        }
        
        public void Defend(int attack_damage)
        // - deducts the damage from this Character's health
        {
            this.Health -= attack_damage;
        }
    }
}