using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayOrientationController : MonoBehaviour
{
    void Start()
    {
        // Set the orientation to LandscapeLeft or LandscapeRight based on your preference
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        // or Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);
    }
}
