using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using WorkshopClasees;
using WorkshopClasees.Converters;
using WorkshopClasees.DataTransfer;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Workshop _workshop;
        private const string JsonFilePath = "workshop.json";

        public MainWindow()
        {
            InitializeComponent();
            _workshop = File.Exists(JsonFilePath)
                ? DeserializeWorkshopFromJson(JsonFilePath)
                : new Workshop();
            UpdateLumberList();
        }

        private void UpdateLumberList()
        {
            LumberListBox.Items.Clear();
            foreach (var lumber in _workshop.Lumbers)
            {
                LumberListBox.Items.Add(lumber.ToString());
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var lumber = new Lumber(new Timber("123", 133, 22), WorkshopClasees.SawingOption.ДошкаОбрізана, DateTime.Now, 32, 22, 333);
            var lumberWindow = new WorkshopWindow(lumber);
            if (lumberWindow.ShowDialog() == true)
            {
                _workshop.AddLumber(lumber);
                UpdateLumberList();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (LumberListBox.SelectedItem != null)
            {
                var selectedIndex = LumberListBox.SelectedIndex;
                var lumber = _workshop.Lumbers[selectedIndex];
                var lumberWindow = new WorkshopWindow(lumber);
                if (lumberWindow.ShowDialog() == true)
                {
                    UpdateLumberList();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SerializeWorkshopToJson(_workshop, JsonFilePath);
        }

        private void SerializeWorkshopToJson(Workshop workshop, string filePath)
        {
            var dto = WorkshopConverter.ToDTO(workshop);
            var json = JsonConvert.SerializeObject(dto, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private Workshop DeserializeWorkshopFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var dto = JsonConvert.DeserializeObject<WorkshopDTO>(json);
            return WorkshopConverter.FromDTO(dto);
        }
    }
}
