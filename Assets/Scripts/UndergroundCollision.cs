using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UndergroundCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!Game.isGameover)
        {
            string tag = other.tag;

            if (tag.Equals("Object"))
            {
                Level.instance.objectsInScene--;
                UiManager.instance.UpdateLevelProgress();
                Destroy(other.gameObject);
                Debug.Log("Object");
            }
            if (tag.Equals("Obstacle"))
            {
                Game.isGameover = true;
                Debug.Log("Obstacle");

                //restart level
            }
        }
    }
}
