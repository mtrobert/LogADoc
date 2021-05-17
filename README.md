# Description
The app improves greatly the way the items received from a third party are tracked and managed. This way, at any given point we know where the item is and we can take action accordingly. This managment tool is devided into two section.
The admin team section and the other department team section. Each team can perform some actions respectively.

When the item arrives, it is recorder in the app by the admin team. From this point the item can be used by employees from other departments. Also at the end,
if the item is not needed any more, the final action on the item can be requested. The items are stored by the admin team by default.

The app is written in C# using .net 5.

## Within the app you can:

### As non-admin employee

- add a new item
- set the item status
- request action to perform on the item
- request the item from the admin

### As admin employee

- record the item
- send the item to a non-admin employee
- destroy the item
- return the item to the source

