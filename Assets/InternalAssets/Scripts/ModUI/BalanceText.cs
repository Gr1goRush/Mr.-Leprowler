using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BalanceText : MonoBehaviour
{
    [SerializeField, HideInInspector] private Text balanceText;

    private void OnValidate()
    {
        balanceText ??= GetComponent<Text>();
    }

    private void OnEnable()
    {
        PlayerBalance.OnBalanceChange += UpdateView;
    }

    private void OnDisable()
    {
        PlayerBalance.OnBalanceChange -= UpdateView;
    }

    private void Start()
    {
        balanceText.text = PlayerBalance.ChachedMoney.ToString();
    }

    public void UpdateView(int newBalance)
    {
        balanceText.text = newBalance.ToString();
    }
}
