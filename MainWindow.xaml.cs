using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.Vaiables;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<QuestionRecord> Questions { get; set; }

        private int _idCounter = 0;
        private readonly string _filePath;

        public MainWindow()
        {
            InitializeComponent();

            _filePath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "dane.json");

            Questions = new ObservableCollection<QuestionRecord>();

            DataContext = this;

            LoadFromFile();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _idCounter++;

            var record = new QuestionRecord
            {
                Id = _idCounter,
                Text = "Nowe pytanie",
                QuestionType = "closed"
            };

            Questions.Add(record);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = QuestionsDataGrid.SelectedItem as QuestionRecord;
            if (selected != null)
            {
                Questions.Remove(selected);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFromFile();
        }

        private void SaveToFile()
        {
            try
            {
                var list = new List<QuestionRecord>(Questions);
                var json = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(_filePath, json);
                MessageBox.Show("Zapisano do: " + _filePath, "Zapis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message);
            }
        }

        private void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return;

                var json = File.ReadAllText(_filePath);
                var list = JsonSerializer.Deserialize<List<QuestionRecord>>(json);

                Questions.Clear();

                if (list != null)
                {
                    foreach (var q in list)
                    {
                        Questions.Add(q);
                        if (q.Id > _idCounter)
                            _idCounter = q.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd odczytu: " + ex.Message);
            }
        }
    }
}
