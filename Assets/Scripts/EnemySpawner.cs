using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public List<Wave> Waves;
    private float _nextSpawnTime;
    public EnemyPathNode FirstNode;
    private bool _waveIsRunning = false;

    // Todo: WaveCounter hinzufügen
    // Todo: Setze _waveIsRunning false, sobald die Wave zu ende ist. Hinweis: ihr werdet auch die Wave Klasse bearbeiten müssen.
    // Todo: Nach der ersten Wave wird dann die zweite erscheinen, sobald wir noch mal "StartWave" aufrufen (Knopf gedrückt)
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        for (int i = 0; i < Waves.Count; i++){
            Waves[i] = Instantiate(Waves[i]); // Wir erstellen Kopien der SOs, um nicht das original zu überschreiben.
        }
    }

    [ContextMenu("Start wave")] // Erlaubt es aus dem Unity Editor heraus diese Funktion aufzurufen.
    public void StartWave(){
        _waveIsRunning = true;
        _nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update(){
        if (_waveIsRunning){ // Wenn eine Wave am laufen ist:
            if (_nextSpawnTime < Time.time && !Waves[0].IsEmpty()){ // Wenn der Zeitpunkt vergangen ist
                var newestEnemy =
                    Instantiate(Waves[0].GetTopMostEnemy(), transform.position,
                        Quaternion.identity); // Spawne den neusten Enemy
                _nextSpawnTime += Waves[0].GetTopmostDelay(); // Erhöhe den Zeitstempel um den Spawn-Versatz
                Waves[0].Pop(); // Entferne den höchsten eintrag der Wave
                newestEnemy.GetComponent<Enemy>().Target = FirstNode; // Gebe dem gespawnten Gegner sein erstes Ziel.
            }
            else{
                if (Waves[0].IsEmpty()){
                    // Finde raus wie viele Gegner noch leben.
                    var anyEnemy = GameObject.FindAnyObjectByType<Enemy>();
                    if (anyEnemy == null){
                        _waveIsRunning = false;
                        Bank.AddMoney.Invoke(Waves[0].Reward);
                        Waves.RemoveAt(0);
                    }
                }
            }
        }
    }
}