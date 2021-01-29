using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public string mainScene;
    public string credits;
    public string menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // For restart a new party
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainScene);
    }

    public void  Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(credits);
    }

    public void Return()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(menu);
    }

    // To quit the game
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
