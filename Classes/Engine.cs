using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZBase.Utilities;

namespace ZBase.Classes
{
    public class Engine
    {
        public int EnginePtr;

        public Engine(int Base)
        {
            EnginePtr = Base;
        }

        public Entity LocalPlayer
        {
            get
            {
                return new Entity(Memory.ReadMemory<int>((int)Memory.Client + Main.O.signatures.dwLocalPlayer));
            }
        }

        public int GlowObjectManager
        {
            get
            {
                return Memory.ReadMemory<int>((int)Memory.Client + Main.O.signatures.dwGlowObjectManager);
            }
        }

        // viewangles should never have a roll value
        public Vector2 ViewAngles
        {
            get
            {
                Vector3 v3 = Memory.ReadMemory<Vector3>(ClientState + Main.O.signatures.dwClientState_ViewAngles);
                return new Vector2(v3.X, v3.Y);
            }
            set
            {
                Memory.WriteMemory<Vector3>(ClientState + Main.O.signatures.dwClientState_ViewAngles, new Vector3(value.X, value.Y, 0));
            }
        }

        public float[] ViewMatrix
        {
            get
            {
                float[] temp = new float[16];
                for (int i = 0; i < 16; i++)
                    temp[i] = Memory.ReadMemory<float>((int)Memory.Client + Main.O.signatures.dwViewMatrix + (i * 0x4));
                return temp;
            }
        }

        public int ClientState
        {
            get
            {
                return Memory.ReadMemory<int>(EnginePtr + Main.O.signatures.dwClientState);
            }
        }

        public float ModelBrightness
        {
            get
            {
                return Memory.ReadMemory<int>(EnginePtr + Main.O.signatures.model_ambient_min);
            }
            set
            {
                int thisPtr = (int)(Memory.Engine + Main.O.signatures.model_ambient_min - 0x2c);
                byte[] bytearray = BitConverter.GetBytes(value);
                int intbrightness = BitConverter.ToInt32(bytearray, 0);
                int xored = intbrightness ^ thisPtr;
                Memory.WriteMemory<int>(EnginePtr + Main.O.signatures.model_ambient_min, xored);
            }
        }

        public void Shoot()
        {
            Memory.WriteMemory<int>((int)Memory.Client + Main.O.signatures.dwForceAttack, 5);
            Thread.Sleep(20);
            Memory.WriteMemory<int>((int)Memory.Client + Main.O.signatures.dwForceAttack, 4);
        }

        public void Jump()
        {
            Memory.WriteMemory<int>((int)Memory.Client + Main.O.signatures.dwForceJump, 6);
        }
    }
}
