using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Players
{
    public class Player : IPlayer
    {
        public string Username { get; }
        public Color FiguresColor { get; }
        public bool IsActive { get; set; }

        public Player (string username, Color color)
        {
            Username = username;
            FiguresColor = color;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            Player player = (Player)obj;
            return (Username == player.Username && FiguresColor == player.FiguresColor && IsActive == player.IsActive);
        }

        public override int GetHashCode()
        {
            var result = int.Parse(Username, System.Globalization.NumberStyles.Any);
            return result;
        }
    }
}
