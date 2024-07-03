using System.Reactive;
using FarmingSimApp.MainView.Launcher;
using FarmingSimApp.MainView.ModBrowser;
using FarmingSimApp.MainView.ModDb;
using FarmingSimApp.Shared.View;
using ReactiveUI;

namespace FarmingSimApp.MainView;

public class MainWindowViewModel : ViewModelBase
{
    #region Declarations ------------------------

    private ViewModelBase? _contentView;

    #endregion

    #region Veiw Properties ---------------------

    public ViewModelBase ContentView
    {
        get => _contentView!;
        private set => this.RaiseAndSetIfChanged(ref _contentView, value);
    }
    
    public ReactiveCommand<ViewModelBase, Unit> ShowContentView { get; }
    public ViewModelBase ModDbViewModel { get; } = new ModDbViewModel();
    public ViewModelBase LauncherViewModel { get; } = new LauncherViewModel();
    public ViewModelBase ModBrowserViewModel { get; } = new ModBrowserViewModel();

    #endregion

    #region C'tor -------------------------------

    public MainWindowViewModel()
    {
        ShowContentView = ReactiveCommand.Create<ViewModelBase>(ChangeContentView);
        ChangeContentView(ModDbViewModel);
    }

    #endregion

    #region Private Methods ---------------------

    private void ChangeContentView(ViewModelBase viewModel)
    {
        if (ContentView != viewModel)
            ContentView = viewModel;
    }

    #endregion
}