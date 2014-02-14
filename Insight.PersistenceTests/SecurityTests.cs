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
    public class SecurityTests
    {
        private ModuleRepository _moduleRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _moduleRepository = new ModuleRepository();
        }

        [Test]
        public void CanGetByStatus()
        {
            var m = _moduleRepository.GetByStatus(true);
            Assert.IsNotNull(m);
            Assert.AreEqual(4, m.Count);
        }
    }
}
