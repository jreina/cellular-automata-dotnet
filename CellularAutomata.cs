using System;
using System.Collections.Generic;
using System.Linq;

namespace CellularAutomata
{
    /// <summary>A stateful 2D cellular automata.</summary>
    public class CellularAutomata
    {
        private int _rule;
        private int[] _ruleBinary;
        private int[] _currentGeneration;
        private Dictionary<string, int> _ruleSet;
        public CellularAutomata(int rule, int[] seed) {
            _rule = rule;
            _currentGeneration = seed;
            _ruleBinary = _convertToBinaryArray(rule);
            _ruleSet = _buildRuleSet(_ruleBinary);
        }
        /// <summary>Returns the next generation of cells.</summary>
        public int[] Next() {
            _currentGeneration = _evolve(_currentGeneration);
            return _currentGeneration;
        }
        private int[] _evolve(int[] row)
        {
            var newRow = new int[row.Length];
            newRow[0] = 0;
            newRow[row.Length - 1] = 0;
            for (var cell = 1; cell < row.Length - 1; cell++)
            {
                var condition = string.Format("{0}{1}{2}", row[cell - 1], row[cell], row[cell + 1]);
                newRow[cell] = _ruleSet[condition];
            }
            return newRow;
        }
        private Dictionary<string, int> _buildRuleSet(int[] ruleNum)
        {
            return new Dictionary<string, int>(){
                {"000", ruleNum[0]},
                {"001", ruleNum[1]},
                {"010", ruleNum[2]},
                {"011", ruleNum[3]},
                {"100", ruleNum[4]},
                {"101", ruleNum[5]},
                {"110", ruleNum[6]},
                {"111", ruleNum[7]}
            };
        }
        private int[] _convertToBinaryArray(int num)
        {
            var positions = Enumerable.Range(0, 8);
            var places = positions.Select(position =>
            {
                var pow = 8 - position - 1;
                var val = (int)Math.Pow(2, pow);
                if (num - val >= 0)
                {
                    num -= val;
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            return places.ToArray();
        }
    }
}