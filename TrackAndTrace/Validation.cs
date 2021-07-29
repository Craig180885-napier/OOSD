using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class Validation 
    {
        /**
         * This class has methods that perform validation upon performing an action that changes a list object in the Track.cs Class
         * This class is the Parent of the Query Class, although not a natural parent the do perform similar actions.
         * Inheritance was used in this case to try to  keep the code more manageable and readable
         **/

        public Track tr = new Track();
        public string lineBreak()
        {  
            return "----------------------------------------------------------------------------------";
        }

        // This method validate that the phone number meets the criteria and that the User ID is unique, 
        // if both conditions are met the user is added to the Person class
        public string newPersonValidation(int UserID, string phoneNumber)
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
                    string errorMessage1 = "Invalid Phone Number entered \n" +
                                                "- Your Phone Number Must: \n" +
                                                "- Begin With a 0 \n" +
                                                "- Be 11 numbers long or more \n" +
                                                "- you entered: - " + phoneNumber + "\n" +
                                                "- Please Try again";             
                    lineBreak();
                    return errorMessage1;
                }

                // Phone number is valid, user is added to the person list
                else
                { 
                    string successMessage = "User : -" + ID.Instance.currentUserID() + " has been added" + "\n" +
                                            "Capacity = 0 - Phone Number entered is valid - " + phoneNumber + "\n" +
                                            lineBreak(); 
                    // if the user ID is 0 or less allocate the next available user ID and add the user
                    // This should not be possible in the current build  - is here incase of GUI/requirement change in the future
                    if (UserID < 1)
                    {
                        tr.addPerson(ID.Instance.currentUserID(), phoneNumber);
                        ID.Instance.nextUserID();
                        return successMessage;
                    }

                    // otherwise add the user with the details supplied from the GUI
                    else
                    {
                        tr.addPerson(UserID, phoneNumber);
                        ID.Instance.nextUserID();
                        return successMessage;
                    }
             
                }                
            }

            // User ID validation Step 2 - in the case where the Person list is not empty
            else if (validPeople.Capacity > 0)
            {
                string errorMessage2= "";
                foreach (Person p in validPeople.ToList())
                {
                    // If the user ID is not unique then present an error and do not add the person to the list
                    // sets the bool isUnique to false 
                    if (p.userID == UserID)
                    /*if (p.userID == int.Parse(txtBoxUserIDTrack.Text))*/  // for demo purposes to demonstrate validation of Unique user ID
                    {
                        errorMessage2 = "User ID : " + p.userID + " already exisits, please enter a unique user ID \n" +
                                         "is valid is : -" + isUnique +
                                         lineBreak() + "\n";
                        //ID.Instance.nextUserID();
                        return errorMessage2;
                    }                    
                    continue;
                    
                }

                // If the User ID is unique the enter if statement
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
                        if (UserID == 0)
                        {
                            tr.addPerson(ID.Instance.currentUserID(), phoneNumber);
                            ID.Instance.nextUserID();
                            return message5;
                        }

                        else
                        {
                            tr.addPerson(UserID, phoneNumber);
                            ID.Instance.nextUserID();
                            return message5;
                        }                       
                    }                   
                }                
            }
            return "";
            // End of newPersonValidation method
        }

        // Person Interaction : This method ensures that the User ID and contact user ID fields have data that is parsable into an int
        // also ensures that the IDs entered are present in the people list
        // also ensures that the date entered is parsable into a DateTime variable
        public string recordContactDateValidation(string userID, string contactUserID, string dateTime)
        {
            // varaiblaes that represent the first and last IDs in the people list
            // assumes first user ID is 1, TODO : not ideal but I ran out of time to do this properly
            int lastUserID = tr.getPeople().ToList().Capacity;            

            DateTime date;
            int s;

            if (int.TryParse(userID, out s) == false || int.TryParse(contactUserID, out s) == false || 
                int.Parse(userID) > lastUserID || int.Parse(contactUserID) > lastUserID ||
                int.Parse(userID) < 1 || int.Parse(contactUserID) < 1)
            {
                string recordContactErrorMessage1 = "there was an issue with the User ID or the Contact User ID you have entered \n" +
                                                           "Vaild User IDs range from " + 1 + " - " + lastUserID + "\n";
                                                           
                                                           return recordContactErrorMessage1;
            }

           
            else if (DateTime.TryParse(dateTime, out date) == false)
            {
                string recordContactErrorMessage2 = "Date cannot be empty : - " + lineBreak() + "\n";
                return recordContactErrorMessage2;
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

        // Location Interaction : ensures that the location ID is not less than 1
        // TODO : Further validation was intended here but I ran out of time
        public string addLocationValidation(int LocationID, string address)
        {
            if(LocationID < 1 )
            {
                tr.addLocation(ID.Instance.currentLocationID(), address);

                string addlocationValidationSuccessMessage = "Location ID : - " + ID.Instance.currentLocationID() + " Has been added \n" +
                                                             "Address: - " + address + "\n" +
                                                              lineBreak() + "\n";
                ID.Instance.nextLocationID();
                return addlocationValidationSuccessMessage;
            }

            else
            {
                tr.addLocation(LocationID, address);

                string addlocationValidationSuccessMessage = "Location ID : - " + LocationID + " Has been added \n" +
                                                             "Address: - " + address + "\n" +
                                                              lineBreak() + "\n";
                ID.Instance.nextLocationID();
                return addlocationValidationSuccessMessage;
            }
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
