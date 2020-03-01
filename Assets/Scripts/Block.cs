using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySFX;
    [SerializeField] GameObject blockSparklesVFX;
   
    //cashed reference
    Level level;
    GameSession gameStatus;
        private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        TriggerSparcleVFX();
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position);
        gameStatus.AddToScore();
        
        level.BlockDestroy();

        Destroy(gameObject);
    }

    private void TriggerSparcleVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
