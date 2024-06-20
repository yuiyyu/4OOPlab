using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopClasees
{
    public class Lumber : ICloneable, IComparable<Lumber>
    {
        private Timber _timber;
        private SawingOption _sawingOption;
        private DateTime _deliveryDate;
        private int _marking;
        private int _quantity;
        private int _unitPrice;

        public Lumber(Timber timber, SawingOption sawingOption, DateTime deliveryDate, int marking, int quantity, int unitPrice)
        {
            _timber = timber;
            _sawingOption = sawingOption;
            _deliveryDate = deliveryDate;
            _marking = marking;
            _quantity = quantity;
            _unitPrice = unitPrice;
        }

        public Timber Timber
        {
            get { return _timber; }
            set { _timber = value; }
        }

        public SawingOption SawingOption
        {
            get { return _sawingOption; }
            set { _sawingOption = value; }
        }

        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            set { _deliveryDate = value; }
        }

        public int Marking
        {
            get { return _marking; }
            set { _marking = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public int UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public object Clone()
        {
            return new Lumber((Timber)_timber.Clone(), _sawingOption, _deliveryDate, _marking, _quantity, _unitPrice);
        }

        public int CompareTo(Lumber other)
        {
            if (other == null) return 1;
            return _deliveryDate.CompareTo(other._deliveryDate);
        }

        public override bool Equals(object obj)
        {
            if (obj is Lumber other)
            {
                return _timber.Equals(other._timber) &&
                       _sawingOption == other._sawingOption &&
                       _deliveryDate == other._deliveryDate &&
                       _marking == other._marking &&
                       _quantity == other._quantity &&
                       _unitPrice == other._unitPrice;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + _timber.GetHashCode();
            hash = hash * 31 + _sawingOption.GetHashCode();
            hash = hash * 31 + _deliveryDate.GetHashCode();
            hash = hash * 31 + _marking.GetHashCode();
            hash = hash * 31 + _quantity.GetHashCode();
            hash = hash * 31 + _unitPrice.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"Lumber with timber: {_timber}, sawing option: {_sawingOption}, delivery date: {_deliveryDate}, marking: {_marking}, quantity: {_quantity}, unit price: {_unitPrice}";
        }
    }
}
