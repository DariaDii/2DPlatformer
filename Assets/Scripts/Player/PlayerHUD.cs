using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _wallet.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(float currentCoinAmount)
    {
        _text.text = currentCoinAmount.ToString();
    }
}