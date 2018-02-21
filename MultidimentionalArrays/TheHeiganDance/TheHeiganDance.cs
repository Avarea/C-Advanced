using System;
using System.Linq;

namespace TheHeiganDance
{
    class TheHeiganDance
    {
        static void Main()
        {
            double heigan = 3000000;

            int player = 18500;
            bool hasPlague = false;
            string lastUsedSpellOnPlayer = "";
            Position playerPosition = new Position(7, 7);

            double playerDamage = double.Parse(Console.ReadLine());

            while (true)
            {
                GetHitDetails(out Spell spell, out int row, out int col);

                heigan -= playerDamage;

                if (hasPlague)
                {
                    player -= new Cloud().Damage;
                    hasPlague = false;
                }

                if (player <= 0 || heigan <= 0)
                {
                    break;
                }

                if (IsInDanger(playerPosition, row, col))
                {
                    Move(playerPosition, row, col);
                }

                if (IsInDanger(playerPosition, row, col))
                {
                    player -= spell.Damage;
                    if (spell.Name == "Cloud")
                    {
                        hasPlague = true;
                        lastUsedSpellOnPlayer = "Plague Cloud";
                    }
                    else
                    {
                        lastUsedSpellOnPlayer = "Eruption";
                    }
                }

                if (player <= 0)
                {
                    break;
                }
            }
            Console.WriteLine(heigan <= 0 ? "Heigan: Defeated!" : $"Heigan: {heigan:F2}");
            if (player <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastUsedSpellOnPlayer}");
            }
            else
            {
                Console.WriteLine($"Player: {player}");
            }
            Console.WriteLine($"Final position: {playerPosition.Row}, {playerPosition.Col}");
        }

        public static void Move(Position playerPosition, int row, int col)
        {
            if (playerPosition.Row > 0 && playerPosition.Row == row - 1)
            {
                playerPosition.Row--;
            }
            else if (playerPosition.Row < 14 && playerPosition.Row == row + 1)
            {
                playerPosition.Row++;
            }
            else if (playerPosition.Col > 0 && playerPosition.Col == col - 1)
            {
                playerPosition.Col--;
            }
            else if (playerPosition.Col < 14 && playerPosition.Col == col + 1)
            {
                playerPosition.Col++;
            }
        }

        public static bool IsInDanger(Position playerPosition, int row, int col)
        {
            var danger = playerPosition.Row >= row - 1 && playerPosition.Row <= row + 1 &&
                         playerPosition.Col >= col - 1 && playerPosition.Col <= col + 1;
            if (danger)
            {
                return true;
            }

            return false;
        }

        private static void GetHitDetails(out Spell spell, out int row, out int col)
        {
            spell = null;

            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string spellName = input[0];
            if (spellName == "Cloud")
            {
                spell = new Cloud();
            }
            else if (spellName == "Eruption")
            {
                spell = new Eruption();
            }

            row = int.Parse(input[1]);
            col = int.Parse(input[2]);
        }
    }

    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    public class Spell
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Spell(string name, int damage)
        {
            this.Name = name;
            this.Damage = damage;
        }
    }

    public class Cloud : Spell
    {
        public Cloud() : base("Cloud", 3500)
        {
            
        }
    }

    public class Eruption : Spell
    {
        public Eruption() : base("Eruption", 6000)
        {

        }
    }
}
