using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence instance;
    public string username;
    public BestScoreData bestScoreInfo = new BestScoreData("Best Score: ???", 0);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    [System.Serializable]
    public class BestScoreData 
    {
        public string text;
        public int score;

        public BestScoreData(string text, int score)
        {
            this.text = text;
            this.score = score;
        }
    }

    public void saveBestScore(string text, int score)
    {
        string json;

        bestScoreInfo.text = text;
        bestScoreInfo.score = score;
        json = JsonUtility.ToJson(bestScoreInfo);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void loadBestScore()
    {
        string path;

        path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path)) 
        { 
            string json;

            json = File.ReadAllText(path);
            bestScoreInfo = JsonUtility.FromJson<BestScoreData>(json);
        }
    }
}
