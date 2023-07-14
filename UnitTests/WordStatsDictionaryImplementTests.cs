using WordStats.Implements;
using WordStats.Interfaces;

namespace WordStatsTest
{
    [TestClass]
    public class WordStatsDictionaryImplementTests
    {
        private IWordStats wordStats = new WordStatsDictionaryImplement();

        [TestMethod]
        public void AddWords_AddsWordsToDictionary()
        {
            // Act
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 } });

            // Assert
            var words = wordStats.GetWordsOrderByFrequencyDescending();
            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("banana", words.Last().Key);
            Assert.AreEqual(5, words.Last().Value);
        }

        [TestMethod]
        public void AddWords_AddsWordsToDictionaryWithCaseSensitive()
        {
            // Act
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 } });

            // Assert
            var words = wordStats.GetWordsOrderByFrequencyDescending();
            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("Apple", words.Last().Key);
            Assert.AreEqual(5, words.Last().Value);
        }

        [TestMethod]
        public void AddWords_AddsWordsToDictionaryWithCaseSensitiveAndNonLetterCharacters()
        {
            // Act
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 }, { " ", 2 }, { ".", 1 } });

            // Assert
            var words = wordStats.GetWordsOrderByFrequencyDescending();
            Assert.AreEqual(4, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("Apple", words.Skip(1).First().Key);
            Assert.AreEqual(5, words.Skip(1).First().Value);
            Assert.AreEqual(" ", words.Skip(2).First().Key);
            Assert.AreEqual(2, words.Skip(2).First().Value);
            Assert.AreEqual(".", words.Skip(3).First().Key);
            Assert.AreEqual(1, words.Skip(3).First().Value);
        }

        [TestMethod]
        public void AddWords_AddsWordsToDictionaryWithCaseSensitiveAndNonLetterCharactersAndNumbers()
        {
            // Act
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 }, { " ", 2 }, { ".", 1 }, { "123", 3 } });

            // Assert
            var words = wordStats.GetWordsOrderByFrequencyDescending();
            Assert.AreEqual(5, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("Apple", words.Skip(1).First().Key);
            Assert.AreEqual(5, words.Skip(1).First().Value);
            Assert.AreEqual("123", words.Skip(2).First().Key);
            Assert.AreEqual(3, words.Skip(2).First().Value);
            Assert.AreEqual(" ", words.Skip(3).First().Key);
            Assert.AreEqual(2, words.Skip(3).First().Value);
            Assert.AreEqual(".", words.Skip(4).First().Key);
            Assert.AreEqual(1, words.Skip(4).First().Value);
        }

        [TestMethod]
        public void AddCharacters_AddsCharactersToDictionary()
        {
            // Act
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'b', 5 } });

            // Assert
            var characters = wordStats.GetCharactersOrderByFrequencyDescending();
            Assert.AreEqual(2, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('b', characters.Last().Key);
            Assert.AreEqual(5, characters.Last().Value);
        }

        [TestMethod]
        public void AddCharacters_AddsCharactersToDictionaryWithCaseSensitive()
        {
            // Act
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'A', 5 } });

            // Assert
            var characters = wordStats.GetCharactersOrderByFrequencyDescending();
            Assert.AreEqual(2, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('A', characters.Last().Key);
            Assert.AreEqual(5, characters.Last().Value);
        }

        [TestMethod]
        public void AddCharacters_AddsCharactersToDictionaryWithCaseSensitiveAndNonLetterCharacters()
        {
            // Act
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'A', 5 }, { ' ', 2 }, { '.', 1 } });

            // Assert
            var characters = wordStats.GetCharactersOrderByFrequencyDescending();
            Assert.AreEqual(4, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('A', characters.Skip(1).First().Key);
            Assert.AreEqual(5, characters.Skip(1).First().Value);
            Assert.AreEqual(' ', characters.Skip(2).First().Key);
            Assert.AreEqual(2, characters.Skip(2).First().Value);
            Assert.AreEqual('.', characters.Skip(3).First().Key);
            Assert.AreEqual(1, characters.Skip(3).First().Value);
        }

        [TestMethod]
        public void AddCharacters_AddsCharactersToDictionaryWithCaseSensitiveAndNonLetterCharactersAndNumbers()
        {
            // Act
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'A', 5 }, { ' ', 2 }, { '.', 1 }, { '1', 3 } });

            // Assert
            var characters = wordStats.GetCharactersOrderByFrequencyDescending();
            Assert.AreEqual(5, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('A', characters.Skip(1).First().Key);
            Assert.AreEqual(5, characters.Skip(1).First().Value);
            Assert.AreEqual('1', characters.Skip(2).First().Key);
            Assert.AreEqual(3, characters.Skip(2).First().Value);
            Assert.AreEqual(' ', characters.Skip(3).First().Key);
            Assert.AreEqual(2, characters.Skip(3).First().Value);
            Assert.AreEqual('.', characters.Skip(4).First().Key);
            Assert.AreEqual(1, characters.Skip(4).First().Value);
        }

        [TestMethod]
        public void GetWordsOrderByFrequencyDescending_ReturnsEmptyListWhenNoWordsAdded()
        {
            // Act
            var words = wordStats.GetWordsOrderByFrequencyDescending();

            // Assert
            Assert.AreEqual(0, words.Count());
        }

        [TestMethod]
        public void GetWordsOrderByFrequencyDescending_ReturnsWords()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 } });

            // Act
            var words = wordStats.GetWordsOrderByFrequencyDescending();

            // Assert
            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("Apple", words.Last().Key);
            Assert.AreEqual(5, words.Last().Value);
        }

        [TestMethod]
        public void GetWordsOrderByFrequencyDescending_ReturnsWordsWithCaseSensitive()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 } });

            // Act
            var words = wordStats.GetWordsOrderByFrequencyDescending();

            // Assert
            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("apple", words.First().Key);
            Assert.AreEqual(10, words.First().Value);
            Assert.AreEqual("Apple", words.Last().Key);
            Assert.AreEqual(5, words.Last().Value);
        }

        [TestMethod]
        public void GetCharactersOrderByFrequencyDescending_ReturnsEmptyListWhenNoCharactersAdded()
        {
            // Act
            var characters = wordStats.GetCharactersOrderByFrequencyDescending();

            // Assert
            Assert.AreEqual(0, characters.Count());
        }

        [TestMethod]
        public void GetCharactersOrderByFrequencyDescending_ReturnsCharacters()
        {
            // Add some characters
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'b', 5 } });

            // Act
            var characters = wordStats.GetCharactersOrderByFrequencyDescending();

            // Assert
            Assert.AreEqual(2, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('b', characters.Last().Key);
            Assert.AreEqual(5, characters.Last().Value);
        }

        [TestMethod]
        public void GetCharactersOrderByFrequencyDescending_ReturnsCharactersWithCaseSensitive()
        {
            // Add some characters
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'A', 5 } });

            // Act
            var characters = wordStats.GetCharactersOrderByFrequencyDescending();

            // Assert
            Assert.AreEqual(2, characters.Count());
            Assert.AreEqual('a', characters.First().Key);
            Assert.AreEqual(10, characters.First().Value);
            Assert.AreEqual('A', characters.Last().Key);
            Assert.AreEqual(5, characters.Last().Value);
        }

        [TestMethod]
        public void GetLargestFiveWords_ReturnsEmptyListWhenNoWordsAdded()
        {
            // Act
            var largestWords = wordStats.GetLargestFiveWords();

            // Assert
            Assert.AreEqual(0, largestWords.Count());
        }

        [TestMethod]
        public void GetLargestFiveWords_ReturnsLessThanFiveWordsWhenLessThanFiveWordsAdded()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 } });

            // Act
            var largestWords = wordStats.GetLargestFiveWords();

            // Assert
            Assert.AreEqual(2, largestWords.Count());
        }

        [TestMethod]
        public void GetLargestFiveWords_ReturnsLargestFiveWords()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 },
                { "pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 } });

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
        public void GetLargestFiveWords_ReturnsLargestFiveWordsWithCaseSensitive()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 },
                { "Pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 } });

            // Act
            var largestWords = wordStats.GetLargestFiveWords();

            // Assert
            Assert.AreEqual(5, largestWords.Count());
            Assert.AreEqual("elderberry", largestWords.First());
            Assert.AreEqual("Pineapple", largestWords.Skip(1).First());
            Assert.AreEqual("Apple", largestWords.Skip(2).First());
            Assert.AreEqual("apple", largestWords.Skip(3).First());
            Assert.AreEqual("kiwi", largestWords.Skip(4).First());
        }

        [TestMethod]
        public void GetSmallestFiveWords_ReturnsEmptyListWhenNoWordsAdded()
        {
            // Act
            var smallestWords = wordStats.GetSmallestFiveWords();

            // Assert
            Assert.AreEqual(0, smallestWords.Count());
        }

        [TestMethod]
        public void GetSmallestFiveWords_ReturnsLessThanFiveWordsWhenLessThanFiveWordsAdded()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 } });

            // Act
            var smallestWords = wordStats.GetSmallestFiveWords();

            // Assert
            Assert.AreEqual(2, smallestWords.Count());
        }

        [TestMethod]
        public void GetSmallestFiveWords_ReturnsSmallestFiveWords()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 },
                { "pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 } });

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
        public void GetSmallestFiveWords_ReturnsSmallestFiveWordsWithCaseSensitive()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 },
                { "Pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 } });

            // Act
            var smallestWords = wordStats.GetSmallestFiveWords();

            // Assert
            Assert.AreEqual(5, smallestWords.Count());
            Assert.AreEqual("fig", smallestWords.First());
            Assert.AreEqual("kiwi", smallestWords.Skip(1).First());
            Assert.AreEqual("apple", smallestWords.Skip(2).First());
            Assert.AreEqual("Apple", smallestWords.Skip(3).First());
            Assert.AreEqual("Pineapple", smallestWords.Skip(4).First());
        }

        [TestMethod]
        public void GetMostFrequentTenWords_ReturnsEmptyListWhenNoWordsAdded()
        {
            // Act
            var mostFrequentWords = wordStats.GetMostFrequentTenWords();

            // Assert
            Assert.AreEqual(0, mostFrequentWords.Count());
        }

        [TestMethod]
        public void GetMostFrequentTenWords_ReturnsLessThanTenWordsWhenLessThanTenWordsAdded()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 } });

            // Act
            var mostFrequentWords = wordStats.GetMostFrequentTenWords();

            // Assert
            Assert.AreEqual(2, mostFrequentWords.Count());
        }

        [TestMethod]
        public void GetMostFrequentTenWords_ReturnsMostFrequentTenWords()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 },
                { "pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 }, { "mango", 35 },
                { "orange", 40 }, { "pear", 45 }, { "strawberry", 50 }, { "watermelon", 55 } });

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
        public void GetMostFrequentTenWords_ReturnsMostFrequentTenWordsWithCaseSensitive()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "Apple", 5 },
                { "Pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 }, { "mango", 35 },
                { "orange", 40 }, { "pear", 45 }, { "strawberry", 50 }, { "watermelon", 55 } });

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
            Assert.AreEqual(KeyValuePair.Create("Pineapple", 15), mostFrequentWords.Skip(8).First());
            Assert.AreEqual(KeyValuePair.Create("apple", 10), mostFrequentWords.Skip(9).First());
        }

        [TestMethod]
        public void ToJsonString_ReturnsEmptyResultWhenNoWordsAdded()
        {
            // Act
            var jsonString = wordStats.ToJsonString();

            // Assert
            Assert.AreEqual("{\"TotalWords\":0,\"TotalCharacters\":0,\"LargestFiveWords\":[],\"SmallestFiveWords\":[],\"MostFrequentTenWords\":[],\"Characters\":[]}", jsonString);
        }

        [TestMethod]
        public void ToJsonString_ReturnsJsonStringWithWords()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 },
                { "pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 }, { "mango", 35 },
                { "orange", 40 }, { "pear", 45 }, { "strawberry", 50 }, { "watermelon", 55 } });

            // Act
            var jsonString = wordStats.ToJsonString();

            // Assert
            string result = "{\"TotalWords\":330,\"TotalCharacters\":0,\"LargestFiveWords\":[\"watermelon\",\"strawberry\",\"elderberry\",\"pineapple\",\"orange\"],\"SmallestFiveWords\":[\"fig\",\"kiwi\",\"pear\",\"apple\",\"mango\"],\"MostFrequentTenWords\":[{\"Key\":\"watermelon\",\"Value\":55},{\"Key\":\"strawberry\",\"Value\":50},{\"Key\":\"pear\",\"Value\":45},{\"Key\":\"orange\",\"Value\":40},{\"Key\":\"mango\",\"Value\":35},{\"Key\":\"kiwi\",\"Value\":30},{\"Key\":\"fig\",\"Value\":25},{\"Key\":\"elderberry\",\"Value\":20},{\"Key\":\"pineapple\",\"Value\":15},{\"Key\":\"apple\",\"Value\":10}],\"Characters\":[]}";
            Assert.AreEqual(result, jsonString);
        }

        [TestMethod]
        public void ToJsonString_ReturnsJsonStringWithCharacters()
        {
            // Add some characters
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'b', 5 },
                { 'c', 15 }, { 'd', 20 }, { 'e', 25 }, { 'f', 30 }, { 'g', 35 },
                { 'h', 40 }, { 'i', 45 }, { 'j', 50 }, { 'k', 55 } });

            // Act
            var jsonString = wordStats.ToJsonString();

            // Assert
            Assert.AreEqual("{\"TotalWords\":0,\"TotalCharacters\":330,\"LargestFiveWords\":[],\"SmallestFiveWords\":[],\"MostFrequentTenWords\":[],\"Characters\":[{\"Key\":\"k\",\"Value\":55},{\"Key\":\"j\",\"Value\":50},{\"Key\":\"i\",\"Value\":45},{\"Key\":\"h\",\"Value\":40},{\"Key\":\"g\",\"Value\":35},{\"Key\":\"f\",\"Value\":30},{\"Key\":\"e\",\"Value\":25},{\"Key\":\"d\",\"Value\":20},{\"Key\":\"c\",\"Value\":15},{\"Key\":\"a\",\"Value\":10},{\"Key\":\"b\",\"Value\":5}]}", jsonString);
        }

        [TestMethod]
        public void ToJsonString_ReturnsJsonStringWithWordsAndCharacters()
        {
            // Add some words
            wordStats.AddWords(new Dictionary<string, int> { { "apple", 10 }, { "banana", 5 },
                { "pineapple", 15 }, { "elderberry", 20 }, { "fig", 25 }, { "kiwi", 30 }, { "mango", 35 },
                { "orange", 40 }, { "pear", 45 }, { "strawberry", 50 }, { "watermelon", 55 } });
            // Add some characters
            wordStats.AddCharacters(new Dictionary<char, int> { { 'a', 10 }, { 'b', 5 },
                { 'c', 15 }, { 'd', 20 }, { 'e', 25 }, { 'f', 30 }, { 'g', 35 },
                { 'h', 40 }, { 'i', 45 }, { 'j', 50 }, { 'k', 55 } });

            // Act
            var jsonString = wordStats.ToJsonString();

            // Assert
            string result = "{\"TotalWords\":330,\"TotalCharacters\":330,\"LargestFiveWords\":[\"watermelon\",\"strawberry\",\"elderberry\",\"pineapple\",\"orange\"],\"SmallestFiveWords\":[\"fig\",\"kiwi\",\"pear\",\"apple\",\"mango\"],\"MostFrequentTenWords\":[{\"Key\":\"watermelon\",\"Value\":55},{\"Key\":\"strawberry\",\"Value\":50},{\"Key\":\"pear\",\"Value\":45},{\"Key\":\"orange\",\"Value\":40},{\"Key\":\"mango\",\"Value\":35},{\"Key\":\"kiwi\",\"Value\":30},{\"Key\":\"fig\",\"Value\":25},{\"Key\":\"elderberry\",\"Value\":20},{\"Key\":\"pineapple\",\"Value\":15},{\"Key\":\"apple\",\"Value\":10}],\"Characters\":[{\"Key\":\"k\",\"Value\":55},{\"Key\":\"j\",\"Value\":50},{\"Key\":\"i\",\"Value\":45},{\"Key\":\"h\",\"Value\":40},{\"Key\":\"g\",\"Value\":35},{\"Key\":\"f\",\"Value\":30},{\"Key\":\"e\",\"Value\":25},{\"Key\":\"d\",\"Value\":20},{\"Key\":\"c\",\"Value\":15},{\"Key\":\"a\",\"Value\":10},{\"Key\":\"b\",\"Value\":5}]}";
            Assert.AreEqual(result, jsonString);
        }
    }
}