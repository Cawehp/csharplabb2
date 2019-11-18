using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace labb2
{
    public class SortedPosList : IEnumerable<Position>
    {

        List<Position> PositionList;
        List<Position> TempList = new List<Position>();

        public IEnumerator<Position> GetEnumerator()
        {
            return ((IEnumerable<Position>)PositionList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Position>)PositionList).GetEnumerator();
        }

        public SortedPosList()
        {
            PositionList = new List<Position>();

        }

        public override string ToString()
        {
            return string.Join(", ", PositionList);
        }

        public int Count()
        {
            return PositionList.Count;
        }

        public void Add(Position pos)
        {
            if (PositionList.Count() >= 1)
            {
                TempList.Add(pos);
                var SortedList = from x in TempList
                                 orderby x.Xpos, x.Ypos
                                 select x;
                PositionList.Clear();
                foreach (Position p in SortedList)
                {
                    PositionList.Add(p);
                }
            }
            else
            {
                TempList.Add(pos);
                PositionList.Add(pos);
            }
        }

        public bool Remove(Position pos)
        {
            bool isExisting = false;

            foreach (Position p in PositionList.ToList())
            {
                if (p.Equals(pos))
                {
                    PositionList.Remove(p);
                    isExisting = true;
                }
            }

            return isExisting;
        }

        public SortedPosList Clone()
        {
            SortedPosList clonedList = new SortedPosList();

            foreach (Position p in PositionList)
            {
                clonedList.Add(p.Clone());
            }

            return clonedList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList circledList = new SortedPosList();

            foreach (Position p in PositionList)
            {
                bool insideCircle = (Math.Pow(p.Xpos - centerPos.Xpos, 2) +
                    Math.Pow(p.Ypos - centerPos.Ypos, 2)) < Math.Pow(radius, 2);

                if (insideCircle)
                {
                    circledList.Add(p.Clone());
                }
            }

            return circledList;
        }


        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList addedList = new SortedPosList();

            foreach (Position p1 in sp1)
            {
                addedList.Add(p1.Clone());
            }

            foreach (Position p2 in sp2)
            {
                addedList.Add(p2.Clone());
            }

            return addedList;
        }

        public Position this[int i]
        {
            get
            {
                return PositionList[i];
            }
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList subList = new SortedPosList();

            foreach (Position p1 in sp1)
            {
                subList.Add(p1);

                foreach (Position p2 in sp2)
                {
                    if (p1.Equals(p2))
                    {
                        subList.Remove(p1);
                    }
                }
            }

            return subList;
        }
    }
}
