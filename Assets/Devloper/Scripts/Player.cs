using System.Collections;
using System.Collections.Generic;
using GG.Infrastructure.Utils.Swipe;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Rigidbody PlayerRb;
    //Vector3 StartPos, EndPos;
    public float Speed;
    public bool FingerDown;
    //public int Distance;
    public bool IsTouch;
    public bool Istraveling;
    Vector3 travelingDirection, nextcollisonposition;
    public int minswipereco = 500;
    Vector2 SwipePostLastFram, SwipePostCurrectFram, CureectSwipe;
    public ParticleSystem ParticalBubble, TempPartical;
    [SerializeField] private SwipeListener swipeListener;
    
    private void OnEnable()
    {
       TempPartical =  Instantiate(ParticalBubble);
        TempPartical.gameObject.SetActive(true);
        GameManager.gameManager.GamePlayCoinZero();

        if (PlayerPrefs.GetInt("SelectedBallTheam") == 1)
        {
            StartCoroutine(PlayerTrailOpenDelay(0));
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 2)
        {
            StartCoroutine(PlayerTrailOpenDelay(1));
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 3)
        {
            StartCoroutine(PlayerTrailOpenDelay(2));
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 4)
        {
            StartCoroutine(PlayerTrailOpenDelay(3));
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 5)
        {
            StartCoroutine(PlayerTrailOpenDelay(3));
        }
        else if (PlayerPrefs.GetInt("SelectedBallTheam") == 6)
        {
            StartCoroutine(PlayerTrailOpenDelay(4));
        }
    }
    private void OnDisable()
    {
        Destroy(TempPartical);
    }

    IEnumerator PlayerTrailOpenDelay(int number)
    {
        yield return new WaitForSeconds(0.5f);
        switch (number)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    if (i == number)
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(true);
                    }
                    else
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(false);
                    }
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    if (i == number)
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(true);
                    }
                    else
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(false);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    if (i == number)
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(true);
                    }
                    else
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(false);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < 5; i++)
                {
                    if (i == number)
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(true);
                    }
                    else
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(false);
                    }
                }
                break;
            case 4:
                for (int i = 0; i < 5; i++)
                {
                    if (i == number)
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(true);
                    }
                    else
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(false);
                    }
                }
                break;
            case 5:
                for (int i = 0; i < 5; i++)
                {
                    if (i == number)
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(true);
                    }
                    else
                    {
                        GameManager.gameManager.PlayerTrialEffect[i].SetActive(false);
                    }
                }
                break;
        }        
    }
    private void Start()
    {
        swipeListener.OnSwipe.AddListener(swipe =>
        {
            if (PlayerRb.velocity.magnitude < 0.5f)
            {
                switch (swipe)
                {
                    case "Right":
                        SetDireaction(-Vector3.back);
                        break;
                    case "Left":
                        SetDireaction(-Vector3.forward);
                        break;
                    case "Up":
                        SetDireaction(Vector3.left);
                        break;
                    case "Down":
                        SetDireaction(Vector3.right);
                        break;
                }
            }
        });

    }
    private void FixedUpdate()
    {
        #region New Input
        if (Istraveling)
        {
            PlayerRb.velocity = Speed * travelingDirection;
        }
        if (nextcollisonposition != Vector3.zero)
        {
            if (Vector3.Distance(transform.position, nextcollisonposition) < 1)
            {
                Istraveling = false;
                travelingDirection = Vector3.zero;
                nextcollisonposition = Vector3.zero;
            }

        }
        if (Istraveling)
            return;

        #region If Else Touch and Mouse Temp Input
        //if (IsTouch)
        //{

        //    if (Input.touchCount > 0)
        //    {
        //        Debug.Log(TouchPhase.Began);
        //        Touch touch = Input.GetTouch(0);
        //        switch (touch.phase)
        //        {
        //            case TouchPhase.Moved:
        //                SwipePostCurrectFram = new Vector2(touch.position.x, touch.position.y);

        //                if (SwipePostLastFram != Vector2.zero)
        //                {
        //                    CureectSwipe = SwipePostCurrectFram - SwipePostLastFram;

        //                    if (CureectSwipe.sqrMagnitude < minswipereco)
        //                    {
        //                        return;
        //                    }
        //                    CureectSwipe.Normalize();


        //                    if (CureectSwipe.x > -0.5f && CureectSwipe.x < 0.5)
        //                    {
        //                        //Up / Downd
        //                        SetDireaction(CureectSwipe.y > 0 ? Vector3.left : Vector3.right);
        //                    }
        //                    if (CureectSwipe.y > -0.5f && CureectSwipe.y < 0.5)
        //                    {
        //                        //Left / Right
        //                        SetDireaction(CureectSwipe.x > 0 ? -Vector3.back : -Vector3.forward);

        //                    }

        //                }

        //                SwipePostLastFram = SwipePostCurrectFram;
        //                break;

        //            case TouchPhase.Ended:

        //                SwipePostLastFram = Vector2.zero;
        //                CureectSwipe = Vector2.zero;
        //                break;
        //        }
        //    }
        //}
        //else
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        SwipePostCurrectFram = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        //        if (SwipePostLastFram != Vector2.zero)
        //        {
        //            CureectSwipe = SwipePostCurrectFram - SwipePostLastFram;

        //            if (CureectSwipe.sqrMagnitude < minswipereco)
        //            {
        //                return;
        //            }
        //            CureectSwipe.Normalize();



        //            //if (CureectSwipe.x > -0.5f && CureectSwipe.x < 0.5)
        //            //{
        //            //    //Up / Downd
        //            //    SetDireaction(CureectSwipe.y > 0 ? Vector3.left : Vector3.right);
        //            //}
        //            //if (CureectSwipe.y > -0.5f && CureectSwipe.y < 0.5)
        //            //{
        //            //    //Left / Right
        //            //    SetDireaction(CureectSwipe.x > 0 ? -Vector3.back : -Vector3.forward);

        //            //}

        //        }
        //        SwipePostLastFram = SwipePostCurrectFram;
        //    }

        //    //}
        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        SwipePostLastFram = Vector2.zero;
        //        CureectSwipe = Vector2.zero;
        //    }
        //}
        #endregion
        #endregion

    }
    private void SetDireaction(Vector3 direction)
    {
        travelingDirection = direction;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 500f))
        {
            nextcollisonposition = hit.point;
        }

        Istraveling = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            #region Ground Material Color Chanages
            if (PlayerPrefs.GetInt("SelectedBallTheam") == 1)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.yellow, 1);
            }
            else if (PlayerPrefs.GetInt("SelectedBallTheam") == 2)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.black, 1);
            }
            else if (PlayerPrefs.GetInt("SelectedBallTheam") == 3)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.magenta, 1);
            }
            else if (PlayerPrefs.GetInt("SelectedBallTheam") == 4)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1);
            }
            else if (PlayerPrefs.GetInt("SelectedBallTheam") == 5)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1);
            }
            else if (PlayerPrefs.GetInt("SelectedBallTheam") == 6)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.yellow, 1);
            }
            #endregion
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            GameManager.gameManager.TriggerRoad++;
            if (GameManager.gameManager.AllRoad.Equals(GameManager.gameManager.TriggerRoad))
            {
                #region OneTimeCoin System
                if (GameManager.gameManager.LevelClick == 0)
                {
                    FirstTimeCoin.firstTimeCoin.ISFirst = true;
                    PlayerPrefs.SetInt(FirstTimeCoin.FirstPlayPref, 1);
                }
                if (GameManager.gameManager.LevelClick == 1)
                {
                    FirstTimeCoin.firstTimeCoin.IsSecound = true;
                    PlayerPrefs.SetInt(FirstTimeCoin.SecoundPlayPref, 1);
                }
                if (GameManager.gameManager.LevelClick == 2)
                {
                    FirstTimeCoin.firstTimeCoin.IsThird = true;
                    PlayerPrefs.SetInt(FirstTimeCoin.ThirdPlayPref, 1);
                }
                if (GameManager.gameManager.LevelClick == 3)
                {
                    FirstTimeCoin.firstTimeCoin.IsFourth = true;
                    PlayerPrefs.SetInt(FirstTimeCoin.FourPlayPref, 1);
                }
                if (GameManager.gameManager.LevelClick == 4)
                {
                    FirstTimeCoin.firstTimeCoin.IsFive = true;
                    PlayerPrefs.SetInt(FirstTimeCoin.FivePlatPref, 1);
                }
                #endregion
                GameManager.gameManager.ParticalWin.SetActive(true);
                Camera.main.DOShakePosition(1, 0.2f);
                GameManager.gameManager.TriggerRoad = 0;
                GameManager.gameManager.Invoke("GameWin", 0.9f);
            }

        }
        if (other.gameObject.tag == "Coin")
        {
            for (int i = 1; i <= 5; i++)
            {
                GameObject tempcoinanimation = Instantiate(other.gameObject);
                tempcoinanimation.GetComponent<CapsuleCollider>().enabled = false;
                tempcoinanimation.transform.position = other.transform.position;
                tempcoinanimation.transform.Rotate(new Vector3(0, 0, 10));
                tempcoinanimation.transform.localScale = (new Vector3(1f, 0.1f, 1f));
                #region Animation Coin
                if (i == 1)
                {
                    tempcoinanimation.transform.DOMove(GameManager.gameManager.coinfinalanimationpos.position, 1f);
                    Destroy(tempcoinanimation, 0.9f);
                }
                else if (i == 2)
                {
                    tempcoinanimation.transform.DOMove(GameManager.gameManager.coinfinalanimationpos.position, 1.2f);
                    Destroy(tempcoinanimation, 0.9f);
                }
                else if (i == 3)
                {
                    tempcoinanimation.transform.DOMove(GameManager.gameManager.coinfinalanimationpos.position, 1.5f);
                    Destroy(tempcoinanimation, 0.9f);
                }
                else if (i == 4)
                {
                    tempcoinanimation.transform.DOMove(GameManager.gameManager.coinfinalanimationpos.position, 1.8f);
                    Destroy(tempcoinanimation, 0.9f);
                }
                else if (i == 5)
                {
                    tempcoinanimation.transform.DOMove(GameManager.gameManager.coinfinalanimationpos.position, 2f);
                    Destroy(tempcoinanimation, 0.9f);
                }
                #endregion
            }
            Destroy(other.gameObject);
            GameManager.gameManager.Invoke("GamePlayCoinTouch", 0.3f);
        }
    }

}
