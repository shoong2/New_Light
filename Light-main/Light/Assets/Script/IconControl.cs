using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconControl : MonoBehaviour
{
   
    // public GameObject set;
    public GameObject inv;
    public GameObject skl;
    public GameObject qst;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickSet()
    {
        box1.SetActive(true);
        box2.SetActive(false);
        box3.SetActive(false);
        box4.SetActive(false);
        inv.SetActive(false);
        skl.SetActive(false);
        qst.SetActive(false);
    }

     public void clickIvn()
    {
        box1.SetActive(false);
        box2.SetActive(true);
        box3.SetActive(false);
        box4.SetActive(false);
        inv.SetActive(true);
        skl.SetActive(false);
        qst.SetActive(false);
    }

     public void clickSkl()
    {
        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(true);
        box4.SetActive(false);
        inv.SetActive(false);
        skl.SetActive(true);
        qst.SetActive(false);
    }

     public void clickQst()
    {
        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(false);
        box4.SetActive(true);
        inv.SetActive(false);
        skl.SetActive(false);
        qst.SetActive(true);
    }
}
