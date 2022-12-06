using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveData1
{
    public bool tutorial = false; //Ʃ�丮�� ȭ��
    public bool TreeQuest = false;
    public bool isTreeeQuest1 = false; // ���, �������� �ݱ� ����Ʈ �Ϸ�
    public bool StartNextQuest = false; //���� ����Ʈ ���� ��
    public bool isTreeeQuest2 = false;

    public int getApple = 0;
    //public int getBranch = 0;
}

public class SaveNLoad : MonoBehaviour
{
    private SaveData1 saveData = new SaveData1();

    private string SAVE_DATA_DIRECTORY;
    private string SAVE_FILENAME = "/SaveFile.txt";

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        SAVE_DATA_DIRECTORY = Application.persistentDataPath + "/Saves/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);

        SaveData();
        LoadData();
        Debug.Log("???");
    }

    public void SaveData()
    {
        //saveData.test = false;
        string json = JsonUtility.ToJson(saveData);
    
        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        //Debug.Log("Save");
    }

    public void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData1>(loadJson);
        }

        else
            Debug.Log("���̺� ������ �����ϴ�");
        
    }
}
