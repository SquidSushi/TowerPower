using System;
using UnityEngine;

/*
 * Auf technischer Ebene sind structs zu großen Teilen exakt wie Klassen
 * Der größte technische Unterschied ist, dass structs als value-type instanziiert werden anstatt als reference-type
 * Ansonsten haben sie Zugriff auf Methoden aber keine Vererbung. Sie können allerdings Interfaces implementieren.
 * Wir nutzen typischerweise structs für pure, kleine Datenmengen.
 */
[Serializable]
public struct WaveBatch{ 
    public GameObject EnemyType;
    public int Amount;
    public float DelayPerEnemy;
    public float EndDelay;
}
