using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class QueryClass : Validation
    {
      

        // TODO : Add comment
        public string displayAllPeopleQuery()
        {
            string displayAllPeopleSuccessMessage;
            string displayAllPeopleSuccessMessage1 = "User ID : - ";
            string displayAllPeopleSuccessMessage2 = "Telephone number : - ";
            displayAllPeopleSuccessMessage = clearMessage();

            var v = tr.getPeople();
            foreach (Person f in v.ToList())
            {           
                //base.listBoxMainWindow.Items.Add("User ID : - " + f.userID);
                //base.listBoxMainWindow.Items.Add("Telephone number : - " + f.telephoneNumber);
                lineBreak();
               displayAllPeopleSuccessMessage = displayAllPeopleSuccessMessage + displayAllPeopleSuccessMessage1 + f.userID +  "\n" + displayAllPeopleSuccessMessage2 + f.telephoneNumber + "\n";
                // displayAllPeopleSuccessMessage = displayAllPeopleSuccessMessage + displayAllPeopleSuccessMessage;
                
            }
            //return displayAllPeopleSuccessMessage;
            return displayAllPeopleSuccessMessage;

        }

        // Resets a message string
        public string clearMessage()
        {

            return "";
        }

        // TODO : Add comment
        public string searchForContactsQuery(string date, string contactUserID)
        {
            var contactList = tr.getContacts();
            var result = from v in contactList
                         where v.contactDate > DateTime.Parse(date)
                         where v.userID == int.Parse(contactUserID)
                         select v;

            var updatedContactList = tr.getPeople();

            foreach (Person q in result.ToList())
            {
                // listBoxMainWindow.Items.Add("User ID : - " + q.userID);
                var result2 = from b in updatedContactList
                              where b.userID == q.contactUserID
                              select b;

                foreach (Person h in result2.ToList())
                {
                    string searchForContactsSuccessMessage = "List of contacts for User: - " + q.userID + "\n" +
                                                             "Contact User ID : - " + q.contactUserID + "\n" +
                                                             "Telephone Number : - " + h.telephoneNumber + "\n" +
                                                             "Date of Contact : - " + q.contactDate;

                    //base.listBoxMainWindow.Items.Add("List of contacts for User: - " + q.userID);
                    //base.listBoxMainWindow.Items.Add("Contact User ID : - " + q.contactUserID);
                    //base.listBoxMainWindow.Items.Add("Telephone Number : - " + h.telephoneNumber);
                    //base.listBoxMainWindow.Items.Add("Date of Contact : - " + q.contactDate);
                    lineBreak();
                    return searchForContactsSuccessMessage;
                }
            }
            return "";
        }

        // TODO : Add comment
        public void getAllLocationsQuery()
            {
                var v = tr.getLocations();

                foreach (Location r in v)
                {
                //base.listBoxMainWindow.Items.Add("Location ID : - " + r.locationID);
                //base.listBoxMainWindow.Items.Add("Address: - " + r.address);
                    lineBreak();
                }
            }

        // TODO : Add comment
        public void getAllVisitsQuery()
        {
            var v = tr.getVisits();
            foreach (Location f in v)
            {
                //base.listBoxMainWindow.Items.Add("User ID : - " + f.userID);
                //base.listBoxMainWindow.Items.Add("Location ID : - " + f.locationID);
                //base.listBoxMainWindow.Items.Add("Check In Date : - " + f.checkInDate);
                lineBreak();
            }
        }

        // TODO : Add comment
        public void searchForVisits(string startDate, string endDate, string visitedLocationID)
        {
            var visitList = tr.getVisits();
            var result = from v in visitList
                         where v.checkInDate >= DateTime.Parse(startDate)
                         where v.checkInDate <= DateTime.Parse(endDate)
                         where v.locationID == int.Parse(visitedLocationID)
                         select v;

            var updatedVisitList = tr.getPeople();

            //base.listBoxMainWindow.Items.Add("List of Visits for Location ID: - " + visitedLocationID);
            lineBreak();

            foreach (Location q in result.ToList())
            {
                // listBoxMainWindow.Items.Add("User ID : - " + q.userID);
                var result2 = from b in updatedVisitList
                              where b.userID == q.userID
                              select b;

                foreach (Person h in result2.ToList())

                {
                    //base.listBoxMainWindow.Items.Add("Contact User ID : - " + h.userID);
                    //base.listBoxMainWindow.Items.Add("Telephone Number : - " + h.telephoneNumber);
                    //base.listBoxMainWindow.Items.Add("Date of Visit : - " + q.checkInDate);
                    lineBreak();

                }
            }
        }
       




        //  Class closing Brackets
    }
}
