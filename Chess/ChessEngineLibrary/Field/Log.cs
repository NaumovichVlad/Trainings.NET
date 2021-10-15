using ChessEngineLibrary.Figures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public class Log : ILog
    {
        string log = string.Empty;
        char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        public void AddTurn(IFigure figure)
        {
            var position = figure.Position;
            log += string.Format(
                "{0} {1} {2}{3} > ", figure.Owner.FiguresColor, figure.GetFigureType(), 
                letters[position.CoordinateX], position.CoordinateY + 1
            );
        }

        public string GetLog() => log;
        
        public void SaveLog(string filename)
        {
            var path = filename + ".txt";
            using (var sw = new StreamWriter(path, false))
            {
                sw.Write(log);
            }
        }

        public void LoadLog(string filename)
        {
            var path = filename + ".txt"; 
            using (var sr = new StreamReader(path))
            {
                log = sr.ReadToEnd();
            }
        }
    }
}
