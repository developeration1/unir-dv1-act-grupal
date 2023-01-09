using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider barraVolumen;
    public static float ValorSliderMusica;

    public void LoadScene(string scene)
    {
      SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
          Application.Quit();
    }

    void Update()
    {
        ValorSliderMusica = barraVolumen.value;
    }
}
