using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopClasees.DataTransfer;

namespace WorkshopClasees.Converters
{
    public class LumberConverter
    {
        public static LumberDTO ToDTO(Lumber lumber)
        {
            return new LumberDTO
            {
                Timber = TimberConverter.ToDTO(lumber.Timber),
                SawingOption = lumber.SawingOption,
                DeliveryDate = lumber.DeliveryDate,
                Marking = lumber.Marking,
                Quantity = lumber.Quantity,
                UnitPrice = lumber.UnitPrice
            };
        }

        public static Lumber FromDTO(LumberDTO dto) => new Lumber(
            TimberConverter.FromDTO(dto.Timber),
            dto.SawingOption,
            dto.DeliveryDate,
            dto.Marking,
            dto.Quantity,
            dto.UnitPrice);
    }
}
