using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] int scoreToNextLevel;
    [SerializeField] string nextLevelName;
    [SerializeField] public UiManager uiManager;

    int score = 0;
    public float Score => score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= scoreToNextLevel)
            SceneManager.LoadScene(nextLevelName);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        uiManager.SetScore(score);
    }
}
