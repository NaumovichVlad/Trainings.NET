using ChessEngineLibrary.Figures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    /// <summary>
    /// Class for recording moves
    /// </summary>
    public class Log : ILog
    {
        string log = string.Empty;
        char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        /// <summary>
        /// Record the move of a piece
        /// </summary>
        /// <param name="figure">Active piece</param>
        public void AddTurn(IFigure figure)
        {
            var position = figure.Position;
            log += string.Format(
                "{0} {1} {2}{3} > ", figure.Owner.FiguresColor, figure.GetFigureType(), 
                letters[position.CoordinateX], position.CoordinateY + 1
            );
        }

        public string GetLog() => log;
        /// <summary>
        /// Save the log to a file
        /// </summary>
        /// <param name="filename">Name of file</param>
        public void SaveLog(string filename)
        {
            var path = filename + ".txt";
            using (var sw = new StreamWriter(path, false))
            {
                sw.Write(log);
            }
        }
        /// <summary>
        /// Upload a log from a file
        /// </summary>
        /// <param name="filename">Name of file</param>
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
