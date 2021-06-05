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
    }
}
