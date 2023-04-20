using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin coin;

    private void Awake()
    {
        coin = this;
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }

}
