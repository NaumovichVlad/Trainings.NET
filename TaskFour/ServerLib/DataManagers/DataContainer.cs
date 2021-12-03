namespace ServerLib.DataManagers
{
    /// <summary>
    /// Contains system of equations
    /// </summary>
    public class DataContainer
    {
        /// <summary>
        /// Matrix A
        /// </summary>
        public double[,] A { get; set; }
        /// <summary>
        /// Coefficients B
        /// </summary>
        public double[] B { get; set; }
    }
        
}
