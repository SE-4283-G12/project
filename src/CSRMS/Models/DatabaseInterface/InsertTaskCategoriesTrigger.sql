CREATE TRIGGER trg_InsertTaskCategories
ON dbo.Tasks
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Tasks_Categories (taskId, category_id)
    SELECT inserted.taskId, c.categoryId
    FROM inserted
    CROSS JOIN dbo.Categories c
    WHERE c.categoryId = (SELECT categoryId FROM inserted);
END;
