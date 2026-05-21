using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSetterCursor : MonoBehaviour{
    public int SelectedTurretIndex = 0;
    public List<GameObject> PlaceableTurrets;

    void Update(){
        TowerSelection();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);

        if (Physics.Raycast(ray, out hit)){
            Transform objectHit = hit.transform;

            float lerpFactor = 40;
            transform.position = Vector3.Lerp(transform.position, objectHit.position, Time.deltaTime * lerpFactor);
            if (Mouse.current.leftButton.wasPressedThisFrame){
                AttemptPlacingTower(objectHit);
            }
        }
    }

    private void TowerSelection(){
        if (Keyboard.current.digit1Key.wasPressedThisFrame){
            SelectedTurretIndex = 0;
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame){
            SelectedTurretIndex = 1;
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame){
            SelectedTurretIndex = 2;
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame){
            SelectedTurretIndex = 3;
        }

        if (Keyboard.current.digit5Key.wasPressedThisFrame){
            SelectedTurretIndex = 4;
        }

        if (Keyboard.current.digit6Key.wasPressedThisFrame){
            SelectedTurretIndex = 5;
        }

        if (Keyboard.current.digit7Key.wasPressedThisFrame){
            SelectedTurretIndex = 6;
        }

        if (Keyboard.current.digit8Key.wasPressedThisFrame){
            SelectedTurretIndex = 7;
        }

        if (Keyboard.current.digit9Key.wasPressedThisFrame){
            SelectedTurretIndex = 8;
        }

        SelectedTurretIndex %= PlaceableTurrets.Count;
    }

    private void AttemptPlacingTower(Transform objectHit){
        var socket = objectHit.GetComponent<TowerSocket>();
        if (socket){
            if (!socket.HeldTower){
                socket.HeldTower = Instantiate(PlaceableTurrets[SelectedTurretIndex], socket.transform.position,
                    Quaternion.identity);
            }
            else{
                Debug.Log("Tower placement failed because socket is occupied.");
            }
        }
    }
}