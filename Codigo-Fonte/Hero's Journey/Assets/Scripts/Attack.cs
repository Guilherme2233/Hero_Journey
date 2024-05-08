using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private Transform PointAttack;

    [SerializeField]
    private float AreaAttack;

    [SerializeField]
    private LayerMask LayerEnemy;



    void Update()
    {
        Atacar();
    }

    private void OnDrawGizmos()
    {
        if (PointAttack != null)
        {
            Gizmos.DrawWireSphere(this.PointAttack.position, this.AreaAttack);


        }

    }
    private void Atacar()
    {
        if (Input.GetMouseButtonDown(0)){
        Collider2D [] EnemiesHit = Physics2D.OverlapCircleAll(PointAttack.position, AreaAttack, LayerEnemy);
        if (EnemiesHit != null)
        {
            foreach (Collider2D Hit in EnemiesHit)
            {
                Debug.Log("atacando inimigo" + Hit.name);
                if (Hit.TryGetComponent<EnemiesLogic>(out var Inimigo))
                {
                    Inimigo.ReceberDano();
                }
            }

        }
    }

}
}