﻿namespace NueGames.Enums
{
    /// <summary>
    /// 遊戲行為類型
    /// </summary>
    public enum GameActionType
    {
        // 1~10 傷害
        Damage = 1, 
        DamageAllEnemy = 2,
        DamageByQuestioning = 4,
        DamageByAllyPowerValue = 5,
        // 11~20 角色狀態
        ApplyPower = 11, 
        ApplyPowerToAllEnemy = 13,
        // 21~30 卡組相關
        EarnMana = 21,
        DrawCard = 22,
        Heal = 24,
        // 31~40 永久效果(結束戰鬥持續)
        IncreaseMaxHealth = 31,  
        // 41~50 其他系統
        EnterMathQuestioning = 41, 
        
    }

    /// <summary>
    /// 答題後觸發行為的類型
    /// </summary>
    public enum CardActionDataListType
    {
        Normal,
        Correct,
        Wrong
    }
}