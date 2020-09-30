using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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

                // check 

                if (Level.instance.objectsInScene == 0)
                {
                    // no more objects to collect

                    UiManager.instance.ShowLevelCompletedUI();
                    Level.instance.PlayWinFx();

                    Invoke("NextLevel", 2f);
                }
            }
            if (tag.Equals("Obstacle"))
            {
                Game.isGameover = true;
                Camera.main.transform.DOShakePosition(1f, .2f, 20, 90f)
                    .OnComplete(() =>
                    {

                    });

                Level.instance.RestartLevel();

                //restart level
            }
        }
    }

    void NextLevel()
    {
        Level.instance.LoadNextLevel();
    }
}
