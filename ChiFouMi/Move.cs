using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    public enum Move
    {
        Pierre = 1,
        Feuille = 2,
        Ciseaux = 3,
        Lézard = 4,
        Spock = 5,
    }

    internal static class MoveExtension
    {
        private static readonly Dictionary<Move, Move[]> BeatenDictionnary = new Dictionary<Move, Move[]>
        {
            { Move.Pierre,  new []{ Move.Feuille, Move.Spock } },
            { Move.Feuille, new []{ Move.Ciseaux, Move.Lézard } },
            { Move.Ciseaux, new []{ Move.Pierre,  Move.Spock } },
            { Move.Lézard,  new []{ Move.Pierre,  Move.Ciseaux } },
            { Move.Spock,   new []{ Move.Feuille, Move.Lézard } },
        };

        public static bool IsBeatenBy(this Move move, Move otherMove)
        {
            return BeatenDictionnary[move].Contains(otherMove);
        }
    }
}
