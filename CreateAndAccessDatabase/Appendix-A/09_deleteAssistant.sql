-- 09_deleteAssistant.sql
USE SuperheroesDb;

-- This script will delete the assistant from both the Assistant table by declaring a variable AssistantNameToDelete and the Delete Method
-- Declaring an assistant name to variable AssistantNameToDelete
DECLARE @AssistantNameToDelete VARCHAR(255)
SET @AssistantNameToDelete = 'WildMonkey'

-- Deleting the assistant from the Assistant table
DELETE FROM Assistant
WHERE Name = @AssistantNameToDelete;