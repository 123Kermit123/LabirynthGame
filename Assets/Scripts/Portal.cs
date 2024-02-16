using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    private GameObject player;
    private PortalTeleport portalTeleport;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        portalTeleport = portalCollider.GetComponent<PortalTeleport>();
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.portalCollider;
    }

}
