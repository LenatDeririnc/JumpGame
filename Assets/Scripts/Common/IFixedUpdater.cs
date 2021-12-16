using System;

namespace Common
{
    public interface IFixedUpdater
    {
        Action FIXED_UPDATE { get; set; }
    }
}