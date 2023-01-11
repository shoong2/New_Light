using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{
    public Image tutorial;
    public AudioSource tutorialSound;
    public AudioSource mainBackGroundSound;
    void Start()
    {
        StartCoroutine(StartTutorial());       
    }

    IEnumerator StartTutorial()
    {
        //yield return new WaitForSeconds(1.1f);

        if (GameManager.instance.saveData.tutorial == false)
        {
            tutorial.gameObject.SetActive(true);
            tutorialSound.Play();
            float fadeCount = 0;
            while (fadeCount < 1.0f)
            {
                fadeCount += 0.01f;
                yield return new WaitForSeconds(0.005f);
                tutorial.color = new Color(1, 1, 1, fadeCount);
            }
            yield return new WaitForSeconds(1.3f);
            while (fadeCount > 0)
            {
                fadeCount -= 0.02f;
                yield return new WaitForSeconds(0.005f);
                tutorial.color = new Color(1, 1, 1, fadeCount);
            }
            mainBackGroundSound.Play();
            tutorial.gameObject.SetActive(false);
            GameManager.instance.saveData.tutorial = true;
            GameManager.instance.SaveData();
        }
        else
            mainBackGroundSound.Play();

    }


}
