using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string lastPlayerName = "";
    private string bestScoreName = "";
    private int bestScore = 0;

    public string LastPlayerName  { get { return lastPlayerName; } }
    public string BestPlayerName { get { return bestScoreName; } }
    public int BestScore { get { return bestScore; } }
    public string playerName { get; set; }

    public bool IsNewHighScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestScoreName = playerName;
            return true;
        }
        return false;
    }

    [System.Serializable]
    private class SessionData
    {
        public string LastPlayer;
        public string BestPlayer;
        public int BestScore;
    }

    public void SaveData()
    {
        SessionData data = new SessionData
        {
            LastPlayer = playerName,
            BestPlayer = BestPlayerName,
            BestScore = BestScore
        };

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/sessionData.dat", json);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/sessionData.dat";
        if(System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SessionData data = JsonUtility.FromJson<SessionData>(json);

            playerName = data.LastPlayer;
            bestScoreName = data.BestPlayer;
            bestScore = data.BestScore;
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();
    }

}
