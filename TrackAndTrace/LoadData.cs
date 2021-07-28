using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace TrackAndTrace
{
    
    class LoadData : SaveData
    {
        
       public List<Person> displayAllPeopleFromFile()
        {
            List<Person> allPeople = new List<Person>();

                using (var reader = new StreamReader(base.usersPath))
                {
                reader.ReadLine();
                  
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                    
                    int UserID = int.Parse(values[0]);
                    string phoneNumber = "0" + values[1];

                    allPeople.Add(new Person(UserID, phoneNumber));
                 
                    }                
                }
            return allPeople;

        }

        public List<Location> displayAllLocationsFromFile()
        {

            List<Location> allLocations = new List<Location>();

            using (var reader = new StreamReader(base.locationsPath))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    int s;
                    if (int.TryParse(values[0], out s) == false)
                    {
                        break;
                    }                   

                    Console.WriteLine(values[0]);
                    Console.WriteLine(values[1]);
                    int LocationID = int.Parse(values[0]);
                    string address = values[1];

                    allLocations.Add(new Location(LocationID, address));
                }
            }
            return allLocations;
        }

        public List<Person> displayAllContactsFromFile()
        {

            List<Person> allContacts = new List<Person>();

            using (var reader = new StreamReader(base.contactsPath))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    int s;
                    if (int.TryParse(values[0], out s) == false)
                    {
                        break;
                    }

                  
                    int userID = int.Parse(values[0]);
                    int contactUserID = int.Parse(values[1]);
                    DateTime contactDate = DateTime.Parse(values[2]);

                    allContacts.Add(new Person(userID, contactUserID, contactDate));
                }
            }
            return allContacts;
        }

        public List<Location> displayAllVisitsFromFile()
        {
            List<Location> allVisits = new List<Location>();

            using (var reader = new StreamReader(base.visitsPath))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    int s;
                    if (int.TryParse(values[0], out s) == false)
                    {
                        break;
                    }

                    int userID = int.Parse(values[0]);
                    int checkInLocationID = int.Parse(values[1]);                    
                    DateTime checkInDate = DateTime.Parse(values[2]);                    
                    allVisits.Add(new Location(userID, checkInLocationID, checkInDate));
                }
            }
            return allVisits;
        }
    }
}
