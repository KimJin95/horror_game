using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Chair : MonoBehaviour
{
    //public Rigidbody chairRigidbody;
    public Monster_Move monster;

    public float waitTime = 2f;
    public float moveSpeed;
    public float rotSpeed;

    Quaternion presentRot;
    Quaternion targetRot;

    Vector3 startRot;

    private void Start()
    {
        //chairRigidbody = GetComponent<Rigidbody>();
        monster = GameObject.FindObjectOfType<Monster_Move>();
        presentRot = transform.rotation;
    }

    void Update()
    {
        if (monster.isMove)
        {
            StartCoroutine(WhenSlenderManTurn());
        }
    }

    private IEnumerator WhenSlenderManTurn()
    {
        yield return new WaitForSeconds(waitTime);

        Vector3 moveChair = new Vector3(1.53f, 0f, 5.6f);
        targetRot = Quaternion.Euler(-90, 0, -35.681f);

        //chairRigidbody.MovePosition(moveChair);
        //chairRigidbody.MoveRotation(turnChair);

        transform.position = Vector3.MoveTowards(transform.position, moveChair, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed*Time.deltaTime);

    }
}
