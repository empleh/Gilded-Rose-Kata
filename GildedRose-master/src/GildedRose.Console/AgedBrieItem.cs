namespace GildedRose.Console
{
  public class AgedBrieItem : ItemMatcher
  {
    public override ItemMatcher GetItemType(Item item)
    {
      return item.Name == "Aged Brie" ? this:NextMatch.GetItemType(item);
    }

    public override void UpdateQuanity(Item item)
    {
      item.SellIn--;
      if (item.SellIn >= 0)
      {
        item.Quality ++;
      }
      else
      {
        item.Quality += 2;
      }

      item.Quality = item.Quality > 50 ? 50 : item.Quality;
    }
  }
}