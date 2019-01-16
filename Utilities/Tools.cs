using ZBase.Classes;
using hazedumper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZBase.Utilities
{
    public class Tools
    {
        public static void InitializeGlobals()
        {
            while (true)
            {
                Globals.LocalPlayer = new Entity(Memory.ReadMemory<int>((int)Memory.Client + signatures.dwLocalPlayer));
                Globals.GlowObjectManager = Memory.ReadMemory<int>((int)Memory.Client + signatures.dwGlowObjectManager);
                Globals.ClientState = Memory.ReadMemory<int>((int)Memory.Client + signatures.dwClientState);

                // Get Players
                var oldEntityList = new List<Entity>();

                oldEntityList.Clear();
                for (int i = 1; i <= 64; i++)
                {
                    oldEntityList.Add(new Entity(GetEntityBase(i)));
                }
                Globals.EntityList = oldEntityList;
                Thread.Sleep(100);
            }
        }

        public static int GetEntityBase(int PlayerLoopID)
        {
            return Memory.ReadMemory<int>((int)Memory.Client + signatures.dwEntityList + (PlayerLoopID * 0x10));
        }

        public static int GetEntityBaseFromCrosshair(int CrosshairID)
        {
            return Memory.ReadMemory<int>((int)Memory.Client + signatures.dwEntityList + (CrosshairID - 1) * 0x10);
        }

        public static void Shoot()
        {
            Memory.WriteMemory<int>((int)Memory.Client + signatures.dwForceAttack, 5);
            Thread.Sleep(20);
            Memory.WriteMemory<int>((int)Memory.Client + signatures.dwForceAttack, 4);
        }

        public static void Jump()
        {
            Memory.WriteMemory<int>((int)Memory.Client + signatures.dwForceJump, 6);
        }

        // for a health esp gradient
        public static Color HealthGradient(float Percent) //percent hp
        {
            if (Percent < 0 || Percent > 1) { return Color.Black; }

            int Red, Green;
            if (Percent < 0.5)
            {
                Red = 255;
                Green = (int)(255 * Percent);
            }
            else
            {
                Green = 255;
                Red = 255 - (int)(255 * (Percent - 0.5) / 0.5);
            }

            return Color.FromArgb(Red, Green, 0);
        }

        public static float HealthToPercent(int Health)
        {
            return Health / 100f;
        }

        public static float IntegerToFloat(int Value)
        {
            return Value / 255f;
        }
    }
}
