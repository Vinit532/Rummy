using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeSceneOrientationController : MonoBehaviour
{
    [SerializeField] Animator animator; // Reference to the Animator component

    [SerializeField] GameObject PlayButton;

     bool animationFinished = false;
    void Start()
    {
        // Set the orientation to Portrait
        Screen.orientation = ScreenOrientation.Portrait;

        if (animator != null)
        {
            animator.SetTrigger("SplashAnimation"); // Trigger the animation by setting a parameter or calling a trigger
        }

        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 2f)
        {
            yield return null;
        }

        PlayButton.SetActive(true);
    }

    public void loadGamePlay()
    {
        SceneManager.LoadScene(1);
    }
    
}
