using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopClasees.DataTransfer;

namespace WorkshopClasees.Converters
{
    public class TimberConverter
    {
        public static TimberDTO ToDTO(Timber timber)
        {
            return new TimberDTO
            {
                WoodType = timber.WoodType,
                Moisture = timber.Moisture,
                Density = timber.Density
            };
        }

        public static Timber FromDTO(TimberDTO dto) => new Timber(
            dto.WoodType,
            dto.Moisture,
            dto.Density);
    }
}
