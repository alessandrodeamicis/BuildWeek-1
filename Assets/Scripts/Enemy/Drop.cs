using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject weaponDropPrefab;
    public Vector3 dropOffset = Vector3.zero;
    public int chance = 10;
    private bool isQuitting = false;
    private LifeController life;

    void Start()
    {

        life = GetComponent<LifeController>();

    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void Update()
    {
        OnDie(life.CurrentHP);
    }

    void OnDie(int hp)
    {

        if (life.CurrentHP == 0)
        {
            if (isQuitting || weaponDropPrefab == null) return;

            int randomChance = Random.Range(1, 101);
            if (randomChance <= chance)
            {
                Instantiate(weaponDropPrefab, transform.position + dropOffset, Quaternion.identity);
            }
        }
    }
}


