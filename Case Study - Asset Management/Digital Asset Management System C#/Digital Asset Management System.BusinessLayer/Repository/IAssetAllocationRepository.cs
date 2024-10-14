using DigitalAssetManagement.Entity;
using DigitalAssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Repository
{
    public interface IAssetAllocationRepository
    {
        bool AllocateAsset(int assetId, int employeeId, DateTime allocationDate, DateTime? returnDate = null);
        bool DeallocateAsset(int assetId, int employeeId, DateTime? returnDate);
    }

}