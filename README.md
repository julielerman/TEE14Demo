TEE14Demo
=========

Visual Studio Solution for TEE14 Session EF Model Partioning in Domain-Driven Design Bounded Contexts

This is the source for the demos I showed during my session that was recorded here: http://channel9.msdn.com/Events/TechEd/Europe/2014/DEV-B411.

Please keep in mind that this is for demo purposes only and is not meant to be a full DDD reference app but just a solution that I used to demonstrate the concepts I focused on in this session.

There are also examples of things that are specific to the demo, for example, I use a message queue to mirror contact info into a database used by a different BC. This is okay for some scenarios but not when you have to be considerate of race conditions.

The entire solution is not fleshed out. Instead, I worked through the sample code that i needed to demonstrate the concepts in my session.

There are a series of tests. The ContactManagement Tests and SalesOrder.Infrastructure tests, use RabbitMQ as the message queue. You'll need to isntall RabbitMQ (rabbitmq.com) to run those.

The solution requires you to build in order for it to retrieve some of it's necessary DLLs from Nuget.

For a more detailed discussion of the whole pub/sub workflow that triggers the messages to be queued, please see my MSDN Data Points columns:

A Pattern for Sharing Data Across Domain-Driven Design Bounded Contexts
Part 1, October 2014 MSDN Magazine: http://msdn.microsoft.com/en-us/magazine/dn802601.aspx
Part 2, December 2014 MSDN Magazine: (not yet published).

Also, many are finding the Domain-Driven Design Fundamentals course that I did with Steve Smith for Pluralsight to be very helpful. bit.ly/PS-DDD

Hope this helpful!

