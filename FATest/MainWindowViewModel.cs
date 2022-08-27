using System.Collections.Generic;
using System.Windows.Input;
using Avalonia.Threading;
using FluentAvalonia.UI.Controls;
using ReactiveUI;

namespace FATest;

public class MainWindowViewModel : ReactiveObject
{
    private int _selectedItemIndex;

    public MainWindowViewModel()
    {
        NavigateToPage2Command = ReactiveCommand.Create(NavigateToPage2);
    }

    public List<NavigationViewItem> Items { get; } = new()
    {
        new()
        {
            Content = "Page 1"
        },
        new()
        {
            Content = "Page 2"
        }
    };

    public NavigationViewItem SelectedItem
    {
        get => Items[_selectedItemIndex];
        set => this.RaiseAndSetIfChanged(ref _selectedItemIndex, Items.IndexOf(value));
    }

    public ICommand NavigateToPage2Command { get; }

    private void NavigateToPage2()
    {
        SelectedItem = Items[1];
    }
}