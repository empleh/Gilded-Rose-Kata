namespace GildedRose.Console
{
  public class RegularItem : ItemMatcher
  {
    public override ItemMatcher GetItemType(Item item)
    {
      return this;
    }

    public override void UpdateQuanity(Item item)
    {
      item.SellIn--;
      if (item.SellIn > 0)
      {
        item.Quality --;
      }
      else
      {
        item.Quality -= 2;
      }

      item.Quality = item.Quality < 0 ? 0 : item.Quality;
    }
  }
}