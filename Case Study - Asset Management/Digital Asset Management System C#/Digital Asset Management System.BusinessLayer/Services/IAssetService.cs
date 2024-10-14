using DigitalAssetManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Business.Services
{
    public interface IAssetService
    {
        bool AddAsset(Asset asset);
        bool UpdateAsset(Asset asset);
        bool DeleteAsset(int assetId);
        Asset GetAssetById(int assetId);
        List<Asset> GetAllAssets();
    }
}