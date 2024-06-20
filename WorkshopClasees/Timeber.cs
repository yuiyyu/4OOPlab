using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopClasees
{
    public class Timber : ICloneable, IComparable<Timber>
    {
        private string _woodType;
        private int _moisture;
        private int _density;

        public Timber(string woodType, int moisture, int density)
        {
            _woodType = woodType;
            _moisture = moisture;
            _density = density;
        }

        public string WoodType
        {
            get => _woodType;
            set => _woodType = value;
        }

        public int Moisture
        {
            get => _moisture;
            set => _moisture = value;
        }

        public int Density
        {
            get => _density;
            set => _density = value;
        }

        public object Clone()
        {
            return new Timber(_woodType, _moisture, _density);
        }

        public int CompareTo(Timber other)
        {
            if (other == null) return 1;
            return _density.CompareTo(other._density);
        }

        public override bool Equals(object obj)
        {
            if (obj is Timber other)
            {
                return _woodType == other._woodType &&
                       _moisture == other._moisture &&
                       _density == other._density;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_woodType, _moisture, _density);
        }

        public override string ToString()
        {
            return $"{_woodType} (moisture: {_moisture}, density: {_density})";
        }
    }
}
