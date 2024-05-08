using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [Header("PLAYER MOVE VARIABELS")]
    
    public float Speed;
    public float JumpForce;
    public bool TaNoChão;
    public Transform DetectaChao;
    public LayerMask oqueechao;


    [Header("PLAYER ATTACK VARIABELS")]
    public int AttackCounter = 0;
    public float LastAttackTime;
    public float ComboDelay = 1f;    

    [Header("PLAYER KNOCKBACK VARIABLES")]
    public float KbForce;
    public float KbCount;
    public float KbTime;
    public bool IsKnockRight;

    
    public Rigidbody2D Rigibody;
    public Animator Anim;
    

    void Start()
    {
        Rigibody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        
    }
    void Update()
    {
        KnockBack();
        Jump();
        PlayerAnimations();

    }
    void Move()
    {
        Vector3 Movement = new(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Speed * Time.deltaTime * Movement;

    }

    void KnockBack()
    {
        if (KbCount < 0)
        {
            Move();
        }

        else
        {
            if (IsKnockRight == true)
            {
                Rigibody.velocity = new Vector2(-KbForce, KbForce
                );
            }
            if (IsKnockRight == false)
            {
                Rigibody.velocity = new Vector2(KbForce, KbForce
                );
            }

        }
        KbCount -= Time.deltaTime;
    }




    void OnDrawGizmos()
{
    Vector2 boxSize = new(1.0f, 0.5f); 
    Gizmos.color = Color.red; 
    Gizmos.DrawWireCube(DetectaChao.position, boxSize); 
}



    
    void Jump()
    {
    Vector2 boxSize = new(1.0f, 0.5f); 
    TaNoChão = Physics2D.OverlapBox(DetectaChao.position, boxSize, 0, oqueechao);
    if (Input.GetButtonDown("Jump") && TaNoChão == true)
    {
        Rigibody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }
    }

    void PlayerAnimations()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("walk", false);
        }
        else
        {
            Anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, Input.GetAxis("Horizontal") > 0f ? 0f : 180f, 0f);
        }

        if (TaNoChão == true)
        {
            Anim.SetBool("jump", false);

        }
        else if(TaNoChão == false){
            Anim.SetBool("jump",true);
        }
        if (Time.time - LastAttackTime > ComboDelay)
        {
            AttackCounter = 0;

        }

        if (Input.GetMouseButtonDown(0))
        {
            LastAttackTime = Time.time;
            AttackCounter++;
            if (AttackCounter > 3)
            {
                AttackCounter = 0;
            }
            Anim.SetTrigger("Attack" + AttackCounter);
        }

    }

   
}