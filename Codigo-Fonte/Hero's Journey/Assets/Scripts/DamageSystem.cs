using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSystem : MonoBehaviour

{
    public HeartSystem Heart;
    public Player player;
    public EnemiesLogic VidasEnemy;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (VidasEnemy.Vidas > 0){

            player.KbCount = player.KbTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player.IsKnockRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                player.IsKnockRight = false;
            }

            Heart.Life--;
            player.Anim.SetTrigger("TakingDamage");

        }
    }


}
}