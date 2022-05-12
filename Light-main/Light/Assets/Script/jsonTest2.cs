using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class jsonTest2 : MonoBehaviour
{
    
    public PlayerData playerData;
    
    [ContextMenu("To Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData);
        string path = Path.Combine(Application.dataPath,"playerData.json");
        File.WriteAllText(path, jsonData);
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int age;
    public int Level;
}
