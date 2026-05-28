using TMPro;
using UnityEngine;

public class BalanceUIElementController : MonoBehaviour{
    void Start(){
        Bank.MoneyChanged.AddListener(UpdateBalance);
        if (Bank.Instance != null){
            UpdateBalance(Bank.Instance.Balance);
        }
    }

    void UpdateBalance(int newBalance){
        GetComponent<TextMeshProUGUI>().text = newBalance.ToString();
    }
}