using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Players
{
    public interface IPlayer
    {
        string Username { get; }
        Color FiguresColor { get; }
        bool IsActive { get; set; }
    }
}
