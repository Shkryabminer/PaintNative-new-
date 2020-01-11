using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Paint.Draw;
using Paint.Keeper;
using UIKit;

namespace Paint.iOS.Keeper
{
    public class FileKeeperIOS : IDrawKeeper
    {
        DrawModel IDrawKeeper.Load()
        {
            throw new NotImplementedException();
        }

        void IDrawKeeper.Save(DrawModel model)
        {
            throw new NotImplementedException();
        }
    }
}