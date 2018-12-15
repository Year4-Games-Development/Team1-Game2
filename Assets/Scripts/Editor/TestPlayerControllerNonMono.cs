using NUnit.Framework;

class TestPlayerControllerNonMono
{
    [Test]
    public void Test_Player_Starts_at_Five_Five()
    {
        //Arrange
        PlayerControllerNonMono playerControllerNonMono = new PlayerControllerNonMono();
        int expectedRow = 5;
        int expectedCol = 5;

        // Act
        playerControllerNonMono.MyStart();
        playerControllerNonMono.FindPlayer();
        int playerRow = playerControllerNonMono.playerRow;
        int playerCol = playerControllerNonMono.playerCol;


        // Assert
        Assert.AreEqual(expectedRow, playerRow);
        Assert.AreEqual(expectedCol, playerCol);
    }

    [Test]
    public void Test_Player_Move_Up_One_Row_Is_Four()
    {
        //Arrange
        PlayerControllerNonMono playerControllerNonMono = new PlayerControllerNonMono();
        int expectedRow = 4;

        // Act
        playerControllerNonMono.MyStart();
        playerControllerNonMono.MovePlayer(Orientation.Up);
        playerControllerNonMono.MovePlayer(Orientation.Up);
        int playerRow = playerControllerNonMono.playerRow;

        // Assert
        Assert.AreEqual(expectedRow, playerRow);
    }

    [Test]
    public void Test_Player_Move_Up_One_Col_Is_Still_Five()
    {
        //Arrange
        PlayerControllerNonMono playerControllerNonMono = new PlayerControllerNonMono();
        int expectedCol = 5;

        // Act
        playerControllerNonMono.MyStart();
        playerControllerNonMono.MovePlayer(Orientation.Up);
        int playerCol = playerControllerNonMono.playerCol;


        // Assert
        Assert.AreEqual(expectedCol, playerCol);
    }






}
