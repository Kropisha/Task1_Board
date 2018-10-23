// <copyright file="Cell.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>

namespace Task1_Board
{
    using System;

    /// <summary>
    /// This class represents a cell
    /// </summary>
    public class Cell
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
            this.CellColor = Color.Grey;
            this.Size = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class
        /// </summary>
        /// <param name="color">current color</param>
        /// <param name="size">size of cell</param>
        public Cell(Color color, int size)
        {
            if (size > 0 && size < 7)
            {
                this.CellColor = color;
                this.Size = size;
            }
            else
            {
                throw new ArgumentException("The value for cell is incorrect");
            }
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

        /// <summary>
        /// Gets or sets the color of cell
        /// </summary>
        public Color CellColor
        {
            get
            {
                return this.cellColor;
            }

            set
            {
                this.cellColor = value;
            }
        }
    }
}
