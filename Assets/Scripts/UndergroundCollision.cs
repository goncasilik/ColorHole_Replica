using UnityEngine;
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

                if (Level.instance.objectsInScene == 0)
                {
                    UiManager.instance.ShowLevelCompletedUI();
                    Level.instance.PlayWinFx();

                    Invoke("NextLevel", 2f);
                }
            }
            if (tag.Equals("Obstacle"))
            {
                Game.isGameover = true;
                Camera.main.transform.DOShakePosition(3f, .2f, 20, 90f)
                    .OnComplete(() =>
                    {

                    });

                Level.instance.RestartLevel();
            }
        }
    }

    void NextLevel()
    {
        Level.instance.LoadNextLevel();
    }
}
