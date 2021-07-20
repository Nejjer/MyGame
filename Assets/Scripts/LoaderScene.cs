using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScene : MonoBehaviour  //load scene, when player has 10 score
{
    [SerializeField] GameObject _player;
    void Update()
    {
        //check score
        if (_player.GetComponent<PlayerScore>().GetScore == 10)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
