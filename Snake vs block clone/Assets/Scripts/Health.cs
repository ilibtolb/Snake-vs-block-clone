using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{

    private int HealthPlus;
    public TextMeshPro HealthGain;
    public int maxHealth;

    private void Awake()
    {
        HealthPlus = Random.Range(1, maxHealth);
        HealthGain.text = HealthPlus.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CreateBall(HealthPlus);
            this.gameObject.SetActive(false);
        }
    }
}
