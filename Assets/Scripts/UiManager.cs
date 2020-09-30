using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    // Level Progress UI
    [SerializeField] int sceneOffset;
    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] Image progressFillImage;

    [Space]
    [SerializeField] TMP_Text levelCompletedText;

    [Space]
    [SerializeField] Image fadePanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        FadeAtStart();
        progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = (level).ToString();
        nextLevelText.text = (level + 1).ToString();
    }

    // Update is called once per frame
    public void UpdateLevelProgress()
    {
        float val = 1f - ((float)Level.instance.objectsInScene / Level.instance.totalObjects);
        progressFillImage.DOFillAmount(val, .4f);
    }

   //----------

    public void ShowLevelCompletedUI ()
    {
        levelCompletedText.DOFade(1f, .6f).From(0f);
    }

    public void FadeAtStart()
    {
        fadePanel.DOFade(0f, 1.3f).From(1f);
    }
}
