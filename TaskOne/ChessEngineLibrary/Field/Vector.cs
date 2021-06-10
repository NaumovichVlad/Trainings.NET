using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public class Vector
    {
        public int CoordinateX { get; private set; }
        public int CoordinateY { get; private set; }

        public Vector (int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public void ChangeCoordinates(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) 
                return false;

            Vector vector = (Vector)obj;
            return (CoordinateX == vector.CoordinateX && CoordinateY == vector.CoordinateY);
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + CoordinateX;
            result = prime * result + CoordinateY;
            return result;
        }
    }
}
