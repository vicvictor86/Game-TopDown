using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    private void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("Transition", 1);
            }
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }
        
        transform.eulerAngles = player.direction.x > 0 ? new Vector2(0, 0) : new Vector2(0, 180);
    }

    private void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("Transition", 2);
        }
    }
    #endregion
}