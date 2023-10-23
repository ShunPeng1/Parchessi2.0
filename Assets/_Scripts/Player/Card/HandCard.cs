﻿
using System;
using System.Threading.Tasks;
using _Scripts.Player.Dice;
using _Scripts.Player.Pawn;
using _Scripts.Scriptable_Objects;
using _Scripts.Simulation;
using Shun_Card_System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandCard : PlayerEntity, ITargeter
{
    protected PlayerCardHand PlayerCardHand;
    public CardDescription CardDescription { get; protected set; }

    

    public void Initialize(PlayerCardHand playerCardHand, CardDescription cardDescription, int containerIndex, ulong ownerClientID)
    {
        PlayerCardHand = playerCardHand;
        CardDescription = cardDescription;
        Initialize(containerIndex, ownerClientID);
    }



    public virtual SimulationPackage ExecuteTargeter<TTargetee>(TTargetee targetee) where TTargetee : ITargetee
    {
        
        var package = new SimulationPackage();
        
        
        if (targetee is MapPawn playerPawn)
        {
            package.AddToPackage(() =>
            {
            
                // Inherit this class and write Card effect
                Debug.Log(name + " Card drag to Pawn " + playerPawn.name);
                PlayerCardHand.PlayCard(this);

                Destroy();
                
            });
        }
        
        
        return package;
    }

    public virtual SimulationPackage Discard()
    {
        var package = new SimulationPackage();
        package.AddToPackage(() =>
        {
            Debug.Log("Discard Card");
            Destroy();
        });
        return package;
    }

    protected virtual void Destroy()
    {
        if (TryGetComponent<BaseDraggableObject>(out var baseDraggableObject))
            baseDraggableObject.Destroy();
        Destroy(gameObject);
    }
}
