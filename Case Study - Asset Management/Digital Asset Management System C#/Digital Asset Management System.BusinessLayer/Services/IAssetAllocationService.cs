using DigitalAssetManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Services
{
    public interface IAssetAllocationService
    {
        bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate, DateTime? returnDate = null);
        bool DeallocateAsset(int assetId, int employeeId, DateTime? returnDate);

    }
}