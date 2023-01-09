using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SingletonMusica : MonoBehaviour
{
    [SerializeField] AudioSource music;
    public static SingletonMusica Instance { get; private set; }
    private void Awake()
    {

        // Se destruye el singleton si ve que otro ya existe, ya que este reproductor de musica 
        //persistira entre escenas y solo necesitamos uno
        DontDestroyOnLoad(transform.gameObject);


        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void Update()
    {

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            music.volume = (MainMenuManager.ValorSliderMusica) / 10f;
        }
    }
}
