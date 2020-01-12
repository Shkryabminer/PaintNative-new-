using System;

public class KeeperTests
{
   
    [SetUp]
    public void Setup()
    {
       var _drawModel = new DrawModelStubObject();
        _drawModel.CurrentLineWidth = 10;
        _drawModel.CurrentColor = Color.Blu;
    }
    [Test]
    public FileKeeperIosTest()
    {
        _drawKeeper = new DrawKeeperFactory().Create(EDrawKeeperType.File);
        _drawKeeper.Save(_drawModel);
       var _drawModelAfterSave = _drawKeeper.Load();

        Assert.AreEqual(_deawModelAfterSave.CurrentLineWidth, _drawModel.CurrentLineWidth);
    }
}


