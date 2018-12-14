using NUnit.Framework;

class TestModel
{
    [Test]
    public void Test_Create_Model()
    {
        //Arrange
        Model model = new Model(10, 10);
        int expectedResult = 10;

        // Act
        int width = model.GetBoardWidth();

        // Assert
        Assert.AreEqual(expectedResult, width);
    }



}
