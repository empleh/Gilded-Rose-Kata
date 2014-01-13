using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuildedRose.Test
{
  [TestClass]
  public class SulfurasTests
  {
    private Program _app;

    [TestInitialize]
    public void Setup()
    {
      _app = new Program()
      {
        Items = new List<Item>
        {
          new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
        }
      };
    }

    [TestMethod]
    public void SellInBeginsAt0()
    {
      var actual = _app.Items.First().SellIn;

      const int expected = 0;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SellInIsAt0After1Day()
    {
      _app.UpdateQuality();

      var actual = _app.Items.First().SellIn;

      const int expected = 0;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SellInNeverChangesFrom0()
    {
      for (var i = 1; i < 100; i++)
      {
        _app.UpdateQuality();
      }

      var actual = _app.Items.First().SellIn;

      const int expected = 0;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SQualityBeginsAt80()
    {
      var actual = _app.Items.First().Quality;

      const int expected = 80;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void QualityIsAt80After1Day()
    {
      _app.UpdateQuality();

      var actual = _app.Items.First().Quality;

      const int expected = 80;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void QualityNeverChangesFrom80()
    {
      for (var i = 1; i < 100; i++)
      {
        _app.UpdateQuality();
      }

      var actual = _app.Items.First().Quality;

      const int expected = 80;
      Assert.AreEqual(expected, actual);
    }
  }
}
