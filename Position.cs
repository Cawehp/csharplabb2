using System;
namespace labb2
{
    public class Position
    {
        public double Xpos { get; set; }
        public double Ypos { get; set; }
        public double Distance { get; set; }

        public Position(double x, double y)
        {
            this.Xpos = Math.Abs(x);
            this.Ypos = Math.Abs(y);
        }

        public double Length()
        {
            Distance = Math.Sqrt(Math.Pow(Xpos, 2) + Math.Pow(Ypos, 2));
            return Distance;
        }

        public bool Equals(Position p)
        {
            if (Xpos == p.Xpos && Ypos == p.Ypos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Position Clone()
        {
            return new Position(Xpos, Ypos);
        }

        public override string ToString()
        {
            return "(" + Xpos + ", " + Ypos + ")";
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            else if (Math.Abs(p1.Length() - p2.Length()) < 0.000001)
            {
                if (p1.Xpos > p2.Xpos)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }
            else if (Math.Abs(p1.Length() - p2.Length()) < 0.000001)
            {
                if (p1.Xpos < p2.Xpos)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Position operator +(Position p1, Position p2)
        {
            var addedX = p1.Xpos + p2.Xpos;
            var addedY = p1.Ypos + p2.Ypos;
            return new Position(addedX, addedY);
        }

        public static Position operator -(Position p1, Position p2)
        {
            var subtractedX = p1.Xpos - p2.Xpos;
            var subtractedY = p1.Ypos - p2.Ypos;
            return new Position(subtractedX, subtractedY);
        }

        public static double operator %(Position p1, Position p2)
        {
            var distance = Math.Sqrt(Math.Pow((p1.Xpos - p2.Xpos), 2) + Math.Pow((p1.Ypos - p2.Ypos), 2));
            return distance;
        }
    }
}
