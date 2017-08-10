Feature: Support of invoicing for sales departament
   As a seller I want to be able to create an invoice to put ordered items on it
   As a seller I want to be able to put items on invoice to calculate total sum
   As a seller I want to be able to change invoice date to specify sale date
   As a seller I want to be able to close invoice so it cannot be changed

Scenario: Opening invoice
   Given is an empty unopened invoice
   When I open it for some customer
   Then it will report an owner
   And open state

Scenario: Unopened invoice modification
   Given is an empty unopened invoice
   When I try to add item to it
   Then I should get an error "You need to open invoice befor modification."
