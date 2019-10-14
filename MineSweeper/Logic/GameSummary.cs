using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MineSweeper.Logic
{
    internal class GameSummary
    {
        public bool Won { get; }
        private int SecondsElapsed { get; }
        private int FlippedCount { get; }
        private int CorrectlyFlaggedCount { get; }
        private int RedundantFlags { get; }
        private GameSettings GameSettings { get; }

        private GameSummary(bool won,
            int flippedCount,
            int correctlyFlaggedCount,
            int redundantFlags,
            int secondsElapsed,
            GameSettings gameSettings)
        {
            Won = won;
            SecondsElapsed = secondsElapsed;
            GameSettings = gameSettings;
            FlippedCount = flippedCount;
            CorrectlyFlaggedCount = correctlyFlaggedCount;
            RedundantFlags = redundantFlags;
        }

        private static GameSummary CreateGameSummary(bool won, GameSettings gameSettings, Board board, int flippedCount, int secondsElapsed)
        {
            int correctlyFlaggedCount = board.AllTiles
                .Count(tile => tile.State == TileState.CorrectlyFlagged);
            int redundantFlags = board.AllTiles
                .Count(tile => tile.State == TileState.Flagged);

            return new GameSummary(won,
                flippedCount,
                correctlyFlaggedCount,
                redundantFlags,
                secondsElapsed,
                gameSettings);
        }

        public static GameSummary WonGameSummary(GameSettings gameSettings, Board board, int flippedCount, int secondsElapsed)
        {
            return CreateGameSummary(true, gameSettings, board, flippedCount, secondsElapsed);
        }

        public static GameSummary LostGameSummary(GameSettings gameSettings, Board board, int flippedCount, int secondsElapsed)
        {
            return CreateGameSummary(false, gameSettings, board, flippedCount, secondsElapsed);
        }

        public IEnumerable<(string description, string value)> GetSummaryRows()
        {
            yield return ("Size", $"{GameSettings.Columns} x {GameSettings.Rows}");
            yield return ("Total Mines", GameSettings.MinesCount.ToString());
            yield return (PascalToSentence(nameof(SecondsElapsed)), SecondsElapsed.ToString());
            yield return ("Flagged", $"{CorrectlyFlaggedCount}/{GameSettings.MinesCount}");
            yield return ("Flipped", $"{FlippedCount}/{GameSettings.TilesToBeFlippedCount}");
            yield return (PascalToSentence(nameof(RedundantFlags)), RedundantFlags.ToString());
        }

        private static string PascalToSentence(string pascalCaseString) =>
            Regex.Replace(pascalCaseString, "(\\B[A-Z])", " $1");
    }
}