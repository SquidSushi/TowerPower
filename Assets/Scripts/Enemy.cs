using UnityEngine;

public class Enemy : MonoBehaviour{
    public EnemyPathNode Target;

    public float Speed;
    
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
        transform.Translate(Vector3.forward * (Speed * Time.deltaTime)); //Vorwärts bewegen
        if (Vector3.Distance(transform.position, Target.transform.position) <= 0.1f){
            // Wenn wir grob auf dem Ziel sind:
            if (Target.IsEnd){
                Destroy(gameObject);
                // TODO Event callen
            }
            else{
                Target = Target.Next; // Ändere das Ziel auf das nächste
                transform.LookAt(Target.transform.position); // Drehe zum nächsten Ziel
            }
        }
    }
}
