using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntArrayProject
{
    public class ExceptionsFacts
    {

        [Fact]
        public void ReturnsExceptionMessage()
        {
            var ex = new ExceptionExamples();

            Assert.Equal(-1, ex.CountSumOfElements());
        }

        [Fact]
        public void ReturnsOutsideOfTryCount()
        {
            var ex = new ExceptionExamples();

            Assert.Equal(200, ex.CountSumOfElementsMultimpleCatch());
        }

        [Fact]
        public void ReturnErrorMessage()
        {
            var ex = new ExceptionExamples();

            Assert.Equal("Object reference not set to an instance of an object.", ex.FormWord());
        }

        [Fact]
        public void FunctionThrowsCorrectExceptionForCase()
        {
            var ex = new ExceptionExamples();

            Exception exception = Assert.Throws<ArgumentNullException>(() => ex.GetFirstLetterOfAWord(null));

            Assert.Equal("Value cannot be null.", exception.Message);
        }
    }
}
