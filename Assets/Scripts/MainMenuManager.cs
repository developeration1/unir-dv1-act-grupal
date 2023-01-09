using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider barraVolumen;
    public static float ValorSliderMusica;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadScene(int x)
    {
      SceneManager.LoadScene(x);
    }
    
    public void QuitGame()
    {
          Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        ValorSliderMusica = barraVolumen.value;
    }
}
