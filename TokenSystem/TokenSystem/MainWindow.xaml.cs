
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TokenSystem
{
    public partial class MainWindow : Window
    {
        private Queue<Patient> _patientQueue = new Queue<Patient>();
        private int _nextTokenNumber = 1;
        private Patient? _currentPatient = null;

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void BtnCreateToken_Click(object sender, RoutedEventArgs e)
        {
            RegisterPatient();
        }

        private void TxtPatientNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                RegisterPatient();
        }

        private void RegisterPatient()
        {
            string patientName = TxtPatientNameInput.Text.Trim();
            if (string.IsNullOrEmpty(patientName))
            {
                MessageBox.Show("Please enter a patient name.");
                return;
            }

            Patient newPatient = new Patient
            {
                TokenNumber = _nextTokenNumber++,
                Name = patientName
            };

            _patientQueue.Enqueue(newPatient);
            TxtPatientNameInput.Clear();
            UpdateUI();
        }

        private void BtnNextPatient_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPatient != null)
            {
                MessageBox.Show("Please finish the current consultation first.");
                return;
            }
            CallNextPatient();
        }

        private void BtnFinishVisit_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPatient == null)
            {
                MessageBox.Show("No active consultation to finish.");
                return;
            }
            _currentPatient = null;
            CallNextPatient();
        }

        private void CallNextPatient()
        {
            if (_patientQueue.Count > 0)
            {
                _currentPatient = _patientQueue.Dequeue();
                TxtCurrentPatientName.Text = _currentPatient.Name;
                TxtCurrentPatientToken.Text =$"Patient Token #{_currentPatient.FormattedToken}";
                TxtCurrentToken.Text = _currentPatient.DisplayTokenNumber;
                TxtConsultingStatus.Text = "Consulting";
                BorderConsultingStatus.Background =new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E1A47"));
                TxtConsultingStatus.Foreground =new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C084FC"));
            }
            else
            {
                _currentPatient = null;

                TxtCurrentPatientName.Text = "No patients waiting";
                TxtCurrentPatientToken.Text = "Patient Token #---";
                TxtCurrentToken.Text = "--";
                TxtConsultingStatus.Text = "Idle";
                BorderConsultingStatus.Background =new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1F1836"));
                TxtConsultingStatus.Foreground =new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9CA3AF"));
            }
            UpdateUI();
        }
        private void UpdateUI()
        {
            TxtWaitingCount.Text = _patientQueue.Count.ToString();
        }
    }
}
