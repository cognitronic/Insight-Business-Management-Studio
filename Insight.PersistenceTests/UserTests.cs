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
    public class UserTests
    {
        private UserRepository _userRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        public void CanGetByEmail()
        {
            string EMAIL = "dschreiber@mydatapath.com";
            var u = _userRepository.GetByEmail(EMAIL);
            Assert.AreEqual(1, u.ID);
        }

        [Test]
        public void CanGetByUserName()
        {
            string USERNAME = "dschreiber";
            var u = _userRepository.GetByUserName(USERNAME);
            Assert.AreEqual(1, u.ID);
        }

        [Test]
        public void CanGetByUserNamePassword()
        {
            string USERNAME = "dschreiber";
            string PWD = "4cb9c8a8048fd02294477fcb1a41191a";
            var u = _userRepository.GetByUserNamePassword(USERNAME, PWD);
            var u2 = _userRepository.GetByUserNamePassword(USERNAME, IdeaSeed.Core.Security.SecurityUtils.GetMd5Hash("changeme"));
            Assert.AreEqual(1, u.ID);
            Assert.AreEqual(u, u2);
        }

        [Test]
        public void CanGetByMarkedForDeletion()
        {
            var users = _userRepository.GetByMarkedForDeletion(false);
            Assert.AreEqual(1, users.Count);
        }

        [Test]
        public void CanGetByStatus()
        {
            var users = _userRepository.GetByStatus(true);
            Assert.AreEqual(1, users.Count);
        }

        [Test]
        public void CanSaveOrUpdate()
        {
            var users = _userRepository.GetByID(1, false);

            users.CellPhone = "9999999999";
            _userRepository.SaveOrUpdate(users);
            var u = _userRepository.GetByID(1, false);
            Assert.AreEqual("9999999999", u.CellPhone);
        }

        [Test]
        public void CanGetByDepartmentID()
        {
            int DEPARTMENTID = 1;
            var users = _userRepository.GetByDepartmentID(DEPARTMENTID);
            Assert.AreEqual(1, users.Count);
        }
    }
}
