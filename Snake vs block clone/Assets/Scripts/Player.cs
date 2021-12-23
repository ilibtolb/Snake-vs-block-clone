using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Rigidbody player;
    public float sensitivity;
    private bool click = false;
    public Camera film;
    private int HealthCount = 1;
    public GameObject Ball;
    private Stack<GameObject> LastBall = new Stack<GameObject>();
    private bool StopButton;
    public TextMeshPro Count;
    public PlaneMove plane;
    public GameObject LosePanel;

    private void Awake()
    {
        StopButton = true;
        LastBall.Push(this.gameObject);
        HealthCount = 1;
        this.CreateBall(4);
    }

    private void Update()
    {
        if (StopButton)
        {
            if (Input.GetMouseButton(0))
            {
                click = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (click)
        {
            Vector3 MouseScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15);
            Vector3 MousePostition = film.ScreenToWorldPoint(MouseScreen);
            Vector3 delta = (MousePostition - player.position).normalized;
            player.velocity = new Vector3(delta.x * sensitivity, 0, 0);

            click = false;
        }
        else
        {
            player.velocity = Vector3.zero;
        }
    }


    public void CreateBall(int HealthPlus)
    {
            for (int i = 0; i < HealthPlus; i++)
            {

                Vector3 NewBallPosition = new Vector3(LastBall.Peek().transform.position.x, LastBall.Peek().transform.position.y - 1.1f, -0.6f);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                GameObject NewBall = Instantiate(Ball, NewBallPosition, rotation);

                HingeJoint HingeJointLastBall = LastBall.Peek().AddComponent<HingeJoint>();
                HingeJointLastBall.connectedBody = NewBall.GetComponent<Rigidbody>();
                HingeJointLastBall.axis = new Vector3(0, 0, 1);
                HingeJointLastBall.useLimits = true;
                JointLimits BallLimits = HingeJointLastBall.limits;
            if (HealthCount == 1 && i == 0)
            {
                BallLimits.min = -15f;
                BallLimits.max = 15f;
            }
            else
            {
                BallLimits.min = 0;
                BallLimits.max = 0;
            }
                BallLimits.bounciness = 0;
                BallLimits.bounceMinVelocity = 0;
                HingeJointLastBall.limits = BallLimits;

                LastBall.Push(NewBall);
        }

        HealthCount += HealthPlus;
        Count.text = HealthCount.ToString();
    }

    public void DestroyBall()
    {
        HealthCount--;
        if (HealthCount == 0)
        {
            this.Stop();
            plane.Stop();
            LosePanel.gameObject.SetActive(true);
            return;
        }
        plane.Bounce();
        Destroy(LastBall.Pop());
        Count.text = HealthCount.ToString();
    }


    public void Stop()
    {
        StopButton = false;
        player.velocity = new Vector3(0, 0, 0);
    }
}
