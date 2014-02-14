using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using IdeaSeed.Core.Utils;
using IdeaSeed.Core.Data.NHibernate;
using NHibernate.Criterion;
using Insight.Core.Domain;
using Insight.Persistence.Repositories;

namespace Insight.PersistenceTests
{
    [TestFixture]
    public class ApplicationViewTests
    {
        private PageApplicationViewRepository _appViewRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _appViewRepository = new PageApplicationViewRepository();
        }

        [Test]
        public void CanGetByPageID()
        {
            const int PAGEID = 1;
            var list = _appViewRepository.GetByPageID(PAGEID);;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("AccountListView", list[0].ApplicationView.Name);

        }
    }
}
