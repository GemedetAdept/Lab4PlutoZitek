// 2022-09-29; CS 1400; Lab 4

// Calculate yearly salary from inputted values
static decimal yearlySalary(decimal hourlyWage, int hoursPerWeek, int weeksPerYear) {

	decimal yearlySalaryValue = 0M;
	yearlySalaryValue = ((decimal)hoursPerWeek * (decimal)weeksPerYear) * hourlyWage;

	return yearlySalaryValue;
}

// Rectify generated integer wages into decimal values
static decimal rectifyWage(int integerWage){

	decimal rectifiedWage = 0.0M;
	rectifiedWage = (decimal)integerWage / 100.00M;

	return rectifiedWage;
}


int numberOfPeople = 1000;
int wageLowerBound = 725;
int wageUpperBound = 4000;
int hoursPerWeek = 40;
int weeksPerYear = 50;

// decimal salaryValue = 0M;
// salaryValue = yearlySalary(hourlyWage, hoursPerWeek, weeksPerYear);

// Generate integer wages and store in array
int[] integerWages = new int[numberOfPeople];
for (int i = 0; i < numberOfPeople; i++) {

	int generatedWage = 0;

	Random rnd = new Random();
	generatedWage = rnd.Next(wageLowerBound, wageUpperBound);

	integerWages[i] = generatedWage;
}

// Rectify integers wages and store in array
decimal[] rectifiedWages = new decimal[numberOfPeople];
for (int i = 0; i < numberOfPeople; i++) {

	decimal hourlyWage = 0.0M;
	hourlyWage = rectifyWage(integerWages[i]);
	rectifiedWages[i] = hourlyWage;

	// Console.WriteLine($"${rectifiedWages[i]:0.00}");
}

// Calculate yearly salaries and store in array
decimal[] yearlySalaries = new decimal[numberOfPeople];
for (int i = 0; i < numberOfPeople; i++) {

	decimal yearlySalaryValue = 0.0M;
	yearlySalaryValue = yearlySalary(rectifiedWages[i], hoursPerWeek, weeksPerYear);
	yearlySalaries[i] = yearlySalaryValue;
}


// Output Printing
for (int i = 0; i < numberOfPeople; i++) {

	Console.WriteLine($"${rectifiedWages[i]:00.00}/hr === ${yearlySalaries[i]:0.00}/yr");
}


// Addendum Error Log
Console.WriteLine("\n");
Console.WriteLine("|[ Error Log ]|");
foreach (int wage in integerWages) {

	string errorFlag = "";
	if (wage < wageLowerBound || wage > wageUpperBound) {
		errorFlag = "[Wage Out of Bounds]";
		Console.WriteLine($"{wage} {errorFlag}");
	}
}