using Ninject.Modules;
using TextAnalyzer.Interface;
using TextAnalyzer.WPF.Model;
using TextAnalyzer.WPF.ViewModel;

namespace TextAnalyzer.WPF.IoC
{
    internal class ViewModelLocator
    {
        public TextEditorViewModel TextEditorViewModel
        {
            get { return IocKernel.Get<TextEditorViewModel>(); } // Loading TextEditorViewModel will automatically load the binding for IWordFrequencyCounter
        }
    }
}