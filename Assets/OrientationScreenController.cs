using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationScreenController : MonoBehaviour {

    public ScreenOrientation Orientation;
    public DetailAppPanel DetailAppPanel;
    public AppBlockSpawnController AppBlockSpawnController;
    public CategoriesSwitchController CategoriesSwitchController;
    public ScrollRect AppPanelScroll;
    public MenuWindowController MenuWindowController;
    public GameObject Panel;

    public float AppPanelScrollPosition
    {
        get
        {
            return AppPanelScroll.verticalScrollbar.value;
        }
        private set {  }
    }
    public Product.Categories CurrentCategory
    {
        get
        {
            return CategoriesSwitchController.SelectedCategory;
        }
        private set
        {
            
        }
    }
    public bool IsMenuShowingNow
    {
        get
        {
           return MenuWindowController.IsShowingNow;
        }
      
    }
    public bool IsDetailScreenShowingNow
    {
        get
        {
            return DetailAppPanel.IsShowingNow;
        }
        private set
        {
           
        }
    }

    private void SetConfigs(OrientationScreenController orientationScreenController)
    {
        Debug.Log("<color=orange><b> CURRENT CATEGORY </b></color>" + orientationScreenController.CurrentCategory);
        CategoriesSwitchController.ChoseCategory(orientationScreenController.CurrentCategory);
        Debug.Log("<color=orange><b> SCROLL POSITION </b></color>" + orientationScreenController.AppPanelScrollPosition);
        AppPanelScroll.verticalScrollbar.value = orientationScreenController.AppPanelScrollPosition;

        Debug.Log("<color=orange><b> ISSHOWING MENU </b></color>" + orientationScreenController.IsMenuShowingNow);
        if (orientationScreenController.IsMenuShowingNow)
        {
            MenuWindowController.Show();
        }
        else
        {
            MenuWindowController.Close();
        }
        Debug.Log("<color=orange><b> CURRENT PRODUCT </b></color>" + orientationScreenController.DetailAppPanel.IsShowingNow);
        if (orientationScreenController.DetailAppPanel.IsShowingNow)
            DetailAppPanel.Initialize(orientationScreenController.DetailAppPanel.CurrentProduct);
        else
        {
            DetailAppPanel.Hide();
        }
    }
    public void Show(OrientationScreenController lastOrientationScreenController)
    {
        Debug.Log("<color=orange><b> SHOWED </b></color>" + gameObject.name + " OLD " + lastOrientationScreenController.Panel.name);
        Panel.SetActive(true);
        SetConfigs(lastOrientationScreenController);
        lastOrientationScreenController.Hide();
    }
    public void Hide()
    {
        Debug.Log("<color=orange><b> HIDED </b></color>" + gameObject.name);
        Panel.SetActive(false);
    }
}
