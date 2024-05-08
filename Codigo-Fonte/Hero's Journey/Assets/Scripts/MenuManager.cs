using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void LoadScenes(string Cenas){
        SceneManager.LoadScene(Cenas);

    }

    public void Quit(){
        Application.Quit();

    }
}
