using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSprite : MonoBehaviour
{
    [SerializeField] Material normalState;
    [SerializeField] Material highLight;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipLeft()
    {
        spriteRenderer.flipX = true;
    }
    public void FlipRight()
    {
        spriteRenderer.flipX = false;
    }
    public void HightLight()
    {
        spriteRenderer.material = highLight;
    }
    public void MakeNormal()
    {
        spriteRenderer.material = normalState;
    }

}
