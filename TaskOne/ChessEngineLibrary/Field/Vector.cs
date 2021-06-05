using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public class Vector
    {
        int coordinateX;
        int coordinateY;
        
        public Vector (int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }

        public int[] GetCoordinates()
        {
            return new int[2] { coordinateX, coordinateY };
        }

        public void ChangeCoordinates(int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }
    }
}
