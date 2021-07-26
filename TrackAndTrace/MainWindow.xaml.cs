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
        public MainWindow()
        {
            InitializeComponent();
            ID.Instance.nextUserID();
            ID.Instance.nextLocationID();
        }
            

        /*
         * Person interactions
         */

        // Person Interaction : Button click adds a Person with the details in the corrosponding text boxes
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
           // q.newPersonValidation(txtBoxPhoneNumberTrack.Text);
            listBoxMainWindow.Items.Add(q.newPersonValidation(txtBoxPhoneNumberTrack.Text));
            // done
        }

        // Person Interaction : Helper method for the btnAddPerson_Click event handler
   

        // Person Interaction : Displays every person in the people list in the Main Window List Box
        private void btnDisplayAllPeople_Click(object sender, RoutedEventArgs e)
        {
            listBoxMainWindow.Items.Add(q.displayAllPeopleQuery());
            // done
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
            // Validates that the date entered is parsable and adds the contact if so
            listBoxMainWindow.Items.Add(q.recordContactDateValidation(txtBoxUserIDTrack.Text, txtBoxContactUserIDTrack.Text, txtBoxDateAndTimeTrack.Text));
            // done
        }

        // Person Interaction :
        private void btnShowAllContacts_Click(object sender, RoutedEventArgs e)
        {

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
            listBoxMainWindow.Items.Add(q.addLocationValidation(txtBoxAddressTrack.Text));   
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
            listBoxMainWindow.Items.Add(q.searchForVisits(txtBoxStartDateTrace.Text, txtBoxEndDateTrace.Text, txtBoxVisitedLocationTrace.Text));
            // done
        }

      

     
    }
}
