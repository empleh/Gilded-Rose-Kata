namespace GildedRose.Console
{
  public abstract class ItemMatcher
  {
    public ItemMatcher NextMatch { get; private set; }

    public ItemMatcher RegisterNext(ItemMatcher nextMatcher)
    {
      NextMatch = nextMatcher;
      return nextMatcher;
    }

    public abstract ItemMatcher GetItemType(Item item);
    public abstract void UpdateQuanity(Item item);
  }
}