using ChessEngineLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public interface ILog
    {
        void AddTurn(IFigure figure);
        string GetLog();
        void SaveLog(string filename);
        void LoadLog(string filename);
    }
}
