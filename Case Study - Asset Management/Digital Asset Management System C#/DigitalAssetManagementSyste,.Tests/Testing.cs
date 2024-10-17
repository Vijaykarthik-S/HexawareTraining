using NUnit.Framework;
using DigitalAssetManagement.Business.Services;
using DigitalAssetManagement.Entity;
using DigitalAssetManagement.Business.Repository;
using System;
using NUnit;

namespace DigitalAssetManagementSystem.Tests
{
    [TestFixture]
    public class AssetServiceTests
    {
        private AssetService _assetService;

        [SetUp]
        public void Setup()
        {
           
            _assetService = new AssetService(new AssetRepository());
        }

        [Test]
        public void AddAsset_Should_Return_True()
        {
            var asset = new Asset {AssetId  = 1, Name = "Test Asset" };

            bool result = _assetService.AddAsset(asset);

            Assert.IsTrue(result);
        }

        [Test]
        public void GetAssetById_Should_Return_Asset()
        {
            int assetId = 1;

            Asset result = _assetService.GetAssetById(assetId);

            Assert.IsNotNull(result);
            Assert.AreEqual(assetId, result.AssetId);
        }
    }

    [TestFixture]
    public class AssetAllocationServiceTests
    {
        private AssetAllocationService _assetAllocationService;

        [SetUp]
        public void Setup()
        {
            
            _assetAllocationService = new AssetAllocationService(new AssetAllocationRepository());
        }

        [Test]
        public void AllocateAsset_Should_Return_True()
        {
            bool result = _assetAllocationService.AllocateAsset(1, 1, DateTime.Now);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeallocateAsset_Should_Return_True()
        {
            bool result = _assetAllocationService.DeallocateAsset(1, 1, DateTime.Now);

            Assert.IsTrue(result);
        }
    }

    [TestFixture]
    public class MaintenanceRecordServiceTests
    {
        private MaintenanceRecordService _maintenanceRecordService;

        [SetUp]
        public void Setup()
        {
            _maintenanceRecordService = new MaintenanceRecordService(new MaintenanceRecordsRepository());
        }

        [Test]
        public void PerformMaintenance_Should_Return_True()
        {
            bool result = _maintenanceRecordService.PerformMaintenance(1, DateTime.Now, "Routine Check", 100);

            Assert.IsTrue(result);
        }
    }

    [TestFixture]
    public class ReservationServiceTests
    {
        private ReservationService _reservationService;

        [SetUp]
        public void Setup()
        {
            _reservationService = new ReservationService(new ReservationRepository());
        }

        [Test]
        public void ReserveAsset_Should_Return_True()
        {
            bool result = _reservationService.ReserveAsset(1, 1, DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now.AddDays(5));

            Assert.IsTrue(result);
        }

        [Test]
        public void WithdrawReservation_Should_Return_True()
        {
            bool result = _reservationService.WithdrawReservation(1);

            Assert.IsTrue(result);
        }
    }
}
