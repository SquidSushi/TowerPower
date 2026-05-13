using UnityEngine;

public class TowerProjectile : MonoBehaviour{
    public float Speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,Speed * Time.deltaTime);
    }
}
