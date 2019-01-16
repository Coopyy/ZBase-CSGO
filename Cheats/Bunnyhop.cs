using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZBase.Utilities;

namespace ZBase.Cheats
{
    public class Bunnyhop
    {
        public static void Run()
        {
            while (true)
            {
                if (Main.S.BunnyhopEnabled) // make sure the cheats enabled in the menu
                {
                    if ((Memory.GetAsyncKeyState(Keys.VK_SPACE) & 0x8000) > 0) // gross function to check if youre holding space
                    {
                        // Flags show if you are on the ground or not. 257 is standing on the ground, and 263 is crouching on the ground.
                        if (Globals.LocalPlayer.Flags == 257 || Globals.LocalPlayer.Flags == 263)
                        {
                            // stuff checks out. Jump!
                            Tools.Jump();
                        }
                    }
                }
                Thread.Sleep(1); // reduce cpu usage again
            }
        }
    }
}
