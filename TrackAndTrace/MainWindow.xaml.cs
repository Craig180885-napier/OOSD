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
        
        //Track t = new Track();
        //Validation v = new Validation();
        QueryClass q = new QueryClass();
        LoadData d = new LoadData();
        SaveData sd = new SaveData();


        public MainWindow()
        {
            InitializeComponent();
            ID.Instance.nextUserID();
            ID.Instance.nextLocationID();
            loadUsersFromFile();
            loadLocationsFromFile();
            loadContactsFromFile();
            loadVisitsFromFile();
        }

        private void loadLocationsFromFile()
        {
            foreach (Location l in d.displayAllLocationsFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.addLocationValidation(l.locationID, l.address));
            }         
        }

        private void loadContactsFromFile()
        {
            foreach (Person p in d.displayAllContactsFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.recordContactDateValidation(p.userID.ToString(), p.contactUserID.ToString(), p.contactDate.ToString()));
            }
        }

        private void loadVisitsFromFile()
        {
            foreach (Location l in d.displayAllVisitsFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.checkIn(l.userID.ToString(), l.locationID.ToString(), l.checkInDate.ToString()));
            }
        }

        private void SaveUsersToFile()
        {
            //foreach (Person p in q.returnAllPeopleList())
            //{
               sd.saveUsersToFile(q.returnAllPeopleList());
            //}
        }
        /*
         * Person interactions
         */

        // Person Interaction : Loads the users from the Csv file and adds them to the appropriate List
        private void loadUsersFromFile()
        {
            foreach (Person p in d.displayAllPeopleFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.newPersonValidation(p.userID, p.telephoneNumber));
            }
        }
        // Person Interaction : Button click adds a Person with the details in the corrosponding text boxes
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
           // q.newPersonValidation(txtBoxPhoneNumberTrack.Text);
            listBoxMainWindow.Items.Add(q.newPersonValidation(0, txtBoxPhoneNumberTrack.Text));
            // done
        }

        // Person Interaction : Helper method for the btnAddPerson_Click event handler
   

        // Person Interaction : Displays every person in the people list in the Main Window List Box
        private void btnDisplayAllPeople_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllPeopleQuery());
            // done
        }

        // Person Interaction :
        private void BtnLoadUsers_Click(object sender, RoutedEventArgs e)
        {
            loadUsers();
        }

        private void loadUsers()
        {
            listBoxMainWindow.Items.Add(d.displayAllPeopleFromFile());
            foreach (Person p in d.displayAllPeopleFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.newPersonValidation(p.userID, p.telephoneNumber));
            }
        }

        // Person Interaction : Saves the contents of the person list to the CSV file.  Users are appended not overwritten.
        private void BtnSaveUsersTrack_Click(object sender, RoutedEventArgs e)
        {
            SaveUsersToFile();
        }

        // Person Interaction :
        private void btnRecordContact_Click(object sender, RoutedEventArgs e)
        {
            // Validates that the date entered is parsable and adds the contact if so
            listBoxMainWindow.Items.Add(q.recordContactDateValidation(txtBoxUserIDTrack.Text, txtBoxContactUserIDTrack.Text, txtBoxDateAndTimeTrack.Text));
            // done
        }

        // Person Interaction :
        private void btnShowAllContacts_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllContactsQuery());
        }

        // Person Interaction :
        // TODO wrap the body of this method in its own method and call
        private void btnSearchForContactsMainWindow_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.searchForContactsQuery(txtBoxStartDateTrace.Text, txtBoxContactUserIDTrace.Text));
            // done
        }

        /*
         * Location Interactions
         */

        // Location Interaction : Button click adds a location with the deatils in the corrosponding text boxes
        private void btnAddLocation_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.addLocationValidation(0, txtBoxAddressTrack.Text));   
            // done
        }

        // Location Interaction : Shows all of the locations that have been created
        private void btnDisplayLocations_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllLocationsQuery());
            // done
        }

        // Location Interaction : Checks a user into a location 
        // TODO Think this XAML link is broken
        private void btnCheckInMainWindow_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.checkIn(txtBoxUserIDTrack.Text, txtBoxLocationIDTrack.Text, txtBoxDateAndTimeTrack.Text));
            // not done
        }

        // TODO: check which one of these event handlers is the correct one and get rid of the other
        // Location Interaction : Checks a user into a location 
        private void btnCheckInMainWindow_Click_1(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.checkIn(txtBoxUserIDTrack.Text, txtBoxLocationIDTrack.Text, txtBoxDateAndTimeTrack.Text));
            // done
        }

        // Location Interaction : Shows all of the users that have checked in 
        private void btnShowAllVisits_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllVisitsQuery());
            // done
        }

        // Location Interaction :
        private void btnSearchForVisits_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.searchForVisitsQuery(txtBoxStartDateTrace.Text, txtBoxEndDateTrace.Text, txtBoxVisitedLocationTrace.Text));
            // done
        }

        private void BtnClearListBoxTrack_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Clear();
        }

        private void BtnLoadLocationsTrack_Click(object sender, RoutedEventArgs e)
        {
            loadLocationsFromFile();
        }

        private void BtnSaveLocationsTrack_Click(object sender, RoutedEventArgs e)
        {
            saveLocationsToFile();
        }

        private void saveLocationsToFile()
        {
            sd.saveLocationsToFile(q.returnAllLocationsList());
            listBoxMainWindow.Items.Add(q.returnAllLocationsList().ToList().Capacity + " Locations saved");
        }

        private void BtnSaveAllContactsTrace_Click(object sender, RoutedEventArgs e)
        {
            saveContactsToFile();
        }

        private void saveContactsToFile()
        {
            sd.saveContactsToFile(q.returnAllContactsList());
            listBoxMainWindow.Items.Add(q.returnAllContactsList().ToList().Capacity + " Contacts saved");
        }

        private void BtnSaveVisitsTrace_Click(object sender, RoutedEventArgs e)
        {
            saveVisitsToFile();
        }

        private void saveVisitsToFile()
        {
            sd.saveVisitsToFile(q.returnAllVisitsList());
            listBoxMainWindow.Items.Add(q.returnAllVisitsList().ToList().Capacity + " Visits saved");
        }
    }
}
