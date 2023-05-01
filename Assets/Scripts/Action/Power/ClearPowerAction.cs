﻿using NueGames.Card;
using NueGames.Characters;
using NueGames.Data.Collection;
using NueGames.Enums;
using UnityEngine;


namespace NueGames.Action
{
    /// <summary>
    /// 清除能力
    /// </summary>
    public class ClearPowerAction : GameActionBase
    {
        public override GameActionType ActionType => GameActionType.ClearPower;

        public ClearPowerAction()
        {
            FxType = FxType.Buff;
            AudioActionType = AudioActionType.Power;
        }
        
        
        /// <summary>
        /// 執行遊戲行為的功能
        /// </summary>
        public override void DoAction()
        {
            CheckHasSetValue();
            if (IsTargetNull()) return;
            
            Target.CharacterStats.ClearPower(powerType);
            
            PlayFx();
            PlayAudio();
        }
    }
}