using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayOrientationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        // Set the orientation to LandscapeLeft or LandscapeRight based on your preference
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        // or Screen.orientation = ScreenOrientation.LandscapeRight;

        if (animator != null)
        {
            animator.SetTrigger("BoardAnimation"); // Trigger the animation by setting a parameter or calling a trigger
        }


    }

    IEnumerator WaitForAnimation()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 2f)
        {
            yield return null;
        }

        
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);
    }


}
