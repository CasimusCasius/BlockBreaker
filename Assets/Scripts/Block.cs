using System;
using UnityEngine;

public class Block : MonoBehaviour
{

    //Config params
    [SerializeField] AudioClip destroySFX;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] blockSprites;

    //Cashed reference
    Level level;

    //state vars
    [SerializeField] int timesHit;

    GameSession gameStatus;
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = (timesHit * blockSprites.Length)/maxHits; // TODO check this 
        GetComponent<SpriteRenderer>().sprite = blockSprites[spriteIndex];
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        if (tag == "Breakable") level.CountBlocks();
    }

    private void DestroyBlock()
    {
        TriggerSparcleVFX();
        PlayDestroySFX();
        gameStatus.AddToScore();
        level.BlockDestroy();
        Destroy(gameObject);
    }

    private void PlayDestroySFX()
    {
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position);
    }

    private void TriggerSparcleVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
