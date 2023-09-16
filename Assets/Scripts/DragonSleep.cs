using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSleep : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        PutDragonToSleep();
    }

    public void PutDragonToSleep()
    {
        animator.SetBool("sleep", true);
    }
}
