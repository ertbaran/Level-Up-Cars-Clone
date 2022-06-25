using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionControl : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    int enemyLevelFactor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ChangeLevel(-1);
        }

        if (other.gameObject.CompareTag("LevelUp"))
        {
            GameManager.Instance.ChangeLevel(1);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("CarNPC"))
        {
            enemyLevelFactor = other.gameObject.GetComponent<EnemyManager>().levelFactor;
            if (enemyLevelFactor <= GameManager.Instance.currentLevel)
            {
                GameManager.Instance.ChangeLevel(enemyLevelFactor);
            }
            else
            {
                GameManager.Instance.GameOver();
            }
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            winPanel.SetActive(true);
        }
    }
}
