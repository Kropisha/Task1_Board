using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_Board;

namespace Task1_BoardTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]

        public void GetBoard_CorrectValues_NewCorrectBoard()
        {
            //arrange
            int height = 5;
            int width = 8;
            UI user = new UI();

            //act
            Board board  = user.GetBoard(width, height);

            //assert
            Assert.IsNotNull(board);
            Assert.AreEqual(height, board.Height);
            Assert.AreEqual(width, board.Width);
            Assert.IsInstanceOfType(board, typeof(Board));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBoard_IncorrectValues_Exception()
        {
            //arrange
            int height = -5;
            int width = 0;
            UI user = new UI();

            //act
            Board board = user.GetBoard(width, height);
        }

        [TestMethod]
        public void GetCell_CorrectValues_NewCorrectCell()
        {
            //arrange
            int size = 3;
            Color color = Color.Grey;

            //act
            Cell currentCell = new Cell(color, size);

            //assert
            Assert.AreEqual(size,currentCell.Size);
            Assert.AreEqual(color, currentCell.CellColor);
            Assert.IsNotNull(currentCell);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCell_IncorrectValues_Exception()
        {
            //arrange
            int size = 22;
            Color color = Color.Grey;

            //act
            Cell currentCell = new Cell(color, size);
        }
    }
}
