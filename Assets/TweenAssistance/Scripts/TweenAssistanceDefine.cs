using System;

namespace Itach.TweenAssistance
{
    [Flags]
    public enum TweenFlag
    {
        Color = 1 << 0,
        Scale = 1 << 1,
        Position = 1 << 2,
        Rotation = 1 << 3,
        All = 1 | 1 << 1 | 1 << 2 | 1 << 3,
        Color_Scale = Color | Scale,
        Color_Position = Color | Position,
        Color_Rotation = Color | Rotation,
        Scale_Position = Scale | Position,
        Scale_Rotation = Scale | Rotation,
        Position_Rotation = Position | Rotation,
    }
}
