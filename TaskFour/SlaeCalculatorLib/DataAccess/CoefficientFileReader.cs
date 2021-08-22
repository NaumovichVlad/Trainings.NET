using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExceptionsLib;

namespace SlaeCalculatorLib.DataAccess
{
    public class CoefficientFileReader : ICoefficientFileReader
    {
        string coefficientsAFilePath;
        string coefficientsBFilePath;
        string patternFilePath;
        string coefficientsAPattern;
        string coefficientsBPattern;
        string coefficientsASplitPattern;
        string coefficientsBSplitPattern;
        public CoefficientFileReader(string coefficientsAFilePath, string coefficientsBFilePath, string patternFilePath)
        {
            this.coefficientsAFilePath = coefficientsAFilePath;
            this.coefficientsBFilePath = coefficientsBFilePath;
            this.patternFilePath = patternFilePath;
            ReadVerificationTemplate();
        }
        public double[,] ReadACoefficients()
        {
            var coefficients = new List<List<double>>();
            using (StreamReader sr = new StreamReader(coefficientsAFilePath))
            {
                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    var regex = new Regex(coefficientsAPattern);
                    if (regex.IsMatch(line))
                    {
                        var splitPattern = new Regex(coefficientsASplitPattern);
                        var matches = splitPattern.Matches(line);
                        var coefficientsInLine = new List<double>();
                        foreach (var match in matches)
                            coefficientsInLine.Add(Convert.ToDouble(match.ToString()));
                        coefficients.Add(coefficientsInLine);
                    }
                    else
                        throw new FileValidationException();
                }
            }
            return ConvertToMatrix(coefficients);
        }
        private double[,] ConvertToMatrix(List<List<double>> array)
        {
            for (var i = 1; i < array.Count; i++)
                if (array[i].Count != array[i - 1].Count)
                    throw new MatrixDemensionException();
            var matrix = new double[array.Count, array[0].Count];
            for (var i = 0; i < array.Count; i++)
                for (var j = 0; j < array[0].Count; j++)
                    matrix[i, j] = array[i][j];
            return matrix;
        }
        public double[] ReadBCoefficients()
        {
            var coefficients = new List<double>();
            using (StreamReader sr = new StreamReader(coefficientsBFilePath))
            {
                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    var regex = new Regex(coefficientsAPattern);
                    if (regex.IsMatch(line))
                    {
                        var splitPattern = new Regex(coefficientsBSplitPattern);
                        var match = splitPattern.Match(line);
                        coefficients.Add(Convert.ToDouble(match.ToString()));
                    }
                }
            }
            return coefficients.ToArray();
        }
        
        private void ReadVerificationTemplate()
        {
            CheckTemplate();
            using (StreamReader sr = new StreamReader(patternFilePath))
            {
                coefficientsAPattern = sr.ReadLine().Replace("The row of coefficients A: ", string.Empty);
                coefficientsASplitPattern = sr.ReadLine().Replace("Coefficients A: ", string.Empty);
                coefficientsBPattern = sr.ReadLine().Replace("The row of coefficients B: ", string.Empty);
                coefficientsBSplitPattern = sr.ReadLine().Replace("Coefficients B: ", string.Empty);
            }

        }

        private void CheckTemplate()
        {
            var linePattern = "^(The row of coefficients A:\\s.+)" +
                "(Coefficients A:\\s.+)" +
                "(The row of coefficients B:\\s.+)" +
                "(Coefficients B:\\s.+)$";
            using (StreamReader sr = new StreamReader(patternFilePath))
            {
                var option = RegexOptions.Singleline;
                var regex = new Regex(linePattern, option);
                if (!regex.IsMatch(sr.ReadToEnd()))
                    throw new IncorrectTemplateException();
            }
        }
    }
}
