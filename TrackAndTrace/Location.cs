using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class Location : Person
    {
        private int _locationID;
        private string _address;
        private DateTime _checkInDate;
        //private DateTime _startDate;
        //private DateTime _endDate;

        public Location()
        { }
        // Private constructor for constructor chaining
        private Location (int locationID)
        {
            _locationID = locationID;
        }

        // Constructor that creates an instance of a location
        public Location (int locationID, string address) : this (locationID)
        {            
            _address = address;
        }

        // Contructor that creates an instance of a visit
        public Location (int UserID, int locationID,  DateTime dateTime) : this (locationID)
        {
            base.userID = UserID;
            _checkInDate = dateTime;
        }

    
        public int locationID
        {
            get
            {
                return _locationID;
            }
            
        }

        public string address
        {
            get
            {
                return _address;
            }
       
        }

        public DateTime checkInDate
        {
            get
            {
                return _checkInDate;
            }

        }
    }
}
