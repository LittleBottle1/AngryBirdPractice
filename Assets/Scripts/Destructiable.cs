using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructiable : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public List<Sprite> injuredSpriteList;//ÊÜÉËµÄÍ¼Æ¬×é
    private SpriteRenderer spriteRenderer;

    private GameObject boomPrefab;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boomPrefab = Resources.Load<GameObject>("Boom1");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHP -= (int)(collision.relativeVelocity.magnitude) * 8;
        if (currentHP <= 0)
        {
            Dead();
        }
        else
        {
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f))) - 1;
            if (index != -1)
            {
                spriteRenderer.sprite = injuredSpriteList[index];
            }


        }

    }
    public virtual void Dead()
    {
        GameObject.Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
