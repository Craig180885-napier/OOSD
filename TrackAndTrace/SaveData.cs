using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class SaveData
    {
        public string usersPath = "C:\\Users\\Craig\\Documents\\University\\OOSD\\Coursework\\TrackAndTraceUsers.csv";
        public string locationsPath = "C:\\Users\\Craig\\Documents\\University\\OOSD\\Coursework\\TrackAndTraceLocations.csv";
        public string contactsPath = "C:\\Users\\Craig\\Documents\\University\\OOSD\\Coursework\\TrackAndTraceContacts.csv";
        public string visitsPath = "C:\\Users\\Craig\\Documents\\University\\OOSD\\Coursework\\TrackAndTraceVisits.csv";

        public void saveUsers(List<Person> lp)
        {            
            using (var writer = new StreamWriter(usersPath))
            {
                writer.WriteLine("User ID , Telephone Number");
                foreach (Person p in lp)
                { 
                      writer.WriteLine("{0},{1}", p.userID, p.telephoneNumber);
                }
           
            }
        }

        public void saveLocations(List<Location> lp)
        {
            using (var writer = new StreamWriter(locationsPath))
            {
                writer.WriteLine("Location ID , Address");
                foreach (Location l in lp)
                {
                    writer.WriteLine("{0},{1}", l.locationID, l.address);
                }

            }
        }


    }
}
