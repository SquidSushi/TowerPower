using System;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public EnemyPathNode Target;

    public float Speed;
    public float TurnSpeed = 1080;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Target != null){
            transform.LookAt(Target.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) return;
        Vector3 directionToTarget = Target.transform.position - transform.position;
        directionToTarget.Normalize();
        float rightDot = Vector3.Dot(transform.right,directionToTarget);
        if (Mathf.Abs(rightDot)<0.05f){
            transform.LookAt(Target.transform.position);
        }
        else{
            float sign = rightDot > 0 ? 1 : -1;
            transform.Rotate(0,sign * TurnSpeed * Time.deltaTime,0);
        }
        transform.Translate(Vector3.forward * (Speed * Time.deltaTime)); //Vorwärts bewegen
        if (Vector3.Distance(transform.position, Target.transform.position) <= 0.1f){
            // Wenn wir grob auf dem Ziel sind:
            if (Target.IsEnd){
                Destroy(gameObject);
                // TODO Event callen
            }
            else{
                Target = Target.Next; // Ändere das Ziel auf das nächste
                //transform.LookAt(Target.transform.position); // Drehe zum nächsten Ziel
            }
        }
        // Prüfen ob wir am Ziel vorbei sind UND nah dran:
        float fwDot = Vector3.Dot(transform.forward, directionToTarget);
        if (Vector3.Distance(transform.position, Target.transform.position) < 1 && fwDot < 0){
            if (Target.IsEnd){
                Destroy(gameObject);
                // TODO Event callen
            }
            else{
                Target = Target.Next; // Ändere das Ziel auf das nächste
                //transform.LookAt(Target.transform.position); // Drehe zum nächsten Ziel
            }
        }
    }
}
