using CloudManager.Core;
using Fasetto.Word;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
namespace CloudManager
{
    /// <summary>
    /// the View  Model for the custom window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        public List<string> MyProperty { get; set; }

        public object ItemContainerStyle { get; set; }

        public object FileListStyle { get; set; }

        #region Private 

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
        public bool FilePesentFlag
        {
            get { return filePesentFlag; }
            set 
            {
                filePesentFlag = value;
                ChangeFileListPresentation();
            }
        }
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
        #region Constructor

        /// <summary>
        /// Defoult constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            ItemContainerStyle = Application.Current.FindResource("RowFilesListStyle") as Style;

            MyProperty = new List<string> { "qwe", "qweqw", "dfs", "qwe", "qweqw", "dfs", "qwe", "qweqw", "dfs" };


            mWindow = window;
            CloseMenuButtonVisibility = Visibility.Collapsed;
            mWindow.StateChanged += (sender, e) => 
            {
                OnPropertyChanged(nameof(ResizeBorderThikness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThikness));
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
            ChangeFileListPresentationCommand = new RelayCommand(() => ChangeFileListPresentation());
            var resizer = new WindowResizer(mWindow);
        }

        #endregion

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

        private void ChangeFileListPresentation()
        {
            Style tileFilesListStyle = Application.Current.FindResource("TileFilesListStyle") as Style;
            Style rowFilesListStyle = Application.Current.FindResource("RowFilesListStyle") as Style;
            Style fileListStyle = Application.Current.FindResource("TileListStyle") as Style;

            ItemContainerStyle = ItemContainerStyle == null ? rowFilesListStyle : ItemContainerStyle;

            if (FilePesentFlag!=true | ItemContainerStyle == null || ItemContainerStyle == tileFilesListStyle)
            {
                ItemContainerStyle = rowFilesListStyle;
                FileListStyle = null;
            }
            else
            {
                ItemContainerStyle = tileFilesListStyle;
                FileListStyle = fileListStyle;
            }

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

        public ICommand ChangeFileListPresentationCommand { get; set; }

        #endregion


    }
}
