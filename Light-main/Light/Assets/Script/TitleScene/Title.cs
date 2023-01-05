using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject touchToStart;
    public GameObject changeScene;

    private void Start()
    {
        StartCoroutine(ShowStart());
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("main");
    }

    IEnumerator ShowStart()
    {
        yield return new WaitForSeconds(1.8f);
        touchToStart.SetActive(true);
        changeScene.SetActive(true);
    }
}
