CREATE TABLE [dbo].[Accounts] (
    emailAddress VARCHAR(100) PRIMARY KEY,
    firstName VARCHAR(50),
    lastName VARCHAR(50),
    password VARCHAR(100)
);

CREATE TABLE [dbo].[Categories] (
    categoryId INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100)
);

CREATE TABLE [dbo].[Tasks](
    taskId INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(100),
    isComplete BIT,
    startDate DATE,
    dueDate DATE,
    emailAddress VARCHAR(100)
    CONSTRAINT fkEmailAddress_Tasks
      REFERENCES [dbo].[Accounts](emailAddress)
      ON DELETE CASCADE,
    location VARCHAR(100),
    priority INT,
    description TEXT
);

CREATE TABLE [dbo].[Reminders] (
    reminderId INT PRIMARY KEY IDENTITY(1,1),
    message VARCHAR(255),
    taskId INT
    CONSTRAINT fkTaskId_Reminders
      REFERENCES [dbo].[Tasks](taskId)
      ON DELETE CASCADE,
    reminderDateTime DATETIME,
);

CREATE TABLE [dbo].[Tasks_Categories] (
    taskId INT
    CONSTRAINT fkTaskId_TasksCategories
      REFERENCES [dbo].[Tasks](taskId)
      ON DELETE CASCADE,
    category_id INT
    CONSTRAINT fkCategoryId_TasksCategories
      REFERENCES [dbo].[Categories](categoryId)
      ON DELETE CASCADE, 
    PRIMARY KEY (taskId, categoryId)
);


CREATE TABLE [dbo].[Tasks_Reminders] (
    taskId INT
    CONSTRAINT fkTaskId_TasksReminders
      REFERENCES [dbo].[Tasks](taskId)
      ON DELETE CASCADE,
    reminderId INT
    CONSTRAINT fkReminderId_TasksReminders
      REFERENCES [dbo].[Reminders](reminderId)
      ON DELETE CASCADE,
    PRIMARY KEY (taskId, reminderId)
);

CREATE TABLE [dbo].[Accounts_Tasks] (
    emailAddress VARCHAR(100)
    CONSTRAINT fkEmailAddress_AccountsTasks
      REFERENCES [dbo].[Accounts](emailAddress)
      ON DELETE CASCADE,
    taskId INT
    CONSTRAINT fkTaskId_AccountsTasks
      REFERENCES [dbo].[Tasks](taskId)
      ON DELETE CASCADE,
    PRIMARY KEY (emailAddress, taskId)
);

