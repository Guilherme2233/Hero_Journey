using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaFase : MonoBehaviour
{

    [SerializeField]
    public string ProximaFaseName = "";
 
void OnTriggerEnter2D(Collider2D col){
    if(col.gameObject.CompareTag("Player")){
        SceneManager.LoadScene(ProximaFaseName);
    }

    }

}





