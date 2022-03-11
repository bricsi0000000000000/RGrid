using System.Collections.Generic;
using System.Windows;

namespace CustomGrid
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Person> persons = new();
            for (int i = 0; i < 10; i++)
            {
                persons.Add(GeneratePerson(i));
            }

            rgrid.Items = persons;
        }

        private Person GeneratePerson(int index)
        {
            return new Person
            {
                Id = index,
                Name = $"Person{index}",
                Age = index,
                Gender = Gender.Male
            };
        }
    }
}
