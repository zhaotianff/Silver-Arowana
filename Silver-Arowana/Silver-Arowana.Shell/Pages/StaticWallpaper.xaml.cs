﻿using Silver_Arowana.Shell.PInvoke;
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
using Silver_Arowana.Shell.Controls;

namespace Silver_Arowana.Shell.Pages
{
    /// <summary>
    /// StaticWallpaper.xaml 的交互逻辑
    /// </summary>
    public partial class StaticWallpaper : Page
    {
        IEnumerable<string> recentWallpapers;

        public StaticWallpaper()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCurrentBackground();
            LoadRecentBackground();
        }

        private void LoadCurrentBackground()
        {
            var sb = new StringBuilder(DesktopTool.MAX_PATH);
            if (DesktopTool.GetBackground(sb))
            {
                SetPreviewImage(sb.ToString());
            }
        }

        private void SetPreviewImage(string path)
        {
            this.img_background.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
        }

        private void LoadRecentBackground()
        {
            wrap_wallpaper.Children.Clear();
            var sb = new StringBuilder(1024);
            DesktopTool.GetRecentBackground(sb);
            recentWallpapers = sb.ToString().Split(";").Take(5);

            foreach (var wallpaper in recentWallpapers)
            {
                ThumbImageControl thumbImageControl = new ThumbImageControl();
                thumbImageControl.ThumbPath = wallpaper;
                thumbImageControl.Click += OnChangeBackground;
                wrap_wallpaper.Children.Add(thumbImageControl);
            }           
        }

        private void OnChangeBackground(object sender,EventArgs args)
        {
            var path = (sender as ThumbImageControl)?.ThumbPath;

            if (System.IO.File.Exists(path) == false)
                return;

            if (SetBackground(path) == false)
                return;

            SetPreviewImage(path);

            var index = recentWallpapers.ToList().IndexOf(path);
            if (index == 0)
                return;

            var firstThumbImage = wrap_wallpaper.Children[0] as ThumbImageControl;
            var firstThumbImagePath = firstThumbImage.ThumbPath;
            firstThumbImage.ThumbPath = path;
            (wrap_wallpaper.Children[index] as ThumbImageControl).ThumbPath = firstThumbImagePath;
        }

        private bool SetBackground(string path)
        {
            //设置壁纸
            StringBuilder sb = new StringBuilder(PInvoke.DesktopTool.MAX_PATH);
            sb.Append(path);
            return PInvoke.DesktopTool.SetBackground(sb);               
        }
    }
}
