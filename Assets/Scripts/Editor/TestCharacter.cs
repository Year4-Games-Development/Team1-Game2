﻿using NUnit.Framework;

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
        Assert.AreEqual(resultExpected, player.GetHp());
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
        Assert.AreEqual(resultExpected, player.GetHp());
    }

    [Test]
    public void TestReceiveHealth()
    {
        //Arrange
        Character player = new Character("jose", new Coordinates(0, 0),1, true, 100, 80);
        int heqlthReceiveHealth = 20;
        int resultExpected = 100;

        // Act
        player.receiveHealth(heqlthReceiveHealth);

        // Assert
        Assert.AreEqual(resultExpected, player.GetHp());
    }

    [Test]
    public void TestNoReceiveHealthWhenValueNegative()
    {
        //Arrange
        Character player = new Character("jose", new Coordinates(0, 0), 1, true, 100, 80);
        int healthReceive = -20;
        int resultExpected = 80;

        // Act
        player.receiveHealth(healthReceive);

        // Assert
        Assert.AreEqual(resultExpected, player.GetHp());
    }
}
