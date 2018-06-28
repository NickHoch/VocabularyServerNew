using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WCF;

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

        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
