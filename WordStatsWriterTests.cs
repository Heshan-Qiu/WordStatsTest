using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WordStats;

namespace WordStatsTest
{
    [TestClass]
    public class WordStatsWriterTests
    {
        [TestMethod]
        public void WriteStats_WithNullStats_ThrowsArgumentNullException()
        {
            // Arrange
            var writer = new WordStatsWriterConsoleImpl();

            // Act
            Action action = () => writer.WriteStats(null);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}