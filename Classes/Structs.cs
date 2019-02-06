using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZBase.Classes
{
    [StructLayout(LayoutKind.Explicit)]
    public struct GlowStruct
    {
        [FieldOffset(0x00)]
        public int EntityPointer;
        [FieldOffset(0x4)]
        public float r;
        [FieldOffset(0x8)]
        public float g;
        [FieldOffset(0xC)]
        public float b;
        [FieldOffset(0x10)]
        public float a;
        [FieldOffset(0x14)]
        public int jnk1;
        [FieldOffset(0x18)]
        public int jnk2;
        [FieldOffset(0x1C)]
        public float BloomAmount;
        [FieldOffset(0x20)]
        public int jnk3;

        [FieldOffset(0x24)]
        public bool m_bRenderWhenOccluded;
        [FieldOffset(0x25)]
        public bool m_bRenderWhenUnoccluded;
        [FieldOffset(0x2C)]
        public bool m_bFullBloom;
    };

    public struct RECT
    {
        public int left, top, right, bottom;
    }

    public enum WeaponID
    {
        DEAGLE = 1,
        BERETTAS = 2,
        FIVESEVEN = 3,
        GLOCK = 4,
        AK47 = 7,
        AUG = 8,
        AWP = 9,
        FAMAS = 10,
        G3SG1 = 11,
        GALILAR = 13,
        M249 = 14,
        M4A4 = 16,
        MAC10 = 17,
        P90 = 19,
        MP5SD = 23,
        UMP45 = 24,
        XM1014 = 25,
        BIZON = 26,
        MAG7 = 27,
        NEGEV = 28,
        SAWEDOFF = 29,
        TEC9 = 30,
        TASER = 31,
        P2000 = 32,
        MP7 = 33,
        MP9 = 34,
        NOVA = 35,
        P250 = 36,
        SCAR20 = 38,
        SG556 = 39,
        SSG08 = 40,
        KNIFE = 42,
        FLASHBANG = 43,
        HEGRENADE = 44,
        SMOKEGRENADE = 45,
        MOLOTOV = 46,
        DECOY = 47,
        INCGRENADE = 48,
        C4 = 49,
        M4A1S = 60,
        USPS = 61,
        CZ75A = 63,
        REVOLVER = 64,
    }
}
