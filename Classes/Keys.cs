using System.Runtime.InteropServices;

namespace ZBase
{
    internal class Keys
    {
        // Linker Mausbutton
        public const int VK_LBUTTON = 0x1;
        // Rechter Mausbutton
        public const int VK_RBUTTON = 0x2;
        // Mittlerer Mausbutton
        public const int VK_MBUTTON = 0x4;
        // Backspace Taste
        public const int VK_BACK = 0x8;
        // Tab Taste
        public const int VK_TAB = 0x9;
        // Numpad 5 ohne Numlock
        public const int VK_CLEAR = 0xc;
        // Enter Taste
        public const int VK_RETURN = 0xd;
        // Shift Taste
        public const int VK_SHIFT = 0x10;
        // STRG Taste
        public const int VK_CONTROL = 0x11;
        // Alt Taste
        public const int VK_MENU = 0x12;
        // Pause/Untbr
        public const int VK_PAUSE = 0x13;
        // Caps Lock/Feststelltaste
        public const int VK_CAPITAL = 0x14;
        // Escape
        public const int VK_ESCAPE = 0x1b;
        // Space/Leertaste
        public const int VK_SPACE = 0x20;
        // PageUp/Bild hoch
        public const int VK_PRIOR = 0x21;
        // PageDown/Bild runter
        public const int VK_NEXT = 0x22;
        // Ende
        public const int VK_END = 0x23;
        // Home/Pos1
        public const int VK_HOME = 0x24;
        // Linke Pfeiltaste
        public const int VK_LEFT = 0x25;
        // Obere Pfeiltaste
        public const int VK_UP = 0x26;
        // Rechte Pfeiltaste
        public const int VK_RIGHT = 0x27;
        // Untere Pfeiltaste
        public const int VK_DOWN = 0x28;
        // Drucken (Nokia Tastaturen)
        public const int VK_PRINT = 0x2a;
        // Drucken/S-Abf
        public const int VK_SNAPSHOT = 0x2c;
        // Einfügen
        public const int VK_INSERT = 0x2d;
        // Entfernen
        public const int VK_DELETE = 0x2e;
        // Hilfe
        public const int VK_HELP = 0x2f;
        // Taste 0
        public const int VK_0 = 0x30;
        // Taste 1
        public const int VK_1 = 0x31;
        // Taste 2
        public const int VK_2 = 0x32;
        // Taste 3
        public const int VK_3 = 0x33;
        // Taste 4
        public const int VK_4 = 0x34;
        // Taste 5
        public const int VK_5 = 0x35;
        // Taste 6
        public const int VK_6 = 0x36;
        // Taste 7
        public const int VK_7 = 0x37;
        // Taste 8
        public const int VK_8 = 0x38;
        // Taste 9
        public const int VK_9 = 0x39;
        // Taste A
        public const int VK_A = 0x41;
        // Taste B
        public const int VK_B = 0x42;
        // Taste C
        public const int VK_C = 0x43;
        // Taste D
        public const int VK_D = 0x44;
        // Taste E
        public const int VK_E = 0x45;
        // Taste F
        public const int VK_F = 0x46;
        // Taste G
        public const int VK_G = 0x47;
        // Taste H
        public const int VK_H = 0x48;
        // Taste I
        public const int VK_I = 0x49;
        // Taste J
        public const int VK_J = 0x4a;
        // Taste K
        public const int VK_K = 0x4b;
        // Taste L
        public const int VK_L = 0x4c;
        // Taste M
        public const int VK_M = 0x4d;
        // Taste N
        public const int VK_N = 0x4e;
        // Taste O
        public const int VK_O = 0x4f;
        // Taste P
        public const int VK_P = 0x50;
        // Taste Q
        public const int VK_Q = 0x51;
        // Taste R
        public const int VK_R = 0x52;
        // Taste S
        public const int VK_S = 0x53;
        // Taste T
        public const int VK_T = 0x54;
        // Taste U
        public const int VK_U = 0x55;
        // Taste V
        public const int VK_V = 0x56;
        // Taste W
        public const int VK_W = 0x57;
        // Taste X
        public const int VK_X = 0x58;
        // Taste Y
        public const int VK_Y = 0x59;
        // Taste Z
        public const int VK_Z = 0x5a;
        // Startmenütaste
        public const int VK_STARTKEY = 0x5b;
        // Kentextmenü
        public const int VK_CONTEXTKEY = 0x5d;
        // Numpad Taste 0
        public const int VK_NUMPAD0 = 0x60;
        // Numpad Taste 1
        public const int VK_NUMPAD1 = 0x61;
        // Numpad Taste 2
        public const int VK_NUMPAD2 = 0x62;
        // Numpad Taste 3
        public const int VK_NUMPAD3 = 0x63;
        // Numpad Taste 4
        public const int VK_NUMPAD4 = 0x64;
        // Numpad Taste 5
        public const int VK_NUMPAD5 = 0x65;
        // Numpad Taste 6
        public const int VK_NUMPAD6 = 0x66;
        // Numpad Taste 7
        public const int VK_NUMPAD7 = 0x67;
        // Numpad Taste 8
        public const int VK_NUMPAD8 = 0x68;
        // Numpad Taste 9
        public const int VK_NUMPAD9 = 0x69;
        // Numpad Multiplikations Taste (*)
        public const int VK_MULTIPLY = 0x6a;
        // Numpad Additions Taste (+)
        public const int VK_ADD = 0x6b;
        // Numpad Subtrations Taste (-)
        public const int VK_SUBTRACT = 0x6d;
        // Numpad Komma Taste (,)
        public const int VK_DECIMAL = 0x6e;
        // Numpad Devidierungs Taste (/)
        public const int VK_DIVIDE = 0x6f;
        // F1 Taste
        public const int VK_F1 = 0x70;
        // F2 Taste
        public const int VK_F2 = 0x71;
        // F3 Taste
        public const int VK_F3 = 0x72;
        // F4 Taste
        public const int VK_F4 = 0x73;
        // F5 Taste
        public const int VK_F5 = 0x74;
        // F6 Taste
        public const int VK_F6 = 0x75;
        // F7 Taste
        public const int VK_F7 = 0x76;
        // F8 Taste
        public const int VK_F8 = 0x77;
        // F9 Taste
        public const int VK_F9 = 0x78;
        // F10 Taste
        public const int VK_F10 = 0x79;
        // F11 Taste
        public const int VK_F11 = 0x7a;
        // F12 Taste
        public const int VK_F12 = 0x7b;
        // F13 Taste
        public const int VK_F13 = 0x7c;
        // F14 Taste
        public const int VK_F14 = 0x7d;
        // F15 Taste
        public const int VK_F15 = 0x7e;
        // F16 Taste
        public const int VK_F16 = 0x7f;
        // F17 Taste
        public const int VK_F17 = 0x80;
        // F18 Taste
        public const int VK_F18 = 0x81;
        // F19 Taste
        public const int VK_F19 = 0x82;
        // F20 Taste
        public const int VK_F20 = 0x83;
        // F21 Taste
        public const int VK_F21 = 0x84;
        // F22 Taste
        public const int VK_F22 = 0x85;
        // F23 Taste
        public const int VK_F23 = 0x86;
        // F24 Taste
        public const int VK_F24 = 0x87;
        // Numlock Taste
        public const int VK_NUMLOCK = 0x90;
        // Scroll Lock
        public const int VK_OEM_SCROLL = 0x91;
        // Linke Shift-Taste
        public const int VK_LSHIFT = 0xa0;
        // Rechte Shift-Taste
        public const int VK_RSHIFT = 0xa1;
        // Linke STRG-Taste
        public const int VK_LCONTROL = 0xa2;
        // Rechte STRG-Taste
        public const int VK_RCONTROL = 0xa3;
        // Linke ALT-Taste
        public const int VK_LMENU = 0xa4;
        // Rechte ALT-Taste
        public const int VK_RMENU = 0xa5;
        // ";"-Taste
        public const int VK_OEM_1 = 0xba;
        // "
        public const int VK_OEM_PLUS = 0xbb;
        // ","-Taste
        public const int VK_OEM_COMMA = 0xbc;
        // "-"-Taste
        public const int VK_OEM_MINUS = 0xbd;
        // "."-taste
        public const int VK_OEM_PERIOD = 0xbe;
        // "/"-Taste
        public const int VK_OEM_2 = 0xbf;
        // "`"-Taste
        public const int VK_OEM_3 = 0xc0;
        // "["-Taste
        public const int VK_OEM_4 = 0xdb;
        // "\"-Taste
        public const int VK_OEM_5 = 0xdc;
        // "]"-Taste
        public const int VK_OEM_6 = 0xdd;
        // "
        public const int VK_OEM_7 = 0xde;
        // F17 einer Olivette Tastatur (Intern)
        public const int VK_ICO_F17 = 0xe0;
        // F18 einer Olivette Tastatur (Intern)
        public const int VK_ICO_F18 = 0xe1;
        // "<"-Taste oder "|"-Taste einer  
        public const int VK_OEM102 = 0xe2;
        // IBM-Kompatiblen 102 Tastatur (Nicht US)
        // Hilfetaste einer Olivetti Tastatur (Intern) 
        public const int VK_ICO_HELP = 0xe3;
        // 00-Taste einer Olivetti Tastatur (Intern)
        public const int VK_ICO_00 = 0xe4;
        // Löschen Taste einer Olivetti Tastatur (Intern) 
        public const int VK_ICO_CLEAR = 0xe6;
        // Reset Taste (Nokia)
        public const int VK_OEM_RESET = 0xe9;
        // Springen Taste (Nokia)
        public const int VK_OEM_JUMP = 0xea;
        // PA1 Taste (Nokia)
        public const int VK_OEM_PA1 = 0xeb;
        // PA2 Taste (Nokia)
        public const int VK_OEM_PA2 = 0xec;
        // PA3 Taste (Nokia)
        public const int VK_OEM_PA3 = 0xed;
        // WSCTRL Taste (Nokia)
        public const int VK_OEM_WSCTRL = 0xee;
        // WSCTRL Taste (Nokia)
        public const int VK_OEM_CUSEL = 0xef;
        // ATTN Taste (Nokia)
        public const int VK_OEM_ATTN = 0xf0;
        // Fertig Taste (Nokia)
        public const int VK_OEM_FINNISH = 0xf1;
        // Kopieren Taste (Nokia)
        public const int VK_OEM_COPY = 0xf2;
        // Auto Taste (Nokia)
        public const int VK_OEM_AUTO = 0xf3;
        // ENLW Taste (Nokia)
        public const int VK_OEM_ENLW = 0xf4;
        // BackTab Taste (Nokia)
        public const int VK_OEM_BACKTAB = 0xf5;
        // ATTN-Taste
        public const int VK_ATTN = 0xf6;
        // CRSEL-Taste
        public const int VK_CRSEL = 0xf7;
        // EXSEL-Taste
        public const int VK_EXSEL = 0xf8;
        // EREOF-Taste
        public const int VK_EREOF = 0xf9;
        // PLAY-Taste
        public const int VK_PLAY = 0xfa;
        // ZOOM-Taste
        public const int VK_ZOOM = 0xfb;
        // NONAME-Taste
        public const int VK_NONAME = 0xfc;
        // PA1-Taste
        public const int VK_PA1 = 0xfd;
        // OEM_CLEAR-Taste
        public const int VK_OEM_CLEAR = 0xfe;
    }
}
