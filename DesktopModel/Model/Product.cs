using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopModel.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Items { get; set; }
        public int? Quantity { get; set; }
        public string ApprovedBy { get; set; }
        public string TakenBy { get; set; }
        public DateTime TakenDate { get; set; }
        public bool Check { get; set; }
        public int? AvailableQuan { get; set; }
    }
}
