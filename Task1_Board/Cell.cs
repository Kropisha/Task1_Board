// <copyright file="Cell.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task1_Board
{
    /// <summary>
    /// This class represents a cell
    /// </summary>
     internal class Cell
    {
        /// <summary>
        /// current color of cell
        /// </summary>
        private Color cellColor;

        /// <summary>
        /// current size of cell
        /// </summary>
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class
        /// </summary>
        public Cell()
        {
            this.cellColor = Color.Grey;
            this.Size = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class
        /// </summary>
        /// <param name="color">current color</param>
        /// <param name="size">size of cell</param>
        public Cell(Color color, int size)
        {
            this.cellColor = color;
            this.Size = size;
        }

        /// <summary>
        /// Current color of the cell on board
        /// </summary>
        public enum Color
        {
            /// <summary>
            /// grey color
            /// </summary>
            Grey,

            /// <summary>
            /// white color
            /// </summary>
            White
        }

        /// <summary>
        /// Gets or sets the size of cell
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }
    }
}
