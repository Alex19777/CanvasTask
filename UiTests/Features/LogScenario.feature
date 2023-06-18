Feature: LogScenario

Canvas Reply tasks, Scenario for logs

Scenario: T003_DeleteActiveItems
  Given User Login to crmcloud
  When User Navigate to ActivityLog
  And Check recent activity and delete them
  Then Validate deleted information