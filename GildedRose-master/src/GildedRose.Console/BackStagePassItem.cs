namespace GildedRose.Console
{
  public class BackstagePassItem : ItemMatcher
  {
    public override ItemMatcher GetItemType(Item item)
    {
      return item.Name.StartsWith("Backstage") ? this : NextMatch.GetItemType(item);
    }

    public override void UpdateQuanity(Item item)
    {
      item.SellIn--;
      if (item.SellIn >= 10)
      {
        item.Quality++;
      }
      else if (item.SellIn >= 5)
      {
        item.Quality += 2;
      }
      else if (item.SellIn >= 0)
      {
        item.Quality += 3;
      }
      else
      {
        item.Quality = 0;
      }

      item.Quality = item.Quality > 50 ? 50 : item.Quality;
    }
  }
}