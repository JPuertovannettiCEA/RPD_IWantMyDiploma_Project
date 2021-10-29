using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private Vector3 _spawnOffset;

    [SerializeField]
    private GameObject _pillow;

    [SerializeField]
    private GameObject _badGrade;

    private float counter = 0f;
    private float counterFish = 0f;

    private void Update()
    {
        counter += Time.deltaTime;
        counterFish += Time.deltaTime;
        _spawnOffset = new Vector3(Random.Range(-2f,2f), 0f, 0f);
        if(counterFish >= 2f) //Bad Grades
        {
            SpawnObjects(_badGrade);
            counterFish = 0f;
        }
        if (counter >= 5f) //Pillows
        {
            SpawnObjects(_pillow);
            counter = 0f;
        }
    }

    public void SpawnObjects(GameObject prefab)
    {
        if(prefab == _badGrade)
        {
            Instantiate(prefab, transform.position + _spawnOffset, Quaternion.identity);
        }
        else
        {
            Instantiate(prefab, transform.position + _spawnOffset, transform.rotation);
        }
    }

}
