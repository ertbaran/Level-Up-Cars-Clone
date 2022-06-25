using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyManager : MonoBehaviour, IAIControl
{
    [SerializeField] NPCPool npcPool;
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] NavMeshAgent enemyAgent;
    [SerializeField] TMP_Text carLevelText;
    [SerializeField] List<Transform> roadPaths = new List<Transform>();
    [SerializeField] int currentPathIndex;
    public int levelFactor = 12;

    private void OnEnable()
    {
        currentPathIndex = playerManager.currentPathIndex + 2;
        transform.position = roadPaths[currentPathIndex - 1].position;
        StartCoroutine(MoveNextPath());
        carLevelText.text = levelFactor.ToString();
    }

    private void Update()
    {
        if (GameManager.Instance.currentLevel >= levelFactor)
        {
            carLevelText.color = Color.green;
        }
        else
        {
            carLevelText.color = Color.red;
        }
        Debug.Log(GameManager.Instance.currentLevel + " : " + levelFactor);
    }
    private void OnDisable()
    {
        Debug.Log("Disabled Enemy GameObject");
    }

    public IEnumerator MoveNextPath()
    {
        enemyAgent.SetDestination(roadPaths[currentPathIndex].position);

        while (true)
        {
            if (Vector3.Distance(transform.position, roadPaths[currentPathIndex].position) < 5f)
            {
                if (currentPathIndex != roadPaths.Count - 1)
                {
                    currentPathIndex++;
                    enemyAgent.SetDestination(roadPaths[currentPathIndex].position);
                    Debug.Log(Vector3.Distance(transform.position, roadPaths[currentPathIndex].position));
                }
            }
            yield return null;
        }
    }
}
