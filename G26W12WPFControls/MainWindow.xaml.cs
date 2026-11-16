using System.Windows;

namespace G26W12WPFControls;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        DataContext = new SongViewModel(new SongModel());
    }
}