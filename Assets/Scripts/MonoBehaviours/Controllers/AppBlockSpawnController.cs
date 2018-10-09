using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBlockSpawnController : MonoBehaviour
{
    public AddNewProductController AddNewProductController;
    public GameObject CategoryBlockPrefab;
    public GameObject AppBlockPrefab;
    public Transform Content;

    private List<string> _subCategoriesToSpawn;
    private Products _products;

    public void SpawnBlocksByCategory(Product.Categories chosedCategory)
    {
        ClearContent();
        CreateSubcategoriesList(chosedCategory);
        SpawnBlocks(chosedCategory);
    }

    private void ClearContent()
    {
        int childsCount = Content.transform.childCount;
        for (int i = childsCount - 1; i > 0; i--)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
    }

    private void Awake()
    {
        _subCategoriesToSpawn = new List<string>();
    }

    private void Start()
    {
        _products = AddNewProductController.ReadJson("fixeddb");
    }

    private void CreateSubcategoriesList(Product.Categories chosedCategory)
    {
        _subCategoriesToSpawn.Clear();

        for (int i = 0; i < _products.AllProducts.Count; i++)
        {
            if (_products.AllProducts[i].Category == chosedCategory)
            {
                if (_subCategoriesToSpawn.Contains(_products.AllProducts[i].SubCategory))
                    continue;
                else
                    _subCategoriesToSpawn.Add(_products.AllProducts[i].SubCategory);
            }
        }
    }

    private void SpawnBlocks(Product.Categories chosedCategory)
    {
        for (int i = 0; i < _subCategoriesToSpawn.Count; i++)
        {
            GameObject spawnedBlock = Instantiate(CategoryBlockPrefab, Content);
            CategoryBlockController categoryBlockController = spawnedBlock.GetComponent<CategoryBlockController>();
            categoryBlockController.Initialize(_subCategoriesToSpawn[i]);

            for (int k = 0; k < _products.AllProducts.Count; k++)
            {
                if (_products.AllProducts[k].SubCategory != _subCategoriesToSpawn[i] || _products.AllProducts[k].Category != chosedCategory)
                    continue;
                GameObject spawnedAppBlock = Instantiate(AppBlockPrefab, categoryBlockController.Content);
                AppBlockController appBlockController = spawnedAppBlock.GetComponent<AppBlockController>();
                appBlockController.Initialize(_products.AllProducts[k]);
                categoryBlockController.AddAppBlock(appBlockController);
            }
        }

    }
}
