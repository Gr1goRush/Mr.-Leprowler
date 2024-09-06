using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ResolutionsBasedSpacing : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    [SerializeField] private int _spacingOnIphone;
    [SerializeField] private int _spacingOnIpad;

    private readonly int _maxMobileScreebWidth = 1350;

    private void OnValidate()
    {
        gridLayoutGroup ??= GetComponent<GridLayoutGroup>();
    }

    

    void Start()
    {
        UpdateSpacing();
    }

    void UpdateSpacing()
    {
        if (gridLayoutGroup == null)
        {
            Debug.LogError("GridLayoutGroup не присвоен!");
            return;
        }
       
        if (Screen.currentResolution.width < _maxMobileScreebWidth)
        {
            gridLayoutGroup.spacing = new Vector2(_spacingOnIphone, 0);
        }
        else
        {
            gridLayoutGroup.spacing = new Vector2(_spacingOnIpad, 0);
        }
    }
}
