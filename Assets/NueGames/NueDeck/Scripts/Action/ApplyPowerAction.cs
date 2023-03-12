﻿using NueGames.NueDeck.Scripts.Card;
using NueGames.NueDeck.Scripts.Characters;
using NueGames.NueDeck.Scripts.Combat;
using NueGames.NueDeck.Scripts.Data.Collection;
using NueGames.NueDeck.Scripts.Enums;
using UnityEngine;

namespace Assets.NueGames.NueDeck.Scripts.Action
{
    public class ApplyPowerAction : GameActionBase
    {
        private PowerType powerType;

        public ApplyPowerAction()
        {
            FxType = FxType.Buff;
            AudioActionType = AudioActionType.Power;
        }
        
        public override void SetValue(CardActionParameters cardActionParameters)
        {
            CardActionData data = cardActionParameters.CardActionData;
            Target = cardActionParameters.TargetCharacter;
            Duration = cardActionParameters.CardActionData.ActionDelay;
            powerType = data.PowerType;
            Value = data.ActionValue;
        }
        
        public override void DoAction()
        {
            if (!Target) return;
            
            Target.CharacterStats.ApplyPower(powerType,Mathf.RoundToInt(Value));
            
            PlayFx();
            PlayAudio();
        }
    }
}