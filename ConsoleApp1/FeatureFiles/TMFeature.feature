Feature: TMFeature
	As a admin of turn up module, I would like to create, edit and delete records
	in time and material table.
	
@automate @tm
Scenario: Admin should be able to create a time and material record in turn up portal
	Given I have logged into the turn up portal
	And I have navigate to the time and material page
	Then I should be able to create a time and material record.

@tm @automate
Scenario: Turn Up portal admin should be able to delete a time and material record
	Given I have logged into the turn up portal
	And I have navigate to the time and material page
	Then I should be able to delete a time and material record.

@tm @automate
Scenario: Admin should be able to edit a time and material record
	Given I have logged into the turn up portal
	And I have navigate to the time and material page
	Then I should be able to edit a time and material record.


