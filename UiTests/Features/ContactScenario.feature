Feature: ContactScenario

Canvas Reply tasks, Scenarios for Contact

Scenario: T001_CreateContact
	Given User Login to crmcloud
	When User Navigate to Contacts
	And User create new contact with first name Tom, lastName Ford
	Then Validate contact information