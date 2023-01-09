using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public string playerName;
    
    public int bestPlayerScore;
    public string bestPlayerName;

    private string savePath;
    public InputField nameInputField;
    public GameObject nameErrorText;

    private void Awake()
    {
        if (gameManager != null)
        {
            Destroy(gameManager);
            return;
        }
        savePath = Application.persistentDataPath + "/savedata.json";
        gameManager = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void StartGame()
    {
        playerName = nameInputField.text;

        if (String.IsNullOrEmpty(playerName))
        {
            nameErrorText.SetActive(true);
            return;
        }
        
        SceneManager.LoadScene(1);
    }

    public void PersistHighScore(int newBestScore)
    {
        bestPlayerName = playerName;
        bestPlayerScore = newBestScore;
        Save();
    }

    [Serializable]
    public class SaveData
    {
        public string playerName;
    
        public int bestPlayerScore;
        public string bestPlayerName;
    }

    void Load()
    {
        if (File.Exists(savePath))
        {
            string jsonSaveData = File.ReadAllText(savePath);

            SaveData data = JsonUtility.FromJson<SaveData>(jsonSaveData);
            bestPlayerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;
        }
    }

    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.bestPlayerName = bestPlayerName;
        saveData.bestPlayerScore = bestPlayerScore;

        string jsonData = JsonUtility.ToJson(saveData);
        
        File.WriteAllText(savePath, jsonData);
    }

    public void ResetScore()
    {
        bestPlayerName = "";
        bestPlayerScore = 0;
        
        Save();
    }

}
