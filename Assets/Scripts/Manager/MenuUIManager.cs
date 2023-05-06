using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] GameObject selectTab;
    public void StartBtn()
    {
        selectTab.SetActive(true);
    }

    public void SelectBtn(int job)
    {
        Manager.I.job = (CharactorJob)job;
        SceneManager.LoadScene("Game");
    }
}
