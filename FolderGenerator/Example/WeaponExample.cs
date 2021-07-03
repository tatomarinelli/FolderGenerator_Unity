using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponExTemplate.asset", menuName = "Folder Structure Generator/Create Weapon Example Template", order = 1)]
public class WeaponExample : ScriptableObject
{
    [Header("Manager")]
    public uint id;
    public bool state;

    #region Values
    [Header("Values")]
    [SerializeField] private float scaleValuesBy = 100f;

    // Shoot rate - NOT Scaled.//
    [SerializeField, Range(0.00f, 25.00f)] private float shootCooldown = 1f;
    private float currentCooldown;

    // Recoil Force //
    [SerializeField, Range(0.00f, 5.00f)] private float recoil = 1.8f;
    private float s_recoil { get { return recoil * scaleValuesBy; } }
    // ================================================================ //

    // Kickback Force //
    [SerializeField, Range(0.000f, 100f)] private float kickback = 0.75f;
    private float s_kickback { get { return kickback * scaleValuesBy; } }
    // ================================================================ //

    // Hip restore speed //
    [SerializeField, Range(0.00f, 10f)] private float hipRestoreSpeed = 3f;
    private float s_hipRestoreSpeed { get { return hipRestoreSpeed * scaleValuesBy; } }
    // ================================================================ //

    // ADS restore speed //
    [SerializeField, Range(0.00f, 10f)] private float adsRestoreSpeed = 8f;
    private float s_adsRestoreSpeed { get { return adsRestoreSpeed * scaleValuesBy; } }
    // ================================================================ //
    #endregion

        // Shoot //
    [Header("Shoot")]
    [SerializeField] private Transform rayOrigin;
    Ray ray;
    RaycastHit hitInfo;
        // FXs
    [Header("FXs")]
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private ParticleSystem metalHitFx;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private AudioSource shootSound;


    // --------------------------------------------------------------- //
    // --------------------------------------------------------------- //
}
