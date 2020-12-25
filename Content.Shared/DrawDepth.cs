using Robust.Shared.Serialization;
using DrawDepthTag = Robust.Shared.GameObjects.DrawDepth;

namespace Content.Shared
{
    [ConstantsFor(typeof(DrawDepthTag))]
    public enum DrawDepth
    {
        Objects = DrawDepthTag.Default
    }
}