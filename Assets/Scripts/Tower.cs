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
            var target = AcquireFirstTarget();
            if (target){ //Implizierter null check
                transform.LookAt(target.transform.position);
                Shoot(target); 
                
            }
            else{
                _attackCooldown += 0.1f; 
                // Als Optimierungsmaßnahme prüft ein einzelner Turm nur maximal 10 Mal die Sekunde nach Zielen,
                // wenn zuvor keines gefunden wurde. 
            }
        }
    }

    private Enemy AcquireFirstTarget(){
        // Todo: Mit Layern Kollisionserkennung optimieren.
        var collidersInRange = Physics.OverlapSphere(transform.position, Range);
        Enemy targetCandidate = null;
        // Erstmal suchen wir den nächstbesten Enemy
        foreach (var collider in collidersInRange){
            if (collider.GetComponent<Enemy>() != null){
                targetCandidate = collider.GetComponent<Enemy>();
                break;
            }
        }
        // Wenn kein Ziel gefunden wurde, gebe null zurück um die Funktion früh abzubrechen.
        if (targetCandidate == null) return targetCandidate;
        // Ab jetzt ist targetCandidate garantiert definiert.
        // Jetzt vergleichen wir, welches der beste Kandidat ist.
        foreach (var collider in collidersInRange){
            Enemy componentOfTarget = collider.GetComponent<Enemy>();
            if (componentOfTarget != null){
                if (componentOfTarget.DistanceTravelled > targetCandidate.DistanceTravelled){
                    // Wenn der betrachtete Gegner weiter gereist wird, wird dieser zum neuen Kandidaten.
                    targetCandidate = componentOfTarget;
                }
            }
        }
        // AB JETZT ist unser Kandidat optimal
        return targetCandidate;
    }

    private void Shoot(Enemy target){
        var newProjectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        var projectilePosition = newProjectile.transform.position;
        projectilePosition.y = target.transform.position.y;
        newProjectile.transform.position = projectilePosition;
        newProjectile.transform.LookAt(target.transform.position);
        _attackCooldown = 1 / Mathf.Max(FireRate, 0.001f);
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}