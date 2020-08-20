using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float animTime = 1f;

    public Animator transition;
    public GameObject loadScreen;
    public Slider sliding;

    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadLevelCo(levelIndex));
    }

    IEnumerator LoadLevelCo(int levelIndex)
    {
        //play the animation
        transition.SetTrigger("ExitLevel");
        //wait for the animation to finish
        yield return new WaitForSeconds(animTime);

        //Load scene
        //op stores the progress of the current operation
        AsyncOperation op = SceneManager.LoadSceneAsync(levelIndex);
        loadScreen.SetActive(true);
        while (!op.isDone)
        {
            //normalize the progress value to between 0 and 1, instead of 0 and 0.9
            //since the progress of Async Level Loading loads the level during 0 to 0.9 and actually transitions
            //scenes at that point, we never see the values between 0.9 and 1
            float progress = Mathf.Clamp01(op.progress / 0.9f);

            //we set the slider's value to be the progress of the level loading
            sliding.value = progress;

            //wait until next frame
            yield return null;
        }
    }
}
