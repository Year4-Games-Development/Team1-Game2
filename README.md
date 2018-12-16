# Gabby Farrell Project Contribution
This [branch](https://github.com/Year4-Games-Development/Team1-Game2/tree/gabby) was made on the weekend before the deadline, after speaking with you (Matt) in the lab about separating my code contribution.  

My code could not be utilized when every member's features were combined due to many bugs, confusion and miscommunication. On this branch, my code is demonstrated in the console using a character representaion of the model, so that my features could be graded independently to the other features. 

### Code Contribution
- **Model.cs**  
[commit 1 - 16 Nov](https://github.com/Year4-Games-Development/Team1-Game2/commit/ae441eb0b8438242ba9aefbd9c322c77f286d4fd)
- **PlayerController.cs**  
[commit 1 - 23 Nov](https://github.com/Year4-Games-Development/Team1-Game2/commit/0ac9b5e84a9e331d4613d49ed82af02d467d7fba)  
[commit 2 - 13 Dec](https://github.com/Year4-Games-Development/Team1-Game2/commit/f8e6bb90ac75646c21a9fd3b9283a35ca84ea47f)  
[commit 3 - 13 Dec](https://github.com/Year4-Games-Development/Team1-Game2/commit/1d000aef792de695552ad67c76d50fca1680dd5f)  
- **PlayerControllerNonMono.cs**  
[commit 1 - 14 Dec](https://github.com/Year4-Games-Development/Team1-Game2/commit/de8e7885c464b09a32d22c1fa6290273fca482ee)
- **Inventory.cs**  
[commit 1 - 30 Nov](https://github.com/Year4-Games-Development/Team1-Game2/commit/4b8f70e36c8ca13e598997e0624b7784eace1dac)
- **Item.cs**  
[commit 1 - 30 Nov](https://github.com/Year4-Games-Development/Team1-Game2/commit/4b8f70e36c8ca13e598997e0624b7784eace1dac)
- **Obsticle.cs**  
[commit 1 - 30 Nov](https://github.com/Year4-Games-Development/Team1-Game2/commit/4b8f70e36c8ca13e598997e0624b7784eace1dac)

### Testing Contribution
- **TestModel.cs**
- **TestPlayerControllerNonMono.cs**

### Explaination of Code
The model of this game is comprised of a 2D array of Square objects. The Square objects contain data fields for Character objects. These character objects represent either the player or the monster. In this branch, I have isolated my features from the other group members features. You can find a visual representaiton of the model in the console. To discern the object types from eachother, the loop which displays the array will GetCharRepresentation for each index, which will return a specific enum character to represent each object type.
- PLayer: CharRepresentation.P
- Monster: CharRepresentation.M
- Background: CharRepresentation._
- Rock: CharRepresentation.R

PlayerController.cs is a monobehavior class. This class uses the PlayerControllerNonMono class to target and manipulate the player and monster indexes. These classes are separated to allow for unit testing on the controller. 

In PlayerControllerNonMono.cs the model is instantiated. The model in turn, creates the player and monster objects. The playerControllerNonMono then uses the appropriate 'Find' function to find the indeces of the player and monster. The update loop listens for specific keystrokes, and manipulates the player accordingly. To do this, the enum direction is passed to the MovePlayer function, where the destination index is tested for occupation and for boundries. once passed these checks, the destination index is assigned the player object, leaving behind a null index. 

The Obsticles in my code are comprised of 2 attributes: isInteractable and isDamagable. This is to allow for the use of this class for both chest and rock objects (chest: isInteractable & isDamagable, rock: !isInteractable & !isDamagable). In my console view, the rock is Represented with the enum CharRepresntation.R. 

Note: The game window sprite view does not fully represent my code. The console does.


