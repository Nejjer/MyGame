using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] GameObject _scoreBar;
    public int _score = 0;

    public void AddScore(int _addedScore)
    {
        _score += _addedScore;
        _scoreBar.GetComponent<Text>().text = _score.ToString() + "/10";
    }

    public int GetScore
    {
        get
        {
            return _score;
        }
    }


}
