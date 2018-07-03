﻿using BLL;
using BLL.DTOs;
using BLL.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.ServiceModel;
using WCF;
using WCF.Mapping;
using WCF.DCs;
using System.Collections.Generic;

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
            mock.Setup(m => m.GetUserIdByCredential(It.IsAny<CredentialDTO>())).Returns(1);
            int? test = wcf.GetUserIdByCredential(new CredentialDC { Email = "true", Password = "true" });
            Assert.AreEqual(1, test);
        }

        [TestMethod]
        public void AddUser1()
        {
            mock.Setup(m => m.AddUser(It.IsAny<CredentialExtnDTO>())).Returns(true);
            Assert.IsTrue(wcf.AddUser(new CredentialExtnDC()));
        }

        [TestMethod]
        public void DeleteWord1()
        {
            mock.Setup(m => m.DeleteWord(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);
            Assert.IsTrue(wcf.DeleteWord(5));
        }

        [TestMethod]
        public void UpdateWord1()
        {
            wcf.UpdateWord(null);
        }

        [TestMethod]
        public void UpdateWord2()
        {
            wcf.UpdateWord(new WordDC());
        }

        [TestMethod]
        public void GetWords1()
        {
            mock.Setup(m => m.GetWords(It.IsInRange(1, 10, Range.Inclusive))).Returns(new List<WordDTO>());
        
            Assert.IsTrue(wcf.GetWords(1) is List<WordDC>);
        }

        [TestMethod]
        public void GetWords2()
        {
            mock.Setup(m => m.GetWords(It.IsInRange(1, 10, Range.Inclusive))).Returns(new List<WordDTO> {new WordDTO()});

            Assert.AreEqual(1,wcf.GetWords(1).Count);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetWords3()
        {
            List<WordDTO> temp = null;
            mock.Setup(m => m.GetWords(It.IsInRange(1, 10, Range.Inclusive))).Returns(temp);
            wcf.GetWords(1);
        }

        [TestMethod]
        public void GetNotLearnedWords1()
        {
            mock.Setup(m => m.GetNotLearnedWords(It.IsInRange(1, 10,
                Range.Inclusive),It.IsInRange(1, 10, Range.Inclusive))).Returns(new List<WordDTO>());

            Assert.IsTrue(wcf.GetNotLearnedWords(1,1) is List<WordDC>);
        }

        [TestMethod]
        public void GetNotLearnedWords2()
        {
            mock.Setup(m => m.GetNotLearnedWords(It.IsInRange(1, 10, Range.Inclusive),
                It.IsInRange(1, 10, Range.Inclusive))).Returns(new List<WordDTO> { new WordDTO()});

            Assert.AreEqual(1, wcf.GetNotLearnedWords(1,1).Count);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetNotLearnedWords3()
        {
            List<WordDTO> temp = null;
            mock.Setup(m => m.GetNotLearnedWords(It.IsInRange(1, 10, Range.Inclusive),
                It.IsInRange(1, 10, Range.Inclusive))).Returns(temp);
            wcf.GetNotLearnedWords(1,1);
        }

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