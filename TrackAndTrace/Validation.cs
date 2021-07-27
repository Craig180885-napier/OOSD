using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class Validation 
    {

        public Track tr = new Track();
        public string lineBreak()
        {  
            return "--------------------------------------";
        }

        // This method validate that the phone number meets the criteria and that the User ID is unique, 
        // if both conditions are met the user is added to the Person class
        public string newPersonValidation(string phoneNumber)
        {
            // Variables
            var validPeople = tr.getPeople();
            bool isUnique = true;

            // User ID validation Step 1, if the people list is empty there is no need to check if the User ID entered is unique.
            if (validPeople.Capacity < 1)
            {
                // Phone Number Validation, must be 11 integer numbers long, and must begin with a 0
                if (!phoneNumber[0].Equals('0') || phoneNumber.Equals(null) || phoneNumber.Length < 11)
                {
                    string message1 = "Invalid Phone Number entered \n" +
                                                "- Your Phone Number Must: \n" +
                                                "- Begin With a 0 \n" +
                                                "- Be 11 numbers long or more \n" +
                                                "- you entered: - " + phoneNumber + "\n" +
                                                "- Please Try again";             
                    lineBreak();
                    return message1;
                }

                // Phone number is valid, user is added to the person list
                else
                { 
                    string message2 = "Empty User : - is valid is : -" + isUnique + "\n" +
                            "User : -" + ID.Instance.currentUserID() + " has been added" + "\n" +
                            "Capacity = 0 - Phone Number entered is valid - " + phoneNumber;

                    lineBreak();
                    tr.addPerson(ID.Instance.currentUserID(), phoneNumber);
                    ID.Instance.nextUserID();
                    validPeople = tr.getPeople();
                    return message2;
                }                
            }

            // User ID validation Step 2 - in the case where the Person list is not empty
            else if (validPeople.Capacity > 0)
            {
                foreach (Person p in validPeople.ToList())
                {
                    // If the user ID is not unique then present an error and do not add the person to the list
                    // sets the bool isUnique to false 
                    if (p.userID == ID.Instance.currentUserID())
                    /*if (p.userID == int.Parse(txtBoxUserIDTrack.Text))*/  // for demo purposes to demonstrate validation of Unique user ID
                    {
                        string message3 = "User ID already exisits, please enter a unique user ID \n" +
                                          "is valid is : -" + isUnique +
                                          lineBreak() + "\n";         
                        return message3;                       
                    }
                    continue;
                }

                if (isUnique == true)
                {
                    // Phone Number Validation, must be 11 integer numbers long, and must begin with a 0
                    if (!phoneNumber[0].Equals('0') || phoneNumber.Equals(null) || phoneNumber.Length < 11)
                    {
                        string message4 = "Invalid Phone Number entered \n" +
                                                    "- Your Phone Number Must: \n" +
                                                    "- Begin With a 0 \n" +
                                                    "- Be 11 numbers long or more \n" +
                                                    "- you entered: - " + phoneNumber + "\n" +
                                                    "- Please Try again" +
                                                     lineBreak() + "\n";                        
                        return message4;
                    }
                  
                    // If the phone number meets the criteria and the user ID is unique adds this user to the Person list
                    else
                    {
                        string message5 = "is valid is : -" + isUnique + "\n" +
                                          "User : -" + ID.Instance.currentUserID() + " has been added" + "\n" +
                                          "Capacity > 0 - Phone Number entered is valid - " + phoneNumber + "\n" +
                                          lineBreak() + "\n";

                        tr.addPerson(ID.Instance.currentUserID(), phoneNumber);
                        ID.Instance.nextUserID();
                        return message5;
                    }
                   
                }
                
            }
            return "";
            // End of newPersonValidation method
        }

        // TODO : Add a comment
        public string recordContactDateValidation(string userID, string contactUserID, string dateTime)
        {
            DateTime date;
            if (DateTime.TryParse(dateTime, out date) == false)
            {
                string recordContactErrorMessage = "Date cannot be empty : - " + lineBreak() + "\n";
                return recordContactErrorMessage;
            }
            else
            {
                string recordSuccessMessage = "Contact recoded between User : " + userID + " and User " + 
                                               contactUserID + " at : " + DateTime.Parse(dateTime) + "\n" + 
                                               lineBreak() + "\n";
                tr.addContact(int.Parse(userID), int.Parse(contactUserID), DateTime.Parse(dateTime));
                return recordSuccessMessage;
            }
        }

        // TODO : Add validation for location ID, address
        public string addLocationValidation(string address)
        {
            tr.addLocation(ID.Instance.currentLocationID(), address);

            string addlocationValidationSuccessMessage = "Location ID : - " + ID.Instance.currentLocationID() + " Has been added \n" +
                                                         "Address: - " + address + "\n" +
                                                          lineBreak() + "\n";
            ID.Instance.nextLocationID();
            return addlocationValidationSuccessMessage;
        }

        // TODO : Add validation for User ID, location ID and Date that ensures the strings can be parsed
        public string checkIn(string UserID, string locationID, string dateTime)
        {
            string checkInSuccessMessage = "User :" + UserID + " has been checked into \n" +
                                           "location ID : " + locationID + "\n" + 
                                           "at : " + DateTime.Parse(dateTime) + "\n" +
                                            lineBreak() + "\n";
            tr.checkIn(int.Parse(UserID), int.Parse(locationID), DateTime.Parse(dateTime));
            return checkInSuccessMessage;
        }
    }
}
