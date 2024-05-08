﻿using AppLourdAVS.Wpf.ViewModels;
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
using System.Windows.Shapes;

namespace AppLourdAVS.Wpf.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowsCreateType.xaml
    /// </summary>
    public partial class WindowsCreateType : Window
    {
        public WindowsCreateType(ViewModelType context)
        {
            InitializeComponent();
            this.DataContext = context;
        }
    }
}
