using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scr = 0;

    [SerializeField]
    private Text score;
    public void updt_scr()
    {
        scr++;
        score.text = scr.ToString();
    }
        
}
