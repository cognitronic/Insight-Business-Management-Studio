using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Insight.Core.Domain;
using Insight.Persistence.Repositories;
using System.Collections.Generic;
using System.Web.Routing;

namespace Insight.Web.Routing
{
    public class RouteBuilder
    {
        public RouteCollection Routes { get; private set; }
        public RouteBuilder(RouteCollection routes)
        {
            Routes = routes;
        }

        public void Run()
        {
            var rootPages = new PageRepository().GetRootNodes();
            

            Route modalRoute = new Route("Modals/Modal/{*value}", new SalesRouteHandler("~/Modals/Modal.aspx"));
            Routes.Add(modalRoute);

            //Route wcfRoute = new Route("Services/WCFService/{*value}", new SalesRouteHandler("~/Services/Service.svc"));
            //Routes.Add(wcfRoute);

            Route defaultRoute = new Route("Home", new SalesRouteHandler("~/Default.aspx"));
            Routes.Add(defaultRoute);


            
            BuildUtilityRoutes();
            BuildAccountRoutes();
            BuildSalesRoutes();
            BuildProjectRoutes();
            BuildSupportRoutes();
            
            //Errors 404's mostly
            //Route errorRoute = new Route("{*catchall}", new ErrorRouteHandler("~/UtilityPages/Error.aspx"));
            //Routes.Add(errorRoute);
        }

        public List<ApplicationRoute> RemoveDuplicates(List<ApplicationRoute> inputList)
        {
            Dictionary<ApplicationRoute, int> uniqueStore = new Dictionary<ApplicationRoute, int>();
            List<ApplicationRoute> finalList = new List<ApplicationRoute>();

            foreach (ApplicationRoute currValue in inputList)
            {
                if (!uniqueStore.ContainsKey(currValue))
                {
                    uniqueStore.Add(currValue, 0);
                    finalList.Add(currValue);
                }
            }
            return finalList;
        }

        public void BuildAccountRoutes()
        {
            //PROPERTIES
            Route accountRoute = new Route("Accounts/Name={accountname}/Properties", new AccountRouteHandler("~/Accounts/AccountProperties.aspx"));
            accountRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountRoute);

            var accountByIDRoute = new Route("Accounts/ID={accountid}/Properties", new AccountRouteHandler("~/Accounts/AccountProperties.aspx"));
            accountByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountByIDRoute);

            //ADDRESSES
            Route accountAddressRoute = new Route("Accounts/Name={accountname}/Addresses/ID={addressID}", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountAddressRoute.Constraints = new RouteValueDictionary { { "addressID", @"^\d+" } };
            Routes.Add(accountAddressRoute);

            var accountAddressByIDRoute = new Route("Accounts/ID={accountid}/Addresses/ID={addressID}", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountAddressByIDRoute.Constraints = new RouteValueDictionary { { "addressID", @"^\d+" } };
            Routes.Add(accountAddressByIDRoute);

            var accountAddressDefaultRoute = new Route("Accounts/Name={accountname}/Addresses/{new}", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressDefaultRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountAddressDefaultRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountAddressDefaultRoute);

            var accountAddressDefaultByIDRoute = new Route("Accounts/ID={accountid}/Addresses/New", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressDefaultByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountAddressDefaultByIDRoute.Constraints = new RouteValueDictionary { { "new", "new" } };
            Routes.Add(accountAddressDefaultByIDRoute);

            var accountAddressListRoute = new Route("Accounts/Name={accountname}/Addresses", new AccountAddressRouteHandler("~/Accounts/AddressList.aspx"));
            accountAddressListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountAddressListRoute);

            var accountAddressIDListRoute = new Route("Accounts/ID={accountid}/Addresses", new AccountAddressRouteHandler("~/Accounts/AddressList.aspx"));
            accountAddressIDListRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountAddressIDListRoute);

            //CONTACTS LIST
            Route accountContactRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactRoute);

            Route accountContactByNameRoute = new Route("Accounts/Name={accountname}/Contacts/Name={contactName}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactByNameRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactByNameRoute.Constraints = new RouteValueDictionary { { "contactName", @"^\D+" } };
            Routes.Add(accountContactByNameRoute);

            Route accountContactEmailRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Email/ID={emailid}", new ContactEmailRouteHandler("~/Accounts/ContactEmailProperties.aspx"));
            accountContactEmailRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactEmailRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactEmailRoute.Constraints = new RouteValueDictionary { { "emailid", @"^\d+" } };
            Routes.Add(accountContactEmailRoute);

            Route accountContactEmailListRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Email", new ContactEmailRouteHandler("~/Accounts/ContactEmailList.aspx"));
            accountContactEmailListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactEmailListRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactEmailListRoute);

            Route accountContactEmailListNewRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Email/{new}", new ContactEmailRouteHandler("~/Accounts/ContactEmailProperties.aspx"));
            accountContactEmailListNewRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactEmailListNewRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactEmailListNewRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountContactEmailListNewRoute);

            Route accountContactAddressRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Addresses/ID={addressID}", new AccountContactAddressRouteHandler("~/Accounts/ContactAddressProperties.aspx"));
            accountContactAddressRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactAddressRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactAddressRoute.Constraints = new RouteValueDictionary { { "addressID", @"^\d+" } };
            Routes.Add(accountContactAddressRoute);

            Route accountContactAddressNewRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Addresses/{new}", new AccountContactAddressRouteHandler("~/Accounts/ContactAddressProperties.aspx"));
            accountContactAddressNewRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactAddressNewRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactAddressNewRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountContactAddressNewRoute);

            Route accountContactAddressListRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Addresses", new AccountContactRouteHandler("~/Accounts/ContactAddressList.aspx"));
            accountContactAddressListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactAddressListRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactAddressListRoute);

            var accountContactByIDRoute = new Route("Accounts/ID={accountid}/Contacts/ID={contactID}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountContactByIDRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactByIDRoute);

            var accountContactByIDByNameRoute = new Route("Accounts/ID={accountid}/Contacts/Name={contactName}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactByIDByNameRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountContactByIDByNameRoute.Constraints = new RouteValueDictionary { { "contactName", @"^\D+" } };
            Routes.Add(accountContactByIDByNameRoute);

            var accountContactDefaultRoute = new Route("Accounts/Name={accountname}/Contacts/{new}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactDefaultRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactDefaultRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountContactDefaultRoute);

            var accountContactDefaultByIDRoute = new Route("Accounts/ID={accountid}/Contacts/New", new AccountContactRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountContactDefaultByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountContactDefaultByIDRoute.Constraints = new RouteValueDictionary { { "new", "new" } };
            Routes.Add(accountContactDefaultByIDRoute);

            var accountContactsRoute = new Route("Accounts/Name={accountname}/Contacts", new AccountContactRouteHandler("~/Accounts/AccountContactList.aspx"));
            accountContactsRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountContactsRoute);

            var accountContactsByIDRoute = new Route("Accounts/ID={accountid}/Contacts", new AccountContactRouteHandler("~/Accounts/AccountContactList.aspx"));
            accountContactsByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountContactsByIDRoute);

            Route contactListRoute = new Route("Accounts/Contacts", new AccountContactRouteHandler("~/Accounts/ContactList.aspx"));
            Routes.Add(contactListRoute);

            //ACCOUNTS LIST
            Route accountListRoute = new Route("Accounts/List", new AccountRouteHandler("~/Accounts/AccountsList.aspx"));
            Routes.Add(accountListRoute);

            var accountNewRoute = new Route("Accounts/{new}", new AccountRouteHandler("~/Accounts/AccountProperties.aspx"));
            accountNewRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountNewRoute);

            //ACCOUNTS DASHBOARD
            Route accountDashboardRoute = new Route("Accounts/Dashboard/{*value}", new AccountRouteHandler("~/Accounts/Dashboard.aspx"));
            Routes.Add(accountDashboardRoute);

            //Route accountDefault = new Route("Accounts/{catchall}", new AccountRouteHandler("~/Accounts/Dashboard.aspx"));
            //Routes.Add(accountDefault);
        }

        public void BuildUtilityRoutes()
        {
            Route loginRoute = new Route("Login", new UtilityRouteHandler("~/UtilityPages/Login.aspx"));
            Routes.Add(loginRoute);
        }

        public void BuildSalesRoutes()
        {
            Route salesDefaultRoute = new Route("Sales/Dashboard", new SalesRouteHandler("~/Sales/Dashboard.aspx"));
            Routes.Add(salesDefaultRoute);
        }

        public void BuildProjectRoutes()
        {
            Route projectDefaultRoute = new Route("Projects/Dashboard", new SalesRouteHandler("~/Projects/Dashboard.aspx"));
            Routes.Add(projectDefaultRoute);
        }

        public void BuildSupportRoutes()
        {
            Route supportDefaultRoute = new Route("Support/Dashboard", new SalesRouteHandler("~/Support/Dashboard.aspx"));
            Routes.Add(supportDefaultRoute);
        }
    }
}
