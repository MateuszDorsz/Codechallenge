using CodeChallenge.ViewModels;
using System.Windows;

namespace CodeChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            Loaded += delegate
            {
                this.Content.Height = ViewModel.DrawingGridHeight;
                this.Content.Width = ViewModel.DrawingGridWidth;
                SizeChanged += MainWindow_SizeChanged;
            };
            Unloaded += delegate
            {
                SizeChanged -= MainWindow_SizeChanged;
            };
        }

        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)DataContext; }
        }


        void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ViewModel.DrawingGridWidth = this.Content.Width;
            ViewModel.DrawingGridHeight = this.Content.Height;
        }
    }
}
