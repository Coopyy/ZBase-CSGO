﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZBase.Classes;
using ZBase.Utilities;

namespace ZBase
{
    public class Main
    {
        public static Size ScreenSize;
        public static Vector2 MidScreen;
        public static RECT ScreenRect;

        public static RootObject O;
        public static Settings S = new Settings();
        public static bool RunStartup()
        {
            var CSGO = Process.GetProcessesByName("csgo");
            if (CSGO.Length != 0)
            {
                Memory.Process = CSGO[0];
                Memory.ProcessHandle = Memory.OpenProcess(0x0008 | 0x0010 | 0x0020, false, Memory.Process.Id);
                foreach (ProcessModule Module in Memory.Process.Modules)
                {
                    if ((Module.ModuleName == "client.dll"))
                        Memory.Client = Module.BaseAddress;

                    if ((Module.ModuleName == "engine.dll"))
                    {
                        Memory.Engine = Module.BaseAddress;
                        G.Engine = new Engine((int)Module.BaseAddress);
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Please start CSGO Running the cheat", "Error", MessageBoxButtons.OK);
                Environment.Exit(1);
                return false;
            }
        }
    }
}
