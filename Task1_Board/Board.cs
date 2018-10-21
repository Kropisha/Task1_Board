// <copyright file="Board.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task1_Board
{
    using System;

    /// <summary>
    /// This class represent a board
    /// </summary>
    internal class Board
    {
        /// <summary>
        /// current width
        /// </summary>
        private int width;

        /// <summary>
        /// current height
        /// </summary>
        private int height;

        /// <summary>
        /// the array of cell
        /// </summary>
        private Cell[,] cellArray;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class
        /// </summary>
        public Board()
        {
            this.Width = 2;
            this.Height = 2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class
        /// </summary>
        /// <param name="width">width of board</param>
        /// <param name="height">height of board</param>
        public Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.cellArray = new Cell[this.Width, this.Height];
        }

        /// <summary>
        /// Gets or sets the width of board
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of board
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// The indexer for cell on board
        /// </summary>
        /// <param name="_width">current width</param>
        /// <param name="_height">current height</param>
        /// <returns>current cell on board</returns>
        public Cell this[int _width, int _height]
        {
            get
            {
                if (_width <= this.width && _height <= this.height)
                {
                    return this.cellArray[_width, _height];
                }

                throw new IndexOutOfRangeException(); 
            }

            set
            {
                this.cellArray[_width, _height] = value;
            }
        }
    }
}
