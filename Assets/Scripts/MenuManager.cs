using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text BestScoreTxt;
    public InputField inputName;
    public void StartMain()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        GameManager.Instance.SaveData();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveInputValue(string inputvalue)
    {
        GameManager.Instance.playerName = inputvalue;
    }
    public void SetBestScoretxt()
    {
        BestScoreTxt.text = $"BEST SCORE: {GameManager.Instance.BestPlayerName} : {GameManager.Instance.BestScore}";
    }

    private void Start()
    {
        SetBestScoretxt();
        inputName.SetTextWithoutNotify( GameManager.Instance.playerName);
    }
}
