using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Battleships
{
    internal class Partials
    {
    }

    partial class Attacks
    {
        public Attacks() { }
        public Attacks(string Coordinate, bool Hit, int Game_Attack)
        {


            this.Coordinate = Coordinate;
            this.Hit = Hit;
            this.Game_Attack = Game_Attack;
        }
    }
    partial class Players
    {
        public Players() { }
        public Players(string Username, string Password)
        {

            this.Username = Username;
            this.Password = Password;

        }
    }
    partial class Games
    {
        public Games() { }
        public Games(string Title, bool Complete, string CreatorFK, string OpponentFK)
        {

            this.Title = Title;
            this.Complete = Complete;
            this.CreatorFK = CreatorFK;
            this.OpponentFK = OpponentFK;
        }
    }
    partial class Ships
    {
        public Ships() { }
        public Ships(int Ship_ID, string Ship_Title, int Size)
        {
            this.Ship_ID = Ship_ID;
            this.Ship_Title = Ship_Title;
            this.Size = Size;


        }
    }
    partial class GameShipConfig
    {
        public GameShipConfig() { }
        public GameShipConfig(string GSC_Coordinate, string PlayerFK, int GameFK)
        {

            this.GSC_Coordinate = GSC_Coordinate;
            this.PlayerFK = PlayerFK;
            this.GameFK = GameFK;


        }
    }
}
