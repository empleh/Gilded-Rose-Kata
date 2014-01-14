using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuildedRose.Test
{
  [TestClass]
  public class RegularItemTests
  {
    private Program _app;

    [TestInitialize]
    public void Setup()
    {
      _app = new Program()
      {
        Items = new List<Item>
        {
          new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 14}
        }
      };
    }

    [TestMethod]
    public void SellInDecreasesBy1EachDay()
    {
      var previousSellIn = _app.Items.First().SellIn;

      for (var i = 1; i < previousSellIn + 10; i++)
      {
        _app.UpdateQuality();

        var actual = _app.Items.First().SellIn;

        var expected = previousSellIn - 1;
        Assert.AreEqual(expected, actual);

        previousSellIn = actual;
      }
    }

    [TestMethod]
    public void QualityDecreasesBy1EachDay()
    {
      var previousQuality = _app.Items.First().Quality;
      var sellInValue = _app.Items.First().SellIn;

      for (var i = 1; i < sellInValue; i++)
      {
        _app.UpdateQuality();

        var actual = _app.Items.First().Quality;

        var expected = previousQuality - 1;
        Assert.AreEqual(expected, actual);

        previousQuality = actual;
      }
    }

    [TestMethod]
    public void QualityDecreasesBy2EachDayAfterSellInDay()
    {
      var initialQuality = _app.Items.First().Quality;
      var sellInValue = _app.Items.First().SellIn;

      for (var i = 1; i <= sellInValue; i++)
      {
        _app.UpdateQuality();
      }

      var previousQuality = _app.Items.First().Quality;

      for (var i = 1; i < (initialQuality - sellInValue)/2; i++)
      {
        _app.UpdateQuality();

        var actual = _app.Items.First().Quality;

        var expected = previousQuality - 2;
        Assert.AreEqual(expected, actual);

        previousQuality = actual;
      }
    }

    [TestMethod]
    public void QualityNeverDecreasesPast0()
    {
      var sellInValue = _app.Items.First().SellIn;

      for (var i = 1; i < sellInValue + 10; i++)
      {
        _app.UpdateQuality();
      }

      var actual = _app.Items.First().Quality;

      const int expected = 0;
      Assert.AreEqual(expected, actual);
    }
  }
}
