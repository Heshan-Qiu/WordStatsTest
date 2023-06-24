using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WordStats;

namespace WordStatsTest
{
    [TestClass]
    public class WordStatsTests
    {
        [TestMethod]
        public void AddWord_AddsWordToDictionary()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            wordStats.AddWord("apple", 10);

            // Assert
            var words = wordStats.GetWords();
            Assert.AreEqual(1, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
        }

        [TestMethod]
        public void AddWords_AddsWordsToDictionary()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 } });

            // Assert
            var words = wordStats.GetWords();
            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("banana", words.Last().Key);
            Assert.AreEqual(5, words.Last().Value);
        }

        [TestMethod]
        public void AddCharacter_AddsCharacterToDictionary()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            wordStats.AddCharacter('a', 10);

            // Assert
            var characters = wordStats.GetCharacters();
            Assert.AreEqual(1, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
        }

        [TestMethod]
        public void AddCharacters_AddsCharactersToDictionary()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'b', 5 } });

            // Assert
            var characters = wordStats.GetCharacters();
            Assert.AreEqual(2, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('b', characters.Last().Key);
            Assert.AreEqual(5, characters.Last().Value);
        }

        [TestMethod]
        public void GetWords_ReturnsWords()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);

            // Act
            var words = wordStats.GetWords();

            // Assert
            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("banana", words.Last().Key);
            Assert.AreEqual(5, words.Last().Value);
        }

        [TestMethod]
        public void GetCharacters_ReturnsCharacters()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some characters
            wordStats.AddCharacter('a', 10);
            wordStats.AddCharacter('b', 5);

            // Act
            var characters = wordStats.GetCharacters();

            // Assert
            Assert.AreEqual(2, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('b', characters.Last().Key);
            Assert.AreEqual(5, characters.Last().Value);
        }

        [TestMethod]
        public void GetLargestFiveWords_ReturnsEmptyListWhenNoWordsAdded()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            var largestWords = wordStats.GetLargestFiveWords();

            // Assert
            Assert.AreEqual(0, largestWords.Count());
        }

        [TestMethod]
        public void GetLargestFiveWords_ReturnsLessThanFiveWordsWhenLessThanFiveWordsAdded()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);

            // Act
            var largestWords = wordStats.GetLargestFiveWords();

            // Assert
            Assert.AreEqual(2, largestWords.Count());
        }

        [TestMethod]
        public void GetLargestFiveWords_ReturnsLargestFiveWords()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);
            wordStats.AddWord("pineapple", 15);
            wordStats.AddWord("elderberry", 20);
            wordStats.AddWord("fig", 25);
            wordStats.AddWord("kiwi", 30);

            // Act
            var largestWords = wordStats.GetLargestFiveWords();

            // Assert
            Assert.AreEqual(5, largestWords.Count());
            Assert.AreEqual("elderberry", largestWords.First());
            Assert.AreEqual("pineapple", largestWords.Skip(1).First());
            Assert.AreEqual("banana", largestWords.Skip(2).First());
            Assert.AreEqual("apple", largestWords.Skip(3).First());
            Assert.AreEqual("kiwi", largestWords.Skip(4).First());
        }

        [TestMethod]
        public void GetSmallestFiveWords_ReturnsEmptyListWhenNoWordsAdded()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            var smallestWords = wordStats.GetSmallestFiveWords();

            // Assert
            Assert.AreEqual(0, smallestWords.Count());
        }

        [TestMethod]
        public void GetSmallestFiveWords_ReturnsLessThanFiveWordsWhenLessThanFiveWordsAdded()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);

            // Act
            var smallestWords = wordStats.GetSmallestFiveWords();

            // Assert
            Assert.AreEqual(2, smallestWords.Count());
        }

        [TestMethod]
        public void GetSmallestFiveWords_ReturnsSmallestFiveWords()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);
            wordStats.AddWord("pineapple", 15);
            wordStats.AddWord("elderberry", 20);
            wordStats.AddWord("fig", 25);
            wordStats.AddWord("kiwi", 30);

            // Act
            var smallestWords = wordStats.GetSmallestFiveWords();

            // Assert
            Assert.AreEqual(5, smallestWords.Count());
            Assert.AreEqual("fig", smallestWords.First());
            Assert.AreEqual("kiwi", smallestWords.Skip(1).First());
            Assert.AreEqual("apple", smallestWords.Skip(2).First());
            Assert.AreEqual("banana", smallestWords.Skip(3).First());
            Assert.AreEqual("pineapple", smallestWords.Skip(4).First());
        }

        [TestMethod]
        public void GetMostFrequentTenWords_ReturnsEmptyListWhenNoWordsAdded()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            var mostFrequentWords = wordStats.GetMostFrequentTenWords();

            // Assert
            Assert.AreEqual(0, mostFrequentWords.Count());
        }

        [TestMethod]
        public void GetMostFrequentTenWords_ReturnsLessThanTenWordsWhenLessThanTenWordsAdded()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);

            // Act
            var mostFrequentWords = wordStats.GetMostFrequentTenWords();

            // Assert
            Assert.AreEqual(2, mostFrequentWords.Count());
        }

        [TestMethod]
        public void GetMostFrequentTenWords_ReturnsMostFrequentTenWords()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);
            wordStats.AddWord("pineapple", 15);
            wordStats.AddWord("elderberry", 20);
            wordStats.AddWord("fig", 25);
            wordStats.AddWord("kiwi", 30);
            wordStats.AddWord("mango", 35);
            wordStats.AddWord("orange", 40);
            wordStats.AddWord("pear", 45);
            wordStats.AddWord("strawberry", 50);
            wordStats.AddWord("watermelon", 55);

            // Act
            var mostFrequentWords = wordStats.GetMostFrequentTenWords();

            // Assert
            Assert.AreEqual(10, mostFrequentWords.Count());
            Assert.AreEqual(KeyValuePair.Create("watermelon", 55), mostFrequentWords.First());
            Assert.AreEqual(KeyValuePair.Create("strawberry", 50), mostFrequentWords.Skip(1).First());
            Assert.AreEqual(KeyValuePair.Create("pear", 45), mostFrequentWords.Skip(2).First());
            Assert.AreEqual(KeyValuePair.Create("orange", 40), mostFrequentWords.Skip(3).First());
            Assert.AreEqual(KeyValuePair.Create("mango", 35), mostFrequentWords.Skip(4).First());
            Assert.AreEqual(KeyValuePair.Create("kiwi", 30), mostFrequentWords.Skip(5).First());
            Assert.AreEqual(KeyValuePair.Create("fig", 25), mostFrequentWords.Skip(6).First());
            Assert.AreEqual(KeyValuePair.Create("elderberry", 20), mostFrequentWords.Skip(7).First());
            Assert.AreEqual(KeyValuePair.Create("pineapple", 15), mostFrequentWords.Skip(8).First());
            Assert.AreEqual(KeyValuePair.Create("apple", 10), mostFrequentWords.Skip(9).First());
        }

        [TestMethod]
        public void ToJsonString_ReturnsEmptyResultWhenNoWordsAdded()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Act
            var jsonString = wordStats.ToJsonString();

            // Assert
            Assert.AreEqual("{\"LargestFiveWords\":[],\"SmallestFiveWords\":[],\"MostFrequentTenWords\":[],\"Characters\":[]}", jsonString);
        }

        [TestMethod]
        public void ToJsonString_ReturnsJsonStringWithWords()
        {
            // Arrange
            IWordStats wordStats = new WordStatsDictionaryImpl();

            // Add some words
            wordStats.AddWord("apple", 10);
            wordStats.AddWord("banana", 5);
            wordStats.AddWord("pineapple", 15);
            wordStats.AddWord("elderberry", 20);
            wordStats.AddWord("fig", 25);
            wordStats.AddWord("kiwi", 30);
            wordStats.AddWord("mango", 35);
            wordStats.AddWord("orange", 40);
            wordStats.AddWord("pear", 45);
            wordStats.AddWord("strawberry", 50);
            wordStats.AddWord("watermelon", 55);

            // Act
            var jsonString = wordStats.ToJsonString();

            // Assert
            Assert.AreEqual("{\"LargestFiveWords\":[\"elderberry\",\"strawberry\",\"watermelon\",\"pineapple\",\"banana\"],\"SmallestFiveWords\":[\"fig\",\"kiwi\",\"pear\",\"apple\",\"mango\"],\"MostFrequentTenWords\":[{\"Key\":\"watermelon\",\"Value\":55},{\"Key\":\"strawberry\",\"Value\":50},{\"Key\":\"pear\",\"Value\":45},{\"Key\":\"orange\",\"Value\":40},{\"Key\":\"mango\",\"Value\":35},{\"Key\":\"kiwi\",\"Value\":30},{\"Key\":\"fig\",\"Value\":25},{\"Key\":\"elderberry\",\"Value\":20},{\"Key\":\"pineapple\",\"Value\":15},{\"Key\":\"apple\",\"Value\":10}],\"Characters\":[]}", jsonString);
        }
    }
}