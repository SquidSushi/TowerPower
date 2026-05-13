using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject EnemyPrefab; //TODO Mehrere Prefabs
    // Todo Waves
    private float _nextSpawnTime;
    public EnemyPathNode FirstNode;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        _nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextSpawnTime <= Time.time){ // Wenn der nächste Spawn-Zeitpunkt vergangen ist:
            _nextSpawnTime = Time.time + 2f;
            var newSpawn = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            newSpawn.GetComponent<Enemy>().Target = FirstNode;
        }
    }
}
