﻿using NueGames.Card;
using NueGames.Characters;
using NueGames.Combat;
using NueGames.Data.Collection;
using NueGames.Enums;

namespace NueGames.Action
{
    public class DamageAction : GameActionBase
    {
        private DamageInfo damageInfo;
        
        public DamageAction()
        {
            FxType = FxType.Attack;
            AudioActionType = AudioActionType.Attack;
        }
        
        public override void SetValue(CardActionParameters parameters)
        {
            CardActionData data = parameters.CardActionData;
            Duration = parameters.CardActionData.ActionDelay;
            
            SetValue(new DamageInfo(parameters.Value, parameters.SelfCharacter),
                parameters.TargetCharacter);
        }
        
        public void SetValue(DamageInfo info, CharacterBase target)
        {
            damageInfo = info;
            Target = target;

            HasSetValue = true;
        }
        
        public override void DoAction()
        {
            CheckHasSetValue();
            if (IsTargetNull()) return;

            int value = CombatCalculator.GetDamageValue(damageInfo.Value, damageInfo.SelfCharacter, Target);
            
            Target.CharacterStats.Damage(value);

            PlayFx();
            PlaySpawnTextFx($"{value}");
            PlayAudio();
        }
    }
}