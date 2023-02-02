using System;

namespace Homework_08_Interaction.Components
{
    public interface IComponent_Battle
    {
        event Action<BattleOperation> OnStarted;

        event Action<BattleOperation> OnFinished;
        
        bool IsOnBattle { get; }

        bool CanStartBattle(BattleOperation operation);

        void StartBattle(BattleOperation operation);

        void StopBattle();
    }
}