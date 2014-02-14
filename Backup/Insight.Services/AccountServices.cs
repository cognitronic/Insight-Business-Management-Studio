using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain;
using Insight.Core.Interfaces;
using Insight.Persistence.Repositories;

namespace Insight.Services
{
    public class AccountServices
    {
        #region Accounts
        public IList<Account> GetAllAccounts()
        {
            return new AccountRepository().GetAll();
        }

        public IList<Account> GetAllAccounts(int startRow, int pageSize, out int count)
        { 
            return new AccountRepository().GetPagedList(startRow, pageSize, out count);
        }

        public Account GetByAccountID(int accountID)
        {
            return new AccountRepository().GetByID(accountID, false);
        }

        public Account GetByAccountName(string accountName)
        {
            return new AccountRepository().GetByName(accountName);
        }

        public Account SaveAccount(Account a)
        {
            return new AccountRepository().SaveOrUpdate(a);
        }
        #endregion

        #region Addresses
        public AccountAddress SaveAccountAddress(AccountAddress a)
        {
            if (a.ID != 0)
            {
                return new AccountAddressRepository().SaveOrUpdate(a);
            }
            return new AccountAddressRepository().Save(a);
        }

        public IList<AccountAddress> GetAddressesByAccountID(int accountID)
        {
            return new AccountAddressRepository().GetAddressesByAccountID(accountID);
        }

        public AccountAddress GetAddressByAddressID(int addressID)
        {
            return new AccountAddressRepository().GetByID(addressID, false);
        }
        #endregion

        #region Client Contacts

        public IList<ClientContact> GetAllContacts()
        {
            return new ClientContactRepository().GetAll();
        }

        public IList<ClientContact> GetAllContacts(int startRow, int pageSize, out int count)
        {
            return new ClientContactRepository().GetPagedList(startRow, pageSize, out count);
        }

        public IList<ClientContact> GetAllContactsByAccountID(int id)
        {
            return new ClientContactRepository().GetByAccountID(id);
        }

        public ClientContact SaveContact(ClientContact c)
        {
            return new ClientContactRepository().SaveOrUpdate(c);
        }

        public ClientContact GetContactByID(int id)
        {
            return new ClientContactRepository().GetByID(id, false);
        }

        public ContactEmail GetContactEmailByID(int id)
        {
            return new ClientContactEmailRepository().GetByID(id, false);
        }

        public ContactEmail SaveContactEmail(ContactEmail ce)
        {
            return new ClientContactEmailRepository().SaveOrUpdate(ce);
        }

        public ContactAddress SaveContactAddress(ContactAddress ca)
        {
            return new ClientContactAddressRepository().SaveOrUpdate(ca);
        }
        #endregion
    }
}
