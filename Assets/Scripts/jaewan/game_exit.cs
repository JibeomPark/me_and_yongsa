using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_exit : MonoBehaviour
{
    public void do_trun_off_game()
    {
        Debug.Log("exit game!");
        Application.Quit();
    }
    
}
