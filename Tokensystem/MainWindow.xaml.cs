using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace TokenSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int tokenNumber = 0;
        private Queue<string> patientQueue = new Queue<string>();
        private bool doctorArrived = false;
        private int currentToken = 0;
        private bool consultationFinished = false;
        private void UpdateDisplay()
        {
            txtWaiting.Text = patientQueue.Count.ToString();
            if (patientQueue.Count == 0 && (currentToken == 0 || consultationFinished))
            {
                txtPatientName.Text = "NO patients waiting";
                txtPatientToken.Text = "Patient Token #---";
            }
        }
       
            public MainWindow()
        {
            InitializeComponent();
        }
        // Register patient and create token
        private void btnCreateToken_Click(object sender, RoutedEventArgs e)
        {
            string patientName = txtNewPatient.Text.Trim();

            if (patientName == "")
            {
                txtMessage.Text = "Please enter patient name.";
            }
            else
            {
                tokenNumber++;
                string patientDetails = tokenNumber.ToString("D3") + "|" + patientName;
                patientQueue.Enqueue(patientDetails);
                txtMessage.Text ="Token #" + tokenNumber.ToString("D3") + " created successfully.";
                txtNewPatient.Clear();
                UpdateDisplay();
            }
        }

        // Doctor arrives
        private void btnDoctorArrived_Click(object sender, RoutedEventArgs e)
        {
            doctorArrived = true;
            txtStatus.Text = "Doctor has arrived";
            txtMessage.Text = "Doctor is ready.";
            CallNextPatient(); 
        }
        private void CallNextPatient()
        {
            if (doctorArrived && patientQueue.Count > 0)
            {
                string patientDetails = patientQueue.Dequeue();
                txtCurrentToken.Text = patientDetails;
                UpdateDisplay();
            }
        }

        private void txtNewPatient_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (patientQueue.Count == 0)
            {
                currentToken = 0;

                txtCurrentToken.Text = "--";
                txtPatientName.Text = "No patients waiting";
                txtPatientToken.Text = "Patient Token #---";
                txtStatus.Text = "Queue is empty";
                consultationFinished = true;
                txtMessage.Text = "No patients waiting.";
                UpdateDisplay();
            }
            else
            {
                string patientDetails = patientQueue.Dequeue();
                string[] details = patientDetails.Split('|');
                currentToken = int.Parse(details[0]);
                txtPatientName.Text = details[1];
                txtPatientToken.Text = "Patient Token #" + currentToken.ToString("D3");
                txtCurrentToken.Text = currentToken.ToString("D3");
                txtStatus.Text = "Consulting";
                consultationFinished = false;

                txtMessage.Text = "Next patient called successfully.";
                UpdateDisplay();
            }
        }
      
    }
}