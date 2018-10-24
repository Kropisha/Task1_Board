// <copyright file="IBoard.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task1_Board
{
    /// <summary>
    /// Set the  obvious interface for every board
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Gets or sets the height of board
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Gets or sets the width of board
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets or sets cells for board
        /// </summary>
        Cell[,] CellArray { get; set; }

        /// <summary>
        /// The indexer for cell on board
        /// </summary>
        /// <param name="_width">current width</param>
        /// <param name="_height">current height</param>
        /// <returns>current cell on board</returns>
        Cell this[int _width, int _height] { get; set; }
    }
}