﻿using Master_Zhao.Shell.Model.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master_Zhao.Shell.Util
{
    public static class CollectionExtension
    {
        public static IEnumerable<T> SetItemType<T>(this IEnumerable<T> list, ExecuteItemType executeItemType) where T : ExecuteItem
        {
            foreach (var item in list)
            {
                item.ItemType = executeItemType;

                if (executeItemType == ExecuteItemType.MMC)
                {
                    var findObj = System.Windows.Application.Current.TryFindResource(item.Name);
                    if (findObj != null)
                        item.Description = findObj.ToString();
                }

                if (executeItemType == ExecuteItemType.EXE || executeItemType == ExecuteItemType.MMC || executeItemType == ExecuteItemType.CPL)
                {
                    item.Icon = ImageHelper.GetIconImageFromFile(item.Path);
                }

                if (executeItemType == ExecuteItemType.DLL)
                {

                    item.Icon = ImageHelper.GetIconImageFromFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\Shell32.dll");
                }

                if (executeItemType == ExecuteItemType.MSSETTING)
                {
                    item.Icon = ImageHelper.GetIconImageFromFile(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\ImmersiveControlPanel\\SystemSettings.exe");
                }
                yield return item;
            }
        }
    }
}
