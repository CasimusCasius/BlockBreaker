using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {

      
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
