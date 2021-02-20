using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CloudManager
{
    public class WorkPageViewModel : BaseViewModel
    {
        #region Properties
        public List<string> MyProperty { get; set; }

        /// <summary>
        /// File list container style
        /// </summary>
        public object ItemContainerStyle { get; set; }

        /// <summary>
        /// File list style
        /// </summary>
        public object FileListStyle { get; set; }

        /// <summary>
        /// File list style flag
        /// </summary>
        public bool FilePesentFlag
        {
            get { return filePesentFlag; }
            set
            {
                filePesentFlag = value;
                ChangeFileListPresentation();
            }
        }
        #endregion

        #region private fields
        /// <summary>
        /// the file list present style switcher
        /// </summary>
        private bool filePesentFlag;
        #endregion

        public WorkPageViewModel()
        {
            ItemContainerStyle = Application.Current.FindResource("RowFilesListStyle") as Style;

            MyProperty = new List<string> { "qwe", "qweqw", "dfs", "qwe", "qweqw", "dfs", "qwe", "qweqw", "dfs" };

            ChangeFileListPresentationCommand = new RelayCommand(() => ChangeFileListPresentation());
            AddingDriveCommand = new RelayCommand(() => AddingDrive());
        }
        private void ChangeFileListPresentation()
        {
            Style tileFilesListStyle = Application.Current.FindResource("TileFilesListStyle") as Style;
            Style rowFilesListStyle = Application.Current.FindResource("RowFilesListStyle") as Style;
            Style fileListStyle = Application.Current.FindResource("TileListStyle") as Style;

            ItemContainerStyle = ItemContainerStyle == null ? rowFilesListStyle : ItemContainerStyle;

            if (FilePesentFlag != true | ItemContainerStyle == null || ItemContainerStyle == tileFilesListStyle)
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

        public  void AddingDrive()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AddingDrive);
        }

        public ICommand ChangeFileListPresentationCommand { get; set; }
        public ICommand AddingDriveCommand { get; set; }

    }
}
