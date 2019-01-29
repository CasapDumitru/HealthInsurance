
BEGIN

	-- Addresses
	BEGIN

		Select * From Addresses

		Delete From Addresses
		DBCC CHECKIDENT ('Addresses', RESEED, 0)

		Insert Into Addresses(Country, City, Street, StreetNumber, PostalCode)
		Values('Romania', 'Cluj-Napoca', 'Nicolae Draganu', '18A', null) -- Id = 1

		Insert Into Addresses(Country, City, Street, StreetNumber, PostalCode)
		Values('Romania', 'Cluj-Napoca', 'Aleea Baisoara', '9', null) -- Id = 2

		Insert Into Addresses(Country, City, Street, StreetNumber, PostalCode)
		Values('Romania', 'Cluj-Napoca', 'Calea Dorobantilor', '100', null) -- Id = 3

		Insert Into Addresses(Country, City, Street, StreetNumber, PostalCode)
		Values('Republic Of Moldova', 'Chisinau', 'Albisoara', '5', null) -- Id = 4

		Insert Into Addresses(Country, City, Street, StreetNumber, PostalCode)
		Values('Romania', 'Bucuresti', 'Splaiul Indepententei', '76', null) -- Id = 5

		Insert Into Addresses(Country, City, Street, StreetNumber, PostalCode)
		Values('Romania', 'Sibiu', 'Graului', '7', null) -- Id = 6

	END

	-- Users
	BEGIN

		Select * From Users

		Delete From Users
		DBCC CHECKIDENT ('Users', RESEED, 0)

		-- admin
		Insert Into Users(FirstName, LastName, BirthDate, Email, PhoneNumber, UserName, Password, UserType, AddressId)
		Values('Dumitru', 'Casap', '1995-11-07', 'casapdumitru@yahoo.com', '+40757786661', 'casapdumitru', 'casap1234', 1, 1) -- Id = 1

		-- simple users
		Insert Into Users(FirstName, LastName, BirthDate, Email, PhoneNumber, UserName, Password, UserType, AddressId)
		Values('Teodorina', 'Chiriac', '1995-10-31', 'chiriacteodorina@yahoo.com', '+40755478975', 'chiriacteo', 'teo1995', 0, 1) -- Id = 2

		Insert Into Users(FirstName, LastName, BirthDate, Email, PhoneNumber, UserName, Password, UserType, AddressId)
		Values('Iulian', 'Bruma', '1994-12-24', 'brumaiulian@yahoo.com', '+40755347651', 'brumaiulian', 'bruma1234', 0, 2) -- Id = 3

		Insert Into Users(FirstName, LastName, BirthDate, Email, PhoneNumber, UserName, Password, UserType, AddressId)
		Values('Natalia', 'Afanas', '1996-02-15', 'nataliafanas@yahoo.com', '+40758935641', 'nataliaafanas', 'afanas4444', 0, 2) -- Id = 4

		-- doctors
		Insert Into Users(FirstName, LastName, BirthDate, Email, PhoneNumber, UserName, Password, UserType, AddressId)
		Values('Emil', 'Rolinschi', '1968-02-11', 'rolinschiemil@yahoo.com', '+40758438764', 'rolinschiemil', 'rol2019', 2, 3) -- Id = 5

		Insert Into Users(FirstName, LastName, BirthDate, Email, PhoneNumber, UserName, Password, UserType, AddressId)
		Values('Tatiana', 'Rolinschi', '1970-05-25', 'rolinschitatiana@yahoo.com', '+40758438555', 'rolinschitatiana', 'tatiana1234', 2, 3) -- Id = 6

		Insert Into Users(FirstName, LastName, BirthDate, Email, PhoneNumber, UserName, Password, UserType, AddressId)
		Values('Dumitru', 'Munteanu', '1989-02-17', 'dumitrumunteanu@yahoo.com', '+40753498765', 'dumitrumunteanu', 'munte2019', 2, 4) -- Id = 7
	END

	-- Offices
	BEGIN

		Select * From Offices

		Delete From Offices
		DBCC CHECKIDENT ('Offices', RESEED, 0)

		Insert Into Offices(Name, Description, OwnerId, AddressId)
		Values('Regina Maria', 'Foarte Buna', 1, 5) -- Id = 1

		Insert Into Offices(Name, Description, OwnerId, AddressId)
		Values('Chiriac Med', 'Va asteptam cu drag!', 2, 6) -- Id = 2
	END

	-- MedicineSpeciality
	BEGIN

		Select * From MedicineSpeciality

		Delete From MedicineSpeciality
		DBCC CHECKIDENT ('MedicineSpeciality', RESEED, 0)

		Insert Into MedicineSpeciality(Name, Description)
		Values('Stomatology', 'We will help with your teeth') -- Id = 1

		Insert Into MedicineSpeciality(Name, Description)
		Values('Traumatology', 'Waiting for you!') -- Id = 2

		Insert Into MedicineSpeciality(Name, Description)
		Values('Gynecology', 'Baby, baby, bay!') -- Id = 3

	END

	-- Departments
	BEGIN

		Select * From Departments

		Delete From Departments
		DBCC CHECKIDENT ('Departments', RESEED, 0)

		Insert Into Departments(Name, Description, OfficeId, MedicineSpecialityId)
		Values('Traumatology Department', 'If something hurts you, come to us!', 1, 2) -- Id = 1

		Insert Into Departments(Name, Description, OfficeId, MedicineSpecialityId)
		Values('Gynecology Department', 'Baby is the most important', 1, 3) -- Id = 2

		Insert Into Departments(Name, Description, OfficeId, MedicineSpecialityId)
		Values('Stomatology Department', 'Will help with your teeth', 2, 1) -- Id = 3

	END

	-- DoctorDepartments
	BEGIN

		Select * From DoctorDepartments

		Delete From DoctorDepartments
		DBCC CHECKIDENT ('DoctorDepartments', RESEED, 0)

		Insert Into DoctorDepartments(DoctorId, DepartmentId)
		Values(5, 1)

		Insert Into DoctorDepartments(DoctorId, DepartmentId)
		Values(6, 2)

		Insert Into DoctorDepartments(DoctorId, DepartmentId)
		Values(7, 3)

	END

END

