using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopClasees.DataTransfer
{
    public class TimberDTO
    {
        public string WoodType { get; set; }
        public int Moisture { get; set; }
        public int Density { get; set; }
    }

    public class LumberDTO
    {
        public TimberDTO Timber { get; set; }
        public SawingOption SawingOption { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Marking { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }

    public class WorkshopDTO
    {
        //public static int TotalWorkshops { get; set; } = 0;
        public int WorkshopNumber { get; set; }
        public List<LumberDTO> Lumbers { get; set; }
    }
}
