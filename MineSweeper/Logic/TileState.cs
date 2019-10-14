using System;
using System.Reflection;

namespace MineSweeper.Logic
{
    internal enum TileState
    {
        [InGameState] Unflipped,
        [InGameState] Clear,
        [InGameState] Flagged,
        [PostGameState] Boom,
        [PostGameState] UnflaggedMine,
        [PostGameState] CorrectlyFlagged
    }

    internal class InGameState : TileStateAttribute
    {
        public InGameState() : base(true)
        {
        }
    }

    internal class PostGameState : TileStateAttribute
    {
        public PostGameState() : base(false)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal abstract class TileStateAttribute : Attribute
    {
        public bool IsGameTimeState { get; }

        protected TileStateAttribute(bool isGameTimeState)
        {
            IsGameTimeState = isGameTimeState;
        }
    }

    internal static class TileStates
    {
        public static bool IsGameTimeState(this TileState state)
        {
            TileStateAttribute tileStateAttribute = GetTileStateAttribute(state);
            return tileStateAttribute.IsGameTimeState;
        }

        private static TileStateAttribute GetTileStateAttribute(TileState state)
        {
            return (TileStateAttribute)Attribute.GetCustomAttribute(ForValue(state), typeof(TileStateAttribute));
        }

        private static MemberInfo ForValue(TileState state)
        {
            return typeof(TileState).GetField(Enum.GetName(typeof(TileState), state));
        }
    }
}