using System;
using System.Collections.Generic;

namespace BTVN1
{
    internal class Program
    {
        abstract class Character
        {
            public int PosX { get; set; }
            public int PosY { get; set; }
            public int Damage { get; protected set; }
            public int RangeAttack { get; protected set; }

            public abstract void Move(char direction = ' ');
            public abstract void TakeDamage(int damage);
            public abstract void Attack(Tile[,] grid);

            protected Character CheckRangeAttack(Tile[,] grid)
            {
                for (int x = -RangeAttack; x <= RangeAttack; x++)
                {
                    for (int y = -RangeAttack; y <= RangeAttack; y++)
                    {
                        int targetX = PosX + x;
                        int targetY = PosY + y;

                        if (targetX >= 0 && targetY >= 0 && targetX < grid.GetLength(0) && targetY < grid.GetLength(1))
                        {
                            Tile targetTile = grid[targetX, targetY];
                            if (targetTile.IsOccupied() && targetTile.Character != null && targetTile.Character != this)
                            {
                                return targetTile.Character;
                            }
                        }
                    }
                }
                return null;
            }
        }

        class Enemy : Character
        {
            private Random random = new Random();

            public Enemy(int posX, int posY, int damage, int rangeAttack)
            {
                PosX = posX;
                PosY = posY;
                Damage = damage;
                RangeAttack = rangeAttack;
            }

            public override void Move(char direction = ' ')
            {
                int moveX = random.Next(-1, 2);
                int moveY = random.Next(-1, 2);
                PosX += moveX;
                PosY += moveY;
            }

            public override void TakeDamage(int damage)
            {
                Console.WriteLine($"Enemy at ({PosX}, {PosY}) takes {damage} damage!");
            }

            public override void Attack(Tile[,] grid)
            {
                Character target = CheckRangeAttack(grid);
                if (target != null)
                {
                    Console.WriteLine($"Enemy attacks Player at ({target.PosX}, {target.PosY}) for {Damage} damage!");
                    target.TakeDamage(Damage);
                }
            }
        }

        class Player : Character
        {
            public Weapon CurrentWeapon { get; private set; }

            public Player(int posX, int posY, Weapon weapon)
            {
                PosX = posX;
                PosY = posY;
                CurrentWeapon = weapon;
                Damage = weapon.Attack;
                RangeAttack = weapon.RangeAttack;
            }

            public override void Move(char direction = ' ')
            {
                switch (direction)
                {
                    case 'W': PosY -= 1; break;
                    case 'A': PosX -= 1; break;
                    case 'S': PosY += 1; break;
                    case 'D': PosX += 1; break;
                    default: break;
                }
            }

            public override void TakeDamage(int damage)
            {
                Console.WriteLine($"Player takes {damage} damage!");
            }

            public override void Attack(Tile[,] grid)
            {
                Character target = CheckRangeAttack(grid);
                if (target != null)
                {
                    Console.WriteLine($"Player attacks Enemy at ({target.PosX}, {target.PosY}) for {Damage} damage!");
                    target.TakeDamage(Damage);
                }
            }
        }

        class Weapon
        {
            public string Name { get; private set; }
            public int Attack { get; private set; }
            public int RangeAttack { get; private set; }

            public Weapon(string name, int attack, int rangeAttack)
            {
                Name = name;
                Attack = attack;
                RangeAttack = rangeAttack;
            }
        }

        class Tile
        {
            public Character Character { get; set; }
            public int PosX { get; private set; }
            public int PosY { get; private set; }

            public Tile(int posX, int posY)
            {
                PosX = posX;
                PosY = posY;
                Character = null;
            }

            public bool IsOccupied()
            {
                return Character != null;
            }
        }

        class GridManager
        {
            public int xWide { get; private set; }
            public int yHigh { get; private set; }
            public List<Enemy> Enemies { get; private set; }
            public Player Player { get; set; } // Đã đổi thành public set
            public Tile[,] Grid { get; private set; }

            public GridManager(int xWide, int yHigh)
            {
                this.xWide = xWide;
                this.yHigh = yHigh;
                Enemies = new List<Enemy>();
                Grid = new Tile[xWide, yHigh];
                for (int x = 0; x < xWide; x++)
                {
                    for (int y = 0; y < yHigh; y++)
                    {
                        Grid[x, y] = new Tile(x, y);
                    }
                }
            }

            public void SpawnTile(int x, int y)
            {
                Grid[x, y] = new Tile(x, y);
            }

            public void UpdateGrid()
            {
                foreach (var tile in Grid)
                {
                    tile.Character = null;
                }
                foreach (var enemy in Enemies)
                {
                    Grid[enemy.PosX, enemy.PosY].Character = enemy;
                }
                if (Player != null)
                {
                    Grid[Player.PosX, Player.PosY].Character = Player;
                }
            }
        }

        class GameManager
        {
            private GridManager gridManager;
            private bool isPlayerTurn = true;

            public GameManager(int xWide, int yHigh)
            {
                gridManager = new GridManager(xWide, yHigh);

                // Tạo vũ khí cho người chơi
                Weapon weapon = new Weapon("Sword", 10, 2);

                // Gán giá trị trực tiếp cho Player
                gridManager.Player = new Player(0, 0, weapon);

                // Tạo quái và thêm vào danh sách
                gridManager.Enemies.Add(new Enemy(5, 5, 5, 1));
            }

            public void StartBattle()
            {
                while (true)
                {
                    gridManager.UpdateGrid();
                    if (isPlayerTurn)
                    {
                        TurnPlayer();
                    }
                    else
                    {
                        TurnEnemy();
                    }
                    isPlayerTurn = !isPlayerTurn;
                }
            }

            private void TurnPlayer()
            {
                Console.WriteLine("Player's turn. Move (W/A/S/D) or attack:");
                char input = Console.ReadKey().KeyChar;
                gridManager.Player.Move(input);
                gridManager.Player.Attack(gridManager.Grid);
            }

            private void TurnEnemy()
            {
                Console.WriteLine("\nEnemy's turn.");
                foreach (var enemy in gridManager.Enemies)
                {
                    enemy.Move();
                    enemy.Attack(gridManager.Grid);
                }
            }
        }

        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager(10, 10);
            gameManager.StartBattle();
        }
    }
}
