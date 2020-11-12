ALTER PROCEDURE spAddNewEmployee
	@employee_id int,
	@employee_name varchar(50),
	@gender char(1),
	@address varchar(50),
	@start_date date,
	@department_id int,
	@department_name varchar(50),
	@basic_pay float
AS
BEGIN
SET XACT_ABORT ON
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO employee(id, name,gender,address,start)
			VALUES
			(@employee_id,@employee_name, @gender, @address, @start_date);

			DECLARE @department_exist INT = (select count(dept_name) 
											from department 
											where dept_id=@department_id);
			if @department_exist=0
			BEGIN 
				INSERT INTO department(dept_id,dept_name)
				VALUES
				(@department_id, @department_name)
			END;

			INSERT INTO employee_department(emp_id, dept_id)
			VALUES
			(@employee_id, @department_id);

			INSERT INTO payroll(basic_pay,emp_id)
			VALUES
			(@basic_pay,@employee_id);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		PRINT (ERROR_MESSAGE()); 
		ROLLBACK TRANSACTION
	END CATCH
END