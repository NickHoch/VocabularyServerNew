using System;
using BLL;
using BLL.DTOs;
using DAL;
using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestWCF
{
    [TestClass]
    public class BllTest
    {
        Mock<IDataBaseDAL> mock;
        DataBaseBLL Bll;

        [TestInitialize]
        public void TestUnit()
        {
            mock = new Mock<IDataBaseDAL>();

            Bll = new DataBaseBLL(mock.Object);
        }

        [TestCleanup]
        public void TestClean()
        {
            mock = null;
            Bll = null;
        }

        [TestMethod]
        public void IsEmailAddressExists1()
        {
            mock.Setup(m => m.IsEmailAddressExists(It.IsAny<string>())).Returns(true);
            Assert.IsTrue(Bll.IsEmailAddressExists(""));
        }

        [TestMethod]
        public void IsDictionaryNameExists1()
        {
            mock.Setup(m => m.IsDictionaryNameExists(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            Assert.IsTrue(Bll.IsDictionaryNameExists("",1));
        }

        [TestMethod]
        public void GetUserIdByCredential()
        {
            mock.Setup(m => m.GetUserIdByCredential(It.Is<Credential>(x=>x.Email== "myemail"))).Returns(1);
            Assert.IsNotNull(Bll.GetUserIdByCredential(new CredentialDTO() { Email= "myemail" }));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetUserIdByCredential2()
        {
            mock.Setup(m => m.GetUserIdByCredential(It.Is<Credential>(x=>x==null))).Throws(new NullReferenceException());
            Bll.GetUserIdByCredential(null);
        }

        [TestMethod]
        public void GetUserIdByCredential3()
        {
            int? tmp = null;
            mock.Setup(m => m.GetUserIdByCredential(It.Is<Credential>(x=>x.Email!="myemail"))).Returns(tmp);
            Assert.IsNull(Bll.GetUserIdByCredential(new CredentialDTO()));
        }

        [TestMethod]
        public void AddUser1()
        {
            mock.Setup(m => m.AddCredential(It.IsAny<CredentialExtn>())).Returns(true);
            mock.Setup(m => m.AddDictionary(It.IsAny<DictionaryExtn>())).Returns(true);
            mock.Setup(m => m.StartInitializeDictionary(It.IsAny<DictionaryExtn>())).Returns(true);
            Assert.IsTrue(Bll.AddUser(new CredentialExtnDTO()));
        }

        [TestMethod]
        public void AddWord1()
        {
            mock.Setup(m => m.AddWord(It.IsAny<Word>())).Returns(true);
            Assert.IsTrue(Bll.AddWord(new WordDTO(),1));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddWord2()
        {
            mock.Setup(m => m.AddWord(It.Is<Word>(x=>x.Dictionary.Id<=0 || x.Dictionary==null))).Throws(new NullReferenceException());
            Assert.IsTrue(Bll.AddWord(new WordDTO(), 0));
        }

        [TestMethod]
        public void DeleteWord()
        {
            mock.Setup(m => m.DeleteWord(It.Is<int>(x => x > 0))).Returns(true);
            Assert.IsTrue(Bll.DeleteWord(1));
        }

        [TestMethod]
        public void UpdateWord1()
        {
            Bll.UpdateWord(new WordDTO());
        }



    }
}
