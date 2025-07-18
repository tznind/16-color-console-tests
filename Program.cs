
using System.Runtime.InteropServices;


const int STD_OUTPUT_HANDLE = -11;
const int STD_INPUT_HANDLE = -10;

Console.Write("Choose your char: 1 for space 2 for \\0");
bool useSpace = Console.Read() == '1';

var _inputHandle = InteropServices.GetStdHandle (STD_INPUT_HANDLE);
var _outputHandle = InteropServices.GetStdHandle (STD_OUTPUT_HANDLE);

CharInfo[] ci = new CharInfo[4];


ci [0] = new CharInfo
{
    Char = new CharUnion { UnicodeChar = '你' },
    Attributes = 47
};
ci [1] = new CharInfo
{
    Char = new CharUnion { UnicodeChar = useSpace? ' ':'\0' },
    Attributes = 47
};
ci [2] = new CharInfo
{
    Char = new CharUnion { UnicodeChar = 'c' },
    Attributes = 47
};
ci [3] = new CharInfo
{
    Char = new CharUnion { UnicodeChar = 'd' },
    Attributes = 47
};
var window = new SmallRect(0, 0, 10, 10);

InteropServices.WriteConsoleOutput ( _outputHandle, ci, new Coord(4, 1), new Coord { X = 0, Y = 0 }, ref window);

// Console.WriteLine("你");




[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public struct CharUnion
{
    [FieldOffset(0)]
    public char UnicodeChar;

    [FieldOffset(0)]
    public byte AsciiChar;
}


    [Flags]
    public enum ShareMode : uint
    {
        FileShareRead = 1,
        FileShareWrite = 2
    }

    [Flags]
    public enum DesiredAccess : uint
    {
        GenericRead = 2147483648,
        GenericWrite = 1073741824
    }


    [StructLayout (LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct CharInfo
    {
        [FieldOffset (0)]
        public CharUnion Char;

        [FieldOffset (2)]
        public ushort Attributes;
    }


    [StructLayout (LayoutKind.Sequential)]
    public struct Coord
    {
        public short X;
        public short Y;

        public Coord (short x, short y)
        {
            X = x;
            Y = y;
        }

        public readonly override string ToString () { return $"({X},{Y})"; }
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct SmallRect
    {
        public short Left;
        public short Top;
        public short Right;
        public short Bottom;

        public SmallRect (short left, short top, short right, short bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public readonly override string ToString () { return $"Left={Left},Top={Top},Right={Right},Bottom={Bottom}"; }
    }


class InteropServices {


    [DllImport("kernel32.dll", EntryPoint = "WriteConsoleOutputW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool WriteConsoleOutput(
        nint hConsoleOutput,
        CharInfo[] lpBuffer,
        Coord dwBufferSize,
        Coord dwBufferCoord,
        ref SmallRect lpWriteRegion
    );
    
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern nint GetStdHandle (int nStdHandle);
}