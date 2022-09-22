﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Master_Zhao.Shell.View.Setting.Pages
{
    /// <summary>
    /// BackgroundSetting.xaml 的交互逻辑
    /// </summary>
    public partial class BackgroundSetting : Page
    {
        public BackgroundSetting()
        {
            InitializeComponent();
        }

        private void Setbackground_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow;
            mainWindow.Background = (sender as Rectangle).Fill;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(2);
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;

            if(mainWindow.Background is ImageBrush)
            {
                mainWindow.Background.BeginAnimation(Brush.OpacityProperty, doubleAnimation);
            }
        }
    }
}
