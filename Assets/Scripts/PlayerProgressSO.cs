using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "Player Progress", menuName = "Quiz Game/Player Progress")]
public class PlayerProgressSO : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int coin;
        public Dictionary<string, int> levelProgress;
    }

    [SerializeField] string _fileName;
    [SerializeField] string _startingLevelPackName;

    public MainData dataProgress = new MainData();

    public void SaveProgress()
    {
        //dataProgress.coin = 300;

        //if (dataProgress.levelProgress == null)
        //{
        //    dataProgress.levelProgress = new();
        //}

        //dataProgress.levelProgress.Add("Level Pack A", 3);
        //dataProgress.levelProgress.Add("Level Pack B", 1);

        if (dataProgress.levelProgress == null)
        {
            dataProgress.levelProgress = new();
            dataProgress.coin = 0;
            dataProgress.levelProgress.Add(_startingLevelPackName, 1);
        }

#if UNITY_EDITOR
        string directory = Application.dataPath + "/Temp";
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        string directory = Application.persistentDataPath + "/LocalProgress";
#endif

        string filePath = directory + "/" + _fileName;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created: " + directory);
        }

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
            Debug.Log("File created: " + filePath);
        }

        FileStream fileStream = File.Open(filePath, FileMode.Open);

        fileStream.Flush();

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(fileStream, dataProgress);

        //BinaryWriter writer = new BinaryWriter(fileStream);

        //writer.Write(dataProgress.coin);

        //foreach (var progress in dataProgress.levelProgress)
        //{
        //    writer.Write(progress.Key);
        //    writer.Write(progress.Value);
        //}

        // writer.Dispose();
        fileStream.Dispose();

        //string content = $"{dataProgress.coin}\n";

        //foreach (var progress in dataProgress.levelProgress)
        //{
        //    content += $"{progress.Key} {progress.Value}\n";
        //}

        //File.WriteAllText(filePath, content);

        Debug.Log($"{_fileName} Saved");
    }

    public bool LoadProgress()
    {
        string directory = Application.dataPath + "/Temp";
        string filePath = directory + "/" + _fileName;

        //if (!Directory.Exists(directory))
        //{
        //    Directory.CreateDirectory(directory);
        //    Debug.Log("Directory has been created: " + directory);
        //}

        //if (!File.Exists(filePath))
        //{
        //    File.Create(filePath).Dispose();
        //    Debug.Log("File created: " + filePath);
        //}

        FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate);

        try
        {
            //BinaryReader reader = new BinaryReader(fileStream);

            //try
            //{
            //    dataProgress.coin = reader.ReadInt32();

            //    if (dataProgress.levelProgress == null)
            //    {
            //        dataProgress.levelProgress = new();
            //    }

            //    while (reader.PeekChar() != -1)
            //    {
            //        string levelPackName = reader.ReadString();
            //        int levelReached = reader.ReadInt32();

            //        dataProgress.levelProgress.Add(levelPackName, levelReached);

            //        Debug.Log($"{levelPackName}:{levelReached}");
            //    }
            //}
            //catch (System.Exception e)
            //{
            //    reader.Dispose();
            //    fileStream.Dispose();

            //    Debug.LogError($"ERROR: Failed while load binary progress\n{e.Message}");

            //    return false;
            //}

            BinaryFormatter formatter = new BinaryFormatter();

            dataProgress = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log($"{dataProgress.coin}; {dataProgress.levelProgress.Count}");

            return true;
        }
        catch (System.Exception e)
        {
            fileStream.Dispose();

            Debug.LogError($"ERROR: Failed to load progress\n{e.Message}");

            return false;
        }
    }
}
