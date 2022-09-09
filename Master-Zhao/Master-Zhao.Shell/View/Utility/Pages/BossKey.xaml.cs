﻿using Master_Zhao.Shell.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Master_Zhao.Shell.View.Pages
{
    /// <summary>
    /// BossKey.xaml 的交互逻辑
    /// </summary>
    public partial class BossKey : Page
    {
        public BossKey()
        {
            InitializeComponent();
        }

        private void LoadProcessList()
        {
            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                if (PInvoke.DesktopTool.CanAddToTaskBar(process.MainWindowHandle))
                {
                    IntPtr ptr = PInvoke.DesktopTool.GetProcessNameFomrHwnd(process.MainWindowHandle);

                    if (ptr == IntPtr.Zero)
                        continue;

                    var str = Marshal.PtrToStringAuto(ptr);

                    if (!string.IsNullOrEmpty(str))
                    {
                        var strArray = str.Split(";");
                        if (strArray.Length > 1)
                        {
                            var processName = strArray[1];

                            if(string.IsNullOrEmpty(processName))
                            {
                                processName = System.IO.Path.GetFileNameWithoutExtension(strArray[0]);
                            }
                            this.list_Tasks.Items.Add(processName);
                        }
                    }
                }
            }
        }

        private void cbx_Running_Checked(object sender, RoutedEventArgs e)
        {
            LoadProcessList();
        }
    }
}
