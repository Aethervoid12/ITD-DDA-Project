using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Range(0, 1)]
    public float num = 0;
    public void Update()
    {
        Invoke("SelfDestruct", 5.0f);
        Time.timeScale = num;
    }
    public void SelfDestruct()
    {
        Destroy(gameObject);
        Debug.Log("Fruit Self-Destruct!!");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
