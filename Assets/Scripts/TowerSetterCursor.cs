using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSetterCursor : MonoBehaviour{
    public int SelectedTurretIndex = 0;
    public List<GameObject> PlaceableTurrets;
    public List<GameObject> Holograms;

    void Update(){
        TowerSelection();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);

        if (Physics.Raycast(ray, out hit,40,LayerMask.GetMask("Default"))){
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
            SwapToTurret(0);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame){
            SwapToTurret(1);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame){
            SwapToTurret(2);
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame){
            SwapToTurret(3);
        }

        if (Keyboard.current.digit5Key.wasPressedThisFrame){
            SwapToTurret(4);
        }

        if (Keyboard.current.digit6Key.wasPressedThisFrame){
            SwapToTurret(5);
        }

        if (Keyboard.current.digit7Key.wasPressedThisFrame){
            SwapToTurret(6);
        }

        if (Keyboard.current.digit8Key.wasPressedThisFrame){
            SwapToTurret(7);
        }

        if (Keyboard.current.digit9Key.wasPressedThisFrame){
            SwapToTurret(8);
        }

        SelectedTurretIndex %= PlaceableTurrets.Count;
    }

    private void SwapToTurret(int index){
        Holograms[SelectedTurretIndex].SetActive(false);
        SelectedTurretIndex = index;
        Holograms[SelectedTurretIndex].SetActive(true);
    }

    private void AttemptPlacingTower(Transform objectHit){
        if (!_fundsCheck()){
            return; //Es hat an Geld gefehlt. Hier könnte ein Sound abspielen :)
        }

       
        var socket = objectHit.GetComponent<TowerSocket>();
        if (socket){
            if (!socket.HeldTower){
                socket.HeldTower = Instantiate(PlaceableTurrets[SelectedTurretIndex], socket.transform.position,
                    Quaternion.identity);
                int cost = socket.HeldTower.GetComponent<Tower>().Stats.Price;
                Bank.SpendMoney.Invoke(cost);
            }
            else{
                Debug.Log("Tower placement failed because socket is occupied.");
            }
        }
    }

    private bool _fundsCheck(){
        int currentBalance = Bank.Instance.Balance;
        int cost = PlaceableTurrets[SelectedTurretIndex].GetComponent<Tower>().Stats.Price;
        return currentBalance >= cost;
        /* ^Das ist die stark verkürzte Version von:
        if (currentBalance >= cost){
            return true;
        }
        else{
            return false;
        }
        */
    }
}