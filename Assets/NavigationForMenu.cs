using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationForMenu : MonoBehaviour {
    int sceneNum;
    public Button button;
    SceneManager loader;
    // Use this for initialization
    void Start()
    {
        sceneNum = 0;
        button = button.GetComponent<Button>();
        loader = new SceneManager();
        button.onClick.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");

    }
}
