using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour, IAIControl
{
    public Material playerMaterial;
    [SerializeField] TouchControls touchControls;
    [SerializeField] Transform playerTransform;
    [SerializeField] Rigidbody rigid;
    [SerializeField] float moveSpeed;
    [SerializeField] float moveLimit;
    [Tooltip("High value > Faster rotate speed\nLow value > Slower rotate speed\n(Recommended: 1.5)")]
    [Range(0f, 5)]
    [SerializeField] float rotateFactor = 1.5f;

    [SerializeField] NavMeshAgent playerAgent;
    [SerializeField] List<Transform> roadPaths = new List<Transform>();
    public int currentPathIndex;

    Vector2 moveVal;
    bool canMove = true;

    private void OnEnable()
    {
        StartCoroutine(MoveNextPath());

    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        if (canMove)
        {
            moveVal = touchControls.MoveValue;
            rigid.AddRelativeForce(new Vector3(moveVal.x * moveSpeed / 10, 0, 0), ForceMode.Acceleration);

            transform.DOLocalRotate(new Vector3(0, touchControls.MoveValue.x * rotateFactor / 10, 0), 1f);
            MoveLimit();
        }
    }

    private void MoveLimit()
    {
        if (playerTransform.localPosition.x > moveLimit)
        {
            playerTransform.localPosition = new Vector3(moveLimit, playerTransform.localPosition.y, playerTransform.localPosition.z);
        }
        else if (playerTransform.localPosition.x < -moveLimit)
        {
            playerTransform.localPosition = new Vector3(-moveLimit, playerTransform.localPosition.y, playerTransform.localPosition.z);
        }

        if (touchControls.MoveValue == Vector2.zero)
        {
            rigid.velocity = Vector3.zero;
        }
    }



    public IEnumerator MoveNextPath()
    {
        playerAgent.SetDestination(roadPaths[currentPathIndex].position);

        while (true)
        {
            if (Vector3.Distance(transform.position, roadPaths[currentPathIndex].position) < 5f)
            {
                if (currentPathIndex != roadPaths.Count - 1)
                {
                    currentPathIndex++;
                    playerAgent.SetDestination(roadPaths[currentPathIndex].position);
                    Debug.Log("DISTANCE: "+Vector3.Distance(transform.position, roadPaths[currentPathIndex].position));
                }
            }
            yield return null;
        }
    }
}