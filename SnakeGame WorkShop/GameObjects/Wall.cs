﻿namespace SnakeGame.GameObjects
{
    using System;
    using System.Collections.Generic;

    public class Wall : Point
    {
        private int playerPoints;

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
        }

        private const char wallSymbol = '\u25A0';

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);
            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.LeftX == 0
                   || snake.LeftX == this.LeftX - 1
                   || snake.TopY == 0
                   || snake.TopY == this.TopY;
        }

        public void AddPoints(Queue<Point> snakeParts)
        {
            this.playerPoints = snakeParts.Count - 6;
        }

        public void PlayerInfo()
        {
            Console.SetCursorPosition(this.LeftX + 3, 0);
            Console.Write($"Player points: {this.playerPoints}");
            Console.SetCursorPosition(this.LeftX + 3, 1);
            Console.Write($"Player level: {this.playerPoints / 10}");
        }
    }
}