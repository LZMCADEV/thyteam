using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    private SpriteRenderer _sprite;
    private Color color;
    public int number;
    void Awake()
    {
        targetPosition = transform.position;
        correctPosition = targetPosition;
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        color = _sprite.color;
        
        if (targetPosition == correctPosition) {
            color.a = 1f;
        } else {
            color.a = 0.5f;
        }
        _sprite.color = color;
    }
}
