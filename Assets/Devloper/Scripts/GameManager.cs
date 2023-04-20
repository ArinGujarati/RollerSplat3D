using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Gamne Win Loss Code And GamePanneld
    public static GameManager gameManager;
    public GameObject Player;
    public GameObject[] LevelPrefab;
    public GameObject[] Pannels;
    public GameObject TempLevelGameObjectDestroy, TempPlayerGamenObjectDestroy;
    public int AllRoad, TriggerRoad;
    public int LevelClick, templevel, LevelSelected;
    public Button[] LevelButton;
    public TMP_Text LevelRunText, WinLevelTextOutPut, WinCoinOutPut;
    public Toggle MusicToggle, SoundToggle;
    public AudioSource MusicAudio, SoundAudio;
    public AudioClip[] audioClips;
    public Transform coinfinalanimationpos;
    public TMP_Text ToggelTextMusic, ToggleTextSound;
    Vector3 tempplayerpos;
    public GameObject ParticalWin;
    private void Awake()
    {
        ParticalWin.SetActive(false);
        gameManager = this;
        FirstStartPannel();
        MusicAndSoundStartCallFun();

        LevelClick = PlayerPrefs.GetInt("Level");
    }
    private void Update()
    {
        LevelRunText.text = "Level : " + templevel;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            // PlayerPrefs.DeleteAll();
        }
    }

    public void FirstStartPannel()
    {
        for (int i = 0; i < Pannels.Length; i++)
        {
            if (i == 0)
            {
                Pannels[i].SetActive(true);
            }
            else
            {
                Pannels[i].SetActive(false);
            }
        }
    }
    public void GamePlayPannel(int level)
    {
        for (int i = 0; i < Pannels.Length; i++)
        {
            if (i == 3)
            {
                Pannels[i].SetActive(true);
            }
            else
            {
                Pannels[i].SetActive(false);
            }
        }
    }
    public void ButtonClick(string name)
    {
        switch (name)
        {
            case "ReloadGame":
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene(0);
                break;
            case "PlayClick":
                for (int i = 0; i < Pannels.Length; i++)
                {
                    if (i == 2)
                    {
                        Pannels[i].SetActive(true);
                    }
                    else
                    {
                        Pannels[i].SetActive(false);
                    }
                }
                break;
            case "SettingClick":
                for (int i = 0; i < Pannels.Length; i++)
                {
                    if (i == 0)
                    {
                        Pannels[i].SetActive(true);
                    }
                    else if (i == 1)
                    {
                        Pannels[i].SetActive(true);
                    }
                    else
                    {
                        Pannels[i].SetActive(false);
                    }
                }
                break;
            case "Settingback":
                FirstStartPannel();
                break;
            case "ShopClick":
                for (int i = 0; i < Pannels.Length; i++)
                {
                    if (i == 5)
                    {
                        Pannels[i].SetActive(true);
                    }
                    else
                    {
                        Pannels[i].SetActive(false);
                    }
                }
                break;
            case "Shopback":
                FirstStartPannel();
                break;
            case "LevelBack":
                FirstStartPannel();
                break;
            case "Gameplayback":
                Destroy(TempLevelGameObjectDestroy);
                Destroy(TempPlayerGamenObjectDestroy);
                for (int i = 0; i < Pannels.Length; i++)
                {
                    if (i == 2)
                    {
                        Pannels[i].SetActive(true);
                    }
                    else
                    {
                        Pannels[i].SetActive(false);
                    }
                }
                break;
            case "WinHome":
                Destroy(TempLevelGameObjectDestroy);
                Destroy(TempPlayerGamenObjectDestroy);
                SceneManager.LoadScene("RollerSpalt");
                break;
            case "WinRetry":
                Destroy(TempLevelGameObjectDestroy);
                Destroy(TempPlayerGamenObjectDestroy);
                LevelButtonClick(templevel);
                for (int i = 0; i < Pannels.Length; i++)
                {
                    if (i == 3)
                    {
                        Pannels[i].SetActive(true);
                    }
                    else
                    {
                        Pannels[i].SetActive(false);
                    }
                }
                break;
            case "WinNextLevel":
                Destroy(TempLevelGameObjectDestroy);
                Destroy(TempPlayerGamenObjectDestroy);
                #region TempLevel
                PlayerPrefs.SetInt("tempLevel", templevel + 1);
                templevel = PlayerPrefs.GetInt("tempLevel");

                if (templevel == 6)
                {
                    templevel = 1;
                }
                #endregion
                for (int i = 0; i < Pannels.Length; i++)
                {
                    if (i == 3)
                    {
                        Pannels[i].SetActive(true);
                    }
                    else
                    {
                        Pannels[i].SetActive(false);
                    }
                }
                LevelButtonClick(templevel);
                break;

        }
    }
    public void LevelButtonClick(int number)
    {
        switch (number)
        {         
            case 1:

                GamePlayPannel(number);
                LevelSelected = number;
                TriggerRoad = 0;
                templevel = number;
                TempLevelGameObjectDestroy = Instantiate(LevelPrefab[0]);
                tempplayerpos = TempLevelGameObjectDestroy.transform.GetChild(0).transform.position;
                TempPlayerGamenObjectDestroy = Instantiate(Player);
                TempPlayerGamenObjectDestroy.transform.SetParent(Pannels[3].transform);
                TempPlayerGamenObjectDestroy.transform.localScale = new Vector3(58, 58, 58);
                TempPlayerGamenObjectDestroy.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);               
                for (int i = 0; i < PlayerTrialEffect.Length; i++)
                {
                    PlayerTrialEffect[i] = TempPlayerGamenObjectDestroy.transform.GetChild(i).gameObject;
                }
                
                AllRoad = GameObject.FindGameObjectsWithTag("Road").Length;
                break;
            case 2:
                GamePlayPannel(number);
                LevelSelected = number;
                TriggerRoad = 0;
                templevel = number;
                TempLevelGameObjectDestroy = Instantiate(LevelPrefab[1]);
                tempplayerpos = TempLevelGameObjectDestroy.transform.GetChild(0).transform.position;
                TempPlayerGamenObjectDestroy = Instantiate(Player);
                TempPlayerGamenObjectDestroy.transform.SetParent(Pannels[3].transform);
                TempPlayerGamenObjectDestroy.transform.localScale = new Vector3(58, 58, 58);
                TempPlayerGamenObjectDestroy.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                for (int i = 0; i < PlayerTrialEffect.Length; i++)
                {
                    PlayerTrialEffect[i] = TempPlayerGamenObjectDestroy.transform.GetChild(i).gameObject;
                }
                
                Player.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                AllRoad = GameObject.FindGameObjectsWithTag("Road").Length;
                break;
            case 3:
                GamePlayPannel(number);
                TriggerRoad = 0;
                LevelSelected = number;
                templevel = number;
                TempLevelGameObjectDestroy = Instantiate(LevelPrefab[2]);
                tempplayerpos = TempLevelGameObjectDestroy.transform.GetChild(0).transform.position;
                TempPlayerGamenObjectDestroy = Instantiate(Player);
                TempPlayerGamenObjectDestroy.transform.SetParent(Pannels[3].transform);
                TempPlayerGamenObjectDestroy.transform.localScale = new Vector3(58, 58, 58);
                TempPlayerGamenObjectDestroy.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                for (int i = 0; i < PlayerTrialEffect.Length; i++)
                {
                    PlayerTrialEffect[i] = TempPlayerGamenObjectDestroy.transform.GetChild(i).gameObject;
                }
              
                Player.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                AllRoad = GameObject.FindGameObjectsWithTag("Road").Length;
                break;
            case 4:
                GamePlayPannel(number);
                LevelSelected = number;
                templevel = number;
                TempLevelGameObjectDestroy = Instantiate(LevelPrefab[3]);
                tempplayerpos = TempLevelGameObjectDestroy.transform.GetChild(0).transform.position;
                TempPlayerGamenObjectDestroy = Instantiate(Player);
                TempPlayerGamenObjectDestroy.transform.SetParent(Pannels[3].transform);
                TempPlayerGamenObjectDestroy.transform.localScale = new Vector3(58, 58, 58);
                TempPlayerGamenObjectDestroy.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                for (int i = 0; i < PlayerTrialEffect.Length; i++)
                {
                    PlayerTrialEffect[i] = TempPlayerGamenObjectDestroy.transform.GetChild(i).gameObject;
                }
               
                Player.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                AllRoad = GameObject.FindGameObjectsWithTag("Road").Length;
                break;
            case 5:
                GamePlayPannel(number);
                LevelSelected = number;
                templevel = number;
                TempLevelGameObjectDestroy = Instantiate(LevelPrefab[4]);
                tempplayerpos = TempLevelGameObjectDestroy.transform.GetChild(0).transform.position;
                TempPlayerGamenObjectDestroy = Instantiate(Player);
                TempPlayerGamenObjectDestroy.transform.SetParent(Pannels[3].transform);
                TempPlayerGamenObjectDestroy.transform.localScale = new Vector3(58, 58, 58);
                TempPlayerGamenObjectDestroy.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                for (int i = 0; i < PlayerTrialEffect.Length; i++)
                {
                    PlayerTrialEffect[i] = TempPlayerGamenObjectDestroy.transform.GetChild(i).gameObject;
                }                
                Player.transform.position = new Vector3(tempplayerpos.x, tempplayerpos.y + 0.5f, tempplayerpos.z);
                AllRoad = GameObject.FindGameObjectsWithTag("Road").Length;
                break;
        }
    }
    public void GameWin()
    {
        Invoke("ParticalOff", 0.6f);
        Destroy(TempLevelGameObjectDestroy);
        #region LevelButton
        if (LevelSelected > LevelClick)
        {
            PlayerPrefs.SetInt("Level", LevelClick + 1);
            LevelClick = PlayerPrefs.GetInt("Level");
            if (LevelClick >= 6)
            {
                LevelClick = 5;
            }
            if (PlayerPrefs.GetInt("Level") == 6)
            {
                PlayerPrefs.SetInt("Level", 5);
            }
        }
        #endregion
        for (int i = 0; i < Pannels.Length; i++)
        {
            if (i == 4)
            {
                Pannels[i].SetActive(true);
            }
            else
            {
                Pannels[i].SetActive(false);
            }
        }
        WinLevelTextOutPut.text = "Level : " + templevel + " Completed...";
        WinCoinOutPut.text = "You Win Coin : " + GamePlayTouch + "\n" + "Total Coin Is : " + TotalCoin;
    }
    void ParticalOff()
    {
        ParticalWin.SetActive(false);
    }
    #endregion
    #region GameShop    
    public GameObject[] PlayerTrialEffect;
    public Material PlayerTrail, DefualtTrail;
    public int TotalCoin, GamePlayTouch, gametempsavetotal;
    public TMP_Text ShopMenuCoinText, PlayMenuCoinText;
    public Material[] ShopMaterial;


    public GameObject ParentOfPurchaseObject, StoreGameObject;
    public GameObject PurchaseObjectInstantiate;
    public Sprite[] sprites;
    public Material[] materials;
    public List<Button> buttons = new List<Button>();
    GameObject TempInstantiate;
    int temp;
    float FontSizeslected = 35;
    public const string SelecrtedBalltheam = "SelectedBallTheam";
    public void Start()
    {
        if (!PlayerPrefs.HasKey("1"))
        {
            PlayerPrefs.SetInt("1", 1);
            Player.GetComponent<MeshRenderer>().material = materials[0];

        }
        else
        {
            PlayerPrefs.GetInt("1");
        }
        if (!PlayerPrefs.HasKey(SelecrtedBalltheam))
        {
            PlayerPrefs.SetInt(SelecrtedBalltheam, 1);
        }
        else
        {
            PlayerPrefs.GetInt(SelecrtedBalltheam);
        }
        TotalCoin = PlayerPrefs.GetInt("TotalCoin");
        ShopMenuCoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
        for (int i = 0; i < 6; i++)
        {
            TempInstantiate = Instantiate(PurchaseObjectInstantiate, ParentOfPurchaseObject.transform);
            int tempi = i + 1;
            TempInstantiate.gameObject.name = tempi.ToString();
            TempInstantiate.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = sprites[i];
            temp += 100;
            TempInstantiate.transform.GetChild(0).GetComponent<TMP_Text>().text = "Price : " + temp;
            buttons.Add(TempInstantiate.transform.GetChild(1).GetComponent<Button>());
            TempInstantiate.transform.GetChild(1).GetComponent<Button>().GetComponent<ShopButtonClick>().temp = tempi;
        }
        StartFunctionCallForTestYouBuy();
        SeletedBallTheam();

    }
    public void GamePlayCoinTouch()
    {
        gametempsavetotal = 100;
        GamePlayTouch = GamePlayTouch + 100;
        PlayMenuCoinText.text = GamePlayTouch.ToString();
        TotalCoin += gametempsavetotal;
        PlayerPrefs.SetInt("TotalCoin", TotalCoin);
        ShopMenuCoinText.text = TotalCoin.ToString();
    }
    public void GamePlayCoinZero()
    {
        GamePlayTouch = 0;
        PlayMenuCoinText.text = GamePlayTouch.ToString();
    }
    int pannelshakeinn = 10;
    public void ShopPurchaseButtonClick(int number)
    {
        switch (number)
        {
            case 1:
                if (TotalCoin >= 200 && PlayerPrefs.GetInt("1") == 1)
                {
                    PlayerPrefs.SetInt("1", 1);
                    TotalCoin = TotalCoin - 100;
                    PlayerPrefs.SetInt("TotalCoin", TotalCoin);
                    ShopMenuCoinText.text = TotalCoin.ToString();
                    buttons[number - 1].GetComponent<Image>().color = Color.black;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selecte";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt(SelecrtedBalltheam, number);                    
                    SceneManager.LoadScene(0);
                }
                else if (PlayerPrefs.GetInt("1") == 1)
                {
                    buttons[number - 1].GetComponent<Image>().color = Color.red;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt(SelecrtedBalltheam, number);                   
                    SceneManager.LoadScene(0);
                }
                break;
            case 2:
                if (TotalCoin >= 200 && PlayerPrefs.GetInt("2") != 2)
                {
                    PlayerPrefs.SetInt("2", 2);
                    TotalCoin = TotalCoin - 200;
                    PlayerPrefs.SetInt("TotalCoin", TotalCoin);
                    ShopMenuCoinText.text = TotalCoin.ToString();
                    buttons[number - 1].GetComponent<Image>().color = Color.black;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selecte";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);                  
                    SceneManager.LoadScene(0);
                }
                else if (PlayerPrefs.GetInt("2") == 2)
                {
                    buttons[number - 1].GetComponent<Image>().color = Color.red;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);                   
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StoreGameObject.transform.DOShakePosition(2, pannelshakeinn);
                }
                break;
            case 3:
                if (TotalCoin >= 300 && PlayerPrefs.GetInt("3") != 3)
                {
                    PlayerPrefs.SetInt("3", 3);
                    TotalCoin = TotalCoin - 300;
                    PlayerPrefs.SetInt("TotalCoin", TotalCoin);
                    ShopMenuCoinText.text = TotalCoin.ToString();
                    buttons[number - 1].GetComponent<Image>().color = Color.black;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selecte";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];

                    PlayerPrefs.SetInt("SelectedBallTheam", number);
                    SceneManager.LoadScene(0);
                }
                else if (PlayerPrefs.GetInt("3") == 3)
                {
                    buttons[number - 1].GetComponent<Image>().color = Color.red;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StoreGameObject.transform.DOShakePosition(2, pannelshakeinn);
                }
                break;
            case 4:
                if (TotalCoin >= 400 && PlayerPrefs.GetInt("4") != 4)
                {
                    PlayerPrefs.SetInt("4", 4);
                    TotalCoin = TotalCoin - 400;
                    PlayerPrefs.SetInt("TotalCoin", TotalCoin);
                    ShopMenuCoinText.text = TotalCoin.ToString();
                    buttons[number - 1].GetComponent<Image>().color = Color.black;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selecte";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);                   
                    SceneManager.LoadScene(0);
                }
                else if (PlayerPrefs.GetInt("4") == 4)
                {
                    buttons[number - 1].GetComponent<Image>().color = Color.red;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);                  
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StoreGameObject.transform.DOShakePosition(2, pannelshakeinn);
                }
                break;
            case 5:
                if (TotalCoin >= 500 && PlayerPrefs.GetInt("5") != 5)
                {
                    PlayerPrefs.SetInt("5", 5);
                    TotalCoin = TotalCoin - 500;
                    PlayerPrefs.SetInt("TotalCoin", TotalCoin);
                    ShopMenuCoinText.text = TotalCoin.ToString();
                    buttons[number - 1].GetComponent<Image>().color = Color.black;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selecte";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);                 
                    SceneManager.LoadScene(0);
                }
                else if (PlayerPrefs.GetInt("5") == 5)
                {
                    buttons[number - 1].GetComponent<Image>().color = Color.red;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);                   
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StoreGameObject.transform.DOShakePosition(2, pannelshakeinn);
                }
                break;
            case 6:
                if (TotalCoin >= 600 && PlayerPrefs.GetInt("6") != 6)
                {
                    PlayerPrefs.SetInt("6", 6);
                    TotalCoin = TotalCoin - 600;
                    PlayerPrefs.SetInt("TotalCoin", TotalCoin);
                    ShopMenuCoinText.text = TotalCoin.ToString();
                    buttons[number - 1].GetComponent<Image>().color = Color.black;                    
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selecte";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];
                    PlayerPrefs.SetInt("SelectedBallTheam", number);
                    SceneManager.LoadScene(0);
                }
                else if (PlayerPrefs.GetInt("6") == 6)
                {
                    buttons[number - 1].GetComponent<Image>().color = Color.red;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
                    buttons[number - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
                    Player.GetComponent<MeshRenderer>().material = materials[number - 1];                   
                    PlayerPrefs.SetInt("SelectedBallTheam", number);
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StoreGameObject.transform.DOShakePosition(2, pannelshakeinn);
                }
                break;
        }
    }
    public void StartFunctionCallForTestYouBuy()
    {
        if (PlayerPrefs.GetInt("1") == 1)
        {
            buttons[PlayerPrefs.GetInt("1") - 1].GetComponent<Image>().color = Color.black;
            buttons[PlayerPrefs.GetInt("1") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
            buttons[PlayerPrefs.GetInt("1") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
            buttons[PlayerPrefs.GetInt("1") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
            
        }
        if (PlayerPrefs.GetInt("2") == 2)
        {
            buttons[PlayerPrefs.GetInt("2") - 1].GetComponent<Image>().color = Color.black;
            buttons[PlayerPrefs.GetInt("2") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
            buttons[PlayerPrefs.GetInt("2") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
            buttons[PlayerPrefs.GetInt("2") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
           

        }
        if (PlayerPrefs.GetInt("3") == 3)
        {
            buttons[PlayerPrefs.GetInt("3") - 1].GetComponent<Image>().color = Color.black;
            buttons[PlayerPrefs.GetInt("3") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
            buttons[PlayerPrefs.GetInt("3") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
            buttons[PlayerPrefs.GetInt("3") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
           
        }
        if (PlayerPrefs.GetInt("4") == 4)
        {
            buttons[PlayerPrefs.GetInt("4") - 1].GetComponent<Image>().color = Color.black;
            buttons[PlayerPrefs.GetInt("4") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
            buttons[PlayerPrefs.GetInt("4") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
            buttons[PlayerPrefs.GetInt("4") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
           
        }
        if (PlayerPrefs.GetInt("5") == 5)
        {
            buttons[PlayerPrefs.GetInt("5") - 1].GetComponent<Image>().color = Color.black;
            buttons[PlayerPrefs.GetInt("5") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
            buttons[PlayerPrefs.GetInt("5") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
            buttons[PlayerPrefs.GetInt("5") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
           
        }
        if (PlayerPrefs.GetInt("6") == 6)
        {
            buttons[PlayerPrefs.GetInt("6") - 1].GetComponent<Image>().color = Color.black;
            buttons[PlayerPrefs.GetInt("6") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Select";
            buttons[PlayerPrefs.GetInt("6") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = 48.4f;
            buttons[PlayerPrefs.GetInt("6") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
            
        }
    }
    public void SeletedBallTheam()
    {
        if (PlayerPrefs.GetInt("SelectedBallTheam") == 1)
        {
            buttons[PlayerPrefs.GetInt("1") - 1].GetComponent<Image>().color = Color.red;
            buttons[PlayerPrefs.GetInt("1") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
            buttons[PlayerPrefs.GetInt("1") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
            buttons[PlayerPrefs.GetInt("1") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;          
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 2)
        {
            buttons[PlayerPrefs.GetInt("2") - 1].GetComponent<Image>().color = Color.red;
            buttons[PlayerPrefs.GetInt("2") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
            buttons[PlayerPrefs.GetInt("2") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
            buttons[PlayerPrefs.GetInt("2") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;           
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 3)
        {
            buttons[PlayerPrefs.GetInt("3") - 1].GetComponent<Image>().color = Color.red;
            buttons[PlayerPrefs.GetInt("3") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
            buttons[PlayerPrefs.GetInt("3") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
            buttons[PlayerPrefs.GetInt("3") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;         
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 4)
        {
            buttons[PlayerPrefs.GetInt("4") - 1].GetComponent<Image>().color = Color.red;
            buttons[PlayerPrefs.GetInt("4") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
            buttons[PlayerPrefs.GetInt("4") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
            buttons[PlayerPrefs.GetInt("4") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;          
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 5)
        {
            buttons[PlayerPrefs.GetInt("5") - 1].GetComponent<Image>().color = Color.red;
            buttons[PlayerPrefs.GetInt("5") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
            buttons[PlayerPrefs.GetInt("5") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
            buttons[PlayerPrefs.GetInt("5") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;          
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 6)
        {
            buttons[PlayerPrefs.GetInt("6") - 1].GetComponent<Image>().color = Color.red;
            buttons[PlayerPrefs.GetInt("6") - 1].transform.GetChild(0).GetComponent<TMP_Text>().text = "Selected";
            buttons[PlayerPrefs.GetInt("6") - 1].transform.GetChild(0).GetComponent<TMP_Text>().fontSize = FontSizeslected;
            buttons[PlayerPrefs.GetInt("6") - 1].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;           

        }
    }
    
    #endregion
    #region Music And Sound
    public void MusicChnagesValueFun()
    {
        if (MusicToggle.isOn == true)
        {
            ToggelTextMusic.text = "On";
            MusicAudio.volume = 1;
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            ToggelTextMusic.text = "Off";
            MusicAudio.volume = 0;
            PlayerPrefs.SetInt("Music", 0);
        }
    }
    public void SoundChnagesValueFun()
    {
        if (SoundToggle.isOn == true)
        {
            ToggleTextSound.text = "On";
            SoundAudio.volume = 1;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            ToggleTextSound.text = "Off";
            SoundAudio.volume = 0;
            PlayerPrefs.SetInt("Sound", 0);
        }
    }
    public void MusicAndSoundStartCallFun()
    {

        MusicAudio.volume = PlayerPrefs.GetInt("Music");
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            MusicToggle.isOn = true;
            ToggelTextMusic.text = "On";

        }
        else if (PlayerPrefs.GetInt("Music") == 0)
        {
            ToggelTextMusic.text = "Off";
            MusicToggle.isOn = false;
        }
        SoundAudio.volume = PlayerPrefs.GetInt("Sound");
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            ToggleTextSound.text = "On";
            SoundToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("Sound") == 0)
        {
            ToggleTextSound.text = "Off";
            SoundToggle.isOn = false;
        }

    }
    #endregion


}
