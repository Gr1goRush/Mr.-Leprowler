using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PurchaseButton : MonoBehaviour
{
    [SerializeField] protected string _buttonID;
    [SerializeField] protected int _itemCost;
    [SerializeField] public Text _costText;
    private bool _isPurchased;
    public bool IsPurchased => _isPurchased;

    public virtual void Start()
    {
        UpdateInfo();
        _costText.text = _itemCost.ToString();
    }

    public void UpdateInfo()
    {
        _isPurchased = PlayerPrefs.GetInt(FormattToPurchaseData(_buttonID)) == 1;
        if (IsPurchased) { _costText.gameObject.SetActive(false); }
    }

    public virtual void Interact()
    {
        if (!_isPurchased)
        {
            if (PlayerBalance.TryPurchase(_itemCost))
            {
                Unlock();
                UpdateInfo();
                OnPurchaseInvoke();
            }
        }
        else
        {
            OnPurchasedInvoke();

        }
    }

    public virtual void OnPurchasedInvoke() { Debug.Log("BaseCall"); }
    public virtual void OnPurchaseInvoke() { Debug.Log("BaseCall"); }

    public string FormattToPurchaseData(string ButtonID)
    {
        return $"{ButtonID}PurData";
    }

    public void Unlock()
    {
        PlayerPrefs.SetInt(FormattToPurchaseData(_buttonID), 1);
        _isPurchased = true;
        
    }

}
