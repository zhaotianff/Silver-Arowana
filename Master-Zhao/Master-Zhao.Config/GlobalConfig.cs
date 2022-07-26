﻿using Master_Zhao.Config.Helper;
using Master_Zhao.Config.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Zhao.Config
{
    public class GlobalConfig
    {
        private static volatile object obj = new object();
        private static GlobalConfig instance;

        public DynamicWallpaperConfig DynamicWallpaperConfig { get; private set; }
        public StaticWallpaperConfig StaticWallpaperConfig { get; private set; }
        public ToolsConfig ToolsConfig { get; private set; }


        public static GlobalConfig Instance
        {
            get
            {
                if(instance == null)
                {
                    lock(obj)
                    {
                        if (instance == null)
                            instance = new GlobalConfig();
                    }
                }
                return instance;
            }
        }

        public GlobalConfig()
        {
            
        }

        public void LoadAllConfig()
        {
            DynamicWallpaperConfig = DynamicWallpaperHelper.LoadDynamicWallConfig();
            StaticWallpaperConfig = StaticWallpaperHelper.LoadStaticWallpaperConfig();
            ToolsConfig = ToolsHelper.LoadToolsConfig();
        }

        public void SaveAllConfig()
        {
            DynamicWallpaperHelper.SaveDynamicWallList(DynamicWallpaperConfig);
            ToolsHelper.SaveToolsConfig(ToolsConfig);
        }
    }
}
