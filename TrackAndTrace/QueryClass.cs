using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class QueryClass : Validation
    {

        LoadData d = new LoadData();

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
                displayAllLocationsSuccessMessage = displayAllLocationsSuccessMessage +
                                                    displayAllLocationsSuccessMessage1 + r.locationID + "\n" +
                                                    displayAllLocationsSuccessMessage2 + r.address + "\n" +
                                                    lineBreak() + "\n";             
            }
            return displayAllLocationsSuccessMessage;
        }

        //public string getAllPeopleFromFileQuery()
        //{
        //    string getAllPeopleFromFileSuccess;

        //    string displayAllPeopleSuccessMessage1 = "User ID : - ";
        //    string displayAllPeopleSuccessMessage2 = "Telephone number : - ";
        //    var v = d.displayAllFromFile();

        //    foreach (Person f in v)
        //    {
        //        lineBreak();
        //        displayAllPeopleSuccessMessage = displayAllPeopleSuccessMessage +
        //                                         displayAllPeopleSuccessMessage1 + f.userID + "\n" +
        //                                         displayAllPeopleSuccessMessage2 + f.telephoneNumber + "\n" +
        //                                         lineBreak() + "\n";
        //    }
        //    return displayAllPeopleSuccessMessage;
        //    return getAllPeopleFromFileSuccess;
        //}


        // TODO : Add comment
        public List<Person> returnAllPeopleList()
        {                      
            return tr.getPeople();
        }

        public List<Person> returnAllContactsList()
        {
            return tr.getContacts();
        }

        public List<Location> returnAllLocationsList()
        {
            return tr.getLocations();
        }

        public List<Location> returnAllVisitsList()
        {
            return tr.getVisits();
        }

        public string getAllPeopleQuery()
        {
            string displayAllPeopleSuccessMessage = "";
            string displayAllPeopleSuccessMessage1 = "User ID : - ";
            string displayAllPeopleSuccessMessage2 = "Telephone number : - ";         

            var v = tr.getPeople();
            foreach (Person f in v.ToList())
            { 
               lineBreak();
               displayAllPeopleSuccessMessage = displayAllPeopleSuccessMessage + 
                                                displayAllPeopleSuccessMessage1 + f.userID +  "\n" + 
                                                displayAllPeopleSuccessMessage2 + f.telephoneNumber + "\n" +
                                                lineBreak() + "\n";
            }
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
                getAllVisitsQuerySuccessMessage = getAllVisitsQuerySuccessMessage +
                                                  getAllVisitsQuerySuccessMessage1 + f.userID + "\n" +
                                                  getAllVisitsQuerySuccessMessage2 + f.locationID + "\n" +
                                                  getAllVisitsQuerySuccessMessage3 + f.checkInDate + "\n" +
                                                  lineBreak() + "\n";
            }
            return getAllVisitsQuerySuccessMessage;
        }

        public string getAllContactsQuery()
        {
            string displayAllContactsSuccessMessage = "";
            string displayAllContactsSuccessMessage1 = "User ID : - ";
            string displayAllContactsSuccessMessage2 = "Contact User ID : - ";
            string displayAllContactsSuccessMessage3 = "Contact Date : - ";

            foreach (Person p in tr.getContacts().ToList())
            {
                lineBreak();
                displayAllContactsSuccessMessage = displayAllContactsSuccessMessage + displayAllContactsSuccessMessage1 + p.userID + "\n" + 
                                                   displayAllContactsSuccessMessage2 + p.contactUserID + "\n" + 
                                                   displayAllContactsSuccessMessage3 + p.contactDate + "\n" +
                                                   lineBreak() + "\n";
            }
            return displayAllContactsSuccessMessage;
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
                }
            }
            return searchForContactsSuccessMessage;
        }


        // TODO : Add comments
        public string searchForVisitsQuery(string startDate, string endDate, string visitedLocationID)
        {
            var visitList = tr.getVisits();
            var visitsSearchResults = from v in visitList
                                      where v.checkInDate >= DateTime.Parse(startDate)
                                      where v.checkInDate <= DateTime.Parse(endDate)
                                      where v.locationID == int.Parse(visitedLocationID)
                                      select v;

            //var updatedVisitList = tr.getPeople(); // TODO : test this works

            string listOfVisits = "List of Visits for Location ID: - ";
            int listOfVisitsLocationID = 0;
            string searchForVisitsSuccessMessage = "";
            string searchForVisitsSuccessMessage1 = "Contact User ID : - ";
            string searchForVisitsSuccessMessage2 = "Telephone Number : - ";
            string searchForVisitsSuccessMessage3 = "Date of Visit : - ";

            lineBreak();

            if (visitsSearchResults.ToList().Capacity > 0)
            {
                foreach (Location q in visitsSearchResults.ToList())
                {
                    var listOfPeopleRecordedInVisits = from b in tr.getPeople()
                                                       where b.userID == q.userID
                                                       select b;

                    foreach (Person h in listOfPeopleRecordedInVisits.ToList())

                    {
                        searchForVisitsSuccessMessage = searchForVisitsSuccessMessage +
                                                        searchForVisitsSuccessMessage1 + h.userID + "\n" +
                                                        searchForVisitsSuccessMessage2 + h.telephoneNumber + "\n" +
                                                        searchForVisitsSuccessMessage3 + q.checkInDate + "\n" +
                                                        lineBreak() + "\n";
                        listOfVisitsLocationID = q.locationID;
                    }
                }
                return listOfVisits + visitedLocationID + "\n" + searchForVisitsSuccessMessage;
            }

            else
            {
                string emptyListMessage =  lineBreak() + "\n" +
                                           "No visits recorded at Location ID" + visitedLocationID + "\n" +
                                           lineBreak() + "\n"; 
                return listOfVisits + visitedLocationID + "\n" + emptyListMessage;
            }
        }
        //  Class closing Brackets
    }
}
