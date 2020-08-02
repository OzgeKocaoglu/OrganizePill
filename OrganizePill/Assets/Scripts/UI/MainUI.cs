using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class MainUI : MonoBehaviour
{
    //Variables
    [Header ("UI References")]
    [SerializeField] private Text _playerCoinAmount;
    [SerializeField] private Text _playerGainCoinAmount;
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target;

    [Space]
    [Header("Available coins: ")]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQuene = new Queue<GameObject>();

    [Space]
    [Header("Animation settings")]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimationDuration;
    [SerializeField] [Range(0.9f, 2f)] float maxAnimationDuration;

    RectTransform targetPosition;


    private void Awake()
    {

        targetPosition = target.GetComponent<RectTransform>();
        PrepareCoins();
    }

    void PrepareCoins()
    {
        GameObject coin;
        for (int i=0; i< maxCoins; i++)
        {
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQuene.Enqueue(coin);
        }
    }

    public void OnCoinAdd()
    {
        OnAnimate(animatedCoinPrefab.gameObject.GetComponent<RectTransform>(), PlayerPrefs.Coin);
    }

    public GameObject _victoryPanel;

    public void OnAnimate(RectTransform collectedCoinPosition, int amount)
    {
        for(int i=0; i<amount; i++)
        {
            Debug.Log("Animated");
            if (coinsQuene.Count > 0)
            {
                GameObject coin = coinsQuene.Dequeue();
                float duration = Random.Range(minAnimationDuration, maxAnimationDuration);
                RectTransform _clone = 
                coin.transform.position = collectedCoinPosition;
                coin.transform.DOMove(Vector3.zero, duration)
                    .SetEase(Ease.InOutBack)
                    .OnComplete(() =>
                    {
                        coin.SetActive(false);
                        coinsQuene.Enqueue(coin);
                        PlayerPrefs.Coin++;
                    });
            }
        }
    }

    //Unity Funcs
    private void OnEnable()
    {
        _playerCoinAmount.text = PlayerPrefs.Coin.ToString();
    }
}
