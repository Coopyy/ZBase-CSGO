using ZBase.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZBase.Classes
{
    public class Entity
    {
        int EntityBase;

        public Entity(int Base)
        {
            this.EntityBase = Base;
        }

        public int Health
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_iHealth);
            }
        }

        public int GlowIndex
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_iGlowIndex);
            }
        }

        public int Team
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_iTeamNum);
            }
        }

        public int Flags
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_fFlags);
            }
        }

        public bool IsTeammate
        {
            get
            {
                return Team == Globals.LocalPlayer.Team;
            }
        }

        public Vector3 Position
        {
            get
            {
                return Memory.ReadMemory<Vector3>(EntityBase + Main.O.netvars.m_vecOrigin);
            }
        }

        public Vector3 HeadPosition
        {
            get
            {
                return GetBonePosition(8);
            }
        }

        public Vector3 GetBonePosition(int BoneID)
        {
            int bonematrix = Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_dwBoneMatrix);
            float x = Memory.ReadMemory<float>(bonematrix + 0x30 * BoneID + 0x0C);
            float y = Memory.ReadMemory<float>(bonematrix + 0x30 * BoneID + 0x1C);
            float z = Memory.ReadMemory<float>(bonematrix + 0x30 * BoneID + 0x2C);
            return new Vector3(x, y, z);
        }

        public bool Spotted
        {
            get
            {
                return Memory.ReadMemory<bool>(EntityBase + Main.O.netvars.m_bSpotted);
            }
            set
            {
                Memory.WriteMemory<bool>(EntityBase + Main.O.netvars.m_bSpotted, Convert.ToByte(value));
            }
        }

        public int FlashDuration
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_flFlashDuration);
            }
            set
            {
                Memory.WriteMemory<int>(EntityBase + Main.O.netvars.m_flFlashDuration, value);
            }
        }

        public bool Dormant
        {
            get
            {
                return Memory.ReadMemory<bool>(EntityBase + Main.O.signatures.m_bDormant);
            }
        }

        public int CrosshairID
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_iCrosshairId);
            }
        }

        public void Glow(Color color)
        {
            GlowStruct GlowObj = new GlowStruct();

            GlowObj = Memory.ReadMemory<GlowStruct>(Globals.GlowObjectManager + GlowIndex * 0x38);

            GlowObj.r = (float)color.R / 255;
            GlowObj.g = (float)color.G / 255;
            GlowObj.b = (float)color.B / 255;
            GlowObj.a = (float)color.A / 255;
            GlowObj.m_bRenderWhenOccluded = true;
            GlowObj.m_bRenderWhenUnoccluded = false;

            Memory.WriteMemory<GlowStruct>(Globals.GlowObjectManager + GlowIndex * 0x38, GlowObj);
        }

        public void Cham(Color color)
        {
            // these only show while visible
            Memory.WriteMemory<int>(EntityBase + Main.O.netvars.m_clrRender, color.R);
            Memory.WriteMemory<int>(EntityBase + Main.O.netvars.m_clrRender + 1, color.G);
            Memory.WriteMemory<int>(EntityBase + Main.O.netvars.m_clrRender + 2, color.B);
            Memory.WriteMemory<int>(EntityBase + Main.O.netvars.m_clrRender + 3, color.A);
        }
        public void ResetChams()
        {
            Cham(Color.FromArgb(255, 255, 255, 0));
        }
        public bool Alive
        {
            get
            {
                if (Health > 0 && Health <= 100)
                    return true;
                return false;
            }
        }

        public bool Dead
        {
            get
            {
                if (!Alive)
                    return true;
                return false;
            }
        }

        public bool IsPlayer
        {
            get
            {
                if (Team == 2 || Team == 3)
                    return true;
                else if (Team == 0 || Team == 1)
                    return false;
                else
                    return false;
            }
        }

        public bool Valid
        {
            get
            {
                if (Dormant)
                    return false;
                if (Dead)
                    return false;
                if (!IsPlayer)
                    return false;
                return true;
            }
        }

        public Vector2 AimPunch
        {
            get
            {
                return Memory.ReadMemory<Vector2>(EntityBase + Main.O.netvars.m_aimPunchAngle);
            }
        }
        public int ShotsFired
        {
            get
            {
                return Memory.ReadMemory<int>(EntityBase + Main.O.netvars.m_iShotsFired);
            }
        }
        public Vector3 Velocity
        {
            get
            {
                return Memory.ReadMemory<Vector3>(EntityBase + Main.O.netvars.m_vecVelocity);
            }
        }
        public bool Scoped
        {
            get
            {
                return Memory.ReadMemory<bool>(EntityBase + Main.O.netvars.m_bIsScoped);
            }
        }
        public bool IsStill
        {
            get
            {
                if (Velocity.Y == 0 && Velocity.X == 0)
                    return true;
                else
                    return false;
            }
        }
        public float Distance
        {
            get
            {
                return Vector3.Distance(Globals.LocalPlayer.Position, HeadPosition);
            }
        }
    }
}
