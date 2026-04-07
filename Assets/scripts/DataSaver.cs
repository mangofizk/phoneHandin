using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;
using System.Text;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif


public class DataSaver : MonoBehaviour
{
    private GameData gameDataCurrent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameDataCurrent = transform.GetComponent<DataRecorder>().gameData;

#if UNITY_ANDROID
        // Request write permission if needed (older Android)
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
#endif
    }

    public void SaveData()
    {
        SaveJson(gameDataCurrent);
        //SaveCsv(gameDataCurrent);
        //SaveXml(gameDataCurrent);
        //SaveYaml(gameDataCurrent);
        Debug.Log("All data saved!");
    }
    
    public void MoveToDownloads()
    {
        string savedFolder = Path.Combine(GetSavePath(), "SavedData");
        if (!Directory.Exists(savedFolder))
        {
            Debug.LogWarning("SavedData folder does not exist!");
            return;
        }

        string downloadsPath;

        if (Application.platform == RuntimePlatform.Android)
        {
            downloadsPath = "/storage/emulated/0/Download/SavedData"; // Android Downloads
        }
        else
        {
            downloadsPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "SavedData");
        }

        if (!Directory.Exists(downloadsPath))
            Directory.CreateDirectory(downloadsPath);

        foreach (string file in Directory.GetFiles(savedFolder))
        {
            string destFile = Path.Combine(downloadsPath, Path.GetFileName(file));
            File.Copy(file, destFile, true);
            Debug.Log("Copied to Downloads: " + destFile);
        }

        Debug.Log("All files moved to Downloads folder!");
    }

    void SaveJson(GameData gameData)
    {
        string folder = Path.Combine(GetSavePath(), "SavedData");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string pathFull = Path.Combine(folder, "gameData.json");
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(pathFull, json);
        Debug.Log("Saved JSON: " + pathFull);
    }

    private string GetSavePath()
    {
        if (Application.isEditor)
            return Application.dataPath; // Editor folder
        else
            return Application.persistentDataPath; // Android, iOS, Standalone builds
    }
}
