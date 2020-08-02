using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class MainUI : MonoBehaviour
{
    //Editor Variables
    [Header ("UI References")]
    [SerializeField] private Text _playerCoinAmount;
    [SerializeField] private Text _playerGainCoinAmount;
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Canvas targetCanvas;
    [SerializeField] Transform target;

    [Space]
    [Header("Available coins: ")]
    [SerializeField] int maxCoins;
    Queue<RectTransform> coinsQuene = new Queue<RectTransform>();

    [Space]
    [Header("Animation settings")]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimationDuration;
    [SerializeField] [Range(0.9f, 2f)] float maxAnimationDuration;
    public GameObject _victoryPanel;
    RectTransform targetPosition;

    //Unity Funcs
    private void Awake()
    {

        targetPosition = target.GetComponent<RectTransform>();
        PrepareCoins();
    }
    private void OnEnable()
    {
        _playerCoinAmount.text = PlayerPrefs.Coin.ToString();
    }

    //Functions
    void PrepareCoins()
    {
        RectTransform coin;
        for (int i=0; i< maxCoins; i++)
        {
            coin = Instantiate(animatedCoinPrefab).GetComponent<RectTransform>();
            coin.transform.parent = transform;
            coin.gameObject.SetActive(false);
            coinsQuene.Enqueue(coin);
        }
    }
    public void OnCoinAdd()
    {
        OnAnimate(animatedCoinPrefab.gameObject.GetComponent<RectTransform>(), PlayerPrefs.Coin);
    }
    public void OnAnimate(RectTransform collectedCoinPosition, int amount)
    {
        for(int i=0; i<amount; i++)
        {
            Debug.Log("Animated");
            if (coinsQuene.Count > 0)
            {
                RectTransform coin = coinsQuene.Dequeue();
                float duration = Random.Range(minAnimationDuration, maxAnimationDuration);


                coin.transform.DOMove(Vector3.zero, duration)
                    .SetEase(Ease.InOutBack)
                    .OnComplete(() =>
                    {
                        coin.gameObject.SetActive(false);
                        coinsQuene.Enqueue(coin);
                        PlayerPrefs.Coin++;
                    });
            }
        }
    }

}
