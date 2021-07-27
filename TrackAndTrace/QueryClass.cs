using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class QueryClass : Validation
    {

        // Display all methods 

        // TODO : Add comment
        public string getAllLocationsQuery()
        {
            var v = tr.getLocations();
            string displayAllLocationsSuccessMessage = "";
            string displayAllLocationsSuccessMessage1 = "Location ID : - ";
            string displayAllLocationsSuccessMessage2 = "Address : - ";

            foreach (Location r in v)
            {
              
                //base.listBoxMainWindow.Items.Add("Location ID : - " + r.locationID);
                //base.listBoxMainWindow.Items.Add("Address: - " + r.address);
                displayAllLocationsSuccessMessage = displayAllLocationsSuccessMessage +
                                                    displayAllLocationsSuccessMessage1 + r.locationID + "\n" +
                                                    displayAllLocationsSuccessMessage2 + r.address + "\n" +
                                                    lineBreak() + "\n";             
            }
            return displayAllLocationsSuccessMessage;
        }

        // TODO : Add comment
        public string displayAllPeopleQuery()
        {
            string displayAllPeopleSuccessMessage = "";
            string displayAllPeopleSuccessMessage1 = "User ID : - ";
            string displayAllPeopleSuccessMessage2 = "Telephone number : - ";         

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

        // TODO : Add comment
        public string getAllVisitsQuery()
        {
            string getAllVisitsQuerySuccessMessage = "";
            string getAllVisitsQuerySuccessMessage1 = "User ID : - ";
            string getAllVisitsQuerySuccessMessage2 = "Location ID : - ";
            string getAllVisitsQuerySuccessMessage3 = "Check In Date : - ";
            var v = tr.getVisits();
            foreach (Location f in v)
            {
                //base.listBoxMainWindow.Items.Add("User ID : - " + f.userID);
                //base.listBoxMainWindow.Items.Add("Location ID : - " + f.locationID);
                //base.listBoxMainWindow.Items.Add("Check In Date : - " + f.checkInDate);

                getAllVisitsQuerySuccessMessage = getAllVisitsQuerySuccessMessage +
                                                  getAllVisitsQuerySuccessMessage1 + f.userID + "\n" +
                                                  getAllVisitsQuerySuccessMessage2 + f.locationID + "\n" +
                                                  getAllVisitsQuerySuccessMessage3 + f.checkInDate + "\n" +
                                                  lineBreak() + "\n";
                
            }
            return getAllVisitsQuerySuccessMessage;
        }


        // Search Methods

        // TODO : Add comment
        public string searchForContactsQuery(string date, string contactUserID)
        {
            var contactList = tr.getContacts();
            var result = from v in contactList
                         where v.contactDate > DateTime.Parse(date)
                         where v.userID == int.Parse(contactUserID)
                         select v;

            var updatedContactList = tr.getPeople();
            string searchForContactsSuccessMessage = "";
            string searchForContactsSuccessMessage1 = "List of contacts for User: -";
            string searchForContactsSuccessMessage2 = "Contact User ID : - ";
            string searchForContactsSuccessMessage3 = "Telephone Number : - ";
            string searchForContactsSuccessMessage4 = "Date of Contact : - ";

            foreach (Person q in result.ToList())
            {
                // listBoxMainWindow.Items.Add("User ID : - " + q.userID);
                var result2 = from b in updatedContactList
                              where b.userID == q.contactUserID
                              select b;
            
                foreach (Person h in result2.ToList())
                {

                    searchForContactsSuccessMessage = searchForContactsSuccessMessage +
                                         searchForContactsSuccessMessage1 + q.userID + "\n" +
                                         searchForContactsSuccessMessage2 + q.contactUserID + "\n" +
                                         searchForContactsSuccessMessage3 + h.telephoneNumber + "\n" +
                                         searchForContactsSuccessMessage4 + q.contactDate + "\n" +
                                         lineBreak() + "\n"; 


                    //base.listBoxMainWindow.Items.Add("List of contacts for User: - " + q.userID);
                    //base.listBoxMainWindow.Items.Add("Contact User ID : - " + q.contactUserID);
                    //base.listBoxMainWindow.Items.Add("Telephone Number : - " + h.telephoneNumber);
                    //base.listBoxMainWindow.Items.Add("Date of Contact : - " + q.contactDate);
                    //base.lineBreak();
                    
                }
            }
            return searchForContactsSuccessMessage;
        }
           

        // TODO : Add comment
        public string searchForVisits(string startDate, string endDate, string visitedLocationID)
        {
            var visitList = tr.getVisits();
            var result = from v in visitList
                         where v.checkInDate >= DateTime.Parse(startDate)
                         where v.checkInDate <= DateTime.Parse(endDate)
                         where v.locationID == int.Parse(visitedLocationID)
                         select v;

            var updatedVisitList = tr.getPeople();

            string listOfVisits = "List of Visits for Location ID: - ";
            string searchForVisitsSuccessMessage = "";
            string searchForVisitsSuccessMessage1 = "Contact User ID : - ";
            string searchForVisitsSuccessMessage2 = "Telephone Number : - ";
            string searchForVisitsSuccessMessage3 = "Date of Visit : - ";
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

                    searchForVisitsSuccessMessage = searchForVisitsSuccessMessage +
                                                    searchForVisitsSuccessMessage1 + h.userID + "\n" +
                                                    searchForVisitsSuccessMessage2 + h.telephoneNumber + "\n" +
                                                    searchForVisitsSuccessMessage3 + q.checkInDate + "\n" +
                                                    lineBreak() + "\n";
                }

            }

            return listOfVisits + "\n" + searchForVisitsSuccessMessage;
        }
       




        //  Class closing Brackets
    }
}
