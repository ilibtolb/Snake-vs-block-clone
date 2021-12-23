using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Player player;
    public PlaneMove Plane;
    public GameObject WinPanel;

    private void OnTriggerEnter(Collider other)
    {
        player.Stop();
        Plane.Stop();
        WinPanel.gameObject.SetActive(true);
    }
}
