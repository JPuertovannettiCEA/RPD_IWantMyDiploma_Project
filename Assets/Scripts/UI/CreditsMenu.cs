using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenu;

    [SerializeField]
    private AudioSource _optionsSelectionClick;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _optionsSelectionClick.Play();
            _mainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
