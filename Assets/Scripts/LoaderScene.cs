using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScene : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Update()
    {
        if (_player.GetComponent<PlayerScore>().GetScore == 10)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
