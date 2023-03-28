﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NueGames.Card;
using NueGames.Characters;
using NueGames.Data.Characters;
using NueGames.Data.Collection;
using NueGames.Enums;
using UnityEngine;

namespace NueGames.Action
{
    public static class GameActionGenerator
    {
        private static Dictionary<string, Type> _gameActionDict = new Dictionary<string, Type>();

        static GameActionGenerator()
        {
            SetUpGameActionClasses();
        }

        private static void SetUpGameActionClasses()
        {
            IEnumerable<Type> gameActionClasses = Assembly.GetAssembly(typeof(GameActionBase)).GetTypes()
                .Where(t => typeof(GameActionBase).IsAssignableFrom(t) && t.IsAbstract == false);

            foreach (Type gameActionClass in gameActionClasses)
            {
                _gameActionDict.Add(gameActionClass.Name, gameActionClass);
            }
        }
        
        public static List<GameActionBase> GetGameActions(CardData cardData, List<ActionData> cardActionDataList, CharacterBase self,
            CharacterBase target)
        {
            List<GameActionBase> gameActionBases = new List<GameActionBase>();
            foreach (var playerAction in cardActionDataList)
            {
                ActionParameters actionParameters = new ActionParameters(
                    playerAction.ActionValue,
                    target,
                    self,
                    playerAction,
                    cardData
                );

                GameActionBase gameActionBase = GetGameAction(playerAction.GameActionType, actionParameters);
                gameActionBases.Add(gameActionBase);
            }

            return gameActionBases;
        }

        public static GameActionBase GetGameAction(GameActionType actionType, ActionParameters actionParameters)
        {
            GameActionBase gameActionBase = GetGameAction(actionType);
            gameActionBase.SetValue(actionParameters);
            return gameActionBase;
        }

        private static GameActionBase GetGameAction(GameActionType actionType)
        {
            string gameActionName = actionType.ToString() + "Action";

            if (_gameActionDict.ContainsKey(gameActionName))
            {
                return Activator.CreateInstance(_gameActionDict[gameActionName]) as GameActionBase;
            }
            
            Debug.LogError($"沒有 GameAction {gameActionName} 的 Class");
            return null;
        }
    }
}