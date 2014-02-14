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
    public class PageTests
    {
        private PageRepository _pageRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _pageRepository = new PageRepository();
        }

        [Test]
        public void CanGetByURL()
        {
            string URL = "~/Accounts/Accounts.aspx";
            var p = _pageRepository.GetByURL(URL);
            Assert.IsNotNull(p);
            Assert.AreEqual(1, p.ID);
        }

        [Test]
        public void CanGetChildPagesByParentID()
        {
            int PARENTID = 3;
            var p = _pageRepository.GetChildPagesByParentID(PARENTID);
            Assert.IsNotNull(p);
            Assert.AreEqual(2, p.Count);
            p.OrderBy(o => o.SortOrder);
            Assert.AreEqual(5, p[0].ID);
            Assert.AreEqual(7, p[1].ID);
        }

        [Test]
        public void CanGetRootNodes()
        {
            var p = _pageRepository.GetRootNodes();
            Assert.IsNotNull(p);
            Assert.AreEqual(4, p.Count);
            p.OrderBy(o => o.SortOrder);
            Assert.AreEqual(1, p[0].ID);
            Assert.AreEqual(2, p[1].ID);
        }
    }
}
