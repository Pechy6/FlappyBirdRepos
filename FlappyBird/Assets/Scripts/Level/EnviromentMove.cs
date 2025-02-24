using UnityEngine;
using UnityEngine.Serialization;

public class EnviromentMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [FormerlySerializedAs("isMoving")] public bool obstaclesIsMoving = true;

    void Update()
    {
        if (obstaclesIsMoving)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}