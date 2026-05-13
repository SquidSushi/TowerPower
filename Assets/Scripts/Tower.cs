using UnityEngine;

public class Tower : MonoBehaviour{
    // TODO Zum gegner drehen
    // TODO Schießen (Projektile Spawnen)
    // TODO Priority
    // TODO Werte wie Stärke, Schussrate, Reichweite etc.

    public float Range;

    public float FireRate;

    [SerializeField] private float _attackCooldown;

    public GameObject Projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){ }

    // Update is called once per frame
    void Update(){
        var CollidersInRange = Physics.OverlapSphere(transform.position, Range);
        Enemy target;
        foreach (var collider in CollidersInRange){
            Enemy componentOfTarget = collider.GetComponent<Enemy>();
            if (componentOfTarget != null){
                target = componentOfTarget;
                Shoot(target);
                break;
            }
        }
    }

    private void Shoot(Enemy target){
        var newPojectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        newPojectile.transform.LookAt(target.transform.position);
        
    }
}