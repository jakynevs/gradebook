using System;
using GradeBook;
using Xunit;
                
namespace Gradebook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = ReturnMessage;

            var result = log("Hello");
            Assert.Equal("Hello", result);
        }

        private string ReturnMessage(string logMessage)
        {
            return logMessage;
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(5, x);
        }

        private void SetInt(ref int x)
        {
            x = 5;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        void GetBookSetName(ref InMemoryBook book , string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        void GetBookSetName(InMemoryBook book , string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        void SetName(InMemoryBook book , string name)
        {
            book.Name = name;
        }


        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Jack";
            var upper = MakeUpperCase(name);


            Assert.Equal("Jack", name);
            Assert.Equal("JACK", upper);
        }
 
        string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }
 
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book2, book1);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}