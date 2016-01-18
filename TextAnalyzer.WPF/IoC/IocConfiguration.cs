using Ninject.Modules;
using TextAnalyzer.Interface;
using TextAnalyzer.WPF.ViewModel;

namespace TextAnalyzer.WPF.IoC
{
    internal class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IWordFrequencyCounter>().To<Implementation.WordFrequencyCounter>().InSingletonScope(); 
            Bind<TextEditorViewModel>().ToSelf().InSingletonScope(); 
        }
    }
}