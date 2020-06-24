using CloudManager.Core;
using Fasetto.Word;
using System;
using System.Windows;
using System.Windows.Input;
namespace CloudManager
{
    /// <summary>
    /// the View  Model for the custom window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private 

        /// <summary>
        /// Application current theme
        /// </summary>
        private ResourceDictionary currentTheme;
        /// <summary>
        /// the file list present style switcher
        /// </summary>
        private bool filePesentFlag;

        /// <summary>
        /// the window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// the margin drop shadow around window
        /// </summary>
        private int mOuterMarginSize = 10;
        
        /// <summary>
        /// Corner radius of window
        /// </summary>
        private int mWindowRadius = 3;
        #endregion

        #region Public properties
     
        /// <summary>
        /// open menu button visiblity
        /// </summary>
        public Visibility OpenMenuButtonVisibility { get; set; }

        /// <summary>
        /// close menu button visiblity
        /// </summary>
        public Visibility CloseMenuButtonVisibility { get; set; }

        /// <summary>
        /// the size of the  resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 0;

        /// <summary>
        /// Size of the resize border around the window
        /// </summary>
        public Thickness ResizeBorderThikness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// Size of the resize border around the window
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// the window this view model controls
        /// </summary>
        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }

        /// <summary>
        /// the window this view model controls
        /// </summary>
        public Thickness OuterMarginSizeThikness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// Corner radius of window
        /// </summary>
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }

        /// <summary>
        /// Corner radius of window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 20;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public GridLength TitleHeigthGridLine { get { return new GridLength(TitleHeight + ResizeBorder); } }


        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="WindowViewModel"/> class.
        /// Defoult constructor.
        /// </summary>
        public WindowViewModel(Window window)
        {

            //currentTheme = new ResourceDictionary();
            //currentTheme.Source = new Uri("Styles/DarkTheme/Colors.xaml", UriKind.Relative);

           // Application.Current.Resources.MergedDictionaries.Add(currentTheme);

            mWindow = window;
            CloseMenuButtonVisibility = Visibility.Collapsed;
            mWindow.StateChanged += (sender, e) => 
            {
                this.OnPropertyChanged(nameof(ResizeBorderThikness));
                this.OnPropertyChanged(nameof(OuterMarginSize));
                this.OnPropertyChanged(nameof(OuterMarginSizeThikness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            //create commands
            MinimizeWindowCommand = new RelayCommand(()=> mWindow.WindowState = WindowState.Minimized);
            MaximizeWindowCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseWindowCommand = new RelayCommand(() => mWindow.Close());
            OpenMenuButtonCommand = new RelayCommand(() => OpenMenu());
            CloseMenuButtonCommand = new RelayCommand(() => CloseMenu());
            OpenNewAccountPageCommand = new RelayCommand(() => OpenPageNewAccountAdded());
            OpenWorkPageCommand = new RelayCommand(()=> OprenWorkPage());
            var resizer = new WindowResizer(mWindow);
        }

        #region Methods

        /// <summary>
        /// Hide close menu button when menu is closed
        /// </summary>
        private void CloseMenu()
        {
            OpenMenuButtonVisibility = Visibility.Visible;
            CloseMenuButtonVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Hide open menu button when menu is opened
        /// </summary>
        private void OpenMenu()
        {
            OpenMenuButtonVisibility = Visibility.Collapsed;
            CloseMenuButtonVisibility = Visibility.Visible;
        }

        private void OpenPageNewAccountAdded()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.LoginPage);
        }

        private void OprenWorkPage()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.WorkPage);
        }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeWindowCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeWindowCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }

        /// <summary>
        /// Open menu 
        /// </summary>
        public ICommand OpenMenuButtonCommand { get; set; }

        /// <summary>
        /// Close menu 
        /// </summary>
        public ICommand CloseMenuButtonCommand { get; set; }

        /// <summary>
        /// Еhe page for adding a new account
        /// </summary>
        public ICommand OpenNewAccountPageCommand { get; set; }

        public ICommand OpenWorkPageCommand { get; set; }
        #endregion
    }
}
