using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public string levelToLoad;
    public GameObject garage;
    
    public void Timer()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
    public void Multiplayer()
    {
        SceneManager.LoadScene("Lobby");
    }
    
    public void AgainstIA()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
    public void Garage()
    {
        garage.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}