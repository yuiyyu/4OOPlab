using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopClasees
{
    public class Workshop : ICloneable, IComparable<Workshop>
    {
        private static int _totalWorkshops;
        private int _workshopNumber;
        private List<Lumber> _lumbers;

        public Workshop()
        {
            _workshopNumber = ++_totalWorkshops;
            _lumbers = new List<Lumber>();
        }

        public int WorkshopNumber
        {
            get { return _workshopNumber; }
        }

        public List<Lumber> Lumbers
        {
            get { return _lumbers; }
        }

        public void AddLumber(Lumber lumber)
        {
            _lumbers.Add(lumber);
        }

        public object Clone()
        {
            var clonedWorkshop = new Workshop();
            foreach (var lumber in _lumbers)
            {
                clonedWorkshop.AddLumber((Lumber)lumber.Clone());
            }
            return clonedWorkshop;
        }

        public int CompareTo(Workshop other)
        {
            if (other == null) return 1;
            return _workshopNumber.CompareTo(other._workshopNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj is Workshop other)
            {
                return _workshopNumber == other._workshopNumber &&
                       _lumbers.SequenceEqual(other._lumbers);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + _workshopNumber.GetHashCode();
            hash = hash * 31 + (_lumbers != null ? _lumbers.GetHashCode() : 0);
            return hash;
        }

        public override string ToString()
        {
            return $"Workshop #{_workshopNumber}, with {_lumbers.Count} lumbers";
        }

        public string ToShortString()
        {
            int totalCost = _lumbers.Sum(l => l.Quantity * l.UnitPrice);
            return $"Workshop #{_workshopNumber}, Total Cost: {totalCost}";
        }
    }
}
