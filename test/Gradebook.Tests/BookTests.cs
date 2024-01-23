using System;
using GradeBook;
using Xunit;
                
namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverageGrade()
        {
            // Arrange section
            var book = new InMemoryBook("");
            
            book.AddGrade(24.6);
            book.AddGrade(96.6);
            book.AddGrade(62.4);
            
            // Act section
            var result = book.GetStats();

            // Assert section
            Assert.Equal(61.2, result.Average, 1);
            Assert.Equal(96.6, result.High);
            Assert.Equal(24.6, result.Low);
            Assert.Equal('D', result.Letter);
        }
    }
} 