using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Entity
{
    public class AssetAllocation
    {
        public int AllocationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public string AllocationDate { get; set; }
        public string ReturnDate { get; set; }
    }
}