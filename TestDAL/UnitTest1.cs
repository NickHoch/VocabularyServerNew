using System;
using System.Collections.Generic;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace TestDAL
{
    [TestClass]
    public class TestDAL
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<DbSet<Word>> DbWords = new Mock<DbSet<Word>>();
            Mock<VocabularyModel> ctx = new Mock<VocabularyModel>();
            ctx.Setup(x => x.Words).Returns(DbWords.Object);
            DataBaseDAL dal = new DataBaseDAL(ctx.Object);

        }
    }
}
