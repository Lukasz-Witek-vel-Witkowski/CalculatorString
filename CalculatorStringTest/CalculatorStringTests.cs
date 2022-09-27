

using CalculatorString;

namespace CalculatorStringTest
{
    public class CalculatorStringTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [TestCase("")]
        public void CheckAddEmpty(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(0));
        }

        [TestCase("1")]
        public void CheckAddOnNumber(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(1));
        }


        [TestCase("1,2")]
        public void CheckAddTwoNumber(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(3));
        }


        [TestCase("1,2,3,4,5,6,7,8,9")]
        public void CheckAddMultiNumber(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(45));
        }

        [TestCase("1,2,3\n4,5,6\n7,8,9")]
        public void CheckAddNewLine(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(45));
        }

        [TestCase("1,2,3\n4,5,6//;\n7;8;9")]
        public void CheckAddDelimiter(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(45));
        }

        [TestCase("-1, -2, -3")]
        public void TakeTrowNegativesNotAllowed(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(() => calculatorString.Add(name),
                Throws.TypeOf<NegativesNotAllowedException>().With.Message.EqualTo("negatives not allowed -1, -2, -3,"));
        }

        [TestCase("1, 10000, 2")]
        public void CheckAddNumberMaxValue(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(3));
        }

        [TestCase("1, 10000//[***]\n2***1")]
        public void CheckAddMultiDelimiter(string name)
        {
            Calculator calculatorString = new Calculator();

            Assert.That(calculatorString.Add(name), Is.EqualTo(4));
        }
    }
}