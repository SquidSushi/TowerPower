using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour{
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
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown <= 0){ //Wir dürfen schießen.
            var CollidersInRange = Physics.OverlapSphere(transform.position, Range);
            Enemy targetCandidate = null;
            // Erstmal suchen wir den nächstbesten Enemy
            foreach (var collider in CollidersInRange){
                if (collider.GetComponent<Enemy>() != null){
                    targetCandidate = collider.GetComponent<Enemy>();
                    break;
                }
            }
            if (targetCandidate != null){ // Wenn überhaupt einer gefunden wurde:
                // Jetzt vergleichen wir, welches der beste Kandidat ist.
                foreach (var collider in CollidersInRange){
                    Enemy componentOfTarget = collider.GetComponent<Enemy>();
                    if (componentOfTarget != null){
                        if (componentOfTarget.DistanceTravelled > targetCandidate.DistanceTravelled){
                            // Wenn der betrachtete Gegner weiter gereist wird, wird dieser zum neuen Kandidaten.
                            targetCandidate = componentOfTarget;
                        }
                    }
                }
                // AB JETZT ist unser Kandidat optimal
                transform.LookAt(targetCandidate.transform.position);
                Shoot(targetCandidate);
            }
            
        }
    }

    private void Shoot(Enemy target){
        var newProjectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        var projectilePosition = newProjectile.transform.position;
        projectilePosition.y = target.transform.position.y;
        newProjectile.transform.position = projectilePosition;
        newProjectile.transform.LookAt(target.transform.position);
        _attackCooldown = 1 / Mathf.Max(FireRate,0.001f);
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}