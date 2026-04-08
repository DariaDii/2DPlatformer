using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> DestroyCoin;

    private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Wallet>(out _wallet))
        {
            DestroyCoin?.Invoke(this);
            _wallet.AddCoin();
        }
    }
}