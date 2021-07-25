using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class Person
    {
        private int _userID;
        private int _contactUserID;
        private string _telephoneNumber;
        private DateTime _contactDate;
        //private string telephonePrefix;       

        public int userID
        {
            get
            {
                return _userID;
            }

            set
            {
                _userID = value;
            }
        }

        public int contactUserID
        {
            get
            {
                return _contactUserID;
            }

            set
            {
                _contactUserID = value;
            }
        }
        public string telephoneNumber
        {
            get
            {
                return _telephoneNumber;
            }
        }

        public DateTime contactDate
        {
            get
            {
                return _contactDate;
            }
        }


        public Person()
        {
           
        }

        //TODO get User ID from singlton design pattern
        private Person(int userID)
        {
            _userID = userID;
        }
        
        public Person(int userID, string telephoneNumber) : this(userID)
        {           
            _telephoneNumber = telephoneNumber;
        }

        public Person(int userID, int contactUserID, DateTime contactDate) : this(userID)
        {
            _contactUserID = contactUserID;
            _contactDate = contactDate;
        }
      

     

       
     

        
       




    }



}
