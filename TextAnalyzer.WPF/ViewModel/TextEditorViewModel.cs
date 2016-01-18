using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TextAnalyzer.WPF.Commands;
using TextAnalyzer.WPF.Model;
using TextAnalyzer.Interface;

namespace TextAnalyzer.WPF.ViewModel
{
    internal class TextEditorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ReportModel> _reportModels;
        public ObservableCollection<ReportModel> ReportModels
        {
            get
            {
                return _reportModels;
            }
            set
            {
                _reportModels = value;
                OnPropertyChanged("ReportModels");
            }
        }
        public IWordFrequencyCounter WordFrequencyCounter { get; private set; }
        public TextEditorModel TextEditor { get; set; }
        private DelegateCommand _saveTextEditorCommand;

        public ICommand SaveTextEditorCommand
        {
            get { return _saveTextEditorCommand ?? (_saveTextEditorCommand = new DelegateCommand(SaveExecuted, SaveCanExecute)); }
        }
        
        public TextEditorViewModel(IWordFrequencyCounter wordFrequencyCounter)
        {
            _reportModels = new ObservableCollection<ReportModel>();
            TextEditor = new TextEditorModel { Text = string.Empty};
            WordFrequencyCounter = wordFrequencyCounter;
        }

        public bool SaveCanExecute()
        {
            return true;
        }

        public void SaveExecuted()
        {
            WordFrequencyCounter.Reset();
            WordFrequencyCounter.AddSentence(TextEditor.Text);
            WordFrequencyCounter.Calculate();
            MapToReportModel(WordFrequencyCounter);
        }


        private void MapToReportModel(IWordFrequencyCounter counter)
        {
            _reportModels = new ObservableCollection<ReportModel>();
            int count = 1;
            foreach (var key in counter.WordFrequency.Keys)
            {
                _reportModels.Add(new ReportModel { Occurance = counter.WordFrequency[key], Word = key, Id=count++});
            }
            OnPropertyChanged("ReportModels");
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }


    }
}
