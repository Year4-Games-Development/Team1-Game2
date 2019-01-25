using NUnit.Framework;

class TestCharacter
{

    [Test]
    public void TestReceiveDammage()
    {
        //Arrange
        Character player = new Character("jose", new Coordinates(0, 0), 1, true, 100, 100);
        int damageReceive = 20;
        int resultExpected = 80;

        // Act
        player.receiveDamage(damageReceive);

        // Assert
        Assert.AreEqual(resultExpected, player.Hp);
    }

    [Test]
    public void TestNoReceiveDammageWhenValueNegative()
    {
        //Arrange
        Character player = new Character("jose", new Coordinates(0, 0), 1, true, 100, 100);
        int damageReceive = -20;
        int resultExpected = 100;

        // Act
        player.receiveDamage(damageReceive);

        // Assert
        Assert.AreEqual(resultExpected, player.Hp);
    }

    [Test]
    public void TestReceiveHealth()
    {
        //Arrange
        Character player = new Character("jose", new Coordinates(0, 0),1, true, 100, 80);
        int heqlthReceiveHealth = 20;
        int resultExpected = 100;

        // Act
        player.receiveDamage(-heqlthReceiveHealth);

        // Assert
        Assert.AreEqual(resultExpected, player.Hp);
    }

    [Test]
    public void TestNoReceiveHealthWhenValueNegative()
    {
        //Arrange
        Character player = new Character("jose", new Coordinates(0, 0), 1, true, 100, 80);
        int healthReceive = -20;
        int resultExpected = 80;

        // Act
        player.receiveDamage(-healthReceive);

        // Assert
        Assert.AreEqual(resultExpected, player.Hp);
    }
}
