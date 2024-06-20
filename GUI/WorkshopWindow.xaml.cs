using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkshopClasees.DataTransfer;
using WorkshopClasees;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для WorkshopWindow.xaml
    /// </summary>
    public partial class WorkshopWindow : Window
    {
        private Lumber _lumber;
        private Lumber _originalLumber;

        public WorkshopWindow(Lumber lumber)
        {
            InitializeComponent();
            _lumber = lumber;
            _originalLumber = (Lumber)lumber.Clone();
            SawingOptionComboBox.ItemsSource = Enum.GetValues(typeof(WorkshopClasees.SawingOption));
            LoadLumberData();
            this.Closing += Window_Closing;
        }

        private void LoadLumberData()
        {
            WoodTypeTextBox.Text = _lumber.Timber.WoodType;
            MoistureTextBox.Text = _lumber.Timber.Moisture.ToString();
            DensityTextBox.Text = _lumber.Timber.Density.ToString();
            SawingOptionComboBox.SelectedItem = _lumber.SawingOption;
            DeliveryDatePicker.SelectedDate = _lumber.DeliveryDate;
            MarkingTextBox.Text = _lumber.Marking.ToString();
            QuantityTextBox.Text = _lumber.Quantity.ToString();
            PricePerUnitTextBox.Text = _lumber.UnitPrice.ToString();

            WoodTypeTextBox.TextChanged += WoodTypeTextBox_TextChanged;
            MoistureTextBox.TextChanged += MoistureTextBox_TextChanged;
            DensityTextBox.TextChanged += DensityTextBox_TextChanged;
            MarkingTextBox.TextChanged += MarkingTextBox_TextChanged;
            QuantityTextBox.TextChanged += QuantityTextBox_TextChanged;
            PricePerUnitTextBox.TextChanged += PricePerUnitTextBox_TextChanged;
            DeliveryDatePicker.SelectedDateChanged += DeliveryDatePicker_SelectedDateChanged;
        }

        private void WoodTypeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _lumber.Timber.WoodType = WoodTypeTextBox.Text;
        }

        private void MoistureTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(MoistureTextBox.Text, out int value))
            {
                _lumber.Timber.Moisture = value;
            }
        }

        private void DensityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(DensityTextBox.Text, out int value))
            {
                _lumber.Timber.Density = value;
            }
        }

        private void MarkingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(MarkingTextBox.Text, out int value))
            {
                _lumber.Marking = value;
            }
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(QuantityTextBox.Text, out int value))
            {
                _lumber.Quantity = value;
            }
        }

        private void PricePerUnitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(PricePerUnitTextBox.Text, out int value))
            {
                _lumber.UnitPrice = value;
            }
        }

        private void DeliveryDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeliveryDatePicker.SelectedDate.HasValue)
            {
                _lumber.DeliveryDate = DeliveryDatePicker.SelectedDate.Value;
            }
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private bool IsTextNumeric(string text)
        {
            return Regex.IsMatch(text, @"^[0-9]*(?:\.[0-9]*)?$");
        }

        private void SaveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Будь ласка, введіть дійсні числові значення.", "Validation Error", MessageBoxButton.OK); //MessageBoxImage.Error
                return;
            }

            SaveLumberData();
            DialogResult = true;
            Close();
        }

        private bool ValidateInputs()
        {
            return int.TryParse(MoistureTextBox.Text, out _) &&
                   int.TryParse(DensityTextBox.Text, out _) &&
                   int.TryParse(MarkingTextBox.Text, out _) &&
                   int.TryParse(QuantityTextBox.Text, out _) &&
                   int.TryParse(PricePerUnitTextBox.Text, out _);
        }

        private void CancelAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SaveLumberData()
        {
            var newTimber = new TimberDTO
            {
                WoodType = WoodTypeTextBox.Text,
                Moisture = int.Parse(MoistureTextBox.Text),
                Density = int.Parse(DensityTextBox.Text)
            };

            _lumber.Timber.WoodType = WoodTypeTextBox.Text;
            _lumber.SawingOption = (SawingOption)SawingOptionComboBox.SelectedItem;
            _lumber.DeliveryDate = (DateTime)DeliveryDatePicker.SelectedDate;
            _lumber.Marking = int.Parse(MarkingTextBox.Text);
            _lumber.Quantity = int.Parse(QuantityTextBox.Text);
            _lumber.UnitPrice = int.Parse(PricePerUnitTextBox.Text);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult != true)
            {
                if (!_lumber.Equals(_originalLumber))
                {
                    var result = MessageBox.Show("Ви хочете зберегти зміни?", "Confirmation", MessageBoxButton.YesNoCancel);
                    if (result == MessageBoxResult.Yes)
                    {
                        SaveLumberData();
                        DialogResult = true;
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        _lumber = (Lumber)_originalLumber.Clone();
                        DialogResult = false;
                    }

                    else if (result == MessageBoxResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
