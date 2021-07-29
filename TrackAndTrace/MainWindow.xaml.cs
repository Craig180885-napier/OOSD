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
    /// 
    /**
     * There are helper methods for the event handlers in this class which I suspect would normally be in their own class or classes, I didn't have the time to build this in 
     * but I do realise that this method is cluttered and harder to navigate than it should be as a result
     **/
    public partial class MainWindow : Window
    {
        
     
        Query q = new Query();
        LoadData d = new LoadData();      

        /* 
         * This method is called when the app is launched.  Sets up the singleton implementation of User ID and Location ID
         * which is used to allocate unique integer IDs. 
         * Loads all of the data in the csv into the related lists and displays the output of these processes in the list box
         */
        
        public MainWindow()
        {
            InitializeComponent();
            ID.Instance.nextUserID();
            ID.Instance.nextLocationID();
            loadAllData();
        }
        
        /*
         * Load Data Methods and corrosponding load data button methods 
         */ 

        // Calls all methods that load data from the CSVs
        private void loadAllData()
        {
            loadPeopleFromFile();
            loadLocationsFromFile();
            loadContactsFromFile();
            loadVisitsFromFile();
            loadStatusMessage();
        }

        private void loadStatusMessage()
        {
            listBoxMainWindow.Items.Add(d.loadAllPeopleFromFile().ToList().Capacity + " People were loaded from the CSV file \n" + q.lineBreak() + "\n");
            listBoxMainWindow.Items.Add(d.loadAllLocationsFromFile().ToList().Capacity + " Locations were loaded from the CSV file \n" + q.lineBreak() + "\n");
            listBoxMainWindow.Items.Add(d.loadAllContactsFromFile().ToList().Capacity + " Contacts were loaded from the CSV file \n" + q.lineBreak() + "\n");
            listBoxMainWindow.Items.Add(d.loadAllVisitsFromFile().ToList().Capacity + " Visits were loaded from the CSV file \n" + q.lineBreak() + "\n");
        }
        // Person Interaction : Load People button - for demo and debugging purposes
        private void btnLoadPeopleTrack_Click(object sender, RoutedEventArgs e)
        {          
             loadPeopleFromFile();
        }

        // Person Interaction : Loads the users from the Csv file and adds them to the appropriate List
        private void loadPeopleFromFile()
        {
            foreach (Person p in d.loadAllPeopleFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.newPersonValidation(p.userID, p.telephoneNumber));                
            }
            // Load People success message output to the list box
                       
        }

        // Location Interaction : Load locations button event handler
        private void btnLoadLocationsTrack_Click(object sender, RoutedEventArgs e)
        {
            loadLocationsFromFile();
        }

        // Location Interaction : Load Locations method - Loads data from the csv file into a list of type Location  
        private void loadLocationsFromFile()
        {
            foreach (Location l in d.loadAllLocationsFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.addLocationValidation(l.locationID, l.address));
            }
            // Load Loactions success message output to the list box
            
        }

        // Person Interaction : Load Contacts method - Loads data from the csv file into a list of type Location  
        // Has no button and therefore no event handler method
        private void loadContactsFromFile()
        {
            foreach (Person p in d.loadAllContactsFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.recordContactDateValidation(p.userID.ToString(), 
                    p.contactUserID.ToString(), p.contactDate.ToString()));
            }
            // Load Contcats success message output to the list box
            
        }

        // Location Interaction : Load Visits method -  Loads data from the csv file into a list of type Location
        // Has no button and therefore no event handler method
        private void loadVisitsFromFile()
        {
            foreach (Location l in d.loadAllVisitsFromFile().ToList())
            {
                listBoxMainWindow.Items.Add(q.checkIn(l.userID.ToString(), l.locationID.ToString(), l.checkInDate.ToString())); 
            }
            // Load visits success message output to the list box
           
        }      

        /*
         * Save Data Methods and corrosponding load data button methods 
         */

        // Person Interaction : Save People event handler.
        private void btnSavePeopleTrack_Click(object sender, RoutedEventArgs e)
        {
            savePeopleToFile();
        }

        // Person Interaction : Saves the contents of the person list to the CSV file.  Users are appended not overwritten.
        private void savePeopleToFile()
        {           
            d.saveUsersToFile(q.returnAllPeopleList()); // Saves to CSV file      
        }

        // Person Interaction : Save Contacts event handler.
        private void btnSaveAllContactsTrace_Click(object sender, RoutedEventArgs e)
        {
            saveContactsToFile();
        }

        // Person Interaction : Save Contacts method - Saves all contacts to the CSV file and outputs how many contacts were saved in
        // the list box
        private void saveContactsToFile()
        {
            d.saveContactsToFile(q.returnAllContactsList()); // Saves to CSV file  
            listBoxMainWindow.Items.Add(q.returnAllContactsList().ToList().Capacity + " Contacts saved"); // outputs success message to listbox
        }

        // Location Interaction : Save Locations event handler
        private void btnSaveLocationsTrack_Click(object sender, RoutedEventArgs e)
        {
            saveLocationsToFile();
        }

        // Person Interaction : Save Locations method - Saves all contacts to the CSV file and outputs how many Locations were saved in
        // the list box
        private void saveLocationsToFile()
        {
            d.saveLocationsToFile(q.returnAllLocationsList()); // Saves to CSV file  
            listBoxMainWindow.Items.Add(q.returnAllLocationsList().ToList().Capacity + " Locations saved"); // outputs success message to listbox
        }

        // Location Interaction : Save Visits event handler
        private void btnSaveVisitsTrace_Click(object sender, RoutedEventArgs e)
        {
            saveVisitsToFile();
        }

        // Person Interaction : Save Visits method - Saves all contacts to the CSV file and outputs how many Visits were saved in
        // the list box
        private void saveVisitsToFile()
        {
            d.saveVisitsToFile(q.returnAllVisitsList()); // Saves to CSV file
            listBoxMainWindow.Items.Add(q.returnAllVisitsList().ToList().Capacity + " Visits saved"); // outputs success message to listbox
        }

        /*
         * Person interactions outside of persistence
         */

        // Person Interaction : Button click adds a Person with the details in the corrosponding text boxes
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
           // q.newPersonValidation(txtBoxPhoneNumberTrack.Text);
            listBoxMainWindow.Items.Add(q.newPersonValidation(0, txtBoxPhoneNumberTrack.Text)); // Displays the output in the listbox
        }

        // Person Interaction : Displays every person in the people list in the Main Window List Box
        private void btnDisplayAllPeople_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllPeopleQuery()); // Displays the output in the listbox
        }

        // Person Interaction : Records a contact between two people and displays output in the list box
        private void btnRecordContact_Click(object sender, RoutedEventArgs e)
        {
            // Validates that the date entered is parsable and adds the contact if so
            listBoxMainWindow.Items.Add(q.recordContactDateValidation(txtBoxUserIDTrack.Text, 
                txtBoxContactUserIDTrack.Text, txtBoxDateAndTimeTrack.Text));  // Displays the output in the listbox
        } 

        // Person Interaction : Shows all contacts in the listbox - for debuggind and demo purposes
        private void btnShowAllContacts_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllContactsQuery()); // Displays the output in the listbox
        } 

        // Person Interaction : Outputs a list of contacs to the list box based on the person and the date entered in the GUI
        private void btnSearchForContactsTrace_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.searchForContactsQuery(txtBoxStartDateTrace.Text, 
                                        txtBoxContactUserIDTrace.Text)); // Displays the output in the listbox
        } 

        /*
         * Location Interactions outside of persistence
         */

        // Location Interaction : Button click adds a location with the deatils in the corrosponding text boxes
        private void btnAddLocation_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.addLocationValidation(0, txtBoxAddressTrack.Text)); // Displays the output in the listbox
        }// done

        // Location Interaction : Shows all of the locations that have been created - for debugging and demo purposes
        private void btnDisplayLocations_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllLocationsQuery()); // Displays the output in the listbox
        }// done
              
        // Location Interaction : Checks a user into a location 
        private void btnCheckInTrack_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.checkIn(txtBoxUserIDTrack.Text, 
                txtBoxLocationIDTrack.Text, txtBoxDateAndTimeTrack.Text)); // Displays the output in the listbox
        }// done

        // Location Interaction : Shows all of the users that have checked in - for demo and debugging purposes
        private void btnShowAllVisits_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.getAllVisitsQuery()); // Displays the output in the listbox
            // done
        }

        // Location Interaction : Outputs all of the visits that match the input search criteria
        private void btnSearchForVisits_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.searchForVisitsQuery(txtBoxStartDateTrace.Text, 
                txtBoxEndDateTrace.Text, txtBoxVisitedLocationTrace.Text)); // Displays the output in the listbox
        }

        // Clears the list box
        private void btnClearListBoxTrack_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Clear();
        }

  
    }
}
