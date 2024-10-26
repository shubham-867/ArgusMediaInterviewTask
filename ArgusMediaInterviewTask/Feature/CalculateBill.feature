Feature: CalculateBill

There is a new endpoint that will calculate the total of the order, and add a 10% service charge on food.


#Assuming the order is placed before 7pm
Scenario: A group of people place an order in a restaurant
	Given a group of 4 people is in a restaurant
	When they order
		| Item     | Quantity |
		| starters | 4        |
		| mains    | 4        |
		| drinks   | 4        |
	Then The bill should be as per the calculation "55.4"
	And status code should be 200

Scenario: A group of people place an order in a restaurant and are later joined by more people
	Given a group of 2 people is in a restaurant
	When they order 
		| Item     | Quantity |
		| starters | 1        |
		| mains    | 2        |
		| drinks   | 2        |
	And the order is placed at "19:00"
	Then The bill should be as per the calculation "23.3"
	When 2 more people join the group
	And following items are added in the order
		| Item   | Quantity |
		| mains  | 2        |
		| drinks | 2        |
	And the order is placed at "20:00"
	Then The bill should be as per the calculation "43.7"
	And status code should be 200

#Assuming the order is placed before 7pm
Scenario: A group of people place an order in a restaurant and later 1 member cancels thier order
	Given a group of 4 people is in a restaurant
	When they order
		| Item     | Quantity |
		| starters | 1        |
		| mains    | 1        |
		| drinks   | 4        |
	Then The bill should be as per the calculation "19.1"
	When 1 member cancels thier order and leaves the group
	When following items are removed from the order
		| Item   | Quantity |
		| drinks | 1        |
	Then The bill should be as per the calculation "17.35"
	And status code should be 200
	