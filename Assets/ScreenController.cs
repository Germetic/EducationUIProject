using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{   
    public ScreenOrientation CurrentOrientation;

    public DetailAppPanel DetailAppPanel
    {
        get
        {
            return CurrentOrientationScreenController.DetailAppPanel;
        }
    }
    public static ScreenController Instance;
    public OrientationScreenController CurrentOrientationScreenController;

    public OrientationScreenController PortraitScreen;
    public OrientationScreenController LandscapeScreen;
    private OrientationScreenController _lastOrientationScreenController;

    private void Awake()
    {   
        if (Instance == null)
        { 
            Instance = this;
        }
        else if (Instance == this)
        { 
            Destroy(gameObject); 
        }

        OrientationSwitchChecker.Instance.OnOrientationChange += SwitchScreenOrientation;
    }
    public void SwitchScreenOrientation(ScreenOrientation orientationToSwitch)
    {   
        if(orientationToSwitch == ScreenOrientation.Portrait)
        {
            CurrentOrientationScreenController = PortraitScreen;
            _lastOrientationScreenController = LandscapeScreen;
            Debug.Log("PORTRAIT");
        }
        else
        {
            CurrentOrientationScreenController = LandscapeScreen;
            _lastOrientationScreenController = PortraitScreen;
            Debug.Log("LANDSCAPE");
        }
        SwitchScreen();
    }

    private void SwitchScreen()
    {
        CurrentOrientationScreenController.Show(_lastOrientationScreenController);
    }
}
