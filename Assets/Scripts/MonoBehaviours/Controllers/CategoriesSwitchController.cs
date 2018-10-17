using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesSwitchController : MonoBehaviour
{
    public AppBlockSpawnController AppBlockSpawnController;
    public Categories SelectedCategory;
    public Image HeaderColorBackground;
    [Space]
    public CategoryTabPanel GameCategoryTab;
    public CategoryTabPanel MusicCategoryTab;
    public CategoryTabPanel FilmsCategoryTab;
    [Space]
    public List<CategoryTabPanel> AllCategoriesTabs;

    private void OnEnable()
    {
        InitializeCategoriesTabs();
    }
    private void OnDisable()
    {
        for (int i = 0; i < AllCategoriesTabs.Count; i++)
        {            
            AllCategoriesTabs[i].ChoseCategoryButton.onClick.RemoveAllListeners();
        }
    }

    private void InitializeCategoriesTabs()
    {      
        for (int i = 0; i < AllCategoriesTabs.Count; i++)
        {
            CategoryTabPanel categoriesSwitchController = AllCategoriesTabs[i];
            AllCategoriesTabs[i].ChoseCategoryButton.onClick.AddListener(() => ChoseCategory(categoriesSwitchController));
        }       
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

    public void ChoseCategory(Categories chosedCategory)
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
