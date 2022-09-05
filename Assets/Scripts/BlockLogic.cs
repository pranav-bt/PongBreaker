using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    public List<Sprite> BlocksList;
    [SerializeField] AudioClip TileCollisionSound;
    private int CurrentBlock;
    private void Start()
    {
        CurrentBlock = BlocksList.Count - 1;
        UpdateBlock();
    }

    private void UpdateBlock()
    {
        GetComponent<SpriteRenderer>().sprite = BlocksList[CurrentBlock];
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ball" && CurrentBlock > 0)
        {
            CurrentBlock--;
            UpdateBlock();
        }
        else if(other.gameObject.tag == "ball")
        {
            Destroy(gameObject);
        }
        FindObjectOfType<AudioPlayer>().PlaySound(TileCollisionSound);
    }
}
