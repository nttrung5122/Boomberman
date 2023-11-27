using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    public KeyCode inputKey = KeyCode.LeftShift;
    public GameObject bombPrefab;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    private int bombsRemaining;

    [Header("Explosion")]
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;

    private void Update()
    {
        if(Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());
        }
    }

    private void OnEnable()
    {
        bombsRemaining = bombAmount;
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.y = Mathf.Round(position.y);
        position.x = Mathf.Round(position.x);
        GameObject Bomb = Instantiate(bombPrefab,position, Quaternion.identity);

        Debug.Log("place bomb");

        yield return new WaitForSeconds(bombFuseTime);

        Destroy(Bomb);
        Debug.Log("exlosion");
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }
}
