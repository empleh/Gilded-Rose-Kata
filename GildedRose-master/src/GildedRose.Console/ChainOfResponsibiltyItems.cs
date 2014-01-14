using System.Collections.Generic;

namespace GildedRose.Console
{
  public class ChainOfResponsibiltyItems
  {
    private readonly ItemMatcher _itemMatcher;

    public ChainOfResponsibiltyItems()
    {
      _itemMatcher = new ConjuredItem();
      _itemMatcher.RegisterNext(new BackstagePassItem())
                  .RegisterNext(new AgedBrieItem())
                  .RegisterNext(new SulfurasItem())
                  .RegisterNext(new RegularItem());
    }

    public void UpdateList(IList<Item> items)
    {
      foreach (var item in items)
      {
        _itemMatcher.GetItemType(item).UpdateQuanity(item);
      }
    }
  }
}