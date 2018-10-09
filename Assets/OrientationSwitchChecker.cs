using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationSwitchChecker : MonoBehaviour
{
    public static OrientationSwitchChecker Instance;
    public ScreenController ScreenController;
    private ScreenOrientation _lastFrameScreenOrientation;
    public ScreenOrientation CurrentOrientation;
    public Action<ScreenOrientation> OnOrientationChange;
    private void Awake()
    {
        _lastFrameScreenOrientation = Screen.orientation;


        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        _lastFrameScreenOrientation = CurrentOrientation;
        CurrentOrientation = CheckOrientation();
        
        if(_lastFrameScreenOrientation != CurrentOrientation)
        {
            ChangeOrientation();
        }

    }

    private void ChangeOrientation()
    {
        OnOrientationChange(CurrentOrientation);
    }

    private ScreenOrientation CheckOrientation()
    {
        ScreenOrientation currentOrientation = ScreenOrientation.Portrait;
        if (Screen.orientation == ScreenOrientation.Landscape ||
              Screen.orientation == ScreenOrientation.LandscapeLeft ||
              Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            currentOrientation = ScreenOrientation.Landscape;
        }
        else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            currentOrientation = ScreenOrientation.Portrait;
        }
        return currentOrientation;
    }

}
