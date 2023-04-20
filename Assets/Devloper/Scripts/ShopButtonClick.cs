using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonClick : MonoBehaviour
{
    public int temp;
    public static ShopButtonClick shopbtn;
    private void Start()
    {
        shopbtn = this;                    
    }
    public void ButtonClickFunction()
    {
        GameManager.gameManager.ShopPurchaseButtonClick(temp);
    }
}
