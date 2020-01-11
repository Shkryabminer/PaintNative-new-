using System;
using Paint.Keeper;

namespace Paint.Droid.Keeper
{
    public class DrawKeeperFactory : IDrawKeeperFactory
    {
        
        public IDrawKeeper Create(EDrawKeeperType type)
        {
            switch (type)
            {
                case EDrawKeeperType.Internal:
                    return new InternalKeeper();
                case EDrawKeeperType.File:
                    return new FileKeeperDroid();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
