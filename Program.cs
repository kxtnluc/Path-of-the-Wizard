using System;
using System.Windows.Input;

namespace Programing_test //notes: Have MAX HP, Limit Potions
{
    class Wizard
    {
        public string name;
        public string damageSpell01;
        public string damageType01;
        public int spellSlots;
        public float xp;
        public static int AC;
        public static int HP;

        public static int Count;

        public Wizard(string _name, string _damageSpell01, string _damageType01)
        {
            name = _name;
            damageSpell01 = _damageSpell01;
            damageType01 = _damageType01;

            spellSlots = 6;
            xp = 0;
            AC = 12;
            HP = 16;

            Count++;
        }

        public void castSpell()
        {
            if (spellSlots > 0)
            {
                Console.WriteLine(name + " casts " +damageSpell01);
                spellSlots--;
                xp += 3f;

                

            }else{
                Console.WriteLine(name+" is out of spell slots!");
            }
        }
        public void meditate(){
            Console.WriteLine(name + " meditates to regain 3 spell slots!");
            Console.ReadKey();
            spellSlots += 3;
        }

        public void wizardTurnDescription()
        {

            Console.WriteLine("Its "+name+ "'s turn!\nYou can cast spells, meditate, or drink a potion.");
            Console.WriteLine("\nHP = "+HP+ " AC = " +AC);
            Console.WriteLine("You have " +spellSlots+ " spell slots remaining.");
            Console.WriteLine("To Cast a spell, type '1', to meditate type '2' to drink a potion, type '3'");
        }
    }

    class Goblin
    {
        public int gobHP;
        public int gobAC;

        public static int damageTakenStat = 0;

        public Goblin(int _gobHP, int _gobAC)
        {
            gobHP = _gobHP;
            gobAC = _gobAC;
            
        }

        public void clubAttack()
        {
            Console.WriteLine("The goblin takes a mean club attack against you!");
            Random gobAttackRoll = new Random();
            Random gobDamageRoll = new Random();
            int gobAttack = gobAttackRoll.Next(1,21);
            Console.WriteLine("The goblin rolled a "+gobAttack);
            Console.ReadKey();

            if(gobAttack >= Wizard.AC){
                int gobDamage = gobDamageRoll.Next(1,5);
                if(gobAttack == 20)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("CRITICAL HIT!!!");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        gobDamage *= 2;
                    }
                Console.WriteLine("The goblin hits you for "+gobDamage+ " Hitpoints!");
                Wizard.HP -= gobDamage;
                damageTakenStat += gobDamage;
            }else{
                Console.WriteLine("The goblin missed its attack!");
            }
            if (Wizard.HP <= 0)
            {
                Console.WriteLine(Wizard.HP);
                Console.WriteLine("You Died!!!!!");
                Console.WriteLine("Stats:\nDamage Taken: " +damageTakenStat);
                Console.WriteLine("Press <Enter> To Exit. Better luck next time");
                Console.ReadKey();
                Environment.Exit(0);
            }
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int damageTotalStat = 0;
            int pCount = 3;
            int missedSpellStat = 0;

            Console.Title = "Gamer Momento";

            Console.WriteLine("What is the name of your valient Wizard?");

            string playerName = Console.ReadLine();

            Console.WriteLine("What is the name of your favorite Damage Dealing Spell?");

            string damageSpell01 = Console.ReadLine();

            Console.WriteLine("Good! What damage type does that attack deal?");

            string damageType01 = Console.ReadLine();
            
            Wizard wiz01 = new Wizard(playerName, damageSpell01, damageType01);

            Console.WriteLine("While traveling the roads of Samongloras, "+playerName+ " spots a small rock recently overturned.\nhe goes to inspect the rocks, suspecting some stroke of luck to hit somehow.\nmaybe he thinks he will get some sort of magic item? who knows, he inspects it when suddenly\nThree goblins attack! they spring up on poor "+playerName+" before he can even react! how dreadful really");
            Console.ReadKey();
            Console.WriteLine("\nBattle!!!");

            Goblin gob01 = new Goblin(10, 11);
            Goblin gob02 = new Goblin(10, 8);
            Goblin gob03 = new Goblin(12, 10);
            //Start of Combat Loop
            Console.WriteLine("The Goblins take quick strikes at the poor wizard!");

            Console.ReadKey();
            while (gob01.gobHP > 0 || gob02.gobHP > 0 || gob03.gobHP > 0)
            {
                if(gob01.gobHP > 0)
                {
                    gob01.clubAttack();
                }else{Console.WriteLine("Goblin 1 is Dead!");}

                Console.ReadKey();

                if(gob02.gobHP > 0)
                {
                    gob02.clubAttack();
                }else{Console.WriteLine("Goblin 2 is Dead!");}

                Console.ReadKey();

                if(gob03.gobHP > 0)
                {
                    gob03.clubAttack();
                }else{Console.WriteLine("Goblin 3 is Dead!");}

                Console.ReadKey();

                wiz01.wizardTurnDescription();

                int Key;

                Key = Convert.ToInt32(Console.ReadLine());

                switch (Key){
                    case 1:
                        Console.WriteLine("Who do you target?");
                        if(gob01.gobHP > 0){
                            Console.WriteLine("Goblin 1 HP: "+gob01.gobHP);
                        }
                        if(gob02.gobHP > 0){
                            Console.WriteLine("Goblin 2 HP: "+gob02.gobHP);
                        }
                        if (gob03.gobHP > 0){
                            Console.WriteLine("Goblin 3 HP: "+gob03.gobHP);
                        }

                    int target = Convert.ToInt32(Console.ReadLine());

                    Random attackRoll = new Random();

                   

                    switch (target){ 
                        case 1:
                            Console.WriteLine("You Attack Goblin 1!");
                            Console.ReadKey();
                            wiz01.castSpell();
                            //attack and damage roll start
                            
                            int attack = attackRoll.Next(1,21);
                            Console.WriteLine(playerName+ " rolled a "+attack);
                            int damage;
                            Console.ReadKey();
                            

                            if(attack >= gob01.gobAC && wiz01.spellSlots >-1)
                            {
                                
                                Random damageRoll = new Random();
                                damage = damageRoll.Next(1, 13);
                                if(attack == 20)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("CRITICAL HIT!!!");
                                    Console.ReadKey();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    damage *= 2;
                                }
                                Console.WriteLine("You Delt "+ damage + " "+ damageType01 + " damage");
                                damageTotalStat += damage;
                                gob01.gobHP -= damage;
                                
                                Console.ReadKey();
                            }else
                            {
                                Console.WriteLine(playerName + " Missed His Spell Attack!");
                                missedSpellStat++;
                                Console.ReadKey();
                            }
                            
                            //attack and damge roll end
                            break;

                        case 2:
                            Console.WriteLine("You Attack Goblin 2!");
                            Console.ReadKey();
                            wiz01.castSpell();
                            //attack and damage roll start
                            
                            attack = attackRoll.Next(1,21);
                            Console.WriteLine(playerName+ " rolled a "+attack);
                            Console.ReadKey();

                            if(attack >= gob02.gobAC && wiz01.spellSlots >-1)
                            {
                                
                                Random damageRoll = new Random();
                                damage = damageRoll.Next(1, 13);
                                
                                if(attack == 20)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("CRITICAL HIT!!!");
                                    Console.ReadKey();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    damage *= 2;
                                }
                                damageTotalStat += damage;
                                gob02.gobHP -= damage;
                                
                                Console.WriteLine("You Delt "+ damage +" "+ damageType01 + " damage");

                                
                                Console.ReadKey();
                            }else
                            {
                                Console.WriteLine(playerName + " Missed His Spell Attack!");
                                missedSpellStat++;
                                Console.ReadKey();
                            }
                            
                            //attack and damge roll end
                            break;
                        case 3:
                            Console.WriteLine("You Attack Goblin 3!");
                            Console.ReadKey();
                            wiz01.castSpell();
                            //attack and damage roll start
                           
                            attack = attackRoll.Next(1,21);
                            Console.WriteLine(playerName+ " rolled a "+attack);
                            Console.ReadKey();
                            

                            if(attack >= gob03.gobAC && wiz01.spellSlots >-1)
                            {
                                
                                Random damageRoll = new Random();
                                damage = damageRoll.Next(1, 13);
                                if(attack == 20)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("CRITICAL HIT!!!");
                                    Console.ReadKey();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    damage *= 2;
                                }
                                Console.WriteLine("You Delt "+ damage + " "+ damageType01 + " damage");
                                damageTotalStat += damage;
                                gob03.gobHP -= damage;
                                
                                Console.ReadKey();
                            }else
                            {
                                Console.WriteLine(playerName + " Missed His Spell Attack!");
                                missedSpellStat++;
                                Console.ReadKey();
                            }
                            
                            //attack and damge roll end
                            break;
                            default:
                            Console.WriteLine("You Missed The Key, And the Goblin!! (wow)");
                            break;
                    }
                   break;
                case 2:
                    Console.WriteLine("You Meditate!");
                    wiz01.meditate();
                    break;
                case 3:
                     

                     if(pCount > 0){
                        Wizard.HP += 10;
                        Console.WriteLine("You Drink A Potion!\nYou Regain 10HP");
                        Console.ReadKey();
                        pCount--;
                        Console.WriteLine("You have "+pCount+ " Potions Left");
                        Console.ReadKey();
                     }else{Console.WriteLine("You ran out of Potions!");
                     Console.ReadKey();
                     }
                     
                     if(Wizard.HP > 16) //Max Hp 
                     {
                         Wizard.HP = 16;
                     }
                     break;
                default:
                    Console.WriteLine("You Take A Defensive Stance!");
                    break;
                }

            }
            

             //End of Combat Loop

            Console.ReadKey();

            Console.WriteLine(playerName+" beat the goblins! maybe he wont go snooping around in the dangerous wilds of Samongloras, but oh well.");

            Console.ReadKey();

            Console.WriteLine("Stats:\nDamage Delt: "+damageTotalStat+ "\nDamage Taken: " +Goblin.damageTakenStat);
            Console.WriteLine("Missed Spells: " +missedSpellStat);

            Console.WriteLine("\n\nPress <Enter> to Exit");

            Console.ReadKey(); //wait before closing
              
        }
    }
}
//dotnet publish -r win10-x64 -p:PublishSingleFile=true
// Use this command to publish into single EXE