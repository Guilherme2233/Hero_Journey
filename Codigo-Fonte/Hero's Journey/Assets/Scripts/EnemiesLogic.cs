using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesLogic : MonoBehaviour
{
    public float speed ;

    public float MinDistance ;
    public Rigidbody2D Rigi;
    public Animator anime;
    public Transform Player;
    [SerializeField]
    public int Vidas;

    void Start()
    {
        Rigi = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        EnemieMove();
        EnemieAnimations();
    }


    void EnemieMove()
    {
        if (Vidas >= 1)
        {
            float distance = Vector2.Distance(transform.position, Player.position);

            if (distance < MinDistance)
            {

                Vector3 direction = Player.position - transform.position;
                direction.y = 0;
                direction.Normalize();


                Vector3 newPosition = transform.position + speed * Time.deltaTime * direction;
                transform.position = newPosition;

            }

        }


    }
    void EnemieAnimations()
    {
        if ( Vidas >=1 && Vector2.Distance(transform.position, Player.position) < MinDistance)
        {
            
            anime.SetBool("EnemieWalk", true);
            transform.eulerAngles = new Vector3(0f, Player.position.x > transform.position.x ? 0f : 180f, 0f);

        }
        else if(MinDistance < 1)
        {

            anime.SetBool("EnemieWalk", false);
        }

        if (MinDistance < 0.9)
        {
            anime.SetBool("EnemieAttack", true);

        }
        else
        {
            anime.SetBool("EnemieAttack", false);


        }


    }

    public void ReceberDano()
    {
        if (Vidas > 0)
            Vidas--;
        Debug.Log(name + "recebeu dano" + Vidas);
        if (Vidas == 0)
        {
            
            anime.SetBool("IsDead", true);
            GameObject.Destroy(gameObject, 1.0f);
        }
        else
        {
            anime.SetTrigger("TakeDamage");
        }

    }
}