using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;  

public class SpriteController : MonoBehaviour
{
    public Sprite[] mySprites;
    private int index = 0;

    private SpriteRenderer mySpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>(); 
        StartCoroutine(WalkCoRutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index >= mySprites.Length)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
}
