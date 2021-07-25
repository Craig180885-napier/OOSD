using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class Track
    {
        List<Person> people = new List<Person>();
        List<Person> contacts = new List<Person>();
        List<Location> locations = new List<Location>();
        List<Location> listOfLocationVisits = new List<Location>();

        ///
        ///This class is where the methods to add people and locations are located  
        ///
                     
        /*
         * Person Code
         */               

        // Method that adds an instance of a person to the people list
        public void addPerson(int userID, string phoneNumber)
        {
            people.Add(new Person(userID, phoneNumber));
        }

        // Returns the people list
        public List<Person> getPeople()
        {
            return people;
        }

        // Adds acontact event to the contacts list
        public void addContact(int UserID, int contactUserID, DateTime contactDate)
        {
            contacts.Add(new Person(UserID, contactUserID, contactDate));
            contacts.Add(new Person(contactUserID, UserID, contactDate));
        }
                   
        public List<Person> getContacts()
        {
            return contacts;
        }

    
    
        /*
         * Location Code
         */

        // Method that adds an instance of a location to the locations list
        public void addLocation(int locationID, string address)
        {
            locations.Add(new Location(locationID, address));
        }

        // Returns the locations list
        public List<Location> getLocations()
        {
            return locations;
        }

        // Method that adds a person to the list of visits 
        public void checkIn(int UserID, int locationID, DateTime dateTime)
        {
            listOfLocationVisits.Add(new Location(UserID, locationID, dateTime));
        }

        // Returns the list of visits
        public List<Location> getVisits()
        {
            return listOfLocationVisits;
        }

        // Method that writes the contents of the visits list to the console in it's entirety
        // TODO move to the Trace class when it is built
        public void showVisits()
        {
            foreach (Location c in listOfLocationVisits)
            {
                Console.WriteLine("Address : " + c.address);
                Console.WriteLine("Location ID: " + c.locationID);
                Console.WriteLine("Date & Time : " + c.checkInDate);
            }
        }
    }
}
