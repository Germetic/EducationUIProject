[System.Serializable]
public class Product
{
    public enum Categories {Game,Film,Book,Music,Press}
    public Categories Category;
    public enum BlockTypes {None,Recommend,Top,Sale,New,ForYou}
    public BlockTypes BlockType;
    public byte[] Icon;
    public string Title;
    public string Description;
    public bool IsRecommend;
    public float Rating;
    public int Size;
    public int Downloads;

    public Product(byte[] icon, string title, string description, bool isRecommend, float rating, int size, int downloads,Categories category,BlockTypes blockType)
    {
        Icon = icon;
        Title = title;
        Description = description;
        IsRecommend = isRecommend;
        Rating = rating;
        Size = size;
        Downloads = downloads;
        Category = category;
        BlockType = blockType;
    }
}
