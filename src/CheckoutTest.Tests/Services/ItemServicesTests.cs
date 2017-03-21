using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutTest.Core;
using CheckoutTest.Core.Entities;
using CheckoutTest.Core.Services;
using CheckoutTest.Core.Repositories.Abstract;
using NUnit;
using Moq;
namespace CheckoutTest.Core.Services.Tests
{
    [TestClass()]
    public class itemServicesTests
    {
        [TestMethod()]
        public void ValidateOnCreateTest_WhenTitleItsUnique()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            var service = new ItemService(repo.Object);
            var res = service.ValidateOnCreate(item);

            Assert.AreEqual(true, res.ExecutedSuccesfully);
        }
        [TestMethod()]
        public void ValidateOnCreateTest_WhenTitleItsNotUnique()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetByFilter(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Func<Item, bool>>()))
                .Returns(new List<Item> { item });

            var service = new ItemService(repo.Object);
            var res = service.ValidateOnCreate(item);

            Assert.IsFalse(res.ExecutedSuccesfully);
        }
        [TestMethod()]
        public void ValidateOnCreateTest_WhenItemItsNull()
        {
            var repo = new Mock<IItemRepository>();
            var service = new ItemService(repo.Object);
            var res = service.ValidateOnCreate(null);

            Assert.IsFalse(res.ExecutedSuccesfully);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.Add(item));
            var service = new ItemService(repo.Object);
            var res = service.Create(item);

            Assert.IsTrue(res.ExecutedSuccesfully);
        }

        [TestMethod()]
        public void GetByIdTest_found()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetById(It.IsAny<int>())).Returns(item);

            var service = new ItemService(repo.Object);
            var res = service.GetById(1);

            Assert.AreEqual(res, item);
        }
        [TestMethod()]
        public void GetByIdTest_Notfound()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetById(It.IsAny<int>()));

            var service = new ItemService(repo.Object);
            var res = service.GetById(1);

            Assert.IsNull(res);
        }

        [TestMethod()]
        public void GetItemByNameTest_Found()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetByFilter(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Func<Item, bool>>()))
                .Returns(new List<Item> { item });

            var service = new ItemService(repo.Object);
            var res = service.GetItemByName("Edu");

            Assert.AreEqual(res, item);
        }

        [TestMethod()]
        public void GetItemByNameTest_NotFound()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetByFilter(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Func<Item, bool>>()));

            var service = new ItemService(repo.Object);
            var res = service.GetItemByName("Edu");

            Assert.IsNull(res);
        }

        [TestMethod()]
        public void GetItemsTest_Found()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetAll())
                .Returns(new List<Item> { item });

            var service = new ItemService(repo.Object);
            var res = service.GetItems();

            CollectionAssert.Equals( new List<Item> { item },res);
        }

        [TestMethod()]
        public void GetItemsTest_NotFound()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetAll());

            var service = new ItemService(repo.Object);
            var res = service.GetItems();

            Assert.IsNull(res);
        }

        [TestMethod()]
        public void GetItemsPaginatedTest_Found()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetByFilter(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Func<Item, bool>>()))
                .Returns(new List<Item> { item });

            var service = new ItemService(repo.Object);
            var res = service.GetItems(0, 100);

            CollectionAssert.Equals(new List<Item> { item }, res);
        }
        [TestMethod()]
        public void GetItemsPaginatedTest_NotFound()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetByFilter(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Func<Item, bool>>()));

            var service = new ItemService(repo.Object);
            var res = service.GetItems(0, 100);

            CollectionAssert.Equals(new List<Item> { item }, res);
        }


        [TestMethod()]
        public void ValidateOnUpdateTest_WhenItemDoesNotExist()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetById(It.IsAny<int>()));

            var service = new ItemService(repo.Object);
            var res = service.ValidateOnUpdate(item);

            Assert.IsFalse(res.ExecutedSuccesfully);
        }
        [TestMethod()]
        public void ValidateOnUpdateTest_WhenTitleItsNotUnique()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetById(It.IsAny<int>())).Returns(item);
            repo.Setup(x => x.GetByFilter(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Func<Item, bool>>()))
                .Returns(new List<Item> { item });

            var service = new ItemService(repo.Object);
            var res = service.ValidateOnUpdate(item);

            Assert.IsFalse(res.ExecutedSuccesfully);
        }
        [TestMethod()]
        public void ValidateOnUpdateTest_WhenTitleItsUnique()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetById(It.IsAny<int>())).Returns(item);

            var service = new ItemService(repo.Object);
            var res = service.ValidateOnUpdate(item);

            Assert.IsTrue(res.ExecutedSuccesfully);
        }
        public void ValidateOnUpdateTest_WhenItemIsNull()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetById(It.IsAny<int>()));

            var service = new ItemService(repo.Object);
            var res = service.ValidateOnUpdate(item);

            Assert.IsFalse(res.ExecutedSuccesfully);
        }
        [TestMethod()]
        public void UpdateTest()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };

            repo.Setup(x => x.GetById(It.IsAny<int>())).Returns(item);
            repo.Setup(x => x.Update(It.IsAny<Item>()));

            var service = new ItemService(repo.Object);
            var res = service.Update(new Item() { Title = "Name2" });

            Assert.IsTrue(res.ExecutedSuccesfully);
        }

        [TestMethod()]
        public void ValidateOnDeleteTest_WhenItemIsNull()
        {
            var repo = new Mock<IItemRepository>();

            var service = new ItemService(repo.Object);
            var res = service.ValidateOnDelete(null);

            Assert.IsFalse(res.ExecutedSuccesfully);
        }
        [TestMethod()]
        public void DeleteTest()
        {
            var repo = new Mock<IItemRepository>();
            var item = new Item() { Title = "Edu" };
            
            repo.Setup(x => x.Remove(It.IsAny<int>()));
            repo.Setup(x => x.GetById(It.IsAny<int>())).Returns(item);

            var service = new ItemService(repo.Object);
            var res = service.Delete(1);

            Assert.IsTrue(res.ExecutedSuccesfully);
        }
    }
}