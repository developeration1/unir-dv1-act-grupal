using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
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
        
    }
}
