using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    [SerializeField]
    private AudioSource _optionsSelectionClick;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _optionsSelectionClick.Play();
            SceneManager.LoadScene(1);
            gameObject.SetActive(false);
        }
    }
}
