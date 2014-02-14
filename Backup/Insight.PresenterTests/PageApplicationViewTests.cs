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


namespace Insight.PresenterTests
{
    [TestFixture]
    public class PageApplicationViewTests
    {
        private PageApplicationViewRepository _pageApplicationViewRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _pageApplicationViewRepository = new PageApplicationViewRepository();
        }

        [Test]
        public void CanCreatePageApplicationViewProperties()
        {
            int PAGEAPPLICATIONVIEWID = 30;
            var linksList = new List<HistoryLink>();
            linksList.Add(new HistoryLink("Profile", "[url]/Profile", "/Images/vcard.png", ""));
            linksList.Add(new HistoryLink("Dashboard", "[url]/Dashboard", "/Images/chart_pie.png", ""));
            linksList.Add(new HistoryLink("Contacts", "[url]/Contacts", "/Images/group.png", ""));
            linksList.Add(new HistoryLink("Properties", "[url]/Properties", "/Images/cog.png", ""));
            linksList.Add(new HistoryLink("Addresses", "[url]/Addresses", "/Images/map.png", ""));
            //linksList.Add(new HistoryLink("Account List", "[url]/List", "/Images/text_list_bullets.png", ""));
            linksList.Add(new HistoryLink("Equipment", "[url]/Equipment", "/Images/computer.png", ""));
            linksList.Add(new HistoryLink("Contracts", "[url]/Contracts", "/Images/script.png", ""));
            linksList.Add(new HistoryLink("Attachments", "[url]/Attachments", "/Images/attach.png", ""));
            linksList.Add(new HistoryLink("Notes", "[url]/Notes", "/Images/note.png", ""));
            linksList.Add(new HistoryLink("Tickets", "[url]/Tasks", "/Images/tag_blue.png", ""));
            linksList.Add(new HistoryLink("Orders", "[url]/Orders", "/Images/package_green.png", ""));
            linksList.Add(new HistoryLink("Alerts", "[url]/Alerts", "/Images/exclamation.png", ""));
            linksList.Add(new HistoryLink("Messages", "[url]/Messages", "/Images/email.png", ""));
            var pav = _pageApplicationViewRepository.GetByID(PAGEAPPLICATIONVIEWID, false);
            pav.ViewProperties = Insight.Core.Utils.JSONSerializationHelper.Serialize<IList<HistoryLink>>(linksList);
            _pageApplicationViewRepository.SaveOrUpdate(pav);

        }

        [Test]
        public void CanCreateAccountsListPageApplicationViewProperties()
        {
            int PAGEAPPLICATIONVIEWID = 34;
            var linksList = new List<HistoryLink>();
            //linksList.Add(new HistoryLink("Profile", "Accounts/Name=/Profile/", "/Images/vcard.png", ""));
            linksList.Add(new HistoryLink("Email Accounts", "[url]/Email", "/Images/email.png", ""));
            linksList.Add(new HistoryLink("Address List", "[url]/Addresses", "/Images/map.png", ""));
            //linksList.Add(new HistoryLink("Contacts", "Accounts/Contacts", "/Images/group.png", ""));
            //linksList.Add(new HistoryLink("Equipment", "Accounts/Equipment", "/Images/computer.png", ""));
            //linksList.Add(new HistoryLink("Contracts", "Accounts/Contracts", "/Images/script.png", ""));
            //linksList.Add(new HistoryLink("Attachments", "Accounts/Attachments", "/Images/attach.png", ""));
            //linksList.Add(new HistoryLink("Notes", "Accounts/Notes", "/Images/note.png", ""));
            //linksList.Add(new HistoryLink("Alerts", "Accounts/Alerts", "/Images/exclamation.png", ""));
            //linksList.Add(new HistoryLink("Messages", "Accounts/Messages", "/Images/email.png", ""));
            var pav = _pageApplicationViewRepository.GetByID(PAGEAPPLICATIONVIEWID, false);
            pav.ViewProperties = Insight.Core.Utils.JSONSerializationHelper.Serialize<IList<HistoryLink>>(linksList);
            _pageApplicationViewRepository.SaveOrUpdate(pav);

        }


    }
}
