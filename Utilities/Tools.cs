using ZBase.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace ZBase.Utilities
{
    public class Tools
    {
        public static void InitializeGlobals()
        {
            while (true)
            {
                Globals.LocalPlayer = new Entity(Memory.ReadMemory<int>((int)Memory.Client + Main.O.signatures.dwLocalPlayer));
                Globals.GlowObjectManager = Memory.ReadMemory<int>((int)Memory.Client + Main.O.signatures.dwGlowObjectManager);
                Globals.ClientState = Memory.ReadMemory<int>((int)Memory.Client + Main.O.signatures.dwClientState);

                

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

        public static Vector2 WorldToScreen(Size Size, Vector3 from)
        {
            Vector2 _worldToScreenPos;
            Vector3 to;
            float w = 0.0f;

            to.X = Globals.ViewMatrix[0] * from.X + Globals.ViewMatrix[1] * from.Y + Globals.ViewMatrix[2] * from.Z + Globals.ViewMatrix[3];
            to.Y = Globals.ViewMatrix[4] * from.X + Globals.ViewMatrix[5] * from.Y + Globals.ViewMatrix[6] * from.Z + Globals.ViewMatrix[7];

            w = Globals.ViewMatrix[12] * from.X + Globals.ViewMatrix[13] * from.Y + Globals.ViewMatrix[14] * from.Z + Globals.ViewMatrix[15];

            if (w < 0.01f)
                return new Vector2(0, 0);;

            to.X *= (1.0f / w);
            to.Y *= (1.0f / w);

            int width = Size.Width;
            int height = Size.Height;

            float x = width / 2;
            float y = height / 2;

            x += 0.5f * to.X * width + 0.5f;
            y -= 0.5f * to.Y * height + 0.5f;

            to.X = x;
            to.Y = y;

            _worldToScreenPos.X = to.X;
            _worldToScreenPos.Y = to.Y;
            return _worldToScreenPos;
        }

        public static int GetEntityBase(int PlayerLoopID)
        {
            return Memory.ReadMemory<int>((int)Memory.Client + Main.O.signatures.dwEntityList + (PlayerLoopID * 0x10));
        }

        public static int GetEntityBaseFromCrosshair(int CrosshairID)
        {
            return Memory.ReadMemory<int>((int)Memory.Client + Main.O.signatures.dwEntityList + (CrosshairID - 1) * 0x10);
        }

        public static void Shoot()
        {
            Memory.WriteMemory<int>((int)Memory.Client + Main.O.signatures.dwForceAttack, 5);
            Thread.Sleep(20);
            Memory.WriteMemory<int>((int)Memory.Client + Main.O.signatures.dwForceAttack, 4);
        }

        public static void Jump()
        {
            Memory.WriteMemory<int>((int)Memory.Client + Main.O.signatures.dwForceJump, 6);
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
