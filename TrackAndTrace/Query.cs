using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{

    /**
     * This class contains methods that execute queries that return all objects in a list and specific ones based on user input.  
     * These methods then return a string to the MainWindow.cs class that will be output in the listbox in the GUI
     * This class is a child of the Validation class which has a similar function but is not a natural parent of this class.
     * Inheritance has been used in this case to make instantiation of the validation class easier to manage and to help 
     * make the code in the MainWindow.cs class easier to read.
     * Methods have been arranged according to their type and have been signposted in an attempt to make it easier to navigate the code
     **/

    class Query : Validation
    {
        LoadData d = new LoadData();

        /*
         * Display all methods 
         */       
      
        // Person Interaction : Uses the getPeople method from the Track.cs class and returns a string message to be used in the listbox in the GUI
        public string getAllPeopleQuery()
        {
            string displayAllPeopleSuccessMessage = "";
            string displayAllPeopleSuccessMessage1 = "User ID : - ";
            string displayAllPeopleSuccessMessage2 = "Telephone number : - ";

            // Iterates through the list, builds the success message as a string and returns the success message            
            foreach (Person f in tr.getPeople().ToList())
            {
                lineBreak();
                displayAllPeopleSuccessMessage = displayAllPeopleSuccessMessage +
                                                 displayAllPeopleSuccessMessage1 + f.userID + "\n" +
                                                 displayAllPeopleSuccessMessage2 + f.telephoneNumber + "\n" +
                                                 lineBreak() + "\n";
            }
            return displayAllPeopleSuccessMessage;
        }

        // Person Interaction : Uses the getContacts method from the Track.cs class and returns a string message to be used in the listbox in the GUI
        public string getAllContactsQuery()
        {
            string displayAllContactsSuccessMessage = "";
            string displayAllContactsSuccessMessage1 = "User ID : - ";
            string displayAllContactsSuccessMessage2 = "Contact User ID : - ";
            string displayAllContactsSuccessMessage3 = "Contact Date : - ";

            // Iterates through the list, builds the success message as a string and returns the success message
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

        // Location Interaction : Uses the getLocations method from the Track.cs class and returns a string message to be used in the listbox in the GUI
        public string getAllLocationsQuery()
        {
           
            string displayAllLocationsSuccessMessage = "";
            string displayAllLocationsSuccessMessage1 = "Location ID : - ";
            string displayAllLocationsSuccessMessage2 = "Address : - ";

            // Iterates through the list, builds the success message as a string and returns the success message
            foreach (Location r in tr.getLocations().ToList())
            { 
                displayAllLocationsSuccessMessage = displayAllLocationsSuccessMessage +
                                                    displayAllLocationsSuccessMessage1 + r.locationID + "\n" +
                                                    displayAllLocationsSuccessMessage2 + r.address + "\n" +
                                                    lineBreak() + "\n";             
            }
            return displayAllLocationsSuccessMessage;
        }

   
        // Location Interaction : Uses the getVisits method from the Track.cs class and returns a string message to be used in the listbox in the GUI
        public string getAllVisitsQuery()
        {
            string getAllVisitsQuerySuccessMessage = "";
            string getAllVisitsQuerySuccessMessage1 = "User ID : - ";
            string getAllVisitsQuerySuccessMessage2 = "Location ID : - ";
            string getAllVisitsQuerySuccessMessage3 = "Check In Date : - ";
           
            // Iterates through the list, builds the success message as a string and returns the success message
            foreach (Location f in tr.getVisits().ToList())
            {
                getAllVisitsQuerySuccessMessage = getAllVisitsQuerySuccessMessage +
                                                  getAllVisitsQuerySuccessMessage1 + f.userID + "\n" +
                                                  getAllVisitsQuerySuccessMessage2 + f.locationID + "\n" +
                                                  getAllVisitsQuerySuccessMessage3 + f.checkInDate + "\n" +
                                                  lineBreak() + "\n";
            }
            return getAllVisitsQuerySuccessMessage;
        }

        /*
         *Search Methods
         */

        // Person Interaction : Uses a Linq query to return a list of Contacts and the required data based on User input
        public string searchForContactsQuery(string date, string contactUserID)
        {
            // Linq query that returns a list based on user input from the getContacts list
            // user input includes date and User ID
            var contactList = tr.getContacts();
            var result = from v in contactList
                         where v.contactDate > DateTime.Parse(date)
                         where v.userID == int.Parse(contactUserID)
                         select v;


            var updatedContactList = tr.getPeople();

            // string variables for building the success message to be returned
            string searchForContactsSuccessMessage = "";
            string searchForContactsSuccessMessage1 = "List of contacts for User: -";
            string searchForContactsSuccessMessage2 = "Contact User ID : - ";
            string searchForContactsSuccessMessage3 = "Telephone Number : - ";
            string searchForContactsSuccessMessage4 = "Date of Contact : - ";

            // iterates throgh the list returned by the Linq query and performs another linq query exctracting all of the user IDs of
            // the people this User came into contact with
            foreach (Person q in result.ToList())
            {
                var result2 = from b in updatedContactList
                              where b.userID == q.contactUserID
                              select b;
                // iterates through the returned contact list from the above Linq query and builds the success message to be returned
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

        // Location Interaction : Uses a Linq query to return a list of Visits and the required data based on User input
        public string searchForVisitsQuery(string startDate, string endDate, string visitedLocationID)
        {
            var visitList = tr.getVisits();
            // Linq query that returns a list based on user input from the getVists list
            // user input includes start date, end date and location ID
            var visitsSearchResults = from v in visitList
                                      where v.checkInDate >= DateTime.Parse(startDate)
                                      where v.checkInDate <= DateTime.Parse(endDate)
                                      where v.locationID == int.Parse(visitedLocationID)
                                      select v;

            // Control variable for If statements
            int listOfVisitsLocationID = 0;

            // string variables for building the success message to be returned
            string listOfVisits = "List of Visits for Location ID: - ";            
            string searchForVisitsSuccessMessage = "";
            string searchForVisitsSuccessMessage1 = "Contact User ID : - ";
            string searchForVisitsSuccessMessage2 = "Telephone Number : - ";
            string searchForVisitsSuccessMessage3 = "Date of Visit : - ";

            lineBreak();

            // If the list returned by Linq query is not empty enter If statement
            if (visitsSearchResults.ToList().Capacity > 0)
            {
                // then iterate through the list and select people who visited the location
                foreach (Location q in visitsSearchResults.ToList())
                {
                    var listOfPeopleRecordedInVisits = from b in tr.getPeople()
                                                       where b.userID == q.userID
                                                       select b;

                    // then iterate through the list of people who visited the location, build the success message adn return the success message
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

            // If the list is empty return feedback to the user 
            else
            {
                string emptyListMessage = lineBreak() + "\n" +
                                           "No visits recorded at Location ID" + visitedLocationID + "\n" +
                                           lineBreak() + "\n";
                
                return listOfVisits + visitedLocationID + "\n" + emptyListMessage;
            }
        }

        /* 
         * Get methods
         */

        // Person Interaction : returns the people list
        public List<Person> returnAllPeopleList()
        {                      
            return tr.getPeople();
        }

        // Person Interaction : returns the contacts list
        public List<Person> returnAllContactsList()
        {
            return tr.getContacts();
        }

        // Location Interaction : returns the locations list
        public List<Location> returnAllLocationsList()
        {
            return tr.getLocations();
        }

        // Location Interaction : returns the visits list
        public List<Location> returnAllVisitsList()
        {
            return tr.getVisits();
        }
    }
}
