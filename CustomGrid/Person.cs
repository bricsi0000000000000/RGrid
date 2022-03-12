using System.ComponentModel;

namespace CustomGrid
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
