ALTER PROCEDURE spRemoveEmployee
	@employee_id int,
	@dept_id int
AS
BEGIN
SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE FROM dbo.employee_department
			WHERE emp_id = @employee_id AND dept_id=@dept_id;

			UPDATE payroll
			SET is_active = 'F'
			WHERE emp_id=@employee_id;

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		PRINT (ERROR_MESSAGE()); 
		ROLLBACK TRANSACTION
	END CATCH
END