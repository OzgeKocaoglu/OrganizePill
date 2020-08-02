using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    //Variables
    [SerializeField]
    private Text _playerCoinAmount;
    private Text _playerGainCoinAmount;

    //Unity Funcs
    private void OnEnable()
    {
        _playerCoinAmount.text = PlayerPrefs.Coin.ToString();
    }
}
