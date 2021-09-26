using System;
namespace MBS.Framework.USB
{
    public enum ControlType
    {
        Standard = (0 << 5),
        Class = (1 << 5),
        Vendor = (2 << 5),
        Reserved = (3 << 5),
    }
}
