using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float MaxHealth = 100;
    public float RotationSpeed = 10;
    [Range(0,1)]public float HealthDropChance = 1;
    public float ShootDelay = 0.8f;
    public float MoveSpeed = 3.5f;
    
    private void Start()
    {
        GetComponent<Health>().MaxHealth = MaxHealth;
        GetComponent<EnemyController>().OrientationSpeed = RotationSpeed;
        GetComponent<EnemyController>().DropRate = HealthDropChance;
        GetComponentInChildren<WeaponController>().DelayBetweenShots = ShootDelay;
        GetComponent<NavMeshAgent>().speed = MoveSpeed;
        
    }
}
