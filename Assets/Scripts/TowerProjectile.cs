using System;
using UnityEngine;

public class TowerProjectile : MonoBehaviour{
    public float Speed = 5;

    public float RemainingLifeTime;
    void Update(){
        LifeTimeHandling();

        float distanceThisFrame = Speed * Time.deltaTime;

        bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distanceThisFrame + Single.Epsilon, LayerMask.GetMask("Enemies"));
        if (hasHit){
            Destroy(gameObject);
            // Todo deal damage to enemy;
        }
        
        transform.Translate(0,0,distanceThisFrame);
    }

    private void LifeTimeHandling(){
        if (RemainingLifeTime <= 0){
            Destroy(gameObject);
        }

        RemainingLifeTime -= Time.deltaTime;
    }
}
