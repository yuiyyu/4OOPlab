using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopClasees.DataTransfer;

namespace WorkshopClasees.Converters
{
    public class WorkshopConverter
    {
        public static WorkshopDTO ToDTO(Workshop workshop)
        {
            var dto = new WorkshopDTO
            {
                WorkshopNumber = workshop.WorkshopNumber,
                Lumbers = new List<LumberDTO>()
            };
            foreach(var lumber in workshop.Lumbers)
            {
                dto.Lumbers.Add(LumberConverter.ToDTO(lumber));
            }
            return dto;
        }

        public static Workshop FromDTO(WorkshopDTO dto)
        {
            var workshop = new Workshop();
            foreach (var lumberDTO in dto.Lumbers)
            {
                workshop.AddLumber(LumberConverter.FromDTO(lumberDTO));
            }

            return workshop;
        }
    }
}
