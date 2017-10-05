# ShipBobApp Documentation

This application allows user to
1. Create user
2. Create Orders
3. Update Orders
4. Delete Orders

## API Calls from Front-end to Business Logic:

| Description        | API Calls           |
| ------------- |:-------------:|
| Get All Order       | /Order/GetAllOrders |
| Creata Order      |/Order/CretaeOrder/{Order}     |  
| Update Order  | /Order/UpdateOrder/{trackingId}      |  
| Delete Order | /Order/DeleteOrder/{trackingId}|
|Get Order| /Order/GetOrder/{userId}|
|Get All User |/Home/GetUser|  
|Create User|/Home/CreateUser/{User}|

## Screenshots:
### Create User and User look up page

Text box validations are incorporated
1. Null values are not permitted
2. Input values can only be Alphabets

![alt text](https://github.com/prash8692/ShipBobProj/blob/master/images/HomePage.jpeg)

### Create Order Page

Text box validations are incorporated
1. Null values are not permitted
2. Zip code text field can accept only numeric values

![alt text](https://github.com/prash8692/ShipBobProj/blob/master/images/CreateOrder.PNG)

### View/Update/Delete Order Page
Orders can be edited by clicking on the value, Tracking Id is a read only field.

![alt text](https://github.com/prash8692/ShipBobProj/blob/master/images/ViewOrders.jpeg)
