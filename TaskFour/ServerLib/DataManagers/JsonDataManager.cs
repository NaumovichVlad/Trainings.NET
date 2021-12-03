using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ServerLib.DataManagers
{
    public static class JsonDataManager
    {
        public static DataContainer ConvertStringToArrays(string stringArray)
        {
            var splitPattern = new char[] { '}' };
            var arrays = stringArray.Split(splitPattern, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < arrays.Length; i++)
                arrays[i] += '}';

            return new DataContainer()
            {
                A = ConvertStringToMatrix(arrays[0]),
                B = ConvertStringToArray(arrays[0])
            };
        }
        public static double[] ConvertStringToArray(string stringArray)
        {
            return JsonSerializer.Deserialize<double[]>(stringArray);
        }

        public static double[,] ConvertStringToMatrix(string stringArray)
        {
            return JsonSerializer.Deserialize<double[,]>(stringArray);
        }

        public static string ConvertArrayToString(double[] array)
        {
            return JsonSerializer.Serialize<double[]>(array);
        }

        public static string ConvertMatrixToString(double[,] matrix)
        {
            return JsonSerializer.Serialize(matrix);
        }
    }   
}
