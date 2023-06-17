using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FAP_Attendance.Views.UserControll
{
    /// <summary>
    /// Interaction logic for FAP_UC_01View.xaml
    /// </summary>
    public partial class FAP_UC_01View : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(FAP_UC_01View), new PropertyMetadata(null));

        public FAP_UC_01View()
        {
            InitializeComponent();
        }
        /// <summary>
        ///ImageClose_MouseLeftButtonDown method used to when click image close(x) then  window will be closed 
        /// </summary>
        public void Exit_App(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
