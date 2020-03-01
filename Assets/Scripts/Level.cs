using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    //cashed references

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {

        breakableBlocks++;
    }

    public void BlockDestroy()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
