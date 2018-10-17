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
        private set {}
    }

    public Categories CurrentCategory
    {
        get
        {
            return CategoriesSwitchController.SelectedCategory;
        }
        private set { }
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
        private set { }
    }

    //Set alternative orientation state
    private void SetConfigs(OrientationScreenController orientationScreenController)
    {   
        //Current opened category checking
        CategoriesSwitchController.ChoseCategory(orientationScreenController.CurrentCategory);

        //Main Scroll position checking
        AppPanelScroll.verticalScrollbar.value = orientationScreenController.AppPanelScrollPosition;

        //Left side menu state checking
        if (orientationScreenController.IsMenuShowingNow)
            MenuWindowController.Show();
        else        
            MenuWindowController.Close();

        //Detail app view checking
        if (orientationScreenController.DetailAppPanel.IsShowingNow)
            DetailAppPanel.Initialize(orientationScreenController.DetailAppPanel.CurrentProduct);
        else
            DetailAppPanel.Hide();
    }

    /// <summary>
    /// Switch screen orientation
    /// </summary>
    /// <param name="lastOrientationScreenController">Current orientation</param>
    public void Show(OrientationScreenController lastOrientationScreenController)
    {
        Panel.SetActive(true);
        SetConfigs(lastOrientationScreenController);
        lastOrientationScreenController.Hide();
    }

    public void Hide()
    {
        Panel.SetActive(false);
    }
}
