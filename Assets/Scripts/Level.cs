using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] ParticleSystem winFx;

    public static Level instance;

    [Space]
    [HideInInspector] public int objectsInScene;
    [HideInInspector] public int totalObjects;

    [SerializeField] Transform objectsParent;


    // Level Objects Obstacles
    [SerializeField] Material groundMaterial;
    [SerializeField] Material objectMaterial;
    [SerializeField] Material obstacleMaterial;

    [SerializeField] SpriteRenderer groundBorderSprite;
    [SerializeField] SpriteRenderer groundSideSprite;

    [SerializeField] Image progressFillImage;

    [SerializeField] SpriteRenderer bgFadeSprite;

    // Level Colors
    [SerializeField] Color groundColor;
    [SerializeField] Color borderColor;
    [SerializeField] Color sideColor;

    [SerializeField] Color objectColor;
    [SerializeField] Color obstacleColor;

    [SerializeField] Color progressFillColor;

    [SerializeField] Color cameraColor;
    [SerializeField] Color fadeColor;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        CountObjects();
        UpdateLevelColors();
    }

    void CountObjects()
    {
        totalObjects = objectsParent.childCount;
        objectsInScene = totalObjects;
    }

    public void PlayWinFx()
    {
        winFx.Play();
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("You Win");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateLevelColors()
    {
        groundMaterial.color = groundColor;
        groundSideSprite.color = sideColor;
        groundBorderSprite.color = borderColor;

        objectMaterial.color = objectColor;
        obstacleMaterial.color = obstacleColor;

        progressFillImage.color = progressFillColor;

        Camera.main.backgroundColor = cameraColor;
        bgFadeSprite.color = fadeColor;
    }

    private void OnValidate()
    {
        UpdateLevelColors();
    }
}
