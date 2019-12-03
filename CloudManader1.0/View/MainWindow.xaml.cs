using CloudManader1._0.Windows;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using static CloudManader1._0.Windows.GlassHelper;

namespace CloudManader1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
        }

        
       

        private void DragWindowHeader(object sender, MouseButtonEventArgs e)
        {
            AppWindow.DragMove();
            if (e.ClickCount == 2)
            {
                if (AppWindow.WindowState == WindowState.Maximized)
                {
                    AppWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    AppWindow.WindowState = WindowState.Maximized;
                }
            }
        }
        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            var accentStructSize = Marshal.SizeOf(accent);
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }
        private void AppWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                EnableBlur();
                
                IntPtr mainWindowPtr = new WindowInteropHelper(this).Handle;
                HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
                mainWindowSrc.CompositionTarget.BackgroundColor = Color.FromArgb(0, 0, 0, 0);

                // Get System Dpi
                System.Drawing.Graphics desktop = System.Drawing.Graphics.FromHwnd(mainWindowPtr);
                float DesktopDpiX = desktop.DpiX;
                float DesktopDpiY = desktop.DpiY;

                GlassHelper.MARGINS margins = new GlassHelper.MARGINS();

                margins.cxLeftWidth = Convert.ToInt32(5 * (DesktopDpiX / 96));
                margins.cxRightWidth = Convert.ToInt32(5 * (DesktopDpiX / 96));
                margins.cyTopHeight = Convert.ToInt32(5 * (DesktopDpiX / 96));
                margins.cyBottomHeight = Convert.ToInt32(5 * (DesktopDpiX / 96));

                int hr = GlassHelper.DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
                //
                if (hr < 0)
                {
                    //DwmExtendFrameIntoClientArea Failed
                }
            }
            // If not Vista, paint background white.
            catch (DllNotFoundException)
            {
                Application.Current.MainWindow.Background = Brushes.White;
            }
        }
    }
}
