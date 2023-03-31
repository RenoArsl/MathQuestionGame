﻿using NueGames.Card;
using NueGames.Data.Collection;
using NueGames.Enums;
using UnityEngine;

namespace NueGames.Action
{
    /// <summary>
    /// 獲得瑪娜
    /// </summary>
    public class EarnManaAction : GameActionBase
    {
        public EarnManaAction()
        {
            FxType = FxType.Buff;
            AudioActionType = AudioActionType.Power;
        }

        public override void SetValue(ActionParameters parameters)
        {
            ActionData data = parameters.ActionData;
            Duration = parameters.ActionData.ActionDelay;
            
            SetValue(Amount);
        }

        public void SetValue(int earnMana)
        {
            Amount = earnMana;
            
            HasSetValue = true;
        }
        
        /// <summary>
        /// 執行遊戲行為的功能
        /// </summary>
        public override void DoAction()
        {
            CheckHasSetValue();
            
            if (CombatManager != null)
                CombatManager.IncreaseMana(Mathf.RoundToInt(Amount));
            else
                Debug.LogError("There is no CombatManager");

            PlayFx();
            PlayAudio();
        }
    }
}