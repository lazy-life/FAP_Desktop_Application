﻿using System;
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
using System.Windows.Shapes;

namespace FAP_Attendance.Views
{
    /// <summary>
    /// Interaction logic for FAP_STUDENT_HOME_View.xaml
    /// </summary>
    public partial class FAP_STUDENT_HOME_View : Window
    {
        public List<string> contacts { get; set; } = new List<string>();
        public FAP_STUDENT_HOME_View()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                contacts.Add("hello");
            }
        }

    }
}