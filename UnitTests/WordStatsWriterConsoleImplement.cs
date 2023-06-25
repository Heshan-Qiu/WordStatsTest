using WordStats.Implements;

namespace WordStatsTest
{
    [TestClass]
    public class WordStatsWriterConsoleImplementTests
    {
        [TestMethod]
        public void WriteStats_WithNullStats_ThrowsArgumentNullException()
        {
            // Arrange
            var writer = new WordStatsWriterConsoleImplement();

            // Act
            Action action = () => writer.WriteStats(null);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}