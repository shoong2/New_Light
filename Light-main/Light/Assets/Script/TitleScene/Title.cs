using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject touchToStart;
    public GameObject changeScene;
    GameManager theSaveNLoad;

    
    private void Start()
    {
        StartCoroutine(ShowStart());
    }
    public void ChangeScene()
    {
        //StartCoroutine(LoadScene());
        SceneManager.LoadScene("main");
    }

    //IEnumerator LoadScene()
    //{
    //    AsyncOperation operation = SceneManager.LoadSceneAsync("main");
    //    while(!operation.isDone)
    //    {
    //        yield return null;
    //    }
    //    theSaveNLoad = FindObjectOfType<GameManager>();
    //    theSaveNLoad.LoadData();
    //    Debug.Log("Load");
    //    //Destroy(gameObject);

    //}

    IEnumerator ShowStart()
    {
        yield return new WaitForSeconds(1.8f);
        touchToStart.SetActive(true);
        changeScene.SetActive(true);
    }
}
