using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lia_face : MonoBehaviour
{
    Transform tras = null; 
    // public GameObject Lia_ang;
    // public GameObject Lia_emb;
    // public GameObject Lia_disa;
    // public GameObject Lia_shock;
    
    // GameObject[] face = new GameObject[3];



    public void af() //active false
    {
        for(int i=0; i<6; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void sad()
    {
        af();
        transform.GetChild(5).gameObject.SetActive(true);
    }

    public void none()
    {
        af();
        transform.GetChild(4).gameObject.SetActive(true);
    }

    public void shock()
    {
        af();
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void disappoint()
    {
        af();
        transform.GetChild(2).gameObject.SetActive(true);
    }

     public void angry()
    {
        af();
        transform.GetChild(0).gameObject.SetActive(true);
    }

     public void embarrassed()
    {
        af();
        transform.GetChild(1).gameObject.SetActive(true);
    }

    
    // public void shock()
    // {
    // Lia_ang.SetActive(false);
    // Lia_disa.SetActive(false);
    // Lia_emb.SetActive(false);
    // Lia_shock.SetActive(true);
    // }
}


