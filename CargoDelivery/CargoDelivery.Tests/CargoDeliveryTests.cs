using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CargoDelivery.Model;

namespace CargoDelivery.Tests
{
    [TestClass]
    public class CargoDeliveryTests
    {
        [TestMethod]
        public void IsRightPrice()
        {
            Order TestOrder = new Order();
            TestOrder.SenderFirstName = "Valeriy";
            TestOrder.SenderLastName = "Kozlov";
            TestOrder.SenderPhoneNumber = "0950000000";
            TestOrder.SenderCity = "Zaporizhzhya";
            TestOrder.ReceiverFirstName = "Elon";
            TestOrder.ReceiverLastName = "Mask";
            TestOrder.ReceiverPhoneNumber = "0957777777";
            TestOrder.ReceiverCity = "Lviv";
            TestOrder.Type = "Documents";
            TestOrder.Weight = 1;
            TestOrder.Size_X = 10;
            TestOrder.Size_Y = 10;
            TestOrder.Size_Z = 10;
            TestOrder.DeclaredPrice = 100;
            Assert.AreEqual(TestOrder.get_price(), 81);
        }

        [TestMethod]
        public void IsAdmin()
        {
            User TestUser = new User();
            TestUser.Username = "admin";
            TestUser.Password = "admin";
            Assert.AreEqual(TestUser.isLoginAsAdmin(), true);
        }

        [TestMethod]
        public void IsUser()
        {
            User TestUser = new User();
            TestUser.Username = "valeriyzp";
            TestUser.Password = "valeriyzp";
            Assert.AreEqual(TestUser.isLoginAsUser(), true);
        }

        [TestMethod]
        public void IsRightNewOrderDateClearance()
        {
            Order NewOrder = new Order();
            Assert.AreEqual(NewOrder.DateClearance, DateTime.Now.ToString("dd.MM.yyyy"));
        }

        [TestMethod]
        public void IsRightUsernameInNewConsumer()
        {
            User NewUser = new User();
            NewUser.Username = "TestUsername";
            Assert.AreEqual(NewUser.getConsumer().Username, "TestUsername");
        }
    }
}
