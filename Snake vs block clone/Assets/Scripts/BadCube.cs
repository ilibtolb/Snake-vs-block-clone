using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BadCube : MonoBehaviour
{
    private int BadHealth;
    public TextMeshPro Count;
    public int maxHealth;

    private void Awake()
    {
        BadHealth = Random.Range(1, maxHealth);
        Count.text = BadHealth.ToString();
        float delta = (float)BadHealth / (float)maxHealth;
        GetComponent<Renderer>().material.color = new Color(1f - delta, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Player player))
        {
            player.DestroyBall();
            BadHealth--;
            Count.text = BadHealth.ToString();
            if (BadHealth == 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
