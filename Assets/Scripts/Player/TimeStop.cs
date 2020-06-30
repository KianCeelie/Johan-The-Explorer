using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private float Speed;
    private bool RestoreTime;

    public Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        RestoreTime = false;

        animator.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (RestoreTime)
        {
            if (Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * Speed;
            }
            else
            {
                Time.timeScale = 1f;
                RestoreTime = false;
                animator.SetBool("Damaged", false);
            }
        }
    }

    public void StopTime(float ChangeTime, int RestoreSpeed, float Delay)
    {
        Speed = RestoreSpeed;

        if (Delay > 0)
        {
            StopCoroutine(StartTimeAgain(Delay));
            StartCoroutine(StartTimeAgain(Delay));
        }
        else
        {
            RestoreTime = true;
        }

        animator.SetBool("Damaged", true);
        Time.timeScale = ChangeTime;
    }

    IEnumerator StartTimeAgain(float amt)
    {
        yield return new WaitForSecondsRealtime(amt);       
        RestoreTime = true;
        
    }
}
