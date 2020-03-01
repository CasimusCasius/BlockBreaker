using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySFX;
   
    //cashed reference
    Level level;
    GameStatus gameStatus;
        private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position);
        gameStatus.AddToScore();
        
        level.BlockDestroy();
        Destroy(gameObject);
    }
}
