using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeCoin : MonoBehaviour
{
    public static FirstTimeCoin firstTimeCoin;
    public GameObject[] CoinFirst, CoinSecound, CoinThird, CoinFour, CoinFive;
    public bool ISFirst, IsSecound, IsThird, IsFourth, IsFive;
    public const string FirstPlayPref = "FirstTimeCoinFirst", SecoundPlayPref = "FirstTimeCoinSecound", ThirdPlayPref = "FirstTimeCoinThird", FourPlayPref = "FirstTimeCoinFourth", FivePlatPref = "FirstTimeCoinFive";
    private void Awake()
    {
        firstTimeCoin = this;
        if (PlayerPrefs.GetInt(FirstPlayPref) == 1)
        {
            ISFirst = true;
        }
        if (PlayerPrefs.GetInt(SecoundPlayPref) == 1)
        {
            IsSecound = true;
        }
        if (PlayerPrefs.GetInt(ThirdPlayPref) == 1)
        {
            IsThird = true;
        }
        if (PlayerPrefs.GetInt(FourPlayPref) == 1)
        {
            IsFourth = true;
        }
        if (PlayerPrefs.GetInt(FivePlatPref) == 1)
        {
            IsFive = true;
        }
    }
    private void OnEnable()
    {
        if (ISFirst)
        {
            for (int i = 0; i < CoinFirst.Length; i++)
            {
                CoinFirst[i].SetActive(false);
            }            
        }
        if (IsSecound)
        {
            for (int i = 0; i < CoinSecound.Length; i++)
            {
                CoinSecound[i].SetActive(false);
            }
        }
        if (IsThird)
        {
            for (int i = 0; i < CoinThird.Length; i++)
            {
                CoinThird[i].SetActive(false);
            }
        }
        if (IsFourth)
        {
            for (int i = 0; i < CoinFour.Length; i++)
            {
                CoinFour[i].SetActive(false);
            }
        }
        if (IsFive)
        {
            for (int i = 0; i < CoinFive.Length; i++)
            {
                CoinFive[i].SetActive(false);
            }
        }
    }
}
