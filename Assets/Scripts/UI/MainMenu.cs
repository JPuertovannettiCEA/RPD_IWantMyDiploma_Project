using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _selection;

    private int _option;

    [SerializeField]
    private GameObject _credits;

    [SerializeField]
    private AudioSource _optionsSelectionHover;

    [SerializeField]
    private AudioSource _optionsSelectionClick;

    private void Start()
    {
        _option = 0;
    }

    void Update()
    {
        HideHands();
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            _optionsSelectionHover.Play();
            _option++;
            if (_option > 2) _option = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _optionsSelectionHover.Play();
            _option--;
            if (_option < 0) _option = 2;
        }
    }

    private void HideHands()
    {
        if (_option == 0)
        {
            _selection[0].SetActive(true);
            _selection[1].SetActive(false);
            _selection[2].SetActive(false);
            if (Input.GetKeyDown(KeyCode.J))
            {
                _optionsSelectionClick.Play();
                SceneManager.LoadScene(1);
            }
        }

        if (_option == 1)
        {
            _selection[0].SetActive(false);
            _selection[1].SetActive(true);
            _selection[2].SetActive(false);
            if (Input.GetKeyDown(KeyCode.J))
            {
                _optionsSelectionClick.Play();
                _credits.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        if (_option == 2)
        {
            _selection[0].SetActive(false);
            _selection[1].SetActive(false);
            _selection[2].SetActive(true);
            if (Input.GetKeyDown(KeyCode.J))
            {
                _optionsSelectionClick.Play();
                Application.Quit();
            }
        }
    }
}
