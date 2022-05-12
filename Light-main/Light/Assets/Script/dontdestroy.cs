using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    public static dontdestroy instance;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
        
    }

    
}
