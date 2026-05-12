using System;
using UnityEngine;

public class EnemyPathNode : MonoBehaviour{
    public EnemyPathNode Next;
    public bool IsEnd;

    private void OnDrawGizmos(){
        Gizmos.color = Color.cornflowerBlue;
        Gizmos.DrawWireSphere(transform.position,0.5f);
        if(Next!=null){
            Gizmos.DrawLine(transform.position, Next.transform.position);
        }
    }
}
