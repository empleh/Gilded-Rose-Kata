using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuildedRose.Test
{
  [TestClass]
  public class BackStagePassTests
  {
    private Program _app;

    [TestInitialize]
    public void Setup()
    {
      _app = new Program()
      {
        Items = new List<Item>
        {
          new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 25, Quality = 10}
        }
      };
    }

    [TestMethod]
    public void QualityIncreaseBy1Before10DaysOut()
    {
      var previousQuality = _app.Items.First().Quality;

      while (_app.Items.First().SellIn > 10)
      {
        _app.UpdateQuality();

        var actual = _app.Items.First().Quality;

        var expected = previousQuality + 1;
        Assert.AreEqual(expected, actual);

        previousQuality = actual;
      }
    }

    [TestMethod]
    public void QualityIncreasesBy2BetweenDays10And5()
    {

      while (_app.Items.First().SellIn > 10)
      {
        _app.UpdateQuality();
      }

      var previousQuality = _app.Items.First().Quality;

      while (_app.Items.First().SellIn > 5)
      {
        _app.UpdateQuality();

        var actual = _app.Items.First().Quality;

        var expected = previousQuality + 2;
        Assert.AreEqual(expected, actual);

        previousQuality = actual;
      }
    }

    [TestMethod]
    public void QualityIncreasesBy3BetweenDays5And0()
    {

      while (_app.Items.First().SellIn > 5)
      {
        _app.UpdateQuality();
      }

      var previousQuality = _app.Items.First().Quality;

      while (_app.Items.First().SellIn > 0)
      {
        _app.UpdateQuality();

        var actual = _app.Items.First().Quality;

        var expected = previousQuality + 3;
        Assert.AreEqual(expected, actual);

        previousQuality = actual;
      }
    }

    [TestMethod]
    public void QualityReducesTo0AfterSellIn()
    {

      while (_app.Items.First().SellIn >= 0)
      {
        _app.UpdateQuality();
      }

        var actual = _app.Items.First().Quality;

        const int expected = 0;
        Assert.AreEqual(expected, actual);

    }

    [TestMethod]
    public void QualityIsNeverGreaterThan50()
    {
      var longApp = new Program()
      {
        Items = new List<Item>
        {
          new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 100, Quality = 10}
        }
      };

      while (longApp.Items.First().SellIn >= 0)
      {
        longApp.UpdateQuality();
        Assert.IsFalse(longApp.Items.First().Quality > 50);
      }

    }
   
  }
}
