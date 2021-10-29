using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCondition : MonoBehaviour
{
    public static bool _win = false; 

    [SerializeField]
    private GameObject _loseScreen;

    [SerializeField]
    private GameObject _winScreen;

    private void Update()
    {
        if(_win)
        {
            _winScreen.gameObject.SetActive(true);
            _loseScreen.gameObject.SetActive(false);
        }
        else
        {
            _winScreen.gameObject.SetActive(false);
            _loseScreen.gameObject.SetActive(true);
        }
    }
}
