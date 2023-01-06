using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public bool vivo = true;
    public int Score = 0000;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject ScoreObject;
    [SerializeField] GameObject VidasObject;
    [SerializeField] GameObject GameoverObject;
    public int Vidas = 3;
    [SerializeField] GameObject[] iconosVidas = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddScore(int x)
    {
        Score += x;
        scoreText.text = Score.ToString();
    }
    //Desactiva iconos de vida a medida que los pierda
    public void PerderVida()
    {
        if (vivo)
        {
            if (Vidas >= 0)
            {
                Vidas--;
                iconosVidas[Vidas].SetActive(false);
            }
            if (Vidas == 0)
                GameOver();
        }
    }

    public void GanarVida()
    {
        if (vivo)
        {
            //Mientras no tengas el maximo de vida, suma vida y reactiva iconos
            if (Vidas < 3)
            {
                iconosVidas[Vidas].SetActive(true);
                Vidas++;
            }
        }
    }

    public void GameOver()
    {
        vivo = false; //se detiene el manejo de vidas
        VidasObject.SetActive(false);
        GameoverObject.SetActive(true);
        ScoreObject.transform.localPosition = new Vector2(-60, 40);
    }

    // Update is called once per frame
    void Update()
    {
        //usando el viejo input system solo para testear, reemplazar o borrar antes de entrega!!!
        if (Input.GetKeyDown(KeyCode.O))
            GanarVida();
        if (Input.GetKeyDown(KeyCode.P))
            PerderVida();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  
}
