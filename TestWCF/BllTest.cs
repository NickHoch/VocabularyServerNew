using System;
using BLL;
using DAL;
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
        public void TestMethod1()
        {
        }
        
    }
}
