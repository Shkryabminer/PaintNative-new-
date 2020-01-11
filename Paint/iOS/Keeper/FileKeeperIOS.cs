using System;
using System.IO;
using Newtonsoft.Json;
using Paint.Draw;
using Paint.Keeper;

namespace Paint.iOS.Keeper
{
    public class FileKeeperIOS : IDrawKeeper
    {
        private const string UserDefaultsKey = "SaveModal.json";
        DrawModel IDrawKeeper.Load()
        {
         
            var strModel = File.ReadAllText(FileName());
            var drawModel = JsonConvert.DeserializeObject<DrawModel>(strModel);
            return drawModel;
        }

        void IDrawKeeper.Save(DrawModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            var strModel = JsonConvert.SerializeObject(model);
            File.WriteAllText(FileName(), strModel);
        }


        private string FileName()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return System.IO.Path.Combine(documents, UserDefaultsKey);
        }
    }
}