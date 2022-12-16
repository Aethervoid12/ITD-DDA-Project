using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefab;
    [Range(0.25f, 1f)]
    // Lower the number, the faster it spawn.
    public float lauchSpeed;
    public AudioSource soundEffect;

    public int minVelocityY;
    public int maxVelocityY;

    private int randomVelocityY;
    public void StartGame()
    {
        StartCoroutine(SpawnFruit());
        Debug.Log("Start");
        lauchSpeed = 1f;
    }
    public void FinalGame()
    {
        lauchSpeed = 0.25f;
    }
    IEnumerator SpawnFruit()
    {
        while(true)
        {
            randomVelocityY = Random.Range(minVelocityY, maxVelocityY);

            GameObject go = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);
            Rigidbody temp = go.GetComponent<Rigidbody>();

            //temp.velocity = new Vector3(0f, 5-10f, 10f);
            temp.velocity = new Vector3(0f, randomVelocityY, 10f);
            temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            temp.useGravity = true;

            Vector3 pos = transform.position;
            pos.x += Random.Range(-1f, 1f);
            go.transform.position = pos;

            yield return new WaitForSeconds(lauchSpeed);
            soundEffect.Play();
        }
        
    }
}
