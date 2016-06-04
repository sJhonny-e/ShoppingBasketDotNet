# ShoppingBasketDotNet
A c# implementation of a shopping basket that allows different discounts  

You can add different `Item`s to your `ShoppingBasket`, and when you `CalculateTotal`, it will show you the amount to pay, taking into account all the different `Discount`s that were definted.

##Install & Run tests
1. clone this repo  
2. build in Visual Studio (this should also restore packages)  
3. run tests in Visual Studio `ctrl + R + A`  
(this project doesn't have a GUI / CLI; it's just a demo of the business logic implementation)  

##About the solution
This solution, like its parallel [Ruby implementation](https://github.com/sJhonny-e/RubyPromotionsApp), uses the visitor pattern to separate the implementation of the `ShoppingBasket` and the different `Discount`s.  
The `ShoppingBasket` will apply all the predefined discounts on itself, allowing different discounts with different logic to be implemented separately.  
  
In this case, we defined two different `Discount`s that have different logic (one that's of the type *"buy X get Y free"*, and one of the type *"buy X of product A, and get a Y% discount on product B"*).  

##What can be improved
Obviously this is just a little demo thing; It can be improved in the following ways:  
* Adding some sort of interface
* Using Value Objects to make sure parameters are within permitted range (i.e `quantity` should only be positive)
* Creating an `ItemInBasket` class instead of using the much less obvious `KeyValuePair<Item,int>` all over the place.
