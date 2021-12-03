using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SlaeCalculatorLib
{
    /// <summary>
    /// Reading data from a file
    /// </summary>
    public class FileManager
    {
        private const string _deffaultPatternFilePath = @"../../TestsData/pattern.txt";
        private readonly string _pattern;
        public FileManager(string patternFilePath)
        {
            _pattern = LoadPattern(patternFilePath);
        }
        public FileManager()
        {
            _pattern = LoadPattern();
        }

        private string LoadPattern()
        {
            return LoadPattern(_deffaultPatternFilePath);
        }

        private string LoadPattern(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }

        public double[,] LoadArrayA(string path)
        {
            var lines = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return ConvertToMatrix(lines);
        }
        private double[,] ConvertToMatrix(List<string> lines)
        {
            var matrix = new List<List<double>>();
            for (var i = 0; i < lines.Count; i++)
            {
                List<double> matrixRow = new List<double>();
                var matches = Regex.Matches(lines[i], _pattern);
                foreach (Match match in matches)
                    matrixRow.Add(double.Parse(match.Value));
                matrix.Add(matrixRow);
            }
            var matrixArr = new double[matrix.Count, matrix[0].Count];
            for (var i = 0;i < matrixArr.GetLength(0); i++)
                for (var j = 0; j < matrixArr.GetLength(1); j++)
                    matrixArr[i, j] = matrix[i][j];
            return matrixArr;
        }

        public double[] LoadArrayB(string path)
        {
            var lines = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return ConvertToArray(lines);
        }

        private double[] ConvertToArray(List<string> lines)
        {
            var array = new List<double>();
            for (var i = 0; i < lines.Count; i++)
                array.Add(double.Parse(Regex.Match(lines[i], _pattern).Value));
            return array.ToArray();
        }
    }
}
