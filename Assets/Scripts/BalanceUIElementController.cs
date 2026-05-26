using TMPro;
using UnityEngine;

public class BalanceUIElementController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bank.AddMoney.AddListener(UpdateBalance);
        Bank.SpendMoney.AddListener(UpdateBalance);
    }

    void UpdateBalance(int x){
        var money = Bank.Instance.Balance;
        var tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = money.ToString();
    }
}
