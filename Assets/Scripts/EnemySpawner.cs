using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour{
    public List<Wave> Waves;
    private float _nextSpawnTime;
    public EnemyPathNode FirstNode;
    private bool _waveIsRunning = false;
    public int CurrentWave{ get; private set; } = 0;
    public static UnityEvent<int> WaveStarted = new();
    public static UnityEvent<int> WaveFinished = new();

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
        if (_waveIsRunning || Waves.Count <= 0) return;
        _waveIsRunning = true;
        _nextSpawnTime = Time.time;
        CurrentWave++;
        WaveStarted.Invoke(CurrentWave);
    }

    // Update is called once per frame
    void Update(){
        if (_waveIsRunning){ // Wenn eine Wave am laufen ist:
            if (_nextSpawnTime < Time.time && !Waves[0].IsEmpty()){ // Wenn der Zeitpunkt vergangen ist UND Wave noch etwas zum spawnen hat
                var newestEnemy =
                    Instantiate(Waves[0].GetTopMostEnemy(), transform.position,
                        Quaternion.identity); // Spawne den neusten Enemy
                _nextSpawnTime += Waves[0].GetTopmostDelay(); // Erhöhe den Zeitstempel um den Spawn-Versatz
                Waves[0].Pop(); // Entferne den höchsten eintrag der Wave
                newestEnemy.GetComponent<Enemy>().Target = FirstNode; // Gebe dem gespawnten Gegner sein erstes Ziel.
            }
            else{
                if (Waves[0].IsEmpty()){
                    // Finde, ob Gegner noch leben.
                    var anyEnemy = GameObject.FindAnyObjectByType<Enemy>();
                    if (anyEnemy == null){ //wenn nicht
                        _waveIsRunning = false; //Der Aktivitätsstatus geht aus
                        Bank.AddMoney.Invoke(Waves[0].Reward); // Geld wird ausgezahlt
                        Waves.RemoveAt(0); // Wave wird entfernt
                        WaveFinished.Invoke(CurrentWave);
                    }
                }
            }
        }
    }
}