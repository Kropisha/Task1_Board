// <copyright file="ICell.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task1_Board
{
    /// <summary>
    /// Set the  obvious interface for every cell
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Gets or sets the color of cell
        /// </summary>
        Color CellColor { get; set; }

        /// <summary>
        /// Gets or sets the size of cell
        /// </summary>
        int Size { get; set; }
    }
}