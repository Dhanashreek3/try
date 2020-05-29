
Feature: TimenMaterial
	As a admin of TurnUp portal
	I would like to manage time and material record portal effectively

@mytag
Scenario: Create a time and material record
	Given I have logged in to the turnup portal successfully
	And I create a time and material
	Then the record should be created successfully
