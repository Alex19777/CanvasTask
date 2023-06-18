Feature: ReportScenario

Canvas Reply tasks, Scenario for report

Scenario: T002_RunReport
	Given User Login to crmcloud
	When User Navigate to Reports
	And User search Project Profitability report
	And User run report
	Then Validate report information