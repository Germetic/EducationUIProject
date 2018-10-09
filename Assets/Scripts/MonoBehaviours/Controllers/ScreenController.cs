using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public static ScreenController Instance;
    public ScreenOrientation CurrentOrientation;
    public OrientationScreenController CurrentOrientationScreenController;
    public OrientationScreenController PortraitScreen;
    public OrientationScreenController LandscapeScreen;
    public DetailAppPanel DetailAppPanel
    {
        get
        {
            return CurrentOrientationScreenController.DetailAppPanel;
        }
    }

    private OrientationScreenController _lastOrientationScreenController;

    private void Awake()
    {   
        //Singletone
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
        }
        else
        {
            CurrentOrientationScreenController = LandscapeScreen;
            _lastOrientationScreenController = PortraitScreen;
        }

        SwitchScreen();
    }

    private void SwitchScreen()
    {
        Debug.Log("Orientation was switched from " + _lastOrientationScreenController.Orientation.ToString()
    + " to " + CurrentOrientationScreenController.Orientation.ToString());

        CurrentOrientationScreenController.Show(_lastOrientationScreenController);
    }
}
