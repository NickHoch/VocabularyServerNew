using BLL;
using BLL.DTOs;
using BLL.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.ServiceModel;
using WCF;
using WCF.Mapping;
using WCF.DCs;

namespace TestWCF
{
    [TestClass]
    public class TestWCF
    {
        Mock<IDataBaseBLL> mock;
        Vocabulary wcf;
        [TestInitialize]
        public void TestUnit()
        {
            mock = new Mock<IDataBaseBLL>();

            wcf = new Vocabulary(mock.Object);
        }

        [TestCleanup]
        public void TestClean()
        {
            mock = null;
            wcf = null;
        }

        [TestMethod]
        public void IsEmailAddressExists1()
        {
            mock.Setup(m => m.IsEmailAddressExists(It.IsIn("true"))).Returns(true);

            bool email = wcf.IsEmailAddressExists("true");
            Assert.IsTrue(email);
        }

        [TestMethod]
        public void IsEmailAddressExists2()
        {
            mock.Setup(m => m.IsEmailAddressExists("true")).Returns(true);
            bool email = wcf.IsEmailAddressExists("false");
            Assert.IsFalse(email);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void IsEmailAddressExists3()
        {
            mock.Setup(m => m.IsEmailAddressExists("")).Throws(new Exception());
            bool email = wcf.IsEmailAddressExists("");
        }

        [TestMethod]
        public void IsDictionaryNameExists1()
        {
            mock.Setup(m => m.IsDictionaryNameExists("Animals", 1)).Returns(true);
            bool test = wcf.IsDictionaryNameExists("Animals", 1);
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void IsDictionaryNameExists2()
        {
            mock.Setup(m => m.IsDictionaryNameExists("Animals", 1)).Returns(true);
            bool test = wcf.IsDictionaryNameExists("", 0);
            Assert.IsFalse(test);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void IsDictionaryNameExists3()
        {
            mock.Setup(m => m.IsDictionaryNameExists("Animals", 1)).Throws(new Exception());
            bool test = wcf.IsDictionaryNameExists("Animals", 1);
        }

        [TestMethod]
        public void GetUserIdByCredential1()
        {
            mock.Setup(m => m.GetUserIdByCredential(new CredentialDTO { Email = "true", Password = "true" })).Returns(1);
            int? test = wcf.GetUserIdByCredential(new CredentialDC { Email = "true", Password = "true" });
            Assert.AreEqual(1, test);
        }

        //[TestMethod]
        //public void GetUserIdByCredential2()
        //{
        //    mock.Setup(m => m.GetUserIdByCredential(new CredentialDTO { Email = "true", Password = "false" })).Returns(1);
        //    int? test = wcf.GetUserIdByCredential(new CredentialDC { Email = "true", Password = "true" });
        //    Assert.AreEqual(1, test);
        //}


        //[TestMethod]
        //[ExpectedException(typeof(FaultException))]
        //public void GetUserIdByCredential3()
        //{
        //    wcf.GetUserIdByCredential(new CredentialDC() { Email ="" , Password=""});
        //}

        [TestMethod]
        public void MappingDCtoDTO1()
        {
            Assert.IsNull(WCF.Mapping.MappingCredential.MappingDCtoDTO(null));
        }


        [TestMethod]
        public void MappingDCtoDTO2()
        {
            var test = WCF.Mapping.MappingCredential.MappingDCtoDTO(new CredentialDC { Email = "true", Password = "true" });

            Assert.AreEqual("true",test.Email);
            Assert.AreEqual("true", test.Password);
        }

    }
}
