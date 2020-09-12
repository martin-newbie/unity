using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneChange : MonoBehaviour
{
    public void ChangeGameScene()
    {
        Player.hp = 100;
        SceneManager.LoadScene("MainScene");
    }
}
