using System.Collections;
using System.Collections.Generic;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public UnityEntity entity;


    [SerializeField] private float stoppingDistance;
    [SerializeField] private Vector3 targetPosiiton;

    [Button]
    void Test(Vector3 position)
    {
        this.targetPosiiton = position;
        StopAllCoroutines();
        StartCoroutine(MoveRoutine());
    }


    private IEnumerator MoveRoutine()
    {
        var period = new WaitForFixedUpdate();

        float time = 0;

        Debug.Log($"MoveRoutine");
        
        while (time < 3f)
        {
            this.DoMove();
            yield return null;
            time += Time.deltaTime;
        }
    }

    private void DoMove()
    {
        var myPosition = entity.Get<IComponent_GetPosition>().Position;
        var distanceVector = this.targetPosiiton - myPosition;

        var isReached = distanceVector.sqrMagnitude <= this.stoppingDistance * this.stoppingDistance;
        
        Debug.Log($"Do isReached: {isReached}");

        
        if (!isReached)
        {
            var moveDirection = distanceVector.normalized;
            Debug.Log($"Do isReached: {moveDirection}");
            this.entity.Get<IComponent_MoveInDirection>().Move(moveDirection);
        }
        else
        {
            Debug.Log("Position Reached");
        }
    }
}