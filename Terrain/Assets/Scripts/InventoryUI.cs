using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using   TMPro;
public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        coinText.text = playerInventory.NumberOfCoins.ToString();
    }
}
