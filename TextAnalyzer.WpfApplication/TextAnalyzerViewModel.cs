using System.ComponentModel;
using System.Windows.Input;

namespace TextAnalyzer.WpfApplication
{
    public class TextAnalyzerViewModel : INotifyPropertyChanged
    {
        public TextAnalyzerViewModel()
        {
            _textAnalyzer = new TextAnalyzer { NumberOfSentence = 0, WordFrequencies = null, NumberofWords = 0};
        }

        TextAnalyzer _textAnalyzer;
        public TextAnalyzer TextAnalyzer
        {
            get
            {
                return _textAnalyzer;
            }
            set
            {
                _textAnalyzer = value;
                RaisePropertyChanged("TextAnalyzer");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        void UpdateCalculateWordFrequencyExecute()
        {
            
        }

        bool CanUpdateArtistNameExecute()
        {
            return true;
        }

        public ICommand UpdateWordFrequencyCount { get { return new RelayCommand(UpdateCalculateWordFrequencyExecute, CanUpdateArtistNameExecute); } }
    }
}

