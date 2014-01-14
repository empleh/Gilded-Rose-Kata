namespace GildedRose.Console
{
  public class ConjuredItem: ItemMatcher
  {

    public override void UpdateQuanity(Item item)
    {
      item.SellIn--;
      if (item.SellIn > 0)
      {
        item.Quality -= 2;
      }
      else
      {
        item.Quality -= 4;
      }

      item.Quality = item.Quality < 0 ? 0 : item.Quality;
    }

    public override ItemMatcher GetItemType(Item item)
    {
      return item.Name.StartsWith("Conjured") ? this : NextMatch.GetItemType(item);
    }
  }
}