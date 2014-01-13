using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuildedRose.Test
{
  [TestClass]
  public class AgedBrieTests
  {
    private Program _app;

    [TestInitialize]
    public void Setup()
    {
      _app = new Program()
      {
        Items = new List<Item>
        {
          new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}
        }
      };
    }

    [TestMethod]
    public void QualityIncreasesTo1After1Day()
    {
      _app.UpdateQuality();

      var actual = _app.Items.First().Quality;

      const int expected = 1;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void QualityIncreasesTo2After2Days()
    {
      _app.UpdateQuality();
      _app.UpdateQuality();

      var actual = _app.Items.First().Quality;

      const int expected = 2;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void QualityNeverIncreasesPast50()
    {
      for (int i = 0; i < 100; i++)
      {
        _app.UpdateQuality();  
      }

      var actual = _app.Items.First().Quality;

      const int expected = 50;
      Assert.AreEqual(expected, actual);
    }
  }
}
