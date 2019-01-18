using ZBase.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBase.Utilities
{
    public class Globals
    {
        public static Entity LocalPlayer;
        public static int GlowObjectManager;
        public static int ClientState;
        public static float[] ViewMatrix = new float[16];
        public static List<Entity> EntityList = new List<Entity>();
    }
}
