using System.ComponentModel;

namespace TextAnalyzer.WPF.Model
{
    internal class ReportModel : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _word;
        public string Word
        {
            get { return _word; }
            set
            {
                _word = value;
                OnPropertyChanged("Word");
            }
        }

        private int _occurance;
        public int Occurance
        {
            get { return _occurance; }
            set
            {
                _occurance = value;
                OnPropertyChanged("Occurance");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}