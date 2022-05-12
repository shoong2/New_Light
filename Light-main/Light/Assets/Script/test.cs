﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Image panel;
    float time = 0f;
    float F_time = 1f;
    void Start()
    {
        StartCoroutine(fadeFlow());
    }

    IEnumerator fadeFlow()
    {
        panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
            
            
        }
        time = 0f;
        yield return new WaitForSeconds(1f);
        while(alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            panel.color = alpha;
            yield return null;
        }
        panel.gameObject.SetActive(false);
        yield return null;
        yield return new WaitForSeconds(1f);
        panel.gameObject.SetActive(true);
         while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
            
            
        }
    }

    // void Start()
    // {
    //     StartCoroutine(testt());
    // }
    // IEnumerator testt() {
    //     panel.gameObject.SetActive(true);
    //     yield return new WaitForSeconds(0.5f);
    //     panel.gameObject.SetActive(false);
    //     yield return new WaitForSeconds(0.5f);
    //     panel.gameObject.SetActive(true);
    //     yield return new WaitForSeconds(0.5f);
    //     panel.gameObject.SetActive(false);
    //     yield return new WaitForSeconds(0.5f);
    //     panel.gameObject.SetActive(true);
    // }



}
