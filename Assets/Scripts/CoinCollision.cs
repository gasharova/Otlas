using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollision : MonoBehaviour
{
    private float coin = 0;
    public TextMeshProUGUI textCoins;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag=="Coin")
        {
            coin++;
            textCoins.text = coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
