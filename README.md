# CheckoutTest

We want to have a web service in either MVC or Web API that will enable us to populate a shopping list for our office. So here is how we want you to create it:
 
# 1- Service Endpoint
 
Create an endpoint which will be accessible through a friendly route. (This can be hosted on your localhost at least for now). 
     
The endpoint will work based on the following web requests:
Http Post request should adding a drink in to the list with quantity e.g. name of drink (Pepsi) and quantity (1)
Http Put request for updating a drinks quantity
Http Delete request for removing a drink from the shopping list
Http Get request for retrieving a drink by its name and its quantity so we can see how many ordered
Http Get request for retrieving full list of what we have in the shopping list
Notes:
This doesn’t have to use database you can use in memory solution to hold the shopping list. Any thing simple that works
Ideally it should contain one unique drink name for each entry to avoid repetitions
Please feel free to implement/explain any advanced features to demonstrate your skills and experience such as paginated lists api authorisation and validation etc. 

# 2- Service Client
 
We have a web api client library at GitHub repository here: https://github.com/CKOTech/checkout-net-library. We want you to modify this library so that it can interact with the shopping list endpoint that will be created so that it can act as a client for the endpoint.
Checkout test
