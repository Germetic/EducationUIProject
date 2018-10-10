[System.Serializable]
public class Product
{
    public enum Categories {Game,Film,Book,Music,Press}
    public Categories Category;    
    public string SubCategory;
    public string Icon;
    public string Title;
    public string Description;
    public bool IsRecommend;
    public float Rating;
    public int Size;
    public int Downloads;

    public Product(string icon, string title, string description, bool isRecommend, float rating, int size, int downloads,Categories category,string subCategory)
    {
        Icon = icon;
        Title = title;
        Description = description;
        IsRecommend = isRecommend;
        Rating = rating;
        Size = size;
        Downloads = downloads;
        Category = category;
        SubCategory = subCategory;
    }
}
