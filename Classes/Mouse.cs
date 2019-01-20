using System.Runtime.InteropServices;

namespace ZBase
{
    internal class Mouse
    {
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
    }
}
