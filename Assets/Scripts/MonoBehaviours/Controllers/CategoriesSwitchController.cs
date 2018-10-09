using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesSwitchController : MonoBehaviour
{
    public AppBlockSpawnController AppBlockSpawnController;
    public Product.Categories SelectedCategory;
    public Image HeaderColorBackground;
    [Space]
    public CategoryTabPanel GameCategoryTab;
    public CategoryTabPanel MusicCategoryTab;
    public CategoryTabPanel FilmsCategoryTab;
    [Space]
    public List<CategoryTabPanel> AllCategoriesTabs;

    private void Awake()
    {
        InitializeCategoriesTabs();
    }

    private void InitializeCategoriesTabs()
    {
        AllCategoriesTabs = new List<CategoryTabPanel>();

        AllCategoriesTabs.Add(GameCategoryTab);
        AllCategoriesTabs.Add(MusicCategoryTab);
        AllCategoriesTabs.Add(FilmsCategoryTab);

        AllCategoriesTabs[0].ChoseCategoryButton.onClick.AddListener(() => ChoseCategory(AllCategoriesTabs[0]));
        AllCategoriesTabs[1].ChoseCategoryButton.onClick.AddListener(() => ChoseCategory(AllCategoriesTabs[1]));
        AllCategoriesTabs[2].ChoseCategoryButton.onClick.AddListener(() => ChoseCategory(AllCategoriesTabs[2]));

    }
    private void Start()
    {
        ChoseCategory(GameCategoryTab);
    }

    private void ChangeHeaderColor(Color32 newColor)
    {
        HeaderColorBackground.color = newColor;
    }

    private void ChoseCategory(CategoryTabPanel chosedCategory)
    {
        SelectedCategory = chosedCategory.CategoryName;

        for (int i = 0; i < AllCategoriesTabs.Count; i++)
        {
            AllCategoriesTabs[i].Chose(false);
        }
        chosedCategory.Chose(true);
        HeaderColorBackground.color = chosedCategory.CategoryColor;
        AppBlockSpawnController.SpawnBlocksByCategory(chosedCategory.CategoryName);
    }

    public void ChoseCategory(Product.Categories chosedCategory)
    {
        for (int i = 0; i < AllCategoriesTabs.Count; i++)
        {
            if (AllCategoriesTabs[i].CategoryName == chosedCategory)
            {
                ChoseCategory(AllCategoriesTabs[i]);
                break;
            }
        }
    }
}
