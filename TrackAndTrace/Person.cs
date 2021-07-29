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
            
        // Getters and Setters 
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

        // Constructors
        public Person()
        {
           
        }

       // private constructor for constructor chaining
        private Person(int userID)
        {
            _userID = userID;
        }
        
        // Constructs a person object that can be used with the people list
        public Person(int userID, string telephoneNumber) : this(userID)
        {           
            _telephoneNumber = telephoneNumber;
        }

        // Constructs a person object that can be used with the contacts list
        public Person(int userID, int contactUserID, DateTime contactDate) : this(userID)
        {
            _contactUserID = contactUserID;
            _contactDate = contactDate;
        }
      

     

       
     

        
       




    }



}
