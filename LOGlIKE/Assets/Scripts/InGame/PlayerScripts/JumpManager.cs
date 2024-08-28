using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] int jumpCount;
    [SerializeField] int maxJump;

    private void Start()
    {
        jumpCount = 0;
        maxJump = 1;
    }
    public int JumpCount
    {
        get { return jumpCount; }
        set { jumpCount = value; }
    }
    public int ChangeMax
    {
        get { return maxJump; }
        set { maxJump = value; }
    }
    public bool CanJump()
    {
        return jumpCount < maxJump;
    }
    public void IncreaseJumpCount()
    {
        jumpCount++;
    }
    public void ResetJumpCount()
    {
        jumpCount = 0;
    }
}
