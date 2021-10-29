using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _selection;

    [SerializeField]
    private AudioSource _optionsSelectionHover;

    [SerializeField]
    private AudioSource _optionsSelectionClick;

    private int _option;


    void Start()
    {
        _option = 0;
    }

    void Update()
    {
        HideHands();
        if (Input.GetKeyDown(KeyCode.S))
        {
            _optionsSelectionHover.Play();
            _option++;
            if (_option > 1) _option = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _optionsSelectionHover.Play();
            _option--;
            if (_option < 0) _option = 1;
        }
    }

    private void HideHands()
    {
        if (_option == 0)
        {
            _selection[0].SetActive(true);
            _selection[1].SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _optionsSelectionClick.Play();
                SceneManager.LoadScene(1);
            }
        }

        if (_option == 1)
        {
            _selection[0].SetActive(false);
            _selection[1].SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _optionsSelectionClick.Play();
                SceneManager.LoadScene(0);
            }
        }
    }
}
