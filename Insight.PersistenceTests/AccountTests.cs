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
    public class AccountTests
    {
        private AccountRepository _accountRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _accountRepository = new AccountRepository();
        }

        [Test]
        public void CanGetAccountById()
        {
            const int ACCOUNTID = 1;
            Assert.AreEqual(ACCOUNTID, _accountRepository.GetByID(ACCOUNTID, false).ID);
        }


        [Test]
        public void CanGetByEmailDomain()
        {
            string EMAILDOMAIN = "testinginsight.com";
            var accounts = _accountRepository.GetByEmailDomain(EMAILDOMAIN);
            Assert.AreEqual(2, accounts.Count);
            foreach (var a in accounts)
            {
                Assert.IsInstanceOfType(typeof(Account), a);
            }
        }

        [Test]
        public void CanGetSubAccountsByAccountID()
        {
            int ACCOUNTID = 1;
            var accounts = _accountRepository.GetSubAccountsByAccountID(ACCOUNTID);
            Assert.AreEqual(1, accounts.Count);
            var a = accounts[0];
            Assert.AreEqual(1, a.ParentAccountID);
            Assert.AreEqual(a.ParentAccountID, a.ParentAccount.ID);
        }

        [Test]
        public void CanGetByAccountManagerID()
        {
            int USERID = 1;
            var accounts = _accountRepository.GetByAccountManagerID(USERID);
            Assert.AreEqual(2, accounts.Count);
            var a = accounts[0];
            Assert.AreEqual(1, a.AccountManagerID);
            Assert.AreEqual(a.AccountManagerID, a.AccountManager.ID);
        }

        [Test]
        public void CanGetByIndustryTypeID()
        {
            int INDUSTRYTYPEID = 5;
            var accounts = _accountRepository.GetByIndustryTypeID(INDUSTRYTYPEID);
            Assert.AreEqual(2, accounts.Count);
        }

        [Test]
        public void CanGetParentAccountByEmailDomain()
        {
            string EMAILDOMAIN = "testinginsight.com";
            var account = _accountRepository.GetParentAccountByEmailDomain(EMAILDOMAIN);
            Assert.AreEqual(1, account.ID);
            Assert.IsNull(account.ParentAccountID);
            Assert.IsNull(account.ParentAccount);
        }

        [Test]
        public void CanGetByStatus()
        {
            var accounts = _accountRepository.GetByStatus(true);
            Assert.AreEqual(2, accounts.Count);
        }

        [Test]
        public void CanGetByMarkedForDeletion()
        {
            var accounts = _accountRepository.GetByMarkedForDeletion(false);
            Assert.AreEqual(2, accounts.Count);
        }
    }
}
