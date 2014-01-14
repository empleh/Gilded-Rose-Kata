namespace GildedRose.Console
{
  public class SulfurasItem : ItemMatcher
  {
    public override ItemMatcher GetItemType(Item item)
    {
      return item.Name == "Sulfuras, Hand of Ragnaros" ? this : NextMatch.GetItemType(item);
    }

    public override void UpdateQuanity(Item item)
    {
      item.Quality = 80;
      item.SellIn = 0;
    }
  }
}