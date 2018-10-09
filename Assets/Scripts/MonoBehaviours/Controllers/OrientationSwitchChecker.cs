using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationSwitchChecker : MonoBehaviour
{
    public static OrientationSwitchChecker Instance;
    public ScreenController ScreenController;
    public ScreenOrientation CurrentOrientation;
    public Action<ScreenOrientation> OnOrientationChange;
    private ScreenOrientation _lastFrameScreenOrientation;

    private void Awake()
    {
        _lastFrameScreenOrientation = Screen.orientation;

        //Singletone
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
        CheckOrientationToChanges();
    }

    //Check current orientation and call event while is changed
    private void CheckOrientationToChanges()
    {
        _lastFrameScreenOrientation = CurrentOrientation;
        CurrentOrientation = CheckOrientation();

        if (_lastFrameScreenOrientation != CurrentOrientation)
        {
            OnOrientationChange(CurrentOrientation);
        }
    }

    //Returns current orientation with state generalization
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
