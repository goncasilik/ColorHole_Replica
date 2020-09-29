using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UndergroundCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if(tag.Equals("Object"))
        {
            Debug.Log("Object");
        }
        if(tag.Equals("Obstacle"))
        {
            Debug.Log("Obstacle");

            //restart level
        }
    }
}
