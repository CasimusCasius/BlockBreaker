using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySFX;
    [SerializeField] GameObject blockSparklesVFX;

    //cashed reference
    Level level;
    GameSession gameStatus;
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable") DestroyBlock();
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
