using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrackAndTrace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Track t = new Track();
        public MainWindow()
        {
            InitializeComponent();
            ID.Instance.nextUserID();
            ID.Instance.nextLocationID();

        }

        private void lineBreak()
        {
            listBoxMainWindow.Items.Add("--------------------------------------");
        }

        /*
         * Person interactions
         */

        // Person Interaction : Button click adds a Person with the details in the corrosponding text boxes
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            newPersonValidation();
        }

        // Person Interaction : Helper method for the btnAddPerson_Click event handler
        private void newPersonValidation()
        {
            // This method validate that the phone number meets the criteria and that the User ID is unique, 
            // if both conditions are met the user is added to the Person class

            // Variables
            var validPeople = t.getPeople();
            bool isUnique = true;

            // User ID validation Step 1, if the people list is empty there is no need to check if the User ID entered is unique.
            if (validPeople.Capacity < 1)
            {
                string phoneNumber = txtBoxPhoneNumberTrack.Text;

                // Phone Number Validation, must be 11 integer numbers long, and must begin with a 0
                if (!phoneNumber[0].Equals('0') || phoneNumber.Equals(null) || phoneNumber.Length < 11)
                {
                    listBoxMainWindow.Items.Add("Invalid Phone Number entered \n" +
                                                "- Your Phone Number Must: \n" +
                                                "- Begin With a 0 \n" +
                                                "- Be 11 numbers long or more \n" +
                                                "- you entered: - " + txtBoxPhoneNumberTrack.Text + "\n" +
                                                "- Please Try again");
                    lineBreak();

                }
                // Phone number is valid, user is added to the person list
                else
                {
                    listBoxMainWindow.Items.Add("Capacity = 0 - Phone Number entered is valid - " + txtBoxPhoneNumberTrack.Text);
                    listBoxMainWindow.Items.Add("User : - " + ID.Instance.currentUserID() + " has been added");
                    lineBreak();
                    t.addPerson(ID.Instance.currentUserID(), txtBoxPhoneNumberTrack.Text);
                    ID.Instance.nextUserID();
                    validPeople = t.getPeople();
                }
            }

            // User ID validation Step 2
            else if (validPeople.Capacity > 0)
            {
                foreach (Person p in validPeople.ToList())
                {
                    // If the user ID is not unique then present an error and do not add the person to the list
                    // sets the bool isUnique to false 
                    //if (p.userID == ID.Instance.currentUserID())
                    if (p.userID == int.Parse(txtBoxUserIDTrack.Text))
                    {
                        listBoxMainWindow.Items.Add("User ID already exisits, please enter a unique user ID \n");
                        lineBreak();
                        isUnique = false;
                        listBoxMainWindow.Items.Add("is valid is : -" + isUnique);
                        break;
                    }
                }

                if (isUnique == true)
                {
                    // Holds the text box input in a string variable so that if conditions can be set
                    string phoneNumber = txtBoxPhoneNumberTrack.Text;

                    // Phone Number Validation, must be 11 integer numbers long, and must begin with a 0
                    if (!phoneNumber[0].Equals('0') || phoneNumber.Equals(null) || phoneNumber.Length < 11)
                    {
                        listBoxMainWindow.Items.Add("Invalid Phone Number entered \n" +
                                                    "- Your Phone Number Must: \n" +
                                                    "- Begin With a 0 \n" +
                                                    "- Be 11 numbers long or more \n" +
                                                    "- you entered: - " + txtBoxPhoneNumberTrack.Text + "\n" +
                                                    "- Please Try again");
                        lineBreak();
                    }

                    // If the phone number meets the criteria and the user ID is unique adds this user to the Person list
                    else
                    {
                        listBoxMainWindow.Items.Add("is valid is : -" + isUnique);
                        listBoxMainWindow.Items.Add("User : - " + ID.Instance.currentUserID() + " has been added");
                        listBoxMainWindow.Items.Add("Capacity > 0 - Phone Number entered is valid - " + txtBoxPhoneNumberTrack.Text);
                        listBoxMainWindow.Items.Add("---------------------------------------------");

                        t.addPerson(ID.Instance.currentUserID(), txtBoxPhoneNumberTrack.Text);
                        ID.Instance.nextUserID();
                  
                    }
                }
            }           
        }

        // Person Interaction : Displays every person in the people list in the Main Window List Box
        private void btnDisplayAllPeople_Click(object sender, RoutedEventArgs e)
        {
            var v = t.getPeople();
            foreach (Person f in v)
            {
                listBoxMainWindow.Items.Add("User ID : - " + f.userID);
                listBoxMainWindow.Items.Add("Telephone number : - " + f.telephoneNumber);
                lineBreak();
            }
        }

        // Person Interaction :
        private void BtnLoadUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        // Person Interaction : Saves the contents of the person list to the CSV file.  Users are appended not overwritten.
        private void BtnSaveUsersTrack_Click(object sender, RoutedEventArgs e)
        {

        }

        // Person Interaction :
        private void btnRecordContact_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(txtBoxDateAndTimeTrack.Text, out date) == false)
            {
                listBoxMainWindow.Items.Add("Date cannot be empty : - ");
                lineBreak();
            }
            else
            {
                t.addContact(int.Parse(txtBoxUserIDTrack.Text), int.Parse(txtBoxContactUserIDTrack.Text), DateTime.Parse(txtBoxDateAndTimeTrack.Text));
            }
        }

        // Person Interaction :
        private void btnShowAllContacts_Click(object sender, RoutedEventArgs e)
        {

        }

        // Person Interaction :
        // TODO wrap the body of this method in its own method and call
        private void btnSearchForContactsMainWindow_Click(object sender, RoutedEventArgs e)
        {
            var contactList = t.getContacts();
            var result = from v in contactList
                         where v.contactDate > DateTime.Parse(txtBoxStartDateTrace.Text)
                         where v.userID == int.Parse(txtBoxContactUserIDTrace.Text)
                         select v;

            var updatedContactList = t.getPeople();



            foreach (Person q in result.ToList())
            {
                // listBoxMainWindow.Items.Add("User ID : - " + q.userID);
                var result2 = from b in updatedContactList
                              where b.userID == q.contactUserID
                              select b;

                foreach (Person h in result2.ToList())
                {
                    listBoxMainWindow.Items.Add("List of contacts for User: - " + q.userID);
                    listBoxMainWindow.Items.Add("Contact User ID : - " + q.contactUserID);
                    listBoxMainWindow.Items.Add("Telephone Number : - " + h.telephoneNumber);
                    listBoxMainWindow.Items.Add("Date of Contact : - " + q.contactDate);
                    lineBreak();
                }
            }
        }

        /*
         * Location Interactions
         */

        // Location Interaction : Button click adds a location with the deatils in the corrosponding text boxes
        private void btnAddLocation_Click(object sender, RoutedEventArgs e)
        {
            //string esd = ;
            //int w = int.Parse(esd);
            t.addLocation(ID.Instance.currentLocationID(), txtBoxAddressTrack.Text);
            listBoxMainWindow.Items.Add("Location ID : - " + ID.Instance.currentLocationID() + " Has been added");
            listBoxMainWindow.Items.Add("Address: - " + txtBoxAddressTrack.Text);
            lineBreak();
            ID.Instance.nextLocationID();
        }

        // Location Interaction : Shows all of the locations that have been created
        private void btnDisplayLocations_Click(object sender, RoutedEventArgs e)
        {
            var v = t.getLocations();

            foreach (Location r in v)
            {
                listBoxMainWindow.Items.Add("Location ID : - " + r.locationID);
                listBoxMainWindow.Items.Add("Address: - " + r.address);
                lineBreak();
            }
        }

        // Location Interaction : Checks a user into a location 
        // TODO Think this XAML link is broken
        private void btnCheckInMainWindow_Click(object sender, RoutedEventArgs e)
        {
            t.checkIn(int.Parse(txtBoxUserIDTrack.Text), int.Parse(txtBoxLocationIDTrack.Text), DateTime.Parse(txtBoxDateAndTimeTrack.Text));
        }

        // Location Interaction : Checks a user into a location 
        private void btnCheckInMainWindow_Click_1(object sender, RoutedEventArgs e)
        {
            t.checkIn(int.Parse(txtBoxUserIDTrack.Text), int.Parse(txtBoxLocationIDTrack.Text), DateTime.Parse(txtBoxDateAndTimeTrack.Text));
        }

        // Location Interaction : Shows all of the users that have checked in 
        private void btnShowAllVisits_Click(object sender, RoutedEventArgs e)
        {
            var v = t.getVisits();
            foreach (Location f in v)
            {
                listBoxMainWindow.Items.Add("User ID : - " + f.userID);
                listBoxMainWindow.Items.Add("Location ID : - " + f.locationID);
                listBoxMainWindow.Items.Add("Check In Date : - " + f.checkInDate);
                lineBreak();
            }
        }

        // Location Interaction :
        private void btnSearchForVisits_Click(object sender, RoutedEventArgs e)
        {
            var visitList = t.getVisits();
            var result = from v in visitList
                         where v.checkInDate >= DateTime.Parse(txtBoxStartDateTrace.Text)
                         where v.checkInDate <= DateTime.Parse(txtBoxEndDateTrace.Text)
                         where v.locationID == int.Parse(txtBoxVisitedLocationTrace.Text)
                         select v;

            var updatedVisitList = t.getPeople();

            listBoxMainWindow.Items.Add("List of Visits for Location ID: - " + txtBoxVisitedLocationTrace.Text);
            lineBreak();

            foreach (Location q in result.ToList())
            {
                // listBoxMainWindow.Items.Add("User ID : - " + q.userID);
                var result2 = from b in updatedVisitList
                              where b.userID == q.userID
                              select b;

                foreach (Person h in result2.ToList())

                {
                    listBoxMainWindow.Items.Add("Contact User ID : - " + h.userID);
                    listBoxMainWindow.Items.Add("Telephone Number : - " + h.telephoneNumber);
                    listBoxMainWindow.Items.Add("Date of Visit : - " + q.checkInDate);
                    lineBreak();

                }
            }
        }

      

     
    }
}
