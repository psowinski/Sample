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

Scenario: Calculate total sum
   Given is an open invoice
   When I add a few items:
      | ProductId | Price | Amount |
      | 1         | 5.00  | 3      |
      | 2         | 3.50  | 1      |
      | 3         | 1.50  | 2      |
   Then total sum should be equal to 21.50

Scenario: Sum amount of the same items
   Given is an open invoice
   When I add twice the same item:
      | ProductId | Price | Amount |
      | 1         | 5.00  | 3      |
      | 1         | 5.00  | 4      |
   Then it should contian item:
      | ProductId | Price | Amount |
      | 1         | 5.00  | 7      |

Scenario: Set invoice sale date
   Given is an open invoice
   When I set a sale date '2017-07-07'
      And I set a sale date '2017-08-08'
   Then an invoice should present the last one '2017-08-08'

Scenario: Cannot set a sale date on unopen invoice
   Given is an empty unopened invoice
   When I set a sale date '2017-07-07'
   Then I should get an error "You need to open invoice befor modification."

Scenario: Close valid invoice
   Given is an open invoice
      And it contians item
      | ProductId | Price | Amount |
      | 1         | 1.00  | 1      |
      And it has set a date '2017-07-07'
   When I close it
   Then it should report as closed not blank

Scenario: Close an empty invoice
   Given is an open invoice without items
   When I close it
   Then I should get an error "Cannot close an empty invoice."

Scenario: Close an invoice without sell date
   Given is an open invoice
      And it contians item
      | ProductId | Price | Amount |
      | 1         | 1.00  | 1      |
   When I close it
   Then I should get an error "Cannot close invoice without sell date."

Scenario: Add item to closed invoice
   Given is a closed invoice
   When I add an item:
      | ProductId | Price | Amount |
      | 1         | 5.00  | 3      |
   Then I should get an error "Cannot modify closed invoice."
