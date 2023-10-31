using System.Security.Cryptography.X509Certificates;

namespace MazeGame
{

    public class Item
    {
        public string name;
        public string type;
    }

    public class Weapon : Item
    {
        public int damage = 0;
        public int magicDamage = 0;
        public int requiredStr = 0;
        public int requiredInt = 0;
    }

    public class Pot : Item
    {
        public string potType;
        public int level = 1;
        
        public int UseHealthPot(Random rnd)
        {
            return rnd.Next(1 * level, 10 * level);
        }
        public int UseManaPot(Random rnd)
        {
            return rnd.Next(5 * level, 20 * level);
        }
    }
    
    public class Player
    {
        public string name;
        #region Stats
        public int health = 100;
        public int maxHealth = 100;
        public int mana = 100;
        public int maxMana = 100;
        public int Strenght = 5;
        public int Intelligence = 5;
        #endregion
        public int level = 1;
        public int xp;
        public Weapon equipedWeapon = null;
        #region Lists
        public List<Item> inventory = new List<Item>();
        public List<Weapon> weapons = new List<Weapon>();
        public List<Pot> pots = new List<Pot>();
        public List<Weapon> bossLootTable = new List<Weapon>();
        public List<Weapon> normalLootTableWeapon = new List<Weapon>();
        public List<Pot> normalLootTablePot = new List<Pot>();
        #endregion
    }

    public class Enemy
    {
        public string name;
        public string type;
        public int health;
        public int defHealth;
        public int damage;
        public int resistanceToPhysical;
        public int resistanceToMagic;
        public int xpToGive;
    }

    public class Room
    {
        public string name;
        public string roomType;
        public int dangerLevel;
    }

    public class Skill
    {
        public string name;
        public int magicDamage;
        public int damage;
        public int manaToUse;
    }

    public class MazeGame
    {
        static void Main(string[] args)
        {
            bool DebugMode = true;
            Random rnd = new Random();
            List<Room> mazeRooms = new List<Room>();
            List<Enemy> enemyTypes = new List<Enemy>();
            List<Enemy> bossTypes = new List<Enemy>();
            int roomCount = rnd.Next(5, 10);
            Player player = new Player();
            Console.WriteLine("Please write your name: ");
            player.name = Console.ReadLine();



            #region Items
            Weapon ShortSword = new Weapon();
            ShortSword.name = "Short Sword";
            ShortSword.type = "Weapon";
            ShortSword.requiredStr = 5;
            ShortSword.damage = 10;

            Weapon GreatSword = new Weapon();
            GreatSword.name = "Great Sword";
            GreatSword.type = "Weapon";
            GreatSword.requiredStr = 10;
            GreatSword.damage = 15;

            Weapon BasicStaff = new Weapon();
            BasicStaff.name = "Basic Staff";
            BasicStaff.type = "Weapon";
            BasicStaff.requiredInt = 5;
            BasicStaff.magicDamage = 10;

            Weapon WizardStaff = new Weapon();
            WizardStaff.name = "Wizard Staff";
            WizardStaff.type = "Weapon";
            WizardStaff.requiredInt = 10;
            WizardStaff.magicDamage = 15;

            Weapon FlamingSword = new Weapon();
            FlamingSword.name = "Flaming Sword";
            FlamingSword.type = "Weapon";
            FlamingSword.requiredStr = 10;
            FlamingSword.requiredInt = 10;
            FlamingSword.magicDamage = 20;
            FlamingSword.damage = 15;

            Pot HealthPotLevel1 = new Pot();
            HealthPotLevel1.name = "Health Pot";
            HealthPotLevel1.type = "Pot";
            HealthPotLevel1.potType = "Health";
            HealthPotLevel1.level = 1;

            Pot ManaPotLevel1 = new Pot();
            ManaPotLevel1.name = "Mana Pot";
            ManaPotLevel1.type = "Pot";
            ManaPotLevel1.potType = "Mana";
            ManaPotLevel1.level = 1;

            #endregion
            #region Enemies

            Enemy Skeleton = new Enemy();
            Skeleton.name = "Skeleton";
            Skeleton.type = "normal";
            Skeleton.health = 30;
            Skeleton.defHealth = 30;
            Skeleton.damage = 10;
            Skeleton.xpToGive = 25;

            Enemy SkeletonKing = new Enemy();
            SkeletonKing.name = "Skeleton King";
            SkeletonKing.type = "boss";
            SkeletonKing.health = 300;
            SkeletonKing.defHealth = 300;
            SkeletonKing.damage = 45;
            SkeletonKing.resistanceToMagic = 25;
            SkeletonKing.xpToGive = 100;

            #endregion
            #region Rooms

            Room treasureRoom = new Room();
            treasureRoom.name = "Treasure Room";
            treasureRoom.roomType = "treasure";
            treasureRoom.dangerLevel = 0;

            Room trapRoom = new Room();
            trapRoom.name = "Trap Room";
            trapRoom.roomType = "trap";
            trapRoom.dangerLevel = 10;

            Room bossRoom = new Room();
            bossRoom.name = "Boss Room";
            bossRoom.roomType = "boss";
            bossRoom.dangerLevel = 15;

            Room combatRoom = new Room();
            combatRoom.name = "Combat Room";
            combatRoom.roomType = "combat";
            combatRoom.dangerLevel = 5;

            #endregion
            #region Skills
            #endregion
            #region Loot Tables
            player.normalLootTablePot.Add(HealthPotLevel1);
            player.normalLootTablePot.Add(ManaPotLevel1);
            player.normalLootTableWeapon.Add(GreatSword);
            player.normalLootTableWeapon.Add(WizardStaff);

            player.bossLootTable.Add(FlamingSword);
            #endregion


            for (int i = 0; i < roomCount; i++)
            {
                int randRoom = rnd.Next(1, 10);
                if (randRoom >= 8)
                    mazeRooms.Add(treasureRoom);
                else if (randRoom == 1)
                    mazeRooms.Add(trapRoom);
                else
                    mazeRooms.Add(combatRoom);
            }
            mazeRooms.Add(bossRoom);

            enemyTypes.Add(Skeleton);

            bossTypes.Add(SkeletonKing);

            #region StartingItems
            player.inventory.Add(ShortSword);
            player.weapons.Add(ShortSword);
            player.inventory.Add(BasicStaff);
            player.weapons.Add(BasicStaff);
            player.inventory.Add(HealthPotLevel1);
            player.pots.Add(HealthPotLevel1);
            player.inventory.Add(HealthPotLevel1);
            player.pots.Add(HealthPotLevel1);
            player.inventory.Add(ManaPotLevel1);
            player.pots.Add(ManaPotLevel1);
            player.inventory.Add(ManaPotLevel1);
            player.pots.Add(ManaPotLevel1);
            #endregion

            Console.WriteLine("Welcome to the dungeon " + player.name + "!");
            int currentRoom = 0;
            while(true)
            {
                int number = 1;
                Console.WriteLine("Pick an action:");
                Console.WriteLine("1. Enter next room");
                Console.WriteLine("2. Show inventory");
                Console.WriteLine("3. Equip a weapon");
                if(DebugMode)
                {
                    Console.WriteLine("4. Debug Mode Options");
                }
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 4 || choice < 1)
                {
                    if(!DebugMode && choice > 4)
                        Console.WriteLine("Please pick a valid action!");
                }
                else if(choice == 1)
                {
                    if(player.equipedWeapon == null)
                        player.equipedWeapon = EquipWeapon(player.equipedWeapon, player.weapons);
                    EnterRoom(mazeRooms, currentRoom, rnd, enemyTypes, bossTypes, player);
                    currentRoom++;
                }
                else if (choice == 2)
                {
                    foreach(var item in player.inventory)
                    {
                        Console.WriteLine(number.ToString() + ". " + item.name);
                        number++;
                    }
                }
                else if (choice == 3)
                {
                    player.equipedWeapon = EquipWeapon(player.equipedWeapon, player.weapons);
                }
                else if(choice == 4)
                {
                    Console.WriteLine("Choose an option: ");
                    Console.WriteLine("1. Show map");
                    Console.WriteLine("2. Increase Short Sword damage to 100 ");
                    Console.WriteLine("3. Make health 99999 & mana 99999");
                    int debugChoice;
                    while (true)
                    {
                        debugChoice = Convert.ToInt32(Console.ReadLine());
                        if (debugChoice > 3 || debugChoice < 1)
                        {
                            Console.WriteLine("Please select a valid option!");
                        }
                        else
                            break;
                    }
                    if(debugChoice == 1)
                    {
                        Console.WriteLine("Debug!");

                        foreach (var room in mazeRooms)
                        {
                            Console.WriteLine(room.name);
                        }
                        Console.WriteLine("-----------------------");
                    }
                    else if(choice == 2)
                    {
                        Console.WriteLine(player.weapons.Find(x => x.name.Equals("Short Sword")).name);
                    }
                    else
                    {
                        player.health = 99999;
                        player.maxHealth = 99999;
                        player.mana = 99999;
                        player.maxMana = 99999;
                    }
                }
            }



            //player.equipedWeapon = EquipWeapon(player.equipedWeapon, player.weapons);
            //Console.WriteLine("You equiped " + player.equipedWeapon.name);
            //Fight(SkeletonKing, player.equipedWeapon, player, rnd);
            //Console.WriteLine("Your current level: " + player.level.ToString());

        }

        static Weapon EquipWeapon(Weapon equipedWeapon, List<Weapon> weapons)
        {
            int number = 1;
            while(true)
            {
                foreach (var weapon in weapons)
                {
                    Console.WriteLine(number.ToString() + ". " + weapon.name);
                    number++;
                }

                Console.WriteLine("Equip a weapon: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                choice--;

                if (choice >= weapons.Count || choice < 0)
                {
                    Console.WriteLine("Please choice a valid weapon!");
                }
                else
                {
                    return weapons[choice];
                }
            }
            
        }

        static void Fight(Enemy enemy, Weapon equipedWeapon, Player player, Random rnd)
        {
            if(enemy.type != "boss")
                Console.WriteLine("You encounter a " + enemy.name);
            while(enemy.health > 0 && player.health > 0)
            {
                int number = 1;
                Console.WriteLine("Your health: " + player.health + "        Your Mana: " + player.mana + "        Enemy Health: " + enemy.health);
                Console.WriteLine("Choose your action!");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use a pot");
                Console.WriteLine("3. Skip");
                int choice;
                while (true)
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice > 3 || choice < 1)
                    {
                        Console.WriteLine("Please choose a valid option!");
                    }
                    else
                    {
                        break;
                    }
                }
                if(choice == 1)
                {
                    enemy.health -= equipedWeapon.damage - (equipedWeapon.damage * enemy.resistanceToPhysical / 100);
                    enemy.health -= equipedWeapon.magicDamage - (equipedWeapon.magicDamage * enemy.resistanceToMagic / 100);
                }
                else if(choice == 2)
                {
                    if(player.pots.Count <= 0)
                    {
                        Console.WriteLine("You do not have any pots to use!");
                    }
                    else
                    {
                        Console.WriteLine("Choose a pot to use:");
                        foreach (var pot in player.pots)
                        {
                            Console.WriteLine(number.ToString() + ". " + pot.name);
                            number++;
                        }
                        int potChoice;
                        while (true)
                        {
                            potChoice = Convert.ToInt32(Console.ReadLine());
                            if (potChoice < 1 || potChoice > player.pots.Count + 1)
                            {
                                Console.WriteLine("Please choose a valid option!");
                            }
                            else
                            {
                                break;
                            }
                        }
                        string usedPotType;
                        if (player.pots[potChoice - 1].potType == "Health")
                        {
                            player.health += player.pots[potChoice - 1].UseHealthPot(rnd);
                            usedPotType = "Health Pot";
                        }
                        else
                        {
                            player.mana += player.pots[potChoice - 1].UseManaPot(rnd);
                            usedPotType = "Mana Pot";
                        }
                        player.pots.RemoveAt(potChoice - 1);
                        foreach (var item in player.inventory)
                        {
                            if (item.name == usedPotType)
                            {
                                player.inventory.Remove(item);
                                break;
                            }
                        }
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("You waited...");
                }

                if(enemy.health > 0)
                {
                    Console.WriteLine(enemy.name + " hit you! -" + enemy.damage.ToString() + " health");
                    player.health -= enemy.damage;
                }
            }

            if(enemy.health <= 0)
            {
                Console.WriteLine("You have defeated " + enemy.name);
                player.xp += enemy.xpToGive;
                enemy.health = enemy.defHealth;
                if(player.xp >= 100)
                {
                    player.xp -= 100;
                    player.level++;
                    Console.WriteLine("You leveled up!");
                }
                if(enemy.type == "normal")
                {
                    int potOrWeapon = rnd.Next(10);
                    if(potOrWeapon > 7) // Weapon
                    {
                        int rndLootIndex = rnd.Next(player.normalLootTableWeapon.Count);
                        player.inventory.Add(player.normalLootTableWeapon[rndLootIndex]);
                        player.weapons.Add(player.normalLootTableWeapon[rndLootIndex]);
                        Console.WriteLine("You got a " + player.normalLootTableWeapon[rndLootIndex].name);
                    }
                    else // Pot
                    {
                        int rndLootIndex = rnd.Next(player.normalLootTablePot.Count);
                        player.inventory.Add(player.normalLootTablePot[rndLootIndex]);
                        player.pots.Add(player.normalLootTablePot[rndLootIndex]);
                        Console.WriteLine("You got a " + player.normalLootTablePot[rndLootIndex].name);
                    }
                }
                else
                {
                    int rndLootIndex = rnd.Next(player.bossLootTable.Count);
                    player.inventory.Add(player.bossLootTable[rndLootIndex]);
                    player.weapons.Add(player.bossLootTable[rndLootIndex]);
                    Console.WriteLine("You got a " + player.bossLootTable[rndLootIndex].name);
                }
            }
            else
            {
                Console.WriteLine("You have been defeated, Game Over!");
                Environment.Exit(0);
            }
        }

        static void EnterRoom(List<Room> mazeRooms, int currentRoom, Random rnd, List<Enemy> enemyTypes, List<Enemy> bossTypes,Player player)
        {
            Room currentRoomType = mazeRooms[currentRoom];
            Console.WriteLine("You have entered to a " + currentRoomType.name);
            Enemy enemyType = enemyTypes[rnd.Next(enemyTypes.Count)];
            Enemy bossType =  bossTypes[rnd.Next(bossTypes.Count)];
            if (currentRoomType.roomType == "combat")
            {
                currentRoomType.dangerLevel = rnd.Next(3, 6);
                Console.WriteLine("There seems to be " + currentRoomType.dangerLevel.ToString() + " " + enemyType.name + "s here!");
                for (int i = 0; i < currentRoomType.dangerLevel; i++)
                {
                    Fight(enemyType, player.equipedWeapon, player, rnd);
                }
            }
            else if(currentRoomType.roomType == "treasure")
            {
                Console.WriteLine("You gained 50 XP !");
                player.xp += 50;
            }
            else if(currentRoomType.roomType == "trap")
            {
                currentRoomType.dangerLevel = rnd.Next(8, 12);
                Console.WriteLine("There seems to be " + currentRoomType.dangerLevel.ToString() + " " + enemyType.name + "s here!");
                for (int i = 0; i < currentRoomType.dangerLevel; i++)
                {
                    Fight(enemyType, player.equipedWeapon, player, rnd);
                }
            }
            else if(currentRoomType.roomType == "boss")
            {
                Console.WriteLine("You encounter the mighty " + bossType.name + "!");
                Fight(bossType, player.equipedWeapon, player, rnd);
            }
        }
    }
}