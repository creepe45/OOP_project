using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Linq.Expressions;

namespace Battleships
{
    internal class Program
    {
        public static BattleshipDatabaseEntities1 db = new BattleshipDatabaseEntities1();

        public static string EnteredVal = "";
        public static int playeridcount = 0;
        public static int gameidcount = 0;






        static void Main(string[] args)
        {
            while (true)
            {
                //Ships xs = new Ships(2, "extra small", 2);
                //Ships s = new Ships(3, "small", 3);
                //Ships s2 = new Ships(4, "small", 3);
                //Ships m = new Ships(5, "medium", 4);
                //Ships l = new Ships(6, "large", 5);
                //db.Ships.Add(xs);
                //db.Ships.Add(s);
                //db.Ships.Add(s2);
                //db.Ships.Add(m);
                //db.Ships.Add(l);
                //db.SaveChanges();
                var xs = (from ships in db.Ships
                          where ships.Ship_ID == 1
                          select ships.Size).Single();


                var s = (from ships in db.Ships
                         where ships.Ship_ID == 2
                         select ships.Size).Single();
                var s2 = (from ships in db.Ships
                          where ships.Ship_ID == 3
                          select ships.Size).Single();
                var m = (from ships in db.Ships
                         where ships.Ship_ID == 4
                         select ships.Size).Single();
                var l = (from ships in db.Ships
                         where ships.Ship_ID == 5
                         select ships.Size).Single();


                int playerturn = 3;
                int usernameexists = 0;
                int usernameexists2 = 0;
                string player1signin1 = "";
                string player2signin1 = "";
                string titlecreation = "";
                List<string> p1rowlist = new List<string> {
                 "    1  2  3  4  5  6  7  8",
                 "A   .  .  .  .  .  .  .  .",
                 "B   .  .  .  .  .  .  .  .",
                 "C   .  .  .  .  .  .  .  .",
                 "D   .  .  .  .  .  .  .  .",
                 "E   .  .  .  .  .  .  .  .",
                 "F   .  .  .  .  .  .  .  .",
                 "G   .  .  .  .  .  .  .  ." };
                List<string> p2rowlist = new List<string> {
                 "    1  2  3  4  5  6  7  8",
                 "A   .  .  .  .  .  .  .  .",
                 "B   .  .  .  .  .  .  .  .",
                 "C   .  .  .  .  .  .  .  .",
                 "D   .  .  .  .  .  .  .  .",
                 "E   .  .  .  .  .  .  .  .",
                 "F   .  .  .  .  .  .  .  .",
                 "G   .  .  .  .  .  .  .  ." };
                List<string> p1attacklist = new List<string> {
                 "    1  2  3  4  5  6  7  8",
                 "A   .  .  .  .  .  .  .  .",
                 "B   .  .  .  .  .  .  .  .",
                 "C   .  .  .  .  .  .  .  .",
                 "D   .  .  .  .  .  .  .  .",
                 "E   .  .  .  .  .  .  .  .",
                 "F   .  .  .  .  .  .  .  .",
                 "G   .  .  .  .  .  .  .  ." };
                List<string> p2attacklist = new List<string> {
                 "    1  2  3  4  5  6  7  8",
                 "A   .  .  .  .  .  .  .  .",
                 "B   .  .  .  .  .  .  .  .",
                 "C   .  .  .  .  .  .  .  .",
                 "D   .  .  .  .  .  .  .  .",
                 "E   .  .  .  .  .  .  .  .",
                 "F   .  .  .  .  .  .  .  .",
                 "G   .  .  .  .  .  .  .  ." };
                int userhaspicked1 = 1;
                List<int> coordinatelist = new List<int> { 4, 7, 10, 13, 16, 19, 22, 25 };
                List<char> letterlist = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

                List<char> numberlist = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8' };
                string username1 = "";
                string username2 = "";
                string newtitle = "";

                while (true)
                {
                    try
                    {
                        bool showMenu = true;
                    while (showMenu)
                    {
                        showMenu = MainMenu();
                    }

                    
                        bool MainMenu()
                        {






                            var usernamecheck = from Playe in db.Players

                                                select Playe;
                            var usernamecheck2 = from Playe in db.Players

                                                 select Playe;

                            Console.Clear();
                            Console.WriteLine("Choose an option:");
                            Console.WriteLine("1) Add Player details");
                            Console.WriteLine("2) Configure Ships");
                            Console.WriteLine("3) Launch Attack");
                            Console.WriteLine("4) Exit");
                            Console.Write("\r\nSelect an option: ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    if (userhaspicked1 > 1)
                                    {
                                        Console.WriteLine("invalid option");
                                        Console.ReadLine();
                                        return true; ;
                                    }
                                    if (userhaspicked1 == 1)
                                    {
                                        Console.WriteLine("add player has been chosen");
                                        Console.WriteLine("Please enter username for player 1");

                                        username1 = Console.ReadLine();

                                        foreach (Players player in usernamecheck)
                                        {
                                            if (player.Username != username1 && usernameexists == 1)
                                            {
                                                usernameexists--;


                                            }
                                            else if (player.Username == username1 && usernameexists == 0)
                                            {
                                                usernameexists++;

                                                break;
                                            }

                                        }
                                        if (usernameexists == 0)
                                        {
                                            Console.WriteLine("please enter password");
                                            string password1 = Console.ReadLine();
                                            SecureString pass = checkPassword();
                                            string Password = new System.Net.NetworkCredential(string.Empty, pass).Password;

                                            Console.ReadKey();
                                            Players player1 = new Players(username1, password1);
                                            db.Players.Add(player1);
                                            db.SaveChanges();
                                            player1signin1 = player1.Username;
                                        }
                                        else if (usernameexists == 1)
                                        {
                                            var usernameispresent = (from Players in db.Players
                                                                     where Players.Username == username1
                                                                     select Players.Password).Single();
                                            var playersignin1 = (from Players in db.Players
                                                                 where Players.Username == username1
                                                                 select Players.Username).Single();
                                            Console.WriteLine("please enter password to login");

                                            string password1 = Console.ReadLine();
                                            SecureString pass = checkPassword();
                                            string Password = new System.Net.NetworkCredential(string.Empty, pass).Password;

                                            Console.ReadKey();
                                            if (usernameispresent == password1)
                                            {
                                                Console.WriteLine(playersignin1 + "  has been selected");

                                            }
                                            else
                                            {
                                                Console.WriteLine("sorry wrong password please try again");

                                                Console.ReadLine();
                                                return true;
                                            }
                                        }


                                        Console.WriteLine("Please enter username for player 2");
                                        username2 = Console.ReadLine();

                                        foreach (Players player in usernamecheck2)
                                        {
                                            if (player.Username != username2 && usernameexists2 == 1)
                                            {
                                                usernameexists--;


                                            }
                                            else if (player.Username == username2 && usernameexists2 == 0)
                                            {
                                                usernameexists2++;

                                                break;
                                            }

                                        }

                                        if (usernameexists2 == 0)
                                        {
                                            Console.WriteLine("please enter password for user 2");
                                            string password2 = Console.ReadLine();
                                            SecureString pass = checkPassword();
                                            string Password = new System.Net.NetworkCredential(string.Empty, pass).Password;

                                            Console.ReadKey();
                                            Players player2 = new Players(username2, password2);
                                            db.Players.Add(player2);
                                            db.SaveChanges();
                                            player2signin1 = player2.Username;


                                        }
                                        else if (usernameexists2 == 1)
                                        {
                                            Console.WriteLine("please enter password for user 2");
                                            var usernameispresent2 = (from Players in db.Players
                                                                      where Players.Username == username2
                                                                      select Players.Password).Single();
                                            var playersignin2 = (from Players in db.Players
                                                                 where Players.Username == username2
                                                                 select Players.Username).Single();
                                            string password2 = Console.ReadLine();

                                            SecureString pass = checkPassword();
                                            string Password = new System.Net.NetworkCredential(string.Empty, pass).Password;

                                            Console.ReadKey();
                                            if (usernameispresent2 == password2)
                                            {
                                                Console.WriteLine(playersignin2 + "  has been selected");

                                            }
                                            else
                                            {
                                                Console.WriteLine("sorry wrong password please try again");
                                                Console.ReadLine();
                                                return true;
                                            }
                                        }


                                        Console.WriteLine("please select a title for your game");
                                        newtitle = Console.ReadLine();

                                        Games game1 = new Games(newtitle, false, username1, username2);
                                        db.Games.Add(game1);
                                        db.SaveChanges();

                                        titlecreation = game1.Title;
                                        Console.WriteLine("Please go configure your ships, press enter to go back to the menu");
                                        Console.ReadLine();
                                        userhaspicked1++;
                                    }

                                    return true;
                                case "2":
                                    if (userhaspicked1 == 2)
                                    {
                                        Console.WriteLine("welcome to the configuration of ships");
                                        Console.WriteLine(player1signin1 + "please configure your ships");
                                        var shipchoices = from shi in db.Ships

                                                          select shi;
                                        foreach (Ships shi in shipchoices)
                                        {
                                            Console.WriteLine("Ship: " + shi.Ship_ID + " " + shi.Ship_Title + " size " + shi.Size);
                                        }

                                        string p1row = (p1rowlist[0] + "\n" + p1rowlist[1] + "\n" + p1rowlist[2] + "\n" + p1rowlist[3] + "\n" + p1rowlist[4] + "\n" + p1rowlist[5] + "\n" + p1rowlist[6] + "\n" + p1rowlist[7]);
                                        Console.WriteLine(p1row);
                                        List<int> shipsalreadychosen = new List<int>(5);
                                        for (int i = 0; i < 5;)
                                        {
                                            Console.WriteLine("Please enter the id of the ship u want to place, please do not enter a ship twice");
                                            string shipidchosenstring = Console.ReadLine();
                                            if (shipidchosenstring == "1" || shipidchosenstring == "2" || shipidchosenstring == "3" || shipidchosenstring == "4" || shipidchosenstring == "5")
                                            {


                                                int shipidchosen = Convert.ToInt32(shipidchosenstring);

                                                var shipchosen = (from Ships in db.Ships
                                                                  where Ships.Ship_ID == shipidchosen
                                                                  select Ships.Ship_ID).Single();
                                                int whichshipsize = 0;
                                                if (shipidchosen == 1)
                                                {
                                                    whichshipsize = xs;
                                                }
                                                else if (shipidchosen == 2)
                                                {
                                                    whichshipsize = s;
                                                }
                                                else if (shipidchosen == 3)
                                                {
                                                    whichshipsize = s2;
                                                }
                                                else if (shipidchosen == 4)
                                                {
                                                    whichshipsize = m;
                                                }
                                                else if (shipidchosen == 5)
                                                {
                                                    whichshipsize = l;
                                                }
                                                var shipchosensize = whichshipsize;
                                                int startofloop = 0;





                                                for (int iship = 0; iship > shipsalreadychosen.Count;)
                                                {
                                                    if (shipsalreadychosen[iship] == shipidchosen)
                                                    {
                                                        Console.WriteLine("you have already chosen this ship");
                                                        startofloop++;
                                                        break;
                                                    }
                                                }

                                                if (startofloop == 1)
                                                {
                                                    continue;
                                                }
                                                Console.WriteLine("you have chosen" + shipchosen);

                                                Console.WriteLine("Please enter the coordinates of the ship u want to place, the coordinates should be written like A2");
                                                string coordinate1 = Console.ReadLine().ToLower();


                                                char valid1 = coordinate1[0];
                                                char valid2 = coordinate1[1];

                                                if ((valid1 == 'a' || valid1 == 'b' || valid1 == 'c' || valid1 == 'd' || valid1 == 'e' || valid1 == 'f' || valid1 == 'g') && (valid2 == '1' || valid2 == '2' || valid2 == '3' || valid2 == '4' || valid2 == '5' || valid2 == '6' || valid2 == '7' || valid2 == '8'))
                                                {

                                                    //coordinate and ship validation with linq tbd

                                                    int gameidcurr = (from Games in db.Games
                                                                      where Games.Title == newtitle
                                                                      select Games.Game_ID).Single();




                                                    GameShipConfig player1config = new GameShipConfig();
                                                    player1config.GSC_Coordinate = coordinate1;
                                                    player1config.PlayerFK = username1;
                                                    player1config.GameFK = gameidcurr;
                                                    db.GameShipConfig.Add(player1config);
                                                    db.SaveChanges();

                                                    Console.WriteLine("Please enter the coordinates of the ship u want to place, the coordinates should be written like A2 note ships cannot be placed diagonally. this will decide if you want to place it horizontally or vertically");
                                                    string coordinate2 = Console.ReadLine().ToLower();
                                                    char valid11 = coordinate2[0];
                                                    char valid22 = coordinate2[1];
                                                    GameShipConfig player1config2 = new GameShipConfig();
                                                    player1config2.GSC_Coordinate = coordinate2;
                                                    player1config2.PlayerFK = username1;
                                                    player1config2.GameFK = gameidcurr;
                                                    db.GameShipConfig.Add(player1config2);
                                                    db.SaveChanges();


                                                    if ((valid11 == 'a' || valid11 == 'b' || valid11 == 'c' || valid11 == 'd' || valid11 == 'e' || valid11 == 'f' || valid11 == 'g') && (valid22 == '1' || valid22 == '2' || valid22 == '3' || valid22 == '4' || valid22 == '5' || valid22 == '6' || valid22 == '7' || valid22 == '8') && coordinate1 != coordinate2 && (valid1 == valid11 || valid2 == valid22))
                                                    {


                                                        char coord11 = coordinate1[0];
                                                        char coord12 = coordinate1[1];
                                                        char coord21 = coordinate2[0];
                                                        char coord22 = coordinate2[1];

                                                        int intcoord12 = coord12 - '0'; //coord of 1 num
                                                        int intcoord22 = coord22 - '0'; //coord of 2 num


                                                        int intcoord11 = coord11 - '`'; // coord of 1 let
                                                        int intcoord21 = coord21 - '`'; // coord of 2 let
                                                        string samespot;
                                                        char samespot2;
                                                        int indexright = 0;
                                                        if (shipchosensize > 1)
                                                        {
                                                            if (coord11 == coord21)
                                                            {
                                                                if (intcoord12 == intcoord22 + 1 || intcoord12 == intcoord22 - 1)
                                                                {
                                                                    indexright = coordinatelist[intcoord12 - 1]; //liem row
                                                                    samespot = p1rowlist[intcoord11];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else
                                                                    {
                                                                        StringBuilder sb = new StringBuilder(p1rowlist[intcoord11]); // liem column
                                                                        sb[indexright] = 'S';
                                                                        p1rowlist[intcoord11] = sb.ToString();
                                                                    }
                                                                    indexright = coordinatelist[intcoord22 - 1];
                                                                    samespot = p1rowlist[intcoord11];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else
                                                                    {
                                                                        StringBuilder sb2 = new StringBuilder(p1rowlist[intcoord11]);
                                                                        sb2[indexright] = 'S';
                                                                        p1rowlist[intcoord11] = sb2.ToString();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    continue;
                                                                }
                                                            }
                                                            if (coord12 == coord22)
                                                            {
                                                                if (intcoord11 == intcoord21 + 1 || intcoord11 == intcoord21 - 1)
                                                                {
                                                                    indexright = coordinatelist[intcoord12 - 1];
                                                                    samespot = p1rowlist[intcoord11];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else {
                                                                        StringBuilder sb = new StringBuilder(p1rowlist[intcoord11]);
                                                                        sb[indexright] = 'S';
                                                                        p1rowlist[intcoord11] = sb.ToString();
                                                                    }

                                                                    indexright = coordinatelist[intcoord12 - 1];
                                                                    samespot = p1rowlist[intcoord21];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else {
                                                                        StringBuilder sb2 = new StringBuilder(p1rowlist[intcoord21]);
                                                                        sb2[indexright] = 'S';
                                                                        p1rowlist[intcoord21] = sb2.ToString();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    continue;
                                                                }
                                                            }
                                                        }
                                                        if (shipchosensize > 2)
                                                        {

                                                            int newshipchosensize = shipchosensize - 2;
                                                            if (coord11 == coord21 || coord12 == coord22)
                                                            {

                                                                for (int iship = newshipchosensize; iship > 0;)
                                                                {
                                                                    Console.WriteLine("please enter the rest of the coordinates");
                                                                    string coordinateleft = Console.ReadLine().ToLower();
                                                                    GameShipConfig player1config3 = new GameShipConfig();
                                                                    player1config3.GSC_Coordinate = coordinateleft;
                                                                    player1config3.PlayerFK = username1;
                                                                    player1config3.GameFK = gameidcurr;
                                                                    db.GameShipConfig.Add(player1config3);
                                                                    db.SaveChanges();


                                                                    char coordl1 = coordinateleft[0];
                                                                    char coordl2 = coordinateleft[1];
                                                                    int intcoordl2 = coordl2 - '0';
                                                                    int intcoordl1 = coordl1 - '`';
                                                                    int indexright2 = 0;
                                                                    string samespotl;
                                                                    char samespot2l;



                                                                    indexright2 = coordinatelist[intcoordl2 - 1]; //liem row
                                                                    samespotl = p1rowlist[intcoordl1];
                                                                    samespot2l = samespotl[indexright2];
                                                                    if (samespot2l == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else {
                                                                        StringBuilder sb = new StringBuilder(p1rowlist[intcoordl1]); // liem column
                                                                        sb[indexright2] = 'S';
                                                                        p1rowlist[intcoordl1] = sb.ToString();



                                                                        iship--;
                                                                    }

                                                                }
                                                            }

                                                        }


                                                        Console.WriteLine(p1rowlist[0] + "\n" + p1rowlist[1] + "\n" + p1rowlist[2] + "\n" + p1rowlist[3] + "\n" + p1rowlist[4] + "\n" + p1rowlist[5] + "\n" + p1rowlist[6] + "\n" + p1rowlist[7]);
                                                        i++;
                                                        shipsalreadychosen.Add(shipidchosen);

                                                    }

                                                    else if (valid1 != valid11 && valid2 != valid22)
                                                    {
                                                        Console.WriteLine("sorry this second coordinate is not valid please try again");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("sorry this second coordinate is not valid please try again");
                                                    }
                                                }




                                                else
                                                {
                                                    Console.WriteLine("sorry this coordinate is not valid please try again");
                                                }



                                            }


                                            else
                                            {
                                                Console.WriteLine("you have entered an invalid value please try again");

                                            }

                                        }





                                        // PLAYER 2 SHIP CONFIG












                                        string p1rowupdated = (p1rowlist[0] + "\n" + p1rowlist[1] + "\n" + p1rowlist[2] + "\n" + p1rowlist[3] + "\n" + p1rowlist[4] + "\n" + p1rowlist[5] + "\n" + p1rowlist[6] + "\n" + p1rowlist[7]);
                                        Console.WriteLine(p1rowupdated);
                                        Console.WriteLine("press enter so the other player can configure his/her ships");
                                        Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("welcome to the configuration of ships");
                                        Console.WriteLine(player2signin1 + "please configure your ships");

                                        foreach (Ships shi in shipchoices)
                                        {
                                            Console.WriteLine("Ship: " + shi.Ship_ID + " " + shi.Ship_Title + " size " + shi.Size);
                                        }
                                        List<int> shipsalreadychosen2 = new List<int>(5);
                                        string p2row = (p2rowlist[0] + "\n" + p2rowlist[1] + "\n" + p2rowlist[2] + "\n" + p2rowlist[3] + "\n" + p2rowlist[4] + "\n" + p2rowlist[5] + "\n" + p2rowlist[6] + "\n" + p2rowlist[7]);
                                        Console.WriteLine(p2row);
                                        for (int i = 0; i < 5;)
                                        {
                                            Console.WriteLine("Please enter the id of the ship u want to place, please do not enter a ship twice");
                                            string shipidchosenstring = Console.ReadLine();
                                            if (shipidchosenstring == "1" || shipidchosenstring == "2" || shipidchosenstring == "3" || shipidchosenstring == "4" || shipidchosenstring == "5")
                                            {


                                                int shipidchosen = Convert.ToInt32(shipidchosenstring);

                                                var shipchosen = (from Ships in db.Ships
                                                                  where Ships.Ship_ID == shipidchosen
                                                                  select Ships.Ship_ID).Single();
                                                int whichshipsize = 0;
                                                if (shipidchosen == 1)
                                                {
                                                    whichshipsize = xs;
                                                }
                                                else if (shipidchosen == 2)
                                                {
                                                    whichshipsize = s;
                                                }
                                                else if (shipidchosen == 3)
                                                {
                                                    whichshipsize = s2;
                                                }
                                                else if (shipidchosen == 4)
                                                {
                                                    whichshipsize = m;
                                                }
                                                else if (shipidchosen == 5)
                                                {
                                                    whichshipsize = l;
                                                }
                                                var shipchosensize = whichshipsize;
                                                int startofloop = 0;





                                                for (int iship = 0; iship > shipsalreadychosen2.Count;)
                                                {
                                                    if (shipsalreadychosen2[iship] == shipidchosen)
                                                    {
                                                        Console.WriteLine("you have already chosen this ship");
                                                        startofloop++;
                                                        break;
                                                    }
                                                }

                                                if (startofloop == 1)
                                                {
                                                    continue;
                                                }


                                                Console.WriteLine("Please enter the coordinates of the ship u want to place, the coordinates should be written like A2");
                                                string coordinate1 = Console.ReadLine().ToLower();


                                                char valid1 = coordinate1[0];
                                                char valid2 = coordinate1[1];

                                                if ((valid1 == 'a' || valid1 == 'b' || valid1 == 'c' || valid1 == 'd' || valid1 == 'e' || valid1 == 'f' || valid1 == 'g') && (valid2 == '1' || valid2 == '2' || valid2 == '3' || valid2 == '4' || valid2 == '5' || valid2 == '6' || valid2 == '7' || valid2 == '8'))
                                                {

                                                    //coordinate and ship validation with linq tbd

                                                    int gameidcurr = (from Games in db.Games
                                                                      where Games.Title == newtitle
                                                                      select Games.Game_ID).Single();




                                                    GameShipConfig player1config = new GameShipConfig();
                                                    player1config.GSC_Coordinate = coordinate1;
                                                    player1config.PlayerFK = username1;
                                                    player1config.GameFK = gameidcurr;
                                                    db.GameShipConfig.Add(player1config);
                                                    db.SaveChanges();

                                                    Console.WriteLine("Please enter the coordinates of the ship u want to place, the coordinates should be written like A2 note ships cannot be placed diagonally. this will decide if you want to place it horizontally or vertically");
                                                    string coordinate2 = Console.ReadLine().ToLower();
                                                    char valid11 = coordinate2[0];
                                                    char valid22 = coordinate2[1];
                                                    GameShipConfig player1config2 = new GameShipConfig();
                                                    player1config2.GSC_Coordinate = coordinate2;
                                                    player1config2.PlayerFK = username2;
                                                    player1config2.GameFK = gameidcurr;
                                                    db.GameShipConfig.Add(player1config2);
                                                    db.SaveChanges();


                                                    if ((valid11 == 'a' || valid11 == 'b' || valid11 == 'c' || valid11 == 'd' || valid11 == 'e' || valid11 == 'f' || valid11 == 'g') && (valid22 == '1' || valid22 == '2' || valid22 == '3' || valid22 == '4' || valid22 == '5' || valid22 == '6' || valid22 == '7' || valid22 == '8') && coordinate1 != coordinate2 && (valid1 == valid11 || valid2 == valid22))
                                                    {


                                                        char coord11 = coordinate1[0];
                                                        char coord12 = coordinate1[1];
                                                        char coord21 = coordinate2[0];
                                                        char coord22 = coordinate2[1];

                                                        int intcoord12 = coord12 - '0'; //coord of 1 num
                                                        int intcoord22 = coord22 - '0'; //coord of 2 num


                                                        int intcoord11 = coord11 - '`'; // coord of 1 let
                                                        int intcoord21 = coord21 - '`'; // coord of 2 let
                                                        string samespot;
                                                        char samespot2;
                                                        int indexright = 0;
                                                        if (shipchosensize > 1)
                                                        {
                                                            if (coord11 == coord21)
                                                            {
                                                                if (intcoord12 == intcoord22 + 1 || intcoord12 == intcoord22 - 1)
                                                                {
                                                                    indexright = coordinatelist[intcoord12 - 1]; //liem row
                                                                    samespot = p2rowlist[intcoord11];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else
                                                                    {
                                                                        StringBuilder sb = new StringBuilder(p2rowlist[intcoord11]); // liem column
                                                                        sb[indexright] = 'S';
                                                                        p2rowlist[intcoord11] = sb.ToString();
                                                                    }
                                                                    indexright = coordinatelist[intcoord22 - 1];
                                                                    samespot = p2rowlist[intcoord11];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else
                                                                    {
                                                                        StringBuilder sb2 = new StringBuilder(p2rowlist[intcoord11]);
                                                                        sb2[indexright] = 'S';
                                                                        p2rowlist[intcoord11] = sb2.ToString();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    continue;
                                                                }
                                                            }
                                                            if (coord12 == coord22)
                                                            {
                                                                if (intcoord11 == intcoord21 + 1 || intcoord11 == intcoord21 - 1)
                                                                {
                                                                    indexright = coordinatelist[intcoord12 - 1];
                                                                    samespot = p2rowlist[intcoord11];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else
                                                                    {
                                                                        StringBuilder sb = new StringBuilder(p2rowlist[intcoord11]);
                                                                        sb[indexright] = 'S';
                                                                        p2rowlist[intcoord11] = sb.ToString();
                                                                    }

                                                                    indexright = coordinatelist[intcoord12 - 1];
                                                                    samespot = p2rowlist[intcoord21];
                                                                    samespot2 = samespot[indexright];
                                                                    if (samespot2 == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else
                                                                    {
                                                                        StringBuilder sb2 = new StringBuilder(p2rowlist[intcoord21]);
                                                                        sb2[indexright] = 'S';
                                                                        p2rowlist[intcoord21] = sb2.ToString();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    continue;
                                                                }
                                                            }
                                                        }
                                                        if (shipchosensize > 2)
                                                        {

                                                            int newshipchosensize = shipchosensize - 2;
                                                            if (coord11 == coord21 || coord12 == coord22)
                                                            {

                                                                for (int iship = newshipchosensize; iship > 0;)
                                                                {
                                                                    Console.WriteLine("please enter the rest of the coordinates");
                                                                    string coordinateleft = Console.ReadLine().ToLower();
                                                                    GameShipConfig player1config3 = new GameShipConfig();
                                                                    player1config3.GSC_Coordinate = coordinateleft;
                                                                    player1config3.PlayerFK = username2;
                                                                    player1config3.GameFK = gameidcurr;
                                                                    db.GameShipConfig.Add(player1config3);
                                                                    db.SaveChanges();

                                                                    char coordl1 = coordinateleft[0];
                                                                    char coordl2 = coordinateleft[1];
                                                                    int intcoordl2 = coordl2 - '0';
                                                                    int intcoordl1 = coordl1 - '`';
                                                                    int indexright2 = 0;
                                                                    string samespotl;
                                                                    char samespot2l;



                                                                    indexright2 = coordinatelist[intcoordl2 - 1]; //liem row
                                                                    samespotl = p2rowlist[intcoordl1];
                                                                    samespot2l = samespotl[indexright2];
                                                                    if (samespot2l == 'S')
                                                                    {
                                                                        Console.WriteLine("Sorry you have already put a ship here");
                                                                        continue;
                                                                    }
                                                                    else
                                                                    {
                                                                        StringBuilder sb = new StringBuilder(p2rowlist[intcoordl1]); // liem column
                                                                        sb[indexright2] = 'S';
                                                                        p2rowlist[intcoordl1] = sb.ToString();



                                                                        iship--;
                                                                    }

                                                                }
                                                            }

                                                        }


                                                        Console.WriteLine(p2rowlist[0] + "\n" + p2rowlist[1] + "\n" + p2rowlist[2] + "\n" + p2rowlist[3] + "\n" + p2rowlist[4] + "\n" + p2rowlist[5] + "\n" + p2rowlist[6] + "\n" + p2rowlist[7]);
                                                        i++;
                                                        shipsalreadychosen2.Add(shipidchosen);

                                                    }

                                                    else if (valid1 != valid11 && valid2 != valid22)
                                                    {
                                                        Console.WriteLine("sorry this second coordinate is not valid please try again");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("sorry this second coordinate is not valid please try again");
                                                    }
                                                }




                                                else
                                                {
                                                    Console.WriteLine("sorry this coordinate is not valid please try again");
                                                }



                                            }


                                            else
                                            {
                                                Console.WriteLine("you have entered an invalid value please try again");

                                            }

                                        }













                                        string p2rowupdated = (p2rowlist[0] + "\n" + p2rowlist[1] + "\n" + p2rowlist[2] + "\n" + p2rowlist[3] + "\n" + p2rowlist[4] + "\n" + p2rowlist[5] + "\n" + p2rowlist[6] + "\n" + p2rowlist[7]);








                                        Console.ReadLine();

                                        userhaspicked1++;
                                        return true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid menu option");
                                        Console.ReadLine();
                                        return true;
                                    }
                                case "3":

                                    if (userhaspicked1 > 2)
                                    {
                                        if (playerturn == 3)
                                        {
                                            var pastgameattack = from attack in db.Attacks
                                                                 select attack;
                                            var currgameid = (from Games in db.Games.Where(x => x.Game_ID == db.Games.Max(b => b.Game_ID))

                                                              select Games.Game_ID).Single();
                                            int intcurrgameid = Convert.ToInt32(currgameid);
                                           
                                            var coordd = from gsc in db.GameShipConfig
                                                         where gsc.PlayerFK == username2 && gsc.GameFK == intcurrgameid
                                                         select gsc;
                                          
                                           
                                            Console.WriteLine(username1 + " turn");
                                            Console.WriteLine(p1attacklist[0] + "\n" + p1attacklist[1] + "\n" + p1attacklist[2] + "\n" + p1attacklist[3] + "\n" + p1attacklist[4] + "\n" + p1attacklist[5] + "\n" + p1attacklist[6] + "\n" + p1attacklist[7]);
                                            
                                            Console.WriteLine("please enter a coordinate on where to hit");
                                            string coordinateattack = Console.ReadLine().ToLower();

                                            foreach (Attacks att in pastgameattack)
                                            {
                                                if (att.Coordinate == coordinateattack)
                                                {
                                                    Console.WriteLine("you have already attacked this spot");
                                                }
                                            }

                                            char coord1 = coordinateattack[0];
                                            char coord2 = coordinateattack[1];
                                            int coord2int = coord2 - '0';
                                            int coord1int = coord1 - '`';
                                            int indexright = 0;
                                            int letterindex = 0;
                                            string samespot;
                                            char samespot2;
                                            for (letterindex = 0; letterindex < 7; letterindex++)
                                            {
                                                if (coord1 == letterlist[letterindex])
                                                {





                                                    indexright = coordinatelist[coord2int - 1];
                                                    StringBuilder sb = new StringBuilder(p1attacklist[coord1int]);
                                                    foreach (GameShipConfig Gamesc in coordd)
                                                    {
                                                        samespot = p1attacklist[coord1int];
                                                        samespot2 = samespot[indexright];
                                                        if (Gamesc.GSC_Coordinate == coordinateattack)
                                                        {
                                                            sb[indexright] = 'X';


                                                            break;
                                                        }
                                                        else if(samespot2 == '.' && Gamesc.GSC_Coordinate != coordinateattack)
                                                        {
                                                            sb[indexright] = 'O';
                                                        }
                                                    }

                                                    p1attacklist[coord1int] = sb.ToString();
                                                    Console.WriteLine(p1attacklist[0] + "\n" + p1attacklist[1] + "\n" + p1attacklist[2] + "\n" + p1attacklist[3] + "\n" + p1attacklist[4] + "\n" + p1attacklist[5] + "\n" + p1attacklist[6] + "\n" + p1attacklist[7]);
                                                    Console.ReadLine();




                                                    indexright++;



                                                }
                                            }
                                            int count = 0;
                                            int count2 = 0;
                                            while (count2 < 8)
                                            {
                                                foreach (var ch in p1attacklist[count2])
                                                {
                                                    if (ch == 'X')
                                                        count++;
                                                    count2++;

                                                }
                                            }


                                            playerturn++;
                                            if (count == 17)
                                            {
                                                Console.WriteLine(username1 + " has won");
                                                return false;
                                            }
                                            return true;

                                        }


                                        else if (playerturn == 4)
                                        {
                                            var pastgameattack1 = from attack in db.Attacks

                                                                 select attack;

                                            var currgameid2 = (from Games in db.Games.Where(x => x.Game_ID == db.Games.Max(b => b.Game_ID))

                                                              select Games.Game_ID).Single();
                                            int intcurrgameid2 = Convert.ToInt32(currgameid2);
                                            var coordd2 = from gsc in db.GameShipConfig
                                                        where gsc.PlayerFK == username1 && gsc.GameFK == intcurrgameid2
                                                        select gsc;
                                            Console.WriteLine(username2 + " turn");
                                            Console.WriteLine(p2attacklist[0] + "\n" + p2attacklist[1] + "\n" + p2attacklist[2] + "\n" + p2attacklist[3] + "\n" + p2attacklist[4] + "\n" + p2attacklist[5] + "\n" + p2attacklist[6] + "\n" + p2attacklist[7]);

                                            Console.WriteLine("please enter a coordinate on where to hit");
                                            string coordinateattack2 = Console.ReadLine().ToLower();

                                            foreach (Attacks att2 in pastgameattack1)
                                            {
                                                if (att2.Coordinate == coordinateattack2)
                                                {
                                                    Console.WriteLine("you have already attacked this spot");
                                                }
                                            }

                                            char coord11 = coordinateattack2[0];
                                            char coord22 = coordinateattack2[1];
                                            int coord22int = coord22 - '0';
                                            int coord11int = coord11 - '`';
                                            int indexright2 = 0;
                                            int letterindex2 = 0;
                                            string samespot;
                                            char samespot2;
                                            for (letterindex2 = 0; letterindex2 < 7; letterindex2++)
                                            {
                                                if (coord11 == letterlist[letterindex2])
                                                {



                                                    indexright2 = coordinatelist[coord22int - 1];
                                                    StringBuilder sb = new StringBuilder(p2attacklist[coord11int]);
                                                    foreach (GameShipConfig Gamesc2 in coordd2)
                                                    {
                                                        samespot = p2attacklist[coord11int];
                                                        samespot2 = samespot[indexright2];
                                                        if (Gamesc2.GSC_Coordinate == coordinateattack2)
                                                        {
                                                            sb[indexright2] = 'X';
                                                            break;
                                                        }
                                                       
                                                        else if(samespot2 == '.' && Gamesc2.GSC_Coordinate != coordinateattack2)
                                                        {
                                                            sb[indexright2] = 'O';
                                                        }
                                                    }

                                                    p2attacklist[coord11int] = sb.ToString();
                                                    Console.WriteLine(p2attacklist[0] + "\n" + p2attacklist[1] + "\n" + p2attacklist[2] + "\n" + p2attacklist[3] + "\n" + p2attacklist[4] + "\n" + p2attacklist[5] + "\n" + p2attacklist[6] + "\n" + p2attacklist[7]);
                                                    Console.ReadLine();






                                                    indexright2++;


                                                }
                                            }
                                            int count = 0;
                                            int count2 = 0;
                                            while (count2 < 8)
                                            {
                                                foreach (var ch in p1attacklist[count2])
                                                {
                                                    if (ch == 'X')
                                                        count++;
                                                    count2++;

                                                }
                                            }



                                            if (count == 17)
                                            {
                                                Console.WriteLine(username2 + " has won");
                                                Console.ReadLine();
                                                return false;
                                            }





                                            playerturn--;
                                            return true;

                                        }

                                        else return true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid menu option");
                                        return true;
                                    }


                                case "4":

                                    Environment.Exit(0);
                                    return false;
                                default:
                                    return true;

                            }

                        }
                    }
                    catch {

                        Console.WriteLine("error found please try again");
                        Console.ReadLine() ;
                    }
            }
            } }
        

                private static SecureString checkPassword()
                {
                    SecureString pass = new SecureString();
                    ConsoleKeyInfo keyInfo;
                    do
                    {
                        keyInfo = Console.ReadKey(true);
                        if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                        }

                        else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass.RemoveAt(pass.Length- 1);
                            Console.Write("\b \b");
                        }
                    }
                    while (keyInfo.Key != ConsoleKey.Enter);
                    {
                        return pass;
                    }
                
                }
                }
                    
                }

            
            

                
            
        
    


                
            
        
    
