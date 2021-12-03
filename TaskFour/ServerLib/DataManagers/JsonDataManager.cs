using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ServerLib.DataManagers
{
    /// <summary>
    /// Json converter for server
    /// </summary>
    public static class JsonDataManager
    {
        public static DataContainer ConvertStringToArrays(string stringArray)
        {
            var splitPattern = "]]";
            var arrays = Regex.Split(stringArray, splitPattern);
            arrays[0] += "]]";

            return new DataContainer()
            {
                A = ConvertStringToMatrix(arrays[0]),
                B = ConvertStringToArray(arrays[1])
            };
        }
        public static double[] ConvertStringToArray(string stringArray)
        {
            return JsonConvert.DeserializeObject<double[]>(stringArray);
        }

        public static double[,] ConvertStringToMatrix(string stringArray)
        {
            return JsonConvert.DeserializeObject<double[,]>(stringArray);
        }

        public static string ConvertArrayToString(double[] array)
        {
            return JsonConvert.SerializeObject(array);
        }

        public static string ConvertMatrixToString(double[,] matrix)
        {
            return JsonConvert.SerializeObject(matrix);
        }
    }   
}
