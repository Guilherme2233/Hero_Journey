using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HeartSystem : MonoBehaviour
{
     [Header("PLAYER LIFE")]
    public int Life = 6;
    public int MaxLife = 6;
     [Header("PLAYER LIFE/UI")]
    public Image[] Heart;
    public Sprite Full_Heart;
    public Sprite Empty_Heart;   
    public Player player;
    public bool IsDead;
    void Start()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        LifeSystemm();
        PlayerDeath();
    }
    void LifeSystemm()
    {

        if (Life == MaxLife)
        {
            Life = MaxLife;
        }

        for (int i = 0; i < Heart.Length; i++)
        {

            if (i < Life)
            {
                Heart[i].sprite = Full_Heart;
            }

            else
            {
                Heart[i].sprite = Empty_Heart;
            }

            if (i < MaxLife)
            {
                Heart[i].enabled = true;

            }
            else
            {
                Heart[i].enabled = false;

            }


        }
    }
    void PlayerDeath()
    {
        if (Life <= 0)
        {
            
            IsDead = true;
            player.Anim.SetBool("IsDead", IsDead);
            Destroy(gameObject, 3.0f);
            Invoke("LoadGameOver",2.0f);
            
            
        }
    }

    void LoadGameOver(){
        SceneManager.LoadScene("GameOver");
        
    }   


} 